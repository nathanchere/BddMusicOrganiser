using System;
using System.IO.Abstractions;

namespace MusicPresort
{
    public class MusicFolderFactory
    {
        private readonly IFileSystem fs;

        public MusicFolderFactory(IFileSystem fileSystem)
        {
            fs = fileSystem;
        }

        /// <summary>
        /// Opens a folder on disk as a MusicFolder
        /// </summary>       
        public MusicFolder Open(string fullPath)
        {
            var result = new MusicFolder();

            try
            {
                // TODO: better/informative error reporting
                if (string.IsNullOrEmpty(fullPath)) return null;
                if (!fs.Directory.Exists(fullPath)) return null;              

                var folderName = fs.Path.GetDirectoryName(fullPath);
                var folderDate = new Date(folderName.Split(' ')[0]);
                var folderCaption = folderName.Substring(folderName.Split(' ')[0].Length);

                // enumerate files

                return result;
            }
            catch (Exception ex)
            {
                // return null?
                throw;
            }     

        }
    }
}