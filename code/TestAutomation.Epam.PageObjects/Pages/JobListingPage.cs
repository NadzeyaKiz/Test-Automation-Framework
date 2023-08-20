using OpenQA.Selenium;
using TestAutomation.Core.Elements;



namespace TestAutomation.Epam.PageObjects.Pages
{
    public class JobListingPage : BasePage
    {
        static JobListingPage()
        {
            PageUrl = "https://www.epam.com/careers/job-listings";
        }

        public JobListingPage(IWebDriver driver) : base(driver)
        {
        }
    }
}
