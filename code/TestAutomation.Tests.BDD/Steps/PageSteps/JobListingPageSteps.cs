using System;
using TechTalk.SpecFlow;
using TestAutomation.Epam.PageObjects.Pages;

namespace TestAutomation.Tests.BDD.Steps.PageSteps
{
    [Binding]
    public class JobListingPageSteps : BaseStep
    {
        protected JobListingPage JobListingPage { get; set; }

        public JobListingPageSteps()
        {
            JobListingPage = new JobListingPage(Driver);
        }

        [Then(@"I check that the '([^']*)' Page is opend")]
        public void ThenICheckThatThePageIsOpend(string page)
        {
            Assert.That(JobListingPage.IsOpened(), $"Page {page} is not opened");
        }
    }
}
