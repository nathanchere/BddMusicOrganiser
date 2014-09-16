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

        public Thingy()
        {
            GoodFolders = new List<MusicFolder>();
            BadFolders = new List<MusicFolder>();
            IsArtistMissing = f => string.IsNullOrEmpty(f.ArtistName);
            IsAlbumMissing = f => string.IsNullOrEmpty(f.AlbumTitle);
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

            if (folder._files.Any(x => x.ArtistName != folder._files[0].ArtistName)) return false;

            if (folder._files.Any(x => x.AlbumTitle!= folder._files[0].AlbumTitle)) return false;

            return true;
        }
    }
}