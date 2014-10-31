using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.IO.Abstractions.TestingHelpers;

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
        public ImportResult Import(string fullPath)
        {
            try
            {
                if (string.IsNullOrEmpty(fullPath) || !fs.Directory.Exists(fullPath))
                {
                    return new ImportResult { Result = ImportResult.ResultEnum.PathNotFound };
                }

                var folder = new MusicFolder();
                folder.FullPath = fullPath;
                folder.FileName = fs.Path.GetDirectoryName(fullPath);
                folder.Date = new Date(folder.FileName.Split(' ')[0]);
                //var folderCaption = folderName.Substring(folderName.Split(' ')[0].Length);

                
                

                return new ImportResult{
                    Folder = folder,
                    // include analysis cache if it already exists
                };                
                return result;
            }
            catch (Exception ex)
            {
                // return null?
                throw;
            }     

        }
    }

    public static class  TestFileSystemBuilder
    {
        public static IFileSystem Get()
        {
            var items = new Dictionary<string, MockFileData>();

            return new MockFileSystem();
        }
    }
}