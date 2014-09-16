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

        public Thingy()
        {
            GoodFolders = new List<MusicFolder>();
            BadFolders = new List<MusicFolder>();
            IsArtistMissing = f => string.IsNullOrEmpty(f.ArtistName);
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

            if (folder._files.Any(x => x.ArtistName != folder._files[0].ArtistName)) return false;

            return true;
        }
    }
}