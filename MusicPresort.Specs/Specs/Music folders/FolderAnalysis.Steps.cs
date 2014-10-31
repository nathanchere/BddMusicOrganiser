using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Kernel;
using TechTalk.SpecFlow;
using Xunit;

namespace MusicPresort.Specs
{
    [Binding, Scope(Feature = "Folder analysis")]
    class FolderAnalysisSteps
    {
        public FolderAnalysisSteps()
        {
            _analyser = new FolderAnalyser();
            _fixture = new Fixture();
        }

        private Fixture _fixture;        
        private readonly IFolderAnalyser _analyser;
        private MusicFolder _folder;

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

        [Given(@"the folder has an analysis cache")]
        public void GivenTheFolderHasAnAnalysisCache()
        {
            _folder.Analysis = _fixture.Build<AnalysisCache>().Create();
        }

        [Given(@"I have a music folder")]
        public void GivenIHaveAMusicFolder()
        {
            _folder = _fixture.Create<MusicFolder>();
        }

        [Given(@"the music folder hasn't been processed")]
        public void GivenTheMusicFolderHasnTBeenProcessed()
        {            
            _folder.Analysis = null;
        }
        #endregion

        #region When
        [When(@"I analyse the folder")]
        public void WhenIAnalysesTheFolder()
        {
            _analyser.Analyse(_folder);
        }
        #endregion

        #region Then       
        [Then(@"analysis cache should list the files in the music folder")]
        public void ThenAnalysisCacheShouldListTheFilesInTheMusicFolder()
        {            
            Assert.Equal(_folder.Analysis.Files.Count, _folder.Files.Count);
            foreach (var file in _folder.Files)
            {
                Assert.Contains(file.Path, _folder.Analysis.Files.Select(x=>x.FullPath));
            }
        }
        #endregion
    }
}
