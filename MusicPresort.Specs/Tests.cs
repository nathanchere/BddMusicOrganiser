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

        private void AddFile(string artistName, string albumTitle, string trackTitle)
        {
            _folder._files.Add(
                new MusicFile{
                    ArtistName = artistName,
                    AlbumTitle = albumTitle,
                    TrackTitle = trackTitle,
                }
            );
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
            AddFile("Some artist", "Some album", "Track 1");
            AddFile("Some artist", "Some album", "Track 2");
            AddFile("Another artist", "Some album", "Track 3");
        }

        [Given(@"the folder has MP3s with missing track titles")]
        public void GivenTheFolderHasMPsWithMissingTrackTitles(int p0)
        {
            ScenarioContext.Current.Pending();
        }


        [Given(@"the folder has MP3s with missing album titles")]
        public void GivenTheFolderHasMPsWithMissingAlbumTitles()
        {
            AddFile("Some artist", "", "Track 1");
            AddFile("Some artist", "", "Track 2");
            AddFile("Some artist", "", "Track 3");
        }


        [Given(@"the folder has MP3s with missing artist names")]
        public void GivenTheFolderHasMPsWithMissingArtistNames()
        {
            AddFile("", "Some album", "Track 1");
            AddFile("", "Some album", "Track 2");
            AddFile("", "Some album", "Track 3");
        }

        [Given(@"the folder has MP3s with mixed album titles")]
        public void GivenTheFolderHasMPsWithMixedAlbumTitles()
        {
            AddFile("Some artist", "Some album", "Track 1");
            AddFile("Some artist", "Different album", "Track 2");
            AddFile("Some artist", "Some album", "Track 3");
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
