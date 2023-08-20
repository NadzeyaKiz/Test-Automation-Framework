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
        static MainPage()
        {
            PageUrl = UiTestSettings.ApplicationUrl;
        }
        public MainPage(IWebDriver driver) : base(driver)
        {
            driver.SetUpCookies(By.XPath("//button[@id='onetrust-accept-btn-handler']"));
        }

        public JobListingPage NavigateToJobListingsPage()
        {
            Driver
                .MoveToElement(By.XPath("//*[@href = '/careers' and  contains(@class, 'top-navigation__item-link')]"))
                .ClickWithFindElement(By.XPath("//nav[contains(@class,'top-navigation')]//a[@href='/careers/job-listings']"));

            return new JobListingPage(Driver);
        }
        public MainPage OpenLanguagePannel()
        {
            Driver.ClickUsingJSWithFind(By.XPath("//button[@class='location-selector__button']"));
            return this;
        }
        public List<string> GetLanguagesFromLangPannel()
        {
            Driver.FindElementWithElementTobeVisible(By.XPath("//nav[@class='location-selector__panel']"));
            return Driver.FindTheElements(By.XPath("//nav[@class='location-selector__panel']//a[contains(@class,'location-selector__link')]/span"))
                .Select(x => x.Text)
                .ToList();
        }
        public IWebElement GetFrequentSearchRandomElement()
        {
            Driver.ClickWithFindElement(By.XPath("//span[contains(@class,'dark-iconheader-search__search-icon')]"));

            ReadOnlyCollection<IWebElement> listOfSearchElements = null;
            Driver.WaitForCondition(driver =>
            {
                listOfSearchElements = Driver.FindElements(By.XPath("//li[@class='frequent-searches__item']"));
                return listOfSearchElements.Count > 0;
            });
            Random random = new Random();
            int randomIndex = random.Next(0, listOfSearchElements.Count);
            return listOfSearchElements[randomIndex];

        }
        public void ClickFindButtonOnSearchPannel()
        {
            Driver.ClickWithFindElement(By.XPath("//*[@class='bth-text-layer']"));
        }
        
    }
}
