using System;
using System.Collections.Generic;

namespace MusicPresort.Specs
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

    public class MusicFolderFactory
    {
        private IFileSystem _fileSystem;

        public MusicFolderFactory(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        /// <summary>
        /// Opens a folder on disk as a MusicFolder
        /// </summary>       
        public MusicFolder Open(string directory)
        {
            var result = new MusicFolder();
            return new MusicFolder();
        }
    }

}