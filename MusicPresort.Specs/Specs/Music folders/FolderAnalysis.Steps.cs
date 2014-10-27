﻿using System;
using System.Collections.Generic;
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

        [Given(@"I have a music folder which hasn't been processed")]
        public void GivenIHaveAMusicFolderWhichHasnTBeenProcessed()
        {
            _folder = _fixture.Create<MusicFolder>();
            _folder.Analysis = null;
        }

        [Given(@"the music folder has some files")]
        public void GivenTheMusicFolderHasSomeFiles()
        {
            
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

        [Then(@"analysis cache should list the input files")]
        public void ThenAnalysisCacheShouldListTheInputFiles()
        {
            ScenarioContext.Current.Pending();
        }


        [Then(@"processing should be skipped")]
        public void ThenProcessingShouldBeSkipped()
        {
            mockProcessor.Verify(mock=>mock.Process(It.IsAny<MusicFolder>()), Times.Never());
        }

        #endregion
    }

    public class DataFile
    {
        public string FullPath { get; set; }
    }
}
