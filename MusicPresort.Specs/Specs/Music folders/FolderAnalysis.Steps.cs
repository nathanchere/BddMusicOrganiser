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
            mockProcessor = new Mock<IFolderProcessor>();

            _fixture = new Fixture();            
            _fixture.Customize<OrchestratorThingy>(c=>c.FromFactory(new MethodInvoker(new GreedyConstructorQuery())));
            _fixture.Register<IFolderProcessor>(()=>mockProcessor.Object);            
            
            _orchestratorThingy = _fixture.Create<OrchestratorThingy>();            
        }

        private Fixture _fixture;
        private List<DataFile> _files; 
        private Mock<IFolderProcessor> mockProcessor;
        private readonly OrchestratorThingy _orchestratorThingy;
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
            _folder = _fixture.Build<MusicFolder>().Create();
        }

        [Given(@"the music folder hasn't been processed")]
        public void GivenTheMusicFolderHasnTBeenProcessed()
        {            
            _folder.Analysis = null;
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
        [Then(@"the folder should be processed")]
        public void ThenTheFolderShouldBeProcessed()
        {
            mockProcessor.Verify(mock => mock.Process(It.IsAny<MusicFolder>()), Times.Once());
        }

        [Then(@"analysis cache should list the files in the music folder")]
        public void ThenAnalysisCacheShouldListTheFilesInTheMusicFolder()
        {            
            Assert.Equal(_folder.Analysis.Files.Count, _files.Count);
            foreach (var file in _files)
            {
                Assert.Contains(file.FullPath, _folder.Analysis.Files.Select(x=>x.FullPath));
            }
        }


        [Then(@"processing should be skipped")]
        public void ThenProcessingShouldBeSkipped()
        {
            mockProcessor.Verify(mock=>mock.Process(It.IsAny<MusicFolder>()), Times.Never());
        }

        #endregion
    }
}
