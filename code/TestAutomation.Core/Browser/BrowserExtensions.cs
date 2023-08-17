using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.ObjectModel;
using TestAutomation.Core.Enums;
using TestAutomation.Core.Utilities;

namespace TestAutomation.Core.Browser
{
    public static class BrowserExtensions
    {
        public static string GetUrl(this IWebDriver webDriver)
        {
            return webDriver.Url;
        }

        public static void GotToWebPageUrl(this IWebDriver webDriver, string url)
        {
            webDriver.Navigate().GoToUrl(url);
        }

        public static void ScrollToElement(this IWebDriver webDriver, IWebElement element)
        {            
            Actions actions = webDriver.GetActions();
            actions.ScrollToElement(element).Build().Perform();
        }

        public static void MoveToElement(this IWebDriver webDriver, IWebElement element)
        {
            Actions actions = webDriver.GetActions();
            actions.MoveToElement(element).Build().Perform();
        }
       
        public static void GoBack(this IWebDriver webDriver)
        {
            Logger.Info("Navigate Back");
            webDriver!.Navigate().Back();
        }

        public static void GoForward(this IWebDriver webDriver)
        {
            Logger.Info("Navigate Back");
            webDriver!.Navigate().Forward();
        }

        public static void RefreshPage(this IWebDriver webDriver)
        {
            Logger.Info("Refresh page");
            webDriver.Navigate().Refresh();
        }
        public static void Maximize(this IWebDriver webDriver)
        {
            Logger.Info("Maximize Browser");
            webDriver.Manage().Window.Maximize();
        }
        public static void ScrollTop(this IWebDriver webDriver)
        {
            Actions actions = webDriver.GetActions();
            actions.SendKeys(Keys.Home).Build().Perform();
        }
        public static IWebElement FindTheElement(this IWebDriver webDriver, By locator)
        {
            return webDriver.FindElement(locator);
        }
        public static ReadOnlyCollection<IWebElement> FindTheElements(this IWebDriver webDriver, By by)
        {
            return webDriver!.FindElements(by);
        }
        public static void SetSessionToken(this IWebDriver webDriver, string token)
        {
            var tokenValue = "{\"type\":\"bearer\",\"value\":\"" + token + " \"}";
            ExecuteScript(webDriver, "javascript:localStorage.token=arguments[0];", tokenValue);
        }

        public static object ExecuteScript(this IWebDriver webDriver, string script, params object[] args)
        {
            try
            {
                return ((IJavaScriptExecutor)webDriver!).ExecuteScript(script, args);
            }
            catch (WebDriverTimeoutException e)
            {
                Logger.Info($"Error: Timeout Exception thrown while running JS Script:{e.Message}-{e.StackTrace}");
            }

            return null!;
        }
        public static Actions GetActions(this IWebDriver webDriver)
        {
            return new Actions(webDriver);
        }

        public static void OpenNewTab(this IWebDriver webDriver)
        {
            webDriver.SwitchTo().NewWindow(WindowType.Tab);
        }

        public static void CloseBrowser(this IWebDriver webDriver)
        {
            Logger.Info("Close Browser.");
            webDriver.Close();
        }

        public static void QuitBrowser(this IWebDriver webDriver)
        {
            Logger.Info("Quit Browser.");
            try
            {
                webDriver.Quit();
            }

            catch (Exception ex)
            {
                Logger.Error($"Unable to Quit the browser. Reason: {ex.Message}");
            }
        }

        public static void SwitchToWindow(this IWebDriver webDriver, string windowHandle)
        {
            webDriver.SwitchTo().Window(windowHandle);
        }

    }

}

