using OpenQA.Selenium;
using TestAutomation.Core.Browser;
namespace TestAutomation.Core.Utilities
{
    public static class WebDriverCookiesExtensions
    {
        public static void SetUpCookies(this IWebDriver driver, By locator)
        {
            driver.WaitForCondition(d =>
            {
                var cookiesAcceptButtons = d.FindElements(locator);
                if (cookiesAcceptButtons.Count == 1)
                {
                    if (cookiesAcceptButtons[0].Displayed)
                    {
                        cookiesAcceptButtons[0].Click();
                    }

                    return cookiesAcceptButtons[0].Displayed == false;
                }
                return false;
            });
        }
    }
}
