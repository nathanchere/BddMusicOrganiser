using System;
using System.Collections.Generic;
using System.Linq;
using MusicPresort.Specs;

namespace MusicPresort
{
    public class OrchestratorThingy
    {
        public List<PreprocessResult> Results { get; private set; }

        public List<MusicFolder> GoodFolders { get; private set; }
        public List<MusicFolder> BadFolders { get; private set; }
        public string RootFolder { get; set; }

        //TODO: probably move to some kind of folderValidator
        private readonly Func<MusicFile, bool> IsArtistMissing;
        private readonly Func<MusicFile, bool> IsAlbumMissing;
        private readonly Func<MusicFile, bool> IsTrackNumberMissing;
        private readonly Func<MusicFile, bool> IsTrackNumberInvalid;
        private readonly Func<MusicFolder, bool> IsTrackNumberSequenceIncomplete;
        private readonly Func<MusicFile, bool> IsTrackNameMissing;

        private IFolderProcessor _processor;

        public OrchestratorThingy() : this(
            new FolderProcessor()
        ){}

        public OrchestratorThingy(IFolderProcessor processor)
        {
            _processor = processor;

            GoodFolders = new List<MusicFolder>();
            BadFolders = new List<MusicFolder>();
            Results = new List<PreprocessResult>();

            IsArtistMissing = f => string.IsNullOrEmpty(f.ArtistName);
            IsAlbumMissing = f => string.IsNullOrEmpty(f.AlbumTitle);
            IsTrackNumberMissing = f => !f.TrackNumber.HasValue;
            IsTrackNumberInvalid = f => !f.TrackNumber.HasValue || f.TrackNumber.Value <= 0;
            IsTrackNumberSequenceIncomplete = f =>
            {
                int i = 1;
                foreach (var file in f.Files.OrderBy(x => x.TrackNumber))
                {
                    if (file.TrackNumber != i) return true;
                    i++;
                }
                return false;
            };
            IsTrackNameMissing = f => string.IsNullOrWhiteSpace(f.TrackTitle);
        }

        public bool IsValid(MusicFolder folder)
        {
            if (!folder.Files.Any()) return false;

            if (folder.Files.Any(IsArtistMissing)) return false;

            if (folder.Files.Any(IsAlbumMissing)) return false;

            if (folder.Files.Any(IsTrackNumberMissing)) return false;

            if (folder.Files.Any(IsTrackNameMissing)) return false;

            if (folder.Files.Any(IsTrackNumberInvalid)) return false;

            if (IsTrackNumberSequenceIncomplete(folder)) return false;

            if (folder.Files.Any(x => x.ArtistName != folder.Files[0].ArtistName)) return false;

            if (folder.Files.Any(x => x.AlbumTitle != folder.Files[0].AlbumTitle)) return false;

            return true;
        }
       
        public void ProcessFolder(MusicFolder folder)
        {
            if (folder.Analysis != null) return;

            if(!IsValid(folder)) _processor.Process(folder);

            if (!IsValid(folder))
                BadFolders.Add(folder); // TODO: probably change these tests
            else
                GoodFolders.Add(folder);

            folder.Analysis = new AnalysisCache();
        }
        
        /// <summary>
        /// Basic/shallow verification of folder suitability for processing
        /// </summary>
        public void PreprocessFolder(MusicFolder folder)
        {            
            try
            {
                if (string.IsNullOrEmpty(folder.FileName)) return;
                folder.Date = new Date(folder.FileName.Split(' ')[0]);
            }
            catch (Exception ex)
            {
                // TODO: WTF was I doing here
            }            
        }
    }

    public class PreprocessResult
    {
        public MusicFolder Folder { get; set; }
        public Date Date { get; set; }
    }
}