using OpenQA.Selenium;
using TestAutomation.Epam.PageObjects.Pages;
using TestAutomation.Epam.Tests.TestDataClasses;
using TestAutomation.Tests;

namespace TestAutomation.Epam.Tests
{
    public class CareersPageTests : BaseTest
    {
        protected MainPage MainPage { get; set; }

        public override void BrowserSetup(IWebDriver driver)
        {
            MainPage = new MainPage(driver);
        }

        [Test]
        public void KeywordSearchResultСontextTest()
        {
            var mainPage = new MainPage(_driver);
            var jobListingPage = mainPage.NavigateToJobListingsPage();
            var testData = TestDataClassFactory.GetTestData<CareersKeywordSearchTestData>("CareersKeywordSearchTestData.json");
            
            foreach(var element in testData)
            {
                var searchResultTitleText = jobListingPage.SearchByKeyword(element.Keyword).GetSearchResultTitleText();
                Assert.That(searchResultTitleText.Contains(element.Keyword), $"Search result {searchResultTitleText} does not contain {element.Keyword}");
            }           
        }

        [Test]        
        public void KeywordLocationSearchResultСontextTest()
        {
            var mainPage = new MainPage(_driver);
            var jobListingPage = mainPage.NavigateToJobListingsPage();
            var testData = TestDataClassFactory.GetTestData<CareersLocationKeywordSearchTestData>("CareersLocationKeywordSearchTestData.json");

            foreach (var element in testData)
            {
                var searchResultLocations = jobListingPage.SelectByLocationKeyword(element.KeywordCountry, element.KeywordCity);
                var wrongResults = searchResultLocations.Where(x => !x.Contains(element.KeywordCountry,StringComparison.OrdinalIgnoreCase) || !x.Contains(element.KeywordCity, StringComparison.OrdinalIgnoreCase));
                CollectionAssert.IsEmpty(wrongResults, $"Not all elements are related to the selected location {element.KeywordCountry} and {element.KeywordCity}");
            }
        }
        [Test]
        public void SkillSearchResultContextTest()
        {
            var mainPage = new MainPage(_driver);
            var jobListingPage = mainPage.NavigateToJobListingsPage();
            var testData = TestDataClassFactory.GetTestData<CareersSkillKeywordChooseTestData>("CareersSkillKeywordChooseTestData.json");

            foreach (var element in testData)
            {
                var searchResultLocations = jobListingPage.SelectBySkillKeyword(element.Skill);
                var wrongResults = searchResultLocations.Where(x => !x.Contains(element.Skill, StringComparison.OrdinalIgnoreCase));
                CollectionAssert.IsEmpty(wrongResults, $"Not all elements are related to the selected skill {element.Skill}");
            }
        }

        [Test]
        public void KLSFilterringTest()
        {
            var mainPage = new MainPage(_driver);
            var jobListingPage = mainPage.NavigateToJobListingsPage();
            var testData = TestDataClassFactory.GetTestData<CareersKLSFilteringTestData>("CareersKLSFilteringTestData.json");

            foreach (var element in testData)
            {
                var searchResultLocations = jobListingPage.KLSFiltering(element.Keyword, element.KeywordCountry, element.KeywordCity, element.Skill);
                Assert.That(searchResultLocations.Count(), Is.AtLeast(1), 
                    $"There no faund elements with filters: {element.Keyword}, {element.KeywordCountry}, " +
                    $"{element.KeywordCity}, {element.Skill}");
            }
        }

        [Test]
        public void KLFilterTest()
        {
            var mainPage = new MainPage(_driver);            
            var jobListingPage = mainPage.NavigateToJobListingsPage();
            var testData = TestDataClassFactory.GetTestData<CareersKLFilteringTestData>("CareersKLFilteringTestData.json");

            foreach (var element in testData)
            {
                jobListingPage.KLFiltering(element.Keyword, element.KeywordCountry, element.KeywordCity);
                var actualErrorMessageText = jobListingPage.SearchResultErrorMessageTextCheck();
                Assert.That(actualErrorMessageText.Equals(element.ErrorMessage), 
                    $"The expected error message '{element.ErrorMessage}' differ from actual message '{actualErrorMessageText}'.");
            }
        }
    }
}
