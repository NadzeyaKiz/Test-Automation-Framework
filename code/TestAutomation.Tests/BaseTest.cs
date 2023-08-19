using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using TestAutomation.Core.Browser;
using TestAutomation.Core.Enums;
using TestAutomation.Core.Utilities;
using TestAutomation.Epam.PageObjects.Pages;
using TestAutomation.Utilities;
namespace TestAutomation.Tests
{
    public abstract class BaseTest
    {
        protected IWebDriver _driver { get; set; }

        [OneTimeSetUp]
        public void InitSetUp() 
        {
            UiTestSettings.Init();
            Logger.InitLogger("Browser");
            ScreenShotTaker.InitScreenShotTaker();
        }

        [SetUp]
        public virtual void InternalBrowserSetup()
        {
            _driver = DriverFactory.GetWebBrowser(UiTestSettings.Browser).GotToWebPageUrl(UiTestSettings.ApplicationUrl);
            BrowserSetup(_driver);
        }

        public abstract void BrowserSetup(IWebDriver driver);

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed)
            {
                Logger.Info($"Test '{TestContext.CurrentContext.Test.Name}' has passed.");
                ScreenShotTaker.CaptureScreenshot(_driver, $"success_{ TestContext.CurrentContext.Test.Name}");                
            }
            else if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                Logger.Info($"Test '{TestContext.CurrentContext.Test.Name}' has failed.");
                ScreenShotTaker.CaptureScreenshot(_driver, $"failed_{TestContext.CurrentContext.Test.Name}");
            }

            _driver.CloseBrowser();
            _driver.QuitBrowser();
        }
    }
}