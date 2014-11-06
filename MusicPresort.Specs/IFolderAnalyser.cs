using System;
using System.IO.Abstractions;
using System.Linq;
using MusicPresort.Specs;

namespace MusicPresort
{
    public interface IFolderAnalyser
    {
        AnalysisCache Analyse(MusicFolder folder);
        bool IsValid(MusicFolder folder);
    }

    public class FolderAnalyser : IFolderAnalyser
    {
        private readonly IFileSystem _fileSystem;

        private readonly Func<MusicFile, bool> IsArtistMissing;
        private readonly Func<MusicFile, bool> IsAlbumMissing;
        private readonly Func<MusicFile, bool> IsTrackNumberMissing;
        private readonly Func<MusicFile, bool> IsTrackNumberInvalid;
        private readonly Func<MusicFolder, bool> IsTrackNumberSequenceIncomplete;
        private readonly Func<MusicFile, bool> IsTrackNameMissing;

        public AnalysisCache Analyse(MusicFolder folder)
        {
            var result = new AnalysisCache(folder.FullPath);
            
            foreach (var file in folder.Files)
            {
                result.Files.Add(new DataFile{FullPath = file.Path});
            }

            folder.Analysis = result;
            return result;
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

        public FolderAnalyser(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;

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
    }
}