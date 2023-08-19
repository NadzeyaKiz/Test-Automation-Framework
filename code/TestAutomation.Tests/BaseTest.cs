using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using TestAutomation.Core.Utilities;


namespace TestAutomation.Tests
{
    public class BaseTest
    {
        protected IWebDriver _driver { get; set; }

        [OneTimeSetUp]
        public void InitSetUp() 
        {
            Core.Utilities.Logger.InitLogger("Browser");
            ScreenShotTaker.InitScreenShotTaker();
        }       

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed)
            {
                // Test failed, capture screenshot
                ScreenShotTaker.CaptureScreenshot(_driver, $"success_{ TestContext.CurrentContext.Test.Name}");                
            }
            else if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                // Test failed, capture screenshot
                ScreenShotTaker.CaptureScreenshot(_driver, $"failed_{TestContext.CurrentContext.Test.Name}");
            }

            _driver.Close();
            _driver.Quit();
        }
    }
}