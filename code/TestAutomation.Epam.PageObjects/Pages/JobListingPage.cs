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
        public static string SearchLocationArrowLocator = "//*[@class='select2-selection__arrow']";
        public static string SearchLocationDropdownLocator = "//*[@id='select2-new_form_job_search-location-results']"; //all results locator
        public static string SearchLocationDropdownCountryLocator = "//li[@class='select2-results__option'][@aria-label='{0}']";
        public static string SearchLocationDropdownCityLocator = "//li[contains(@id,'{0}')]";
        public static string SearchResultLocationsLocator = "//*[@class='search-result__item-info-group']";
        public static string SearchSkillDropdownFieldLocator = "//*[contains(@class,'multi-select-filter validation')]";
        public static string SearchSkillDropdownConteinerLocator = "//*[@class='multi-select-dropdown-container']//ul";
        public static string SearchSkillDropdownSkillLocator = "//input[@data-value='{0}']/ancestor::li";
        public static string FindButtonLocator = "//button[@type='submit']";
        public static string SearchResultErrorMessageLocator= "//div[contains(@class,'search-result__error-message')]";
        
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

        public List<string> SelectByLocationKeyword(string countryToSelect, string cityToSelect)
        {
            SearchBy(() =>
            {
                Driver.FindElement(By.XPath(SearchLocationArrowLocator)).Click();
                Driver.WaitForElementToBePresent(By.XPath(SearchLocationDropdownLocator), TimeSpan.FromSeconds(5));
                Driver.ClickWithFindElement(By.XPath(string.Format(SearchLocationDropdownCountryLocator, countryToSelect)));
                Driver.ClickWithFindElement(By.XPath(string.Format(SearchLocationDropdownCityLocator, cityToSelect)));
            });

            var searchResults = Driver.FindElements(By.XPath(SearchResultLocationsLocator));
            return searchResults.Select(element => element.Text).ToList();
        }

        public string GetSearchResultTitleText()
        {
            var element = Driver.FindElement(By.XPath(SearchResultTitleLocator));
            return element.Text;
        }

        public List<string> SelectBySkillKeyword(string skillToSelect)
        {
            SearchBy(() =>
            {
                Driver.FindElement(By.XPath(SearchSkillDropdownFieldLocator)).Click();
                Driver.WaitForElementToBePresent(By.XPath(SearchSkillDropdownConteinerLocator), TimeSpan.FromSeconds(5));
                Driver.ClickWithFindElement(By.XPath(string.Format(SearchSkillDropdownSkillLocator, skillToSelect)));
            });
            
            var searchResults = Driver.FindElements(By.XPath(SearchResultLocationsLocator));
            return searchResults.Select(element => element.Text).ToList();
        }

        public List<string> KLSFiltering(string textToSearch, string countryToSelect, string cityToSelect, string skillToSelect)
        {
            SearchByKeyword(textToSearch);
            SelectBySkillKeyword(skillToSelect);
            SelectByLocationKeyword(countryToSelect, cityToSelect);
            
            var searchResults = Driver.FindElements(By.XPath(SearchResultLocationsLocator));
            return searchResults.Select(element => element.Text).ToList();
        }

        public List<string> KLFiltering(string textToSearch, string countryToSelect, string cityToSelect)
        {
            SearchByKeyword(textToSearch);
            SelectByLocationKeyword(countryToSelect, cityToSelect);

            var searchResults = Driver.FindElements(By.XPath(SearchResultLocationsLocator));
            return searchResults.Select(element => element.Text).ToList();
        }

        public string SearchResultErrorMessageTextCheck()
        {
            var searchResultErrorMessageText = Driver.FindElement(By.XPath(SearchResultErrorMessageLocator)).Text;
            return searchResultErrorMessageText;
        }

        protected void SearchBy(Action search)
        {
            var beforeSearchTitleText = Driver.FindElement(By.XPath(SearchResultTitleLocator)).Text;

            search();

            Driver.WaitForCondition(driver =>
            {
                var searchTitleElement = driver.FindElement(By.XPath(SearchResultTitleLocator));
                if (searchTitleElement.Text != beforeSearchTitleText)
                {
                    return true;
                }
                return false;
            }, TimeSpan.FromSeconds(5));
        }
    }
}
