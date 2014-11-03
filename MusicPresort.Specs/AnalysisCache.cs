﻿using System.Collections.Generic;

namespace MusicPresort
{
    public class AnalysisCache
    {
        public const string FileName = @"analysis.cache.json";

        public AnalysisCache()
        {
            Files = new List<DataFile>();
            Errors = new List<object>();
        }

        public IList<object> Errors { get; set; }
        public IList<DataFile> Files { get; set; }
    }
}