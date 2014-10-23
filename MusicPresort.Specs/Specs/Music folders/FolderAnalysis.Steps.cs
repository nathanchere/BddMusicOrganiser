using System;
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
        private Mock<IFolderProcessor> mockProcessor;
        private readonly OrchestratorThingy _orchestratorThingy;
        private MusicFolder _folder;

        #region Helpers

        private void AddFile(string artistName, string albumTitle, string trackTitle, int? trackNumber)
        {
        
            _folder._files.Add(
                new MusicFile{
                    ArtistName = artistName,
                    AlbumTitle = albumTitle,
                    TrackTitle = trackTitle,
                    TrackNumber = trackNumber
                }
            );
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
            Assert.NotNull(_folder.Analysis);
        }

        [Then(@"processing should be skipped")]
        public void ThenProcessingShouldBeSkipped()
        {
            // TODO: this isn't really ensuring it hasn't been processed and given a new cache
            Assert.NotNull(_folder.Analysis);
        }

        #endregion
    }
}
