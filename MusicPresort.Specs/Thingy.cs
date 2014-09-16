using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicPresort.Specs
{
    public class Thingy
    {
        public List<MusicFolder> GoodFolders { get; private set; }
        public List<MusicFolder> BadFolders { get; private set; }

        private readonly Func<MusicFile, bool> IsArtistMissing;
        private readonly Func<MusicFile, bool> IsAlbumMissing;
        private readonly Func<MusicFile, bool> IsTrackNumberMissing;
        private readonly Func<MusicFile, bool> IsTrackNumberInvalid;
        private readonly Func<MusicFolder, bool> IsTrackNumberSequenceIncomplete;

        public Thingy()
        {
            GoodFolders = new List<MusicFolder>();
            BadFolders = new List<MusicFolder>();
            IsArtistMissing = f => string.IsNullOrEmpty(f.ArtistName);
            IsAlbumMissing = f => string.IsNullOrEmpty(f.AlbumTitle);
            IsTrackNumberMissing = f => !f.TrackNumber.HasValue;
            IsTrackNumberInvalid = f => f.TrackNumber.Value <= 0;
            IsTrackNumberSequenceIncomplete = f => {
                int i = 1;
                foreach (var file in f._files.OrderBy(x => x.TrackNumber))
                {
                    if (file.TrackNumber != i) return true;
                    i++;
                }
                return false;
            };
        }
       
        public void ProcessFolder(MusicFolder folder)
        {
            if(!IsValid(folder))
                BadFolders.Add(folder);
            else
                GoodFolders.Add(folder);
        }
        
        private bool IsValid(MusicFolder folder)
        {
            if(!folder._files.Any()) return false;

            if (folder._files.Any(IsArtistMissing)) return false;

            if (folder._files.Any(IsAlbumMissing)) return false;

            if (folder._files.Any(IsTrackNumberMissing)) return false;

            if (folder._files.Any(IsTrackNumberInvalid)) return false;

            if (IsTrackNumberSequenceIncomplete(folder)) return false;

            if (folder._files.Any(x => x.ArtistName != folder._files[0].ArtistName)) return false;

            if (folder._files.Any(x => x.AlbumTitle!= folder._files[0].AlbumTitle)) return false;

            return true;
        }
    }
}