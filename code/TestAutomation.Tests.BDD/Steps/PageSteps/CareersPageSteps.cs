using TechTalk.SpecFlow;
using TestAutomation.Epam.PageObjects.Pages;

namespace TestAutomation.Tests.BDD.Steps.PageSteps
{
    [Binding]
    public class CareersPageSteps : BaseStep
    {
        protected CareersPage CareersPage { get; set; }
        public CareersPageSteps()
        {
            CareersPage = new CareersPage(Driver);
        }

        [Given(@"I open Careers page with click on '([^']*)' button")]
        public void GivenIOpenCareersPageWithClickOnButton(string careers)
        {
            CareersPage.OpenCareersPageClickCareersButton();
        }

        [When(@"I click on the '([^']*)'")]
        public void WhenIClickOnThe(string p0)
        {
            CareersPage.OpenJobListingsPageClickFindYourDreamJobButton(); 
        }

        [Then(@"I check that the actual list of locations contains the following <locations>:")]
        public void ThenICheckThatTheActualListOfLocationsContainsTheFollowingLocations(Table table)
        {
            string[]locationTextConstantsCollection = { "AMERICAS", "EMEA", "APAC" };
            var actualLocationTextConstantsCollection = CareersPage.GetCareersLocationItemList();
            CollectionAssert.AreEquivalent(locationTextConstantsCollection, actualLocationTextConstantsCollection);
        }

        [Then(@"I check that the all of the check boxes for choosing type of work are presented on the page <TypesOfWork>:")]
        public void ThenICheckThatTheAllOfTheCheckBoxesForChoosingTypeOfWorkArePresentedOnThePageTypesOfWork(Table table)
        {
            var expectedWorkingTypes = new List<string> { "Remote", "Office", "Open to Relocation" };
            var actualWorkingTypes = CareersPage.GetCareersTypeOfWorkingCheckboxesItemList();
            CollectionAssert.AreEquivalent(expectedWorkingTypes, actualWorkingTypes, $"The {expectedWorkingTypes} differs from {actualWorkingTypes}.");
        }    

    }
}
