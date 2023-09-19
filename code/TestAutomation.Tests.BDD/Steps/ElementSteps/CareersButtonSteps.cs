using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TestAutomation.Epam.PageObjects.Pages;

namespace TestAutomation.Tests.BDD.Steps.ElementSteps
{
    [Binding]
    public class CareersButtonSteps : BaseStep
    {
        protected MainPage MainPage { get; set; }

        public CareersButtonSteps()
        {
            MainPage = new MainPage(Driver);
        }

        [When(@"I hover over the '([^""]*)' click on Join our team link from the dropdown menu")]
        public void WhenIHoverOverTheClickOnJoinOurTeamLinkFromTheDropdownMenu(string careers)
        {
            MainPage.NavigateToJobListingsPage();
        }
    }
}
