using Microsoft.VisualBasic;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomation.Core.Browser;
using TestAutomation.Core.Elements;

namespace TestAutomation.Epam.PageObjects.Pages
{
    public class CareersPage : BasePage
    {
        public static string searchCareersButtonLocator = "//*[contains(@class,'top-navigation')][@href='/careers']";
        public static string findYourDreamJobButtonLocator = "//div[@class='owl-item active']//a[@href='/careers/job-listings']";
        public static string careersLocationsLocator = "//div[contains(@class,'tabs-links-list')]//a";
        public static string careersTypeOfWorkCheckboxesConteinerLocator = "//*[@class='recruiting-search__filter']//label";

        public CareersPage(IWebDriver driver) : base(driver)
        {
            PageUrl = "https://www.epam.com/careers";
        }

        public List<string> GetCareersLocationItemList() => 
            Driver.FindElements(By.XPath(careersLocationsLocator))
                .Select(x => x.Text)
                .ToList();
        public List<string> GetCareersTypeOfWorkingCheckboxesItemList() =>
            Driver.FindElements(By.XPath(careersTypeOfWorkCheckboxesConteinerLocator))
                .Select(x => x.Text)
                .ToList();

        public CareersPage OpenCareersPageClickCareersButton()
        {
            Driver.ClickWithFindElement(By.XPath(searchCareersButtonLocator));
            return this;
        }

        public CareersPage OpenJobListingsPageClickFindYourDreamJobButton()
        {
            Driver.ClickWithFindElement(By.XPath(findYourDreamJobButtonLocator));
            return this;
        }
    }

}
