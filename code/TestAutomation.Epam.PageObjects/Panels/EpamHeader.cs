using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TestAutomation.Core.Elements;

namespace TestAutomation.Epam.PageObjects.Panels
{
    public class EpamHeader
    {
        public IWebDriver Driver { get; protected set; }
        public IWebElement Element { get; protected set; }  

        public static string headerPanelLocator = "//*[@class='header-ui']";
        public static string epamLogoLocator = "//*[@class='header__logo']";
        public static string servicesLinkLocator = "//*[@class='top-navigation__item-link' and @href='/services']";       
        public static string insightsLinkLocator = "//*[@class='top-navigation__item-link' and @href='/insights']";
        public static string aboutLinkLocator = "//*[@class='top-navigation__item-link' and @href='/about']";
        public static string careersLinkLocator = "//*[@class='top-navigation__item-link' and @href='/careers']";
        public static string contactUsButtonLocator = "//*[@class='cta-button__text']";
        public static string languageDropdownLocator = "//*[@class='location-selector__button']";
        public static string searchButtonLocator = "//*[@class='header-search__button header__icon']";        

        public bool IsEpamLogoDisplayed()
        {
            var epamLogo = Driver.FindElement(By.XPath(epamLogoLocator));
            return Element.IsElementDisplayedOnPage(epamLogo);
        }
    }
}
