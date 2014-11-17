using System;
using System.Collections.Generic;
using System.IO;

namespace MusicPresort
{
    public class MusicFolder
    {
        public MusicFolder()
        {
            Files = new List<MusicFile>();
        }

        public List<MusicFile> Files;
        // TODO: misc files

        // Path? Root folder name?
        public string FullPath { get; set; }
        public string FileName { get; set; }
        public Date Date { get; set; }

        public MusicFolderStatusEnum Status { get; set; }

        /// <summary>
        /// Result of prior processing (not import)
        /// </summary>
        public AnalysisCache Analysis { get; set; }

        public string AnalysisCachePath()
        {
            if (string.IsNullOrEmpty(FullPath)) throw new InvalidOperationException("MusicFolder has no path set");
            return Path.Combine(FullPath, AnalysisCache.FileName);
        }
    }

    public enum MusicFolderStatusEnum
    {
        Unknown,
        NotAnalysed,
        AnalysedWithErrors,
        ReadyToProcess,
        Processed,
    }
}