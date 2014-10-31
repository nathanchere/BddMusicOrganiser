using System;
using TechTalk.SpecFlow;
using Xunit;

namespace MusicPresort.Specs
{
    [Binding, Scope(Feature = "Initial folder import")]
    class InitialFolderImportSteps
    {
        private readonly MusicFolderFactory _folderFactory;

        private string _path;
        private MusicFolder _folder;

        public InitialFolderImportSteps()
        {
            _folderFactory = new MusicFolderFactory();
        }

        #region Given
        [Given(@"the folder name is in a valid format")]
        public void GivenTheFolderNameIsInAValidFormat()
        {
            _path = "2010-01-30 (1977) Fleetwood.Mac.Rumours [vinyl rip]";
        }

        [Given(@"the folder name is not in a valid format")]
        public void GivenTheFolderNameIsNotInAValidFormat()
        {
            _path = "1977 Fleetwood.Mac.Rumours [vinyl rip]";
        }

        [Given(@"the folder name is in a valid format but with an invalid date")]
        public void GivenTheFolderNameIsInAValidFormatButWithAnInvalidDate()
        {
            _path = "2010-02-30 (1977) Fleetwood.Mac.Rumours [vinyl rip]";
        }


        [Given(@"I have a full folder path")]
        public void GivenIHaveAFullFolder()
        {
            _folder = new MusicFolder();
        }      
        #endregion

        #region When        
        [When(@"I pre-process the folder")]
        public void WhenIPre_ProcessTheFolder()
        {
            _folderFactory.Open(_path);
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
