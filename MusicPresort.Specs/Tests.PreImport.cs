using System;
using TechTalk.SpecFlow;

namespace MusicPresort.Specs
{
    /// <summary>
    /// Folder name
    /// </summary>
    partial class MusicFolderTests
    {
        [Given(@"the folder name is ""(.*)""")]
        public void GivenTheFolderNameIs(string folderName)
        {
            _folder.Name = folderName;
        }

        [When(@"I pre-process the folder")]
        public void WhenIPre_ProcessTheFolder()
        {
            _thingy.PreprocessFolder(_folder);
        }

        [Then(@"the result should have the date (.*)(.*)")]
        public void ThenTheResultShouldHaveTheDate(string p0, int p1)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
