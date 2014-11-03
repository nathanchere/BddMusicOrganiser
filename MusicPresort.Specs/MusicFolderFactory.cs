using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.IO.Abstractions.TestingHelpers;
using System.Linq;
using System.Text.RegularExpressions;

namespace MusicPresort
{
    public class MusicFolderFactory
    {
        private readonly IFileSystem fs;
        //private Regex validFolderName; 

        public MusicFolderFactory(IFileSystem fileSystem)
        {
            fs = fileSystem;
            // TODO: init regex
        }

        /// <summary>
        /// Opens a folder on disk as a MusicFolder
        /// </summary>       
        public ImportResult Import(string fullPath)
        {
            if (string.IsNullOrEmpty(fullPath)) return ImportResult.PathNotFound();            
            if (!fs.Directory.Exists(fullPath)) return ImportResult.PathNotFound();

            //TODO: replace with regex
            {
                var fileName = fullPath.Split(fs.Path.DirectorySeparatorChar).Last();   
                if(fileName.Substring(10,1) != " ") return ImportResult.InvalidFolderName();
                var values = fileName.Split(' ')[0].Split('-');
                if(values.Count() != 3)  return ImportResult.InvalidFolderName();
            }

            var folder = new ImportedFolder();
            folder.FullPath = fullPath;
            folder.FileName = fullPath.Split(fs.Path.DirectorySeparatorChar).Last();

            try
            {
                folder.Date = new Date(folder.FileName.Split(' ')[0]);
            }
            catch(Exception ex)
            {
                return ImportResult.InvalidDate();
            }

            //var folderCaption = folderName.Substring(folderName.Split(' ')[0].Length);

            foreach (var file in GetFiles(fullPath))
            {
                folder.Files.Add(file);
            }            

            return new ImportResult
            {
                Folder = folder,
                // include analysis cache if it already exists
            };
        }

        private IEnumerable<string> GetFiles(string path)
        {
            foreach (var file in fs.Directory.GetFiles(path))
            {
                yield return file;
            }

            foreach (var dir in fs.Directory.GetDirectories(path))
            {
                foreach (var result in GetFiles(dir))
                {
                    yield return result;
                }
            }
        }
    }

    public static class TestFileSystemBuilder
    {
        public static IFileSystem Get()
        {
            var items = new Dictionary<string, MockFileData>();

            return new MockFileSystem();
        }
    }
}