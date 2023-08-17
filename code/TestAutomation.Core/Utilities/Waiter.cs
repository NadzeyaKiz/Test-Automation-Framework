using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation.Core.Utilities
{
    public static class Waiter
    {
        public static void WaitForCondition(IWebDriver driver, Func<IWebDriver, bool> condition, TimeSpan timeout)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeout);
            wait.Until(condition);
        }

        public static void WaitForElementToBeVisible(IWebDriver driver, IWebElement element, TimeSpan timeout)
        {
            WaitForCondition(driver, d => element.Displayed, timeout);
        }

        public static void WaitForElementToBeClickable(IWebDriver driver, IWebElement element, TimeSpan timeout)
        {
            WaitForCondition(driver, d => element.Enabled && element.Displayed, timeout);
        }

        public static void WaitForElementToBePresent(IWebDriver driver, By locator, TimeSpan timeout)
        {
            WaitForCondition(driver, d => d.FindElements(locator).Count > 0, timeout);
        }
    }
}
