using System;
using TechTalk.SpecFlow;

namespace MusicPresort.Specs
{
    [Binding]
    public class VerifyingConsistencyOfTagsSteps
    {
        [Given(@"I have a music folder")]
        public void GivenIHaveAMusicFolder()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"the folder has MP(.*)s with mixed artist names")]
        public void GivenTheFolderHasMPsWithMixedArtistNames(int p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"the folder has MP(.*)s with mixed album names")]
        public void GivenTheFolderHasMPsWithMixedAlbumNames(int p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"the folder has MP(.*)s with missing artist names")]
        public void GivenTheFolderHasMPsWithMissingArtistNames(int p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I process the folder")]
        public void WhenIProcessTheFolder()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the folder should be filtered out")]
        public void ThenTheFolderShouldBeFilteredOut()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
