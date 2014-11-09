using System;
using System.Collections.Generic;
using ServiceStack.Text;

namespace MusicPresort
{
    public class AnalysisCache
    {
        public const string FileName = @"analysis.cache.json";

        /// <summary>
        /// Keeps track of the path where the AnalysisCache is located on disk.
        /// All other files within are stored relative to this root path.
        /// Can be used to loosely verify the same device that ran the original analysis.
        /// </summary>
        public string RootPath { get; private set; }

        private AnalysisCache()
        {
            throw new NotImplementedException("No constructor support");
        }

        public AnalysisCache(string rootPath)
        {
            RootPath = rootPath;
            Files = new List<DataFile>();
            Errors = new List<object>();
        }

        public static AnalysisCache FromJson(string json)
        {
            return JsonSerializer.DeserializeFromString<AnalysisCache>(json);
        }

        public IList<object> Errors { get; set; }
        public IList<DataFile> Files { get; set; }
    }
}