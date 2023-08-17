using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using TestAutomation.Core.Browser;
using TestAutomation.Core.Elements;
using TestAutomation.Core.Enums;
using TestAutomation.Core.Utilities;


namespace Test.Automation.Framework.Tests
{
    public class SeleniumAdvancedEpamTests
    {
        private IWebDriver _driver { get; set; }
        private const string _epamUrl = "https://www.epam.com/";       

        [SetUp, Order(1)]
        public void BrowserSetup()
        {
            TestAutomation.Core.Utilities.Logger.InitLogger("Browser");
            _driver = DriverFactory.GetWebBrowser(BrowserType.Edge).GotToWebPageUrl(_epamUrl);
        }

        [SetUp, Order(2)]
        public void SetUpCookies()
        {
            // accept cookies
            _driver.WaitForCondition(driver =>
            {
                var cookiesAcceptButtons = _driver.FindElements(By.XPath("//button[@id='onetrust-accept-btn-handler']"));
                if (cookiesAcceptButtons.Count == 1)
                {
                    if (cookiesAcceptButtons[0].Displayed)
                    {
                        cookiesAcceptButtons[0].Click();
                    }

                    return cookiesAcceptButtons[0].Displayed == false;
                }
                return false;
            });
        }

        [Test]
        public void CheckJobListingsUrlTest()
        {
            _driver
                .MoveToElement(By.XPath("//*[@href = '/careers' and  contains(@class, 'top-navigation__item-link')]"))
                .Click(By.XPath("//nav[contains(@class,'top-navigation')]//a[@href='/careers/job-listings']"));

            Assert.That(_driver.Url, Is.EqualTo("https://www.epam.com/careers/job-listings"), "Incorrect URL");
        }
        [Test]
        public void LanguagesDroudownListOfLanguadesTest()
        {
            var languagesDropdown = _driver.FindTheElement(By.XPath("//button[@class='location-selector__button']"));
            languagesDropdown.ClickUsingJS(_driver);

            var langPanel = _driver.FindTheElement(By.XPath("//nav[@class='location-selector__panel']"));
            _driver.WaitForElementToBeVisible(langPanel);

            var languagesArray = new List<string> { "(English)", "(Русский)", "(Čeština)", "(Українська)", "(日本語)", "(中文)", "(Deutsch)", "(Polski)" };

            var foundLanduages = _driver.FindTheElements(By.XPath("//nav[@class='location-selector__panel']//a[contains(@class,'location-selector__link')]/span"))
                .Select(x => x.Text);
            foreach (var language in languagesArray)
            {
                Assert.IsTrue(foundLanduages.Contains(language), $"Language '{language}' was not found in the list.");
            }
        }
        [Test]
        public void NumberOfArticlesOnPageTest()
        {
            _driver.Click(By.XPath("//span[contains(@class,'dark-iconheader-search__search-icon')]"));
                        
            ReadOnlyCollection<IWebElement> listOfSearchElements = null;
            _driver.WaitForCondition(driver =>
            {
                listOfSearchElements = _driver.FindElements(By.XPath("//li[@class='frequent-searches__item']"));
                return listOfSearchElements.Count > 0;
            });
                        
            Random random = new Random();
            int randomIndex = random.Next(0, listOfSearchElements.Count);
            _driver.WaitForCondition(driver =>
            {
                if (listOfSearchElements[randomIndex].Displayed)
                {
                    listOfSearchElements[randomIndex].Click();
                    return true;
                }
                return false;
            });

            var findButton = _driver.FindTheElement(By.XPath("//*[@class='bth-text-layer']"));
            findButton.Click();

            _driver.WaitForCondition(driver =>
            {
                var listOfArticles = _driver.FindElements(By.XPath("//article"));
                _driver.ScrollToElement(listOfArticles[listOfArticles.Count - 1]);
                var searchViewMoreLink = _driver.FindElements(By.XPath("//a[@class='search-results__view-more button-text']"));

                if (searchViewMoreLink.Count == 1)
                {
                    _driver.ScrollToElement(searchViewMoreLink[0]);
                }
                return searchViewMoreLink.Count == 1;
            });

            var listOfArticles = _driver.FindElements(By.XPath("//article"));
            Assert.That(listOfArticles.Count, Is.EqualTo(20));
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Close();
            _driver.Quit();
        }
    }
}