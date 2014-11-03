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
        private readonly MockFileSystem _fileSystem;
        private string _path;
        private Date _date;
        private ImportResult _result;

        private List<Exception> _exceptions; 

        public InitialFolderImportSteps()
        {
            _fixture = new Fixture();
            _fileSystem = new MockFileSystem();
            _exceptions = new List<Exception>();
        }

        #region Given
        [Given(@"a folder path")]
        public void GivenAFolderPath() {
            _path = @"C:\testData\" + _fixture.Create<string>();
        }        

        [Given(@"the folder name is in a valid format")]
        public void GivenTheFolderNameIsInAValidFormat()
        {
            _date = new Date(2010,1,31);
            _path = string.Format(@"{0}\{1} {2}", _path, _date, _fixture.Create<string>());
        } 

        [Given(@"the folder name is not in a valid format")]
        public void GivenTheFolderNameIsNotInAValidFormat() { }

        [Given(@"the folder name is in a valid format but with an invalid date")]
        public void GivenTheFolderNameIsInAValidFormatButWithAnInvalidDate()
        {
            _path = string.Format(@"{0}\2010-02-30 {1}", _path, _fixture.Create<string>());
        }

        [Given(@"the folder path exists on disk")]
        public void GivenTheFolderPathExistsOnDisk()
        {
            _fileSystem.AddDirectory(_path);
        }

        [Given(@"the folder path doesn't exist on disk")]
        public void GivenTheFolderPathDoesnTExistOnDisk() { }
        #endregion

        #region When        
        [When(@"the folder is imported")]
        public void WhenTheFolderIsImported()
        {
            var factory = new MusicFolderFactory(_fileSystem);            
            _result = factory.Import(_path);
        }
        #endregion

        #region Then       
        [Then(@"the result should not have a 'Not Found' error")]
        public void ThenTheResultShouldNotHaveANotFoundError()
        {
            Assert.NotEqual(ImportResult.ResultEnum.PathNotFound, _result.Result);
        }

        [Then(@"the result should have a 'Not Found' error")]
        public void ThenTheResultShouldHaveAError()
        {
            Assert.Equal(ImportResult.ResultEnum.PathNotFound, _result.Result);
        }

        [Then(@"the result should have an 'Invalid Date' error")]
        public void ThenTheResultShouldHaveAnInvalidDateError()
        {
            Assert.Equal(ImportResult.ResultEnum.InvalidDate, _result.Result);
        }

        [Then(@"the result should have an 'Invalid Folder Name' error")]
        public void ThenTheResultShouldHaveAnInvalidFolderNameError()
        {
            Assert.Equal(ImportResult.ResultEnum.InvalidFolderName, _result.Result);
        }

        [Then(@"the result should have no error")]
        public void ThenTheResultShouldHaveNoError()
        {
            Assert.Equal(ImportResult.ResultEnum.Success, _result.Result);
        }

        [Then(@"the result should have the date")]
        public void ThenTheResultShouldHaveTheDate()
        {
            Assert.Equal(_date, _result.Folder.Date);
        }

        [Then(@"the result should have no date")]
        public void ThenTheResultShouldHaveNoDate()
        {
            Assert.True(_result.Folder == null || _result.Folder.Date == null);
        }

        [Then(@"the result should have no analysis cache")]
        public void ThenTheResultShouldHaveNoAnalysisCache()
        {
            Assert.Null(_result.Folder.Analysis);
        }

        [Then(@"the result should have an analysis cache")]
        public void ThenTheResultShouldHaveAnAnalysisCache()
        {
            Assert.NotNull(_result.Folder.Analysis);
        }
        #endregion
    }
}
