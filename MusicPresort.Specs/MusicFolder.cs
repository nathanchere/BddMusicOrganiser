using System.Collections.Generic;

namespace MusicPresort.Specs
{
    public class MusicFolder
    {
        public List<MusicFile> _files;

        public MusicFolder()
        {
            _files = new List<MusicFile>();
        }

        public void Add(MusicFile musicFile)
        {
            _files.Add(musicFile);
        }
    }
}