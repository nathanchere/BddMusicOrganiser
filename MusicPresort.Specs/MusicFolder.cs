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
        public string FullPath { get; set; }
        public string FileName { get; set; }
        public Date Date { get; set; }

        /// <summary>
        /// Result of prior processing (not import)
        /// </summary>
        public AnalysisCache Analysis { get; set; }
    }

    public class ImportResult
    {
        public ImportedFolder Folder { get; set; }

        public ResultEnum Result { get; set; }

        public bool IsSuccess {
            get { return Result == ResultEnum.Success; }
        }

        public static ImportResult PathNotFound() {
            return new ImportResult { Result = ResultEnum.PathNotFound };
        }

        public static ImportResult InvalidFolderName() {
            return new ImportResult { Result = ResultEnum.InvalidFolderName };
        }

        public static ImportResult InvalidDate() {
            return new ImportResult { Result = ResultEnum.InvalidDate};
        }

        public enum ResultEnum { 
            None,
            Success,

            PathNotFound,
            InvalidFolderName,
            InvalidDate,            
        }
    }
}