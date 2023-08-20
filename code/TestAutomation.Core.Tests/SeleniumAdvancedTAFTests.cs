using OpenQA.Selenium;
using System.Collections.ObjectModel;
using TestAutomation.Core.Browser;
using TestAutomation.Core.Elements;
using TestAutomation.Core.Utilities;
using TestAutomation.Epam.PageObjects.Pages;
using TestAutomation.Tests;

namespace Test.Automation.Framework.Tests
{
    public class SeleniumAdvancedTAFTests : BaseTest
    {
        protected MainPage MainPage { get; set; }

        public override void BrowserSetup(IWebDriver driver)
        {
            MainPage = new MainPage(driver);
        }
        
        [Test]
        public void CheckJobListingsUrlTest()
        {
            var jobListingPage = this.MainPage.NavigateToJobListingsPage();
            Assert.That(jobListingPage.IsOpened(), "Incorrect URL");
        }

        [Test]
        public void LanguagesDropdownListOfLanguadesTest()
        {
            var actualLanguages = MainPage
                .OpenLanguagePannel()
                .GetLanguagesFromLangPannel();

            var expectedLanguages = new List<string> { "(English)", "(Русский)", "(Čeština)", "(Українська)", "(日本語)", "(中文)", "(Deutsch)", "(Polski)" };

            CollectionAssert.IsSubsetOf(expectedLanguages, actualLanguages);
            
        }
        [Test]
        public void NumberOfFrequentSearchArticlesOnPageTest()
        {
            var frequantSearchElement = this.MainPage.GetFrequentSearchRandomElement();
            _driver.ClickWithWaitForDisplay(frequantSearchElement);    
                       
            MainPage.ClickFindButtonOnSearchPannel();
            
            var actualSearchArticles = (new SearchPage(_driver)).GetSearchItemList();
           
            Assert.That(actualSearchArticles, Has.Count.EqualTo(20));
        }        
    }
}