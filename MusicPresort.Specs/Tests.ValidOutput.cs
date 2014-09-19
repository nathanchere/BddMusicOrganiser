using System;
using TechTalk.SpecFlow;

namespace MusicPresort.Specs
{
    [Binding]
    public class EndToEndSteps
    {
        [Given(@"I have a collection of folders")]
        public void GivenIHaveACollectionOfFolders()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"there are some valid folders within")]
        public void GivenThereAreSomeValidFoldersWithin()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I process the collection of folders")]
        public void WhenIProcessTheCollectionOfFolders()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the valid ones should have an import date")]
        public void ThenTheValidOnesShouldHaveAnImportDate()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the valid ones should have an artist name")]
        public void ThenTheValidOnesShouldHaveAnArtistName()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the valid ones should have an album title")]
        public void ThenTheValidOnesShouldHaveAnAlbumTitle()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the valid ones should have an album year")]
        public void ThenTheValidOnesShouldHaveAnAlbumYear()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
