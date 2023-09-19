using OpenQA.Selenium;
using TestAutomation.Core.Browser;
using TestAutomation.Epam.PageObjects.Pages;
using TestAutomation.Tests;

namespace TestAutomation.Epam.Tests
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

        [Test]
        public void NavigateToEpamePageTest()
        {
            Assert.IsTrue(this.MainPage.IsOpened(), "Incorrect EPAM main page Url!");
        }

        [Test]
        public void NavigateToOurWorPagekUrlWithRefreshTest()
        {
            var howWeDoItPage = new HowWeDoItPage(_driver);
            howWeDoItPage.NavigateToPage();
            var ourWorkPage = new OurWorkPage(_driver);
            ourWorkPage
                .NavigateToPage()
                .Refresh()
                .NavigateBackPage();

            Assert.IsTrue(howWeDoItPage.IsOpened(), "Incorrect 'How we do it' page Url!");
        }
        [Test]
        public void CheckAvaliableCountriesTest()
        {
            string[] locationTextConstantsCollection = { "AMERICAS", "EMEA", "APAC" };
            var careersPage = new CareersPage(_driver);
            careersPage
                .OpenCareersPageClickCareersButton()
                .OpenJobListingsPageClickFindYourDreamJobButton();
            //searchLocationElementsLocator               
            CollectionAssert.AreEquivalent(locationTextConstantsCollection, careersPage.GetCareersLocationItemList());
        }

        [Test]
        public void CheckFirstFiveArticleTest()
        {
            var textToSearch = "Automation";
            var expectedOpendPageUrl = $"https://www.epam.com/search?q={textToSearch}";

            var mainPage = new MainPage(_driver);
            mainPage.OpenSearchPageWithSendKeys(textToSearch);

            Assert.AreEqual(expectedOpendPageUrl, _driver.Url, "Invalid opend page Url");

            var searchPage = new SearchPage(_driver);
            var searchArticles = searchPage.GetCollectionArticlesDescriptionOnSearchPage();

            Assert.That(searchArticles.Count(), Is.AtLeast(5));
            Assert.That(searchArticles.All(e => e.Contains(textToSearch, StringComparison.OrdinalIgnoreCase)),
                $"The word '{textToSearch}' is NOT present");

        }

        [Test]
        [TestCase("Business Analyst")]
        public void CheckFirstArticleTest(string textToSearch)
        {
            var textToSearchInUrlIncoding = textToSearch.Replace(" ", "+");
            var expectedOpendPageUrl = $"https://www.epam.com/search?q={textToSearchInUrlIncoding}";

            var mainPage = new MainPage(_driver);
            mainPage.OpenSearchPageWithSendKeys(textToSearch);

            Assert.AreEqual(expectedOpendPageUrl, _driver.Url, "Invalid opend page Url");

            SearchPage searchPage = new SearchPage(_driver);
            var firstArticleElement = searchPage.GetWebElementsCollectionOnSearchPage().First();
            var firstArticleText = firstArticleElement.Text;
            firstArticleElement.Click();

            var actualTitleOfOpendFirstArticlePage = _driver.FindElement(By.XPath("//main//*[@class='museo-sans-light']")).Text;

            Assert.AreEqual(firstArticleText, actualTitleOfOpendFirstArticlePage, "Invalid first article Title");
        }
    }
}