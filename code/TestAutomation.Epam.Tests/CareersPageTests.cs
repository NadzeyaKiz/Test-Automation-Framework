using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        //[Test]
        //public void KeywordLocationSearchResultСontextTest()
        //{
        //    var mainPage = new MainPage(_driver);
        //    var jobListingPage = mainPage.NavigateToJobListingsPage();
        //    var testData = TestDataClassFactory.GetTestData<CareersLocationKeywordSearchTestData>("CareersLocationKeywordSearchTestData.json");

        //    foreach (var element in testData)
        //    {
        //        var searchResultTitleText = jobListingPage.SearchByKeyword(element.Keyword).GetSearchResultTitleText();
        //        Assert.That(searchResultTitleText.Contains(element.Keyword), $"Search result {searchResultTitleText} does not contain {element.Keyword}");
        //    }
        //}
    }
}
