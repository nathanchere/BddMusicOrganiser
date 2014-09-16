using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xunit;

namespace MusicPresort.Specs
{
    [Binding]
    class MusicFolderTests
    {
        private readonly Thingy _thingy;

        private MusicFolder _folder;

        public MusicFolderTests()
        {
            _thingy = new Thingy();
        }

        [Given(@"I have a music folder")]
        public void GivenIHaveAMusicFolder()
        {
            _folder = new MusicFolder();
        }

        [Given(@"the folder has MP3s with mixed artist names")]
        public void GivenTheFolderHasMPsWithMixedArtistNames()
        {
            _folder.Add(new MusicFile { ArtistName = "Some artist" });
            _folder.Add(new MusicFile { ArtistName = "Some artist" });
            _folder.Add(new MusicFile { ArtistName = "Another artist" });
        }

        [Given(@"the folder has MP3s with missing artist names")]
        public void GivenTheFolderHasMPsWithMissingArtistNames()
        {
            _folder.Add(new MusicFile { ArtistName = "Some artist" });
            _folder.Add(new MusicFile { ArtistName = "" });
            _folder.Add(new MusicFile { ArtistName = "Another artist" });
        }

        [Given(@"the folder has MP3s with mixed album titles")]
        public void GivenTheFolderHasMPsWithMixedAlbumTitles()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"the folder has no MP3s")]
        public void GivenTheFolderHasNoMPs()
        {
            // Nothing to do! :)
        }

        [When(@"I process the folder")]
        public void WhenIProcessTheFolder()
        {
            _thingy.ProcessFolder(_folder);
        }

        [Then(@"the folder should be filtered out")]
        public void ThenTheFolderShouldBeFilteredOut()
        {
            Assert.Contains(_folder, _thingy.BadFolders);
        }


    }
}
