using NuGet;
using System.Collections.Generic;
using System.Runtime.Versioning;

namespace SampleProgram.Config
{
    public class QueryConfig
    {
        /// <summary>
        /// Nuget API URI
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// Packages to be minimized
        /// </summary>
        public List<QueryConfigItem> Packages { get; set; }

        /// <summary>
        /// Target framework
        /// </summary>
        public FrameworkName Target { get; set; }
    }

    public class QueryConfigItem
    {
        /// <summary>
        /// Name of the nuget package
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Version of the nuget package
        /// </summary>
        public SemanticVersion Version { get; set; }
    }
}
