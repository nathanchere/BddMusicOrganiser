using System;

namespace MusicPresort.Specs
{
    public class MusicFile
    {
        public string ArtistName { get; set; }
        public string AlbumTitle { get; set; }
        public string TrackTitle { get; set; }
        public int? TrackNumber { get; set; }
    }

    public class ValidMusicFolder : MusicFolder
    {
        private static int counter = 0;
        private static Random rnd = new Random();

        private string[] _artistNames = new[] { 
            "Tommy Emmanuel",
            "Dream Theater",
            "Mattias Eklundh",
            "Dire Straits",
            "Dave Martone",
            "Biomechanical",
            "Slash's Snakepit",
            "Theory In Practice",
            "Saber Tiger",
            "Jean Michel Jarre",
            "Fleetwood Mac",
            "Helloween",
            "Chroma Key",
            "Various Artists",
        };

        public ValidMusicFolder() : base()
        {
            var artistName = _artistNames[counter++ % _artistNames.Length];
            var albumTitle = "Album Number " + counter;
            for (int i = 1; i < rnd.Next(3, 10); ++i)
            {
                Files.Add(new MusicFile{
                    ArtistName = artistName,
                    AlbumTitle = albumTitle,
                    TrackNumber = i,
                    TrackTitle = "Track " + i,
                });
            }
        }
    }
}