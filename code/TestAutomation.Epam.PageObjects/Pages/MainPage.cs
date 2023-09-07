using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomation.Core.Browser;
using TestAutomation.Core.Elements;
using TestAutomation.Core.Utilities; 

namespace TestAutomation.Epam.PageObjects.Pages
{
    public class MainPage : BasePage
    {
        public static string cookiesAcceptButtonLocator  = "//button[@id='onetrust-accept-btn-handler']";
        public static string careersHeaderButtonLocator = "//*[@href = '/careers' and  contains(@class, 'top-navigation__item-link')]";
        public static string joinOurTeamCareersLinkLocator = "//nav[contains(@class,'top-navigation')]//a[@href='/careers/job-listings']";
        public static string locationSelectorHeaderButtonLocator = "//button[@class='location-selector__button']";
        public static string languagesPannelLocator = "//nav[@class='location-selector__panel']";
        public static string locationSelectorLanguagesLocator = "//nav[@class='location-selector__panel']//a[contains(@class,'location-selector__link')]/span";
        public static string magnifyingGlassButtonLocator = "//span[contains(@class,'dark-iconheader-search__search-icon')]";
        public static string frequentSearchElementsLocator = "//li[@class='frequent-searches__item']";
        public static string findButtonOnSearchPannelLocator = "//*[@class='bth-text-layer']";
        public static string searchFieldLocator = "new_form_search";
        public static string mainPageUrl = "https://www.epam.com/";

        public MainPage(IWebDriver driver) : base(driver)
        {
            PageUrl = UiTestSettings.ApplicationUrl;
            //todo: fix it later for nunit tests
            //driver.SetUpCookies(By.XPath(cookiesAcceptButtonLocator));
        }

        public void AcceptCoockies()
        {
            Driver.SetUpCookies(By.XPath(cookiesAcceptButtonLocator));
        }

        public JobListingPage NavigateToJobListingsPage()
        {
            Driver
                .MoveToElement(By.XPath(careersHeaderButtonLocator))
                .ClickWithFindElement(By.XPath(joinOurTeamCareersLinkLocator));

            return new JobListingPage(Driver);
        }
        public MainPage OpenLanguagePannel()
        {
            Driver.ClickUsingJSWithFind(By.XPath(locationSelectorHeaderButtonLocator));
            return this;
        }
        public List<string> GetLanguagesFromLangPannel()
        {
            Driver.FindElementWithElementTobeVisible(By.XPath(languagesPannelLocator));
            return Driver.FindTheElements(By.XPath(locationSelectorLanguagesLocator))
                .Select(x => x.Text)
                .ToList();
        }
        public IWebElement GetFrequentSearchRandomElement()
        {
            Driver.ClickWithFindElement(By.XPath(magnifyingGlassButtonLocator));

            ReadOnlyCollection<IWebElement> listOfSearchElements = null;
            Driver.WaitForCondition(driver =>
            {
                listOfSearchElements = Driver.FindElements(By.XPath(frequentSearchElementsLocator));
                return listOfSearchElements.Count > 0;
            });
            Random random = new Random();
            int randomIndex = random.Next(0, listOfSearchElements.Count);
            return listOfSearchElements[randomIndex];

        }
        public void ClickFindButtonOnSearchPannel()
        {
            Driver.ClickWithFindElement(By.XPath(findButtonOnSearchPannelLocator));
        }        
        public void OpenSearchPageWithSendKeys(string textToSearch)
        {
            Driver.ClickWithFindElement(By.XPath(magnifyingGlassButtonLocator));
            Driver.SendKeysWithFindElement(By.Id(searchFieldLocator), textToSearch);
            Driver.ClickWithFindElement(By.XPath(findButtonOnSearchPannelLocator));
        }
    }
}
