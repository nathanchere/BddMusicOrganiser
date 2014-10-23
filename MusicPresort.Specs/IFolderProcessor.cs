using System;
using System.Linq;
using MusicPresort.Specs;

namespace MusicPresort
{
    public interface IFolderProcessor
    {
        bool IsValid(MusicFolder folder);
        void Process(MusicFolder folder);
    }

    public class FolderProcessor : IFolderProcessor
    {
        public FolderProcessor()
        {
            IsArtistMissing = f => string.IsNullOrEmpty(f.ArtistName);
            IsAlbumMissing = f => string.IsNullOrEmpty(f.AlbumTitle);
            IsTrackNumberMissing = f => !f.TrackNumber.HasValue;
            IsTrackNumberInvalid = f => !f.TrackNumber.HasValue || f.TrackNumber.Value <= 0;
            IsTrackNumberSequenceIncomplete = f =>
            {
                int i = 1;
                foreach (var file in f._files.OrderBy(x => x.TrackNumber))
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
            if (!folder._files.Any()) return false;

            if (folder._files.Any(IsArtistMissing)) return false;

            if (folder._files.Any(IsAlbumMissing)) return false;

            if (folder._files.Any(IsTrackNumberMissing)) return false;

            if (folder._files.Any(IsTrackNameMissing)) return false;

            if (folder._files.Any(IsTrackNumberInvalid)) return false;

            if (IsTrackNumberSequenceIncomplete(folder)) return false;

            if (folder._files.Any(x => x.ArtistName != folder._files[0].ArtistName)) return false;

            if (folder._files.Any(x => x.AlbumTitle != folder._files[0].AlbumTitle)) return false;

            return true;
        }

        public void Process(MusicFolder folder)
        {
            // TODO: ?
        }
    }
}