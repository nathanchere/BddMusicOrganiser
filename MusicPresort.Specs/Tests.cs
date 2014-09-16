using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace MusicPresort.Specs
{
    [Binding]
    class MusicFolderTests
    {
        private Thingy _thingy;
        private MusicFolder _folder;

        [BeforeFeature]
        public void Setup()
        {
            _thingy = new Thingy(); 
        }

        public MusicFolderTests()
        {
        }

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
            _folder.Add(new MusicFile { ArtistName = "" });
            _folder.Add(new MusicFile { ArtistName = "" });
            _folder.Add(new MusicFile { ArtistName = "" });
        }


        [When(@"I process the folder")]
        public void WhenIProcessTheFolder()
        {
            _thingy.ProcessFolder(_folder);
        }

        [Then(@"the folder should be filtered out")]
        public void ThenTheFolderShouldBeFilteredOut()
        {
            ScenarioContext.Current.Pending();
        }


    }
}
