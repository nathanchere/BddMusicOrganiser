using System;
using System.Linq;
using Ploeh.AutoFixture;
using TechTalk.SpecFlow;
using Xunit;

namespace MusicPresort.Specs.FolderProcessor
{
    [Binding, Scope(Feature = "Tag consistency")]
    class TagConsistencySteps
    {
        private readonly OrchestratorThingy _orchestratorThingy;
        private readonly Fixture _fixture;

        private MusicFolder _folder;

        public TagConsistencySteps()
        {
            _orchestratorThingy = new OrchestratorThingy();
            _fixture = new Fixture();
        }

        #region Helpers

        private void AddFile(string artistName, string albumTitle, string trackTitle, int? trackNumber)
        {
            throw new NotImplementedException();
            //_folder._files.Add(
            //    new MusicFile{
            //        ArtistName = artistName,
            //        AlbumTitle = albumTitle,
            //        TrackTitle = trackTitle,
            //        TrackNumber = trackNumber
            //    }
            //);
        }

        #endregion

        #region Given
        [Given(@"the folder has no analysis cache")]
        public void GivenTheFolderHasNoAnalysisCache()
        {
            _folder.Analysis = null;
        }

        [Given(@"the folder name is in a valid format")]
        public void GivenTheFolderNameIsInAValidFormat()
        {
            _folder.FileName = "2010-01-30 (1977) Fleetwood.Mac.Rumours [vinyl rip]";
        }

        [Given(@"the folder name is not in a valid format")]
        public void GivenTheFolderNameIsNotInAValidFormat()
        {
            _folder.FileName = "1977 Fleetwood.Mac.Rumours [vinyl rip]";
        }

        [Given(@"the folder name is in a valid format but with an invalid date")]
        public void GivenTheFolderNameIsInAValidFormatButWithAnInvalidDate()
        {
            _folder.FileName = "2010-02-30 (1977) Fleetwood.Mac.Rumours [vinyl rip]";
        }


        [Given(@"I have a music folder")]
        public void GivenIHaveAMusicFolder()
        {
            _folder = _fixture.Create<MusicFolder>();
        }

        [Given(@"the folder has MP3s with mixed artist names")]
        public void GivenTheFolderHasMP3sWithMixedArtistNames()
        {
            AddFile("Some artist", "Some album", "Track 1", 1);
            AddFile("Some artist", "Some album", "Track 2", 2);
            AddFile("Another artist", "Some album", "Track 3", 3);
        }

        [Given(@"the folder has MP3s with missing track titles")]
        public void GivenTheFolderHasMP3sWithMissingTrackTitles()
        {
            _folder.Files.Last().TrackTitle = "";
        }

        [Given(@"the folder has MP3s with an incomplete sequence of track numbers")]
        public void GivenTheFolderHasMP3sWithAnIncompleteSequenceOfTrackNumbers()
        {
            AddFile("Some artist", "Some album", "Track 1", 1);
            AddFile("Some artist", "Some album", "Track 2", 2);
            AddFile("Some artist", "Some album", "Track 4", 4);
        }


        [Given(@"the folder has MP3s with missing track numbers")]
        public void GivenTheFolderHasMP3sWithMissingTrackNumbers()
        {
            AddFile("Some artist", "Some album", "Track 1", 1);
            AddFile("Some artist", "Some album", "Track 2", null);
            AddFile("Some artist", "Some album", "Track 3", 3);
        }

        [Given(@"the folder has MP3s with invalid track numbers")]
        public void GivenTheFolderHasMP3sWitInvalidTrackNumbers()
        {
            AddFile("Some artist", "Some album", "Track 1", 1);
            AddFile("Some artist", "Some album", "Track 2", 0);
            AddFile("Some artist", "Some album", "Track 3", 3);
        }

        [Given(@"the folder has MP3s with missing album titles")]
        public void GivenTheFolderHasMP3sWithMissingAlbumTitles()
        {
            AddFile("Some artist", "", "Track 1", 1);
            AddFile("Some artist", "", "Track 2", 2);
            AddFile("Some artist", "", "Track 3", 3);
        }


        [Given(@"the folder has MP3s with missing artist names")]
        public void GivenTheFolderHasMP3sWithMissingArtistNames()
        {
            AddFile("", "Some album", "Track 1", 1);
            AddFile("", "Some album", "Track 2", 2);
            AddFile("", "Some album", "Track 3", 3);
        }

        [Given(@"the folder has MP3s with mixed album titles")]
        public void GivenTheFolderHasMP3sWithMixedAlbumTitles()
        {
            AddFile("Some artist", "Some album", "Track 1", 1);
            AddFile("Some artist", "Different album", "Track 2", 2);
            AddFile("Some artist", "Some album", "Track 3", 3);
        }

        [Given(@"the folder has no MP3s")]
        public void GivenTheFolderHasNoMP3s()
        {
            // Nothing to do! :)
        }
        #endregion

        #region When
        [When(@"I process the folder")]
        public void WhenIProcessTheFolder()
        {
            _orchestratorThingy.ProcessFolder(_folder);
        }

        [When(@"I pre-process the folder")]
        public void WhenIPre_ProcessTheFolder()
        {
            _orchestratorThingy.PreprocessFolder(_folder);
        }
        #endregion

        #region Then
        [Then(@"the folder should be filtered out")]
        public void ThenTheFolderShouldBeFilteredOut()
        {
            Assert.Contains(_folder, _orchestratorThingy.BadFolders);
        }

        [Then(@"the result should have the date")]
        public void ThenTheResultShouldHaveTheDate()
        {
            Assert.True(_folder.Date != null);
        }

        [Then(@"the result should have no date")]
        public void ThenTheResultShouldHaveNoDate()
        {
            Assert.True(_folder.Date == null);
        }

        [Then(@"the folder should be processed")]
        public void ThenTheFolderShouldBeProcessed()
        {
            //Assert.
            //_thingy.PreprocessFolder();
        }

        #endregion
    }
}
