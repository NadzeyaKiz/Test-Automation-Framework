using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TestAutomation.Core.Browser;
using TestAutomation.Core.Elements;
using TestAutomation.Epam.PageObjects.Pages;

namespace TestAutomation.Tests.BDD.Steps.BDDSteps
{
    [Binding]
    public class LandingPageSteps : BaseStep
    {
        protected MainPage MainPage { get; set; }

        public LandingPageSteps()
        {            
            MainPage = new MainPage(Driver);
        }        

        [Given(@"I navigate to the main page of Epam site")]
        public void GivenINavigateToTheMainPageOfEpamSite()
        {
            MainPage.NavigateToPage();             
        }
    }
}
