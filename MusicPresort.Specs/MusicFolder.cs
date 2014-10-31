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

        // Path? Root folder name?
        public string FileName { get; set; }
        public Date Date { get; set; }
        public AnalysisCache Analysis { get; set; }
    }
}