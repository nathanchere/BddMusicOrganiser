using System.Collections.Generic;

namespace MusicPresort
{
    public class ImportedFolder
    {
        public ImportedFolder()
        {
            Files = new List<string>();
        }

        public List<string> Files;

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