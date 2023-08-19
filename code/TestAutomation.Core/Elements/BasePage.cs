using OpenQA.Selenium;
using TestAutomation.Core.Browser;

namespace TestAutomation.Core.Elements
{
    public abstract class BasePage
    {
        public IWebDriver Driver { get; protected set; }
        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }
        public abstract bool IsOpened();

        public string GetPageUrl() => Driver.GetUrl();

        public string GetPageTitle() => Driver.Title;
    }
}
