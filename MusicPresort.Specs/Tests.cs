using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace MusicPresort.Specs
{
    class MusicFolderTests
    {
        private MusicFolder _folder;

        [Given(@"I have a music folder")]
        public void GivenIHaveAMusicFolder()
        {
            _folder = new MusicFolder();
        }

        [Given(@"the folder has MP3s with mixed artist names")]
        public void GivenTheFolderHasMPsWithMixedArtistNames()
        {
            _folder.Add(new MusicFile{});
        }


    }

    public class MusicFolder
    {
        public void Add(MusicFile musicFile)
        {
            throw new NotImplementedException();
        }
    }

    public class MusicFile
    {
        public string ArtistName { get; set; }
    }
}
