using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace MusicPresort.Specs
{
    [Binding]
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

        [Given(@"the folder has MP3s with missing artist names")]
        public void GivenTheFolderHasMPsWithMissingArtistNames()
        {
            ScenarioContext.Current.Pending();
        }


        [When(@"I process the folder")]
        public void WhenIProcessTheFolder()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the folder should be filtered out")]
        public void ThenTheFolderShouldBeFilteredOut()
        {
            ScenarioContext.Current.Pending();
        }


    }

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

    public class MusicFile
    {
        public string ArtistName { get; set; }
    }
}
