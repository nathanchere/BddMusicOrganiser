using System;
using System.Collections.Generic;

namespace MusicPresort.Specs
{
    public class MusicFolder
    {
        public MusicFolder()
        {
            _files = new List<MusicFile>();
        }

        public void Add(MusicFile musicFile)
        {
            _files.Add(musicFile);
        }

        public List<MusicFile> _files;

        // Path? Root folder name?
        public string FileName { get; set; }
        public Date Date { get; set; }
        public Sandwich Analysis { get; set; }
    }

    // Analysis cache
    public class Sandwich
    {
    }
}