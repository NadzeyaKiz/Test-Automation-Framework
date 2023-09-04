using OpenQA.Selenium;
using TestAutomation.Core.Browser;
using TestAutomation.Core.Elements;
using System.Threading;

namespace TestAutomation.Epam.PageObjects.Pages
{
    public class JobListingPage : BasePage
    {
        public static string KeyWordOrJobIDLocator = "//input[@id='new_form_job_search-keyword']";
        public static string FindButtonOnJobListingsPage = "//button[@type='submit']";
        public static string SearchResultTitleLocator = "//*[contains(@class,'search-result__heading')]";
        public static string SearchLocationInputLocator = "//*[@class='select2-search__field']";
        public static string SearchLocationDropdownLocator = "//*[@id='select2-new_form_job_search-location-results']"; //all results locator
        public static string SearchLocationDropdownCountryLocator = "//li[@class='select2-results__option'][@aria-label='{0}']";

        public JobListingPage(IWebDriver driver) : base(driver)
        {
            PageUrl = "https://www.epam.com/careers/job-listings";
        }

        public JobListingPage SearchByKeyword(string textToSearch)
        {
            Driver.SendKeysWithFindElementAndClean(By.XPath(KeyWordOrJobIDLocator), textToSearch);
            Driver.ClickWithFindElement(By.XPath(FindButtonOnJobListingsPage));
            Driver.WaitForCondition(driver =>
            {
                var element = driver.FindElement(By.XPath(SearchResultTitleLocator));
                if (element != null && element.Text.Contains(textToSearch))
                {
                    return true;
                }
                return false;
            } , TimeSpan.FromSeconds(5));

            return this;
        }

        //public JobListingPage SelectByLocationKeyword(string countryToSelect, string cityToSelect)
        //{
        //    Driver.FindElement(By.XPath(SearchLocationInputLocator)).Click();
        //    Driver.WaitForElementToBePresent(By.XPath(SearchLocationDropdownLocator), TimeSpan.FromSeconds(5));
        //    Driver.ClickWithFindElement(By.XPath(string.Format(SearchLocationDropdownCountryLocator, countryToSelect)));
        //    Driver.WaitForElementToBePresent(By.XPath(SearchLocationDropdownLocator), TimeSpan.FromSeconds(5));
        //    dropdown.Select(elemetnt => elemetnt.Text)
        //}

        public string GetSearchResultTitleText()
        {
            var element = Driver.FindElement(By.XPath(SearchResultTitleLocator));
            return element.Text;
        }
    }
}
