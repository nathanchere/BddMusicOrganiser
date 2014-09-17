using System;
using TechTalk.SpecFlow;

namespace MusicPresort.Specs
{
    partial class MusicFolderTests
    {
        [Given(@"the folder name is ""(.*)""")]
        public void GivenTheFolderNameIs(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I pre-process the folder")]
        public void WhenIPre_ProcessTheFolder()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the result should have the date (.*)(.*)")]
        public void ThenTheResultShouldHaveTheDate(string p0, int p1)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
