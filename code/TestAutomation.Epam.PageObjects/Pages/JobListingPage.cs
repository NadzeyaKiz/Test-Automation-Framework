using OpenQA.Selenium;
using TestAutomation.Core.Elements;

namespace TestAutomation.Epam.PageObjects.Pages
{
    public class JobListingPage : BasePage
    {
        public JobListingPage(IWebDriver driver) : base(driver)
        {
            PageUrl = "https://www.epam.com/careers/job-listings";
        }
    }
}
