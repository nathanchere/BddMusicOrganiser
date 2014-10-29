using System;
using TechTalk.SpecFlow;
using Xunit;

namespace MusicPresort.Specs
{
    [Binding, Scope(Feature = "Preimport")]
    class PreimportSteps
    {
        private readonly OrchestratorThingy _orchestratorThingy;

        private MusicFolder _folder;

        public PreimportSteps()
        {
            _orchestratorThingy = new OrchestratorThingy();
        }

        #region Given
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
            _folder = new MusicFolder();
        }      
        #endregion

        #region When        
        [When(@"I pre-process the folder")]
        public void WhenIPre_ProcessTheFolder()
        {
            _orchestratorThingy.PreprocessFolder(_folder);
        }
        #endregion

        #region Then       
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
        #endregion
    }
}
