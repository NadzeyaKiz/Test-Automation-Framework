using OpenQA.Selenium;
using TestAutomation.Core.Browser;

namespace TestAutomation.Core.Elements
{
    public abstract class BasePage
    {
        public IWebDriver Driver { get; protected set; }
        public static string PageUrl { get; protected set; }
        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }
        public bool IsOpened() => GetPageUrl().Equals(PageUrl);

        public string GetPageUrl() => Driver.GetUrl();

        public string GetPageTitle() => Driver.Title;
    }
}
