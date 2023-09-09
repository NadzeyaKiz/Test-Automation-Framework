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

        [When(@"I click on the '([^']*)' dropdown button")]
        public void WhenIClickOnTheDropdownButton(string languagies)
        {
            MainPage.OpenLanguagePannel();
        }

        [Then(@"I check that the list of desired languagies contains the following <language>:")]
        public void ThenICheckThatTheListOfDesiredLanguagiesContainsTheFollowingLanguage(Table table)
        {
            var expectedLanguages = new List<string> { "(English)", "(Русский)", "(Čeština)", "(Українська)", "(日本語)", "(中文)", "(Deutsch)", "(Polski)" };
            var actualLanguagies = MainPage.GetLanguagesFromLangPannel();
            CollectionAssert.IsSubsetOf(expectedLanguages, actualLanguagies, 
                $"The list of expected languages {expectedLanguages} not contained in the actual languages list{actualLanguagies}");
        }

    }
}
