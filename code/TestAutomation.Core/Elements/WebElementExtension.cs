using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.ObjectModel;

namespace TestAutomation.Core.Elements
{
    public static class WebElementExtensions
    {
        public static string GetText(this IWebElement element)
        {
            return element.Text.Trim();
        }

        public static string GetTextFromAttribute(this IWebElement element, string attributeName)
        {
            return element.GetAttribute(attributeName);
        }

        public static void Click(this IWebElement element)
        {
            element.Click();
        }

        public static void SendKeys(this IWebElement element, string text)
        {
            element.SendKeys(text);
        }

        public static void ClearField(this IWebElement element)
        {
            element.Clear();
        }

        public static bool IsElementDisplayedOnPage(this IWebElement element)
        {
            return element.Displayed;
        }

        public static bool IsElementEnabled(this IWebElement element)
        {
            return element.Enabled;
        }

        public static IWebElement FindTheElement(this IWebDriver driver, By locator)
        {
            return driver.FindElement(locator);
        }

        public static ReadOnlyCollection<IWebElement> FindTheElements(this IWebDriver driver, By locator)
        {
            return driver.FindElements(locator);
        }

        public static void ClickUsingJS(this IWebElement element, IWebDriver driver)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", element);
        }

        public static void DragAndDrop(this IWebElement sourceElement, IWebElement targetElement, IWebDriver driver)
        {
            var actions = new Actions(driver);
            actions.DragAndDrop(sourceElement, targetElement).Build().Perform();
        }

        public static void DoubleClick(this IWebElement element, IWebDriver driver)
        {
            var actions = new Actions(driver);
            actions.DoubleClick(element).Build().Perform();
        }
    }
}
