using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.IO.Abstractions.TestingHelpers;
using System.Linq;
using System.Text.RegularExpressions;

namespace MusicPresort
{
    public class MusicFolderFactory
    {
        private readonly IFileSystem fs;
        private Regex validFolderName; 

        public MusicFolderFactory(IFileSystem fileSystem)
        {
            fs = fileSystem;
            validFolderName = new Regex(@"\d{4}-\d{2}-\d{2} .{1,}");
        }

        /// <summary>
        /// Opens a folder on disk as a MusicFolder
        /// </summary>       
        public ImportResult Import(string fullPath)
        {
            if (string.IsNullOrEmpty(fullPath)) return ImportResult.PathNotFound();            
            if (!fs.Directory.Exists(fullPath)) return ImportResult.PathNotFound();
            
            var fileName = fullPath.Split(fs.Path.DirectorySeparatorChar).Last();
            if (!validFolderName.IsMatch(fileName)) return ImportResult.InvalidFolderName();
            
            Date date;            
            try { 
                date = new Date(fileName.Split(' ')[0]); 
            }
            catch (Exception ex) { 
                return ImportResult.InvalidDate(); 
            }

            var folder = new ImportedFolder {
                FullPath = fullPath,
                FileName = fileName,
                Date = date
            };            

            foreach (var file in GetFiles(fullPath))
            {
                var shortFileName = file.Substring(fullPath.Length);
                folder.Files.Add(shortFileName);

                // Detect analysis cache if present
                if (shortFileName.Split(Path.DirectorySeparatorChar).Last() == AnalysisCache.FileName)
                {
                    folder.Analysis = AnalysisCache.FromJson("");
                }
            }            

            return new ImportResult
            {
                Result = ImportResult.ResultEnum.Success,
                Folder = folder,                
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