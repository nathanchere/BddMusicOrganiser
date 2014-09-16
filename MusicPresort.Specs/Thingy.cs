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
            if(folder._files.Any(IsArtistMissing))
                BadFolders.Add(folder);
            else
                GoodFolders.Add(folder);
        }
    }
}