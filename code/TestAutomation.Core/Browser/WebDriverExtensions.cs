using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using TestAutomation.Core.Elements;
using TestAutomation.Utilities;

namespace TestAutomation.Core.Browser
{
    public static class WebDriverExtensions
    {
        public static TimeSpan DefaultTimeout = TimeSpan.FromMilliseconds(15000);
        public static TimeSpan DefaultSleepTimeout = TimeSpan.FromMilliseconds(1000);
        public static string GetUrl(this IWebDriver webDriver)
        {
            return webDriver.Url;
        }

        public static IWebDriver GotToWebPageUrl(this IWebDriver webDriver, string url)
        {
            webDriver.Navigate().GoToUrl(url);
            return webDriver;
        }

        public static void ScrollToElement(this IWebDriver webDriver, IWebElement element)
        {            
            Actions actions = webDriver.GetActions();
            actions.ScrollToElement(element).Build().Perform();
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

        public static void ClickWithFindElement(this IWebDriver driver, By by)
        {
            FindElementWithElementTobeVisible(driver, by).Click();
        }

        public static void SendKeysWithFindElement(this IWebDriver driver, By by, string text)
        {
            FindElementWithElementTobeVisible(driver, by).SendKeys(text);
        }

        public static void ClickWithWaitForDisplay(this IWebDriver driver, IWebElement element)
        {
            driver.WaitForElementToBeVisible(element).Click();
        }

        public static IWebElement FindTheElement(this IWebDriver driver, By locator)
        {
            return driver.FindElement(locator);
        }

        public static IWebElement FindElementWithElementTobeVisible(this IWebDriver driver, By by)
        {
            var element = driver.FindTheElement(by);
            if (element == null)
            {
                throw new Exception($"Element {by.ToString()} has not been found");
            }
            if (!element.Displayed)
            {
                Logger.Info($"Element {by.ToString()} is not displayed. Waiting to be displayed to become clickable");
                driver.WaitForElementToBeVisible(element);
            }
            return element;
        }
       

        public static void MoveToElement(this IWebDriver webDriver, IWebElement element)
        {
            Actions actions = webDriver.GetActions();
            actions.MoveToElement(element).Build().Perform();
        }

        public static IWebDriver MoveToElement(this IWebDriver driver, By by)
        {
            var element = driver.FindTheElement(by);
            if (element == null)
            {
                throw new Exception($"Element {by.ToString()} has not been found");
            }
            Actions actions = driver.GetActions();
            actions.MoveToElement(element).Build().Perform();
            return driver;
        }

        public static void ClickUsingJSWithFind(this IWebDriver driver, By by)
        {

            var element = driver.FindTheElement(by);
            if (element == null)
            {
                throw new Exception($"Element {by.ToString()} has not been found");
            }
            if (!element.Displayed)
            {
                Logger.Info($"Element {by.ToString()} is not displayed. Waiting to be displayed to become clickable");
                driver.WaitForElementToBeVisible(element);
            }
            element.ClickUsingJS(driver);
        }


        #region Waiters
        public static void WaitForCondition(this IWebDriver driver, Func<IWebDriver, bool> condition, TimeSpan timeout)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeout);
            wait.PollingInterval = DefaultSleepTimeout;
            wait.Until(condition);
        }

        public static void WaitForCondition(this IWebDriver driver, Func<IWebDriver, bool> condition)
        {
            WaitForCondition(driver, condition, DefaultTimeout);
        }

        public static void WaitForElementToBeVisible(this IWebDriver driver, IWebElement element, TimeSpan timeout)
        {
            WaitForCondition(driver, d => element.Displayed, timeout);
        }

        public static IWebElement WaitForElementToBeVisible(this IWebDriver driver, IWebElement element)
        {
            WaitForElementToBeVisible(driver, element, DefaultSleepTimeout);
            return element;
        }

        public static void WaitForElementToBeClickable(this IWebDriver driver, IWebElement element, TimeSpan timeout)
        {
            WaitForCondition(driver, d => element.Enabled && element.Displayed, timeout);
        }

        public static void WaitForElementToBePresent(this IWebDriver driver, By locator, TimeSpan timeout)
        {
            WaitForCondition(driver, d => d.FindElements(locator).Count > 0, timeout);
        }
        #endregion

    }

}

