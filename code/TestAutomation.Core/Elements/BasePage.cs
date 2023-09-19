using OpenQA.Selenium;
using TestAutomation.Core.Browser;

namespace TestAutomation.Core.Elements
{
    public abstract class BasePage
    {
        public IWebDriver Driver { get; protected set; }
        public string PageUrl { get; protected set; }

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }
        public bool IsOpened() => GetPageUrl().Equals(PageUrl);

        public string GetPageUrl() => Driver.GetUrl();

        public string GetPageTitle() => Driver.Title;
        //public void NavigateToPage() => Driver.Navigate().GoToUrl(PageUrl);
        public BasePage NavigateToPage()
        {
            Driver.Navigate().GoToUrl(PageUrl);
            return this;
        }
        public BasePage NavigateBackPage()
        {
            Driver.GoBack();
            return this;
        }
        public BasePage Refresh()
        {
            Driver.RefreshPage();
            return this;
        }

    }
}
