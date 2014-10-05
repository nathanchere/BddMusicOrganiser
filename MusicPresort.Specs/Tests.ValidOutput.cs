using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace MusicPresort.Specs
{
    [Binding]
    public class EndToEndSteps
    {
        private readonly Thingy _thingy;
        private List<MusicFolder> _folders;

        [Given(@"I have a collection of folders")]
        public void GivenIHaveACollectionOfFolders()
        {
            _folders = new List<MusicFolder>();
        }

        [Given(@"there are some valid folders within")]
        public void GivenThereAreSomeValidFoldersWithin()
        {
            ScenarioContext.Current.Pending();
            //_folders.Add(new MusicFolder{
            //    _files = 
            //});
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
