using System;
using System.Collections.Generic;

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

        /// <summary>
        /// Result of prior processing (not import)
        /// </summary>
        public AnalysisCache Analysis { get; set; }
    }
}