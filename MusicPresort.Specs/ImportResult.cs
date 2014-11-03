namespace MusicPresort
{
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

        public static ImportResult Success()
        {
            return new ImportResult { Result = ResultEnum.Success };
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