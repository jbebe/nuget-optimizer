using NuGet;
using SampleProgram.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProgram
{
    public  class PackageTool
    {
        private QueryConfig Config { get; }

        private readonly Dictionary<(string, string), IPackage> PackageCache = new Dictionary<(string, string), IPackage>();

        private IPackageRepository Repository = null;

        private Dictionary<string, SemanticVersion> RootPackages;

        public PackageTool(QueryConfig config)
        {
            Config = config;
            RootPackages = Config.Packages.ToDictionary((item) => item.Name, (item) => item.Version);
        }

        private List<IPackage> GetCachedPackages(Dictionary<string, SemanticVersion> packageDict)
        {
            var repository = GetRepository();
            var packageObjects = repository.GetPackages().Where((p) => packageDict.ContainsKey(p.Id)).ToList();
            foreach (var package in packageObjects)
            {
                PackageCache.Add((package.Id, package.Version))
            }
            return packageObjects.ToList();
        }

        public object GetPackages()
        {
            throw new NotImplementedException();
        }

        private IPackageRepository GetRepository()
        {
            if  (Repository == null)
            {
                Repository = PackageRepositoryFactory.Default.CreateRepository(Config.Source);
            }
            return Repository;
        }

    }
}
