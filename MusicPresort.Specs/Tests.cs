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

        #region Helpers

        private void AddFile(string artistName, string albumTitle)
        {
            _folder._files.Add(new MusicFile{ArtistName = artistName, AlbumTitle = albumTitle});
        }

        #endregion

        [Given(@"I have a music folder")]
        public void GivenIHaveAMusicFolder()
        {
            _folder = new MusicFolder();
        }

        [Given(@"the folder has MP3s with mixed artist names")]
        public void GivenTheFolderHasMPsWithMixedArtistNames()
        {
            AddFile("Some artist", "Some album");
            AddFile("Some artist", "Some album");
            AddFile("Another artist", "Some album");
        }

        [Given(@"the folder has MP3s with missing album titles")]
        public void GivenTheFolderHasMPsWithMissingAlbumTitles()
        {
            AddFile("Some artist", "");
            AddFile("Some artist", "");
            AddFile("Some artist", "");
        }


        [Given(@"the folder has MP3s with missing artist names")]
        public void GivenTheFolderHasMPsWithMissingArtistNames()
        {
            AddFile("", "Some album");
            AddFile("", "Some album");
            AddFile("", "Some album");
        }

        [Given(@"the folder has MP3s with mixed album titles")]
        public void GivenTheFolderHasMPsWithMixedAlbumTitles()
        {
            AddFile("Some artist", "Some album");
            AddFile("Some artist", "Different album");
            AddFile("Some artist", "Some album");
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
