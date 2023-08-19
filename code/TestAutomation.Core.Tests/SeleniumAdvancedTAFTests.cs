using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using TestAutomation.Core.Browser;
using TestAutomation.Core.Elements;
using TestAutomation.Core.Enums;
using TestAutomation.Core.Utilities;
using TestAutomation.Tests;

namespace Test.Automation.Framework.Tests
{
    public class SeleniumAdvancedTAFTests : BaseTest
    {        
        private const string _epamUrl = "https://www.epam.com/";

        [SetUp]
        public void BrowserSetup()
        {
            _driver = DriverFactory.GetWebBrowser(BrowserType.Edge).GotToWebPageUrl(_epamUrl);
            _driver.SetUpCookies(By.XPath("//button[@id='onetrust-accept-btn-handler']"));
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
            _driver.ClickUsingJSWithFind(By.XPath("//button[@class='location-selector__button']"));
           
            //Re-do metod to get FindElementWithWait
            var langPanel = _driver.FindTheElement(By.XPath("//nav[@class='location-selector__panel']"));
            _driver.WaitForElementToBeVisible(langPanel);

            var languagesArray = new List<string> { "(English)", "(Русский)", "(Čeština)", "(Українська)", "(日本語)", "(中文)", "(Deutsch)", "(Polski)" };

            //get elements text
            var foundLanduages = _driver.FindTheElements(By.XPath("//nav[@class='location-selector__panel']//a[contains(@class,'location-selector__link')]/span"))
                .Select(x => x.Text);
            foreach (var language in languagesArray)
            {
                Assert.That(foundLanduages, Does.Contain(language), $"Language '{language}' was not found in the list.");
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
            //findButton
            _driver.Click(By.XPath("//*[@class='bth-text-layer']"));

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

            //listOfArticles
            Assert.That(_driver.FindElements(By.XPath("//article")), Has.Count.EqualTo(20));
        }        
    }
}