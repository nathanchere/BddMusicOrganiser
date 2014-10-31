using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.IO.Abstractions.TestingHelpers;
using Ploeh.AutoFixture;
using TechTalk.SpecFlow;
using Xunit;

namespace MusicPresort.Specs
{
    [Binding, Scope(Feature = "Initial folder import")]
    class InitialFolderImportSteps
    {        
        private readonly Fixture _fixture;
        private readonly Dictionary<string,MockFileData> _fileSystem;
        private string _path;
        private MusicFolder _folder;

        private List<Exception> _exceptions; 

        public InitialFolderImportSteps()
        {
            _fixture = new Fixture();
            _fileSystem = new Dictionary<string, MockFileData>();
            _exceptions = new List<Exception>();
        }

        #region Given
        [Given(@"a folder path")]
        public void GivenAFolderPath() {
            _path = _fixture.Create<string>();
        }

        [Given(@"the folder path exists on disk")]
        public void GivenTheFolderPathExistsOnDisk()
        {
            _fileSystem.Add(_path, _fixture.Create<MockFileData>());
        }

        [Given(@"the folder path doesn't exist on disk")]
        public void GivenTheFolderPathDoesnTExistOnDisk(){ }

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
        #endregion

        #region When        
        [When(@"the folder is imported")]
        public void WhenTheFolderIsImported()
        {
            var factory = new MusicFolderFactory(new MockFileSystem(_fileSystem));            
            _folder = factory.Open(_path);
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
