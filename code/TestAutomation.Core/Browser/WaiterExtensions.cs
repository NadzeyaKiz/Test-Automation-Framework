using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation.Core.Browser
{
    public static class WaiterExtensions
    {
        public static TimeSpan DefaultTimeout = TimeSpan.FromMilliseconds(15000);
        public static TimeSpan DefaultSleepTimeout = TimeSpan.FromMilliseconds(1000);

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
            WaitForElementToBeVisible(driver, element, DefaultTimeout);
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
    }
}
