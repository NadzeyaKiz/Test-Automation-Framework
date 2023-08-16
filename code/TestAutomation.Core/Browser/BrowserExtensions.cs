using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace TestAutomation.Core.Browser
{
    public static class BrowserExtensions
    {
        public static string GetUrl(this IWebDriver webDriver)
        {
            return webDriver.Url;
        }

        public static void ScrollToElement(this IWebDriver webDriver, IWebElement element)
        {
            Actions actions = new Actions(webDriver);
            actions.ScrollToElement(element);
            actions.Build().Perform();
        }

        public static void MoveToElement(this IWebDriver webDriver, IWebElement element)
        {
            Actions actions = new Actions(webDriver);
            actions.MoveToElement(element);
            actions.Build().Perform();
        }
    }

}

