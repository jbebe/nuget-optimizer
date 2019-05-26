using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Versioning;
using Newtonsoft.Json;
using NuGet;
using SampleProgram;
using SampleProgram.Config;
using SampleProgram.Extensions;

namespace SampleProgram
{
    public class Program
    {
        

        public static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                throw new Exception("Invalid number of arguments. Should be just a  path to one config file.");
            }

            var configJson = File.ReadAllText(args[0]);
            var config = JsonConvert.DeserializeObject<QueryConfig>(configJson);

            var tool = new PackageTool(config);
            var simplifiedPackageList = tool.GetPackages();

            

            foreach (IPackage package in packages)
            {
                GetValue(repository, config.Target, package, level: 0);
            }
        }

        private static void GetValue(IPackageRepository repository, FrameworkName framework, IPackage package, int level)
        {
            if (package == null)
            {
                return;
            }

            var dependencies = new Dictionary<string, PackageDependency>();
            foreach (var dependencySet in package.DependencySets)
            {
                foreach (var dependency in dependencySet.Dependencies)
                {
                    dependencies.Add(dependency.Id, dependency);
                }
            }

            //foreach (var dependency in package.GetCompatiblePackageDependencies(framework))
            //{
            //    var subPackage = repository.ResolveDependency(dependency, false, true);
            //    dependencies.Add(subPackage.Id, new PackageDependency(subPackage.Id, new VersionSpec(subPackage.Version)));
            //}

            foreach (var (name, dependency) in dependencies)
            {

                GetValue(repository, framework, dependency, level + 1);
            }
        }
    }
}
