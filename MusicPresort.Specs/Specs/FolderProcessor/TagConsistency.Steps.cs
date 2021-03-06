﻿using System;
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
        private MusicFolder _folder;

        public TagConsistencySteps()
        {
            _orchestratorThingy = new OrchestratorThingy();
        }

        #region Helpers

        private void AddFile(string artistName, string albumTitle, string trackTitle, int? trackNumber)
        {
            _folder.Files.Add(
                new MusicFile
                {
                    ArtistName = artistName,
                    AlbumTitle = albumTitle,
                    TrackTitle = trackTitle,
                    TrackNumber = trackNumber
                }
            );
        }
        #endregion

        #region Given
        [Given(@"I have a music folder")]
        public void GivenIHaveAMusicFolder()
        {
            _folder = new MusicFolder();
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
            AddFile("Some artist", "Some album", "Track 1", 1);
            AddFile("Some artist", "Some album", "", 2);
            AddFile("Some artist", "Some album", "Track 3", 3);
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
        #endregion

        #region Then
        [Then(@"the folder should be filtered out")]
        public void ThenTheFolderShouldBeFilteredOut()
        {
            Assert.Contains(_folder, _orchestratorThingy.BadFolders);
        }        
        #endregion
    }
}
