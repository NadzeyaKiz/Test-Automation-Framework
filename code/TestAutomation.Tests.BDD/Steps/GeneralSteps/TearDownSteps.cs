using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TestAutomation.Core.Browser;
using TestAutomation.Epam.PageObjects.Pages;
using TestAutomation.Utilities;

namespace TestAutomation.Tests.BDD.Steps.GeneralSteps
{
    [Binding]
    public class TearDownSteps
    {
        [AfterScenario (Order = 1)]
        public static void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                Utilities.Logger.Info("Test is faild");
                ScreenShotTaker.InitScreenShotTaker();
            }
            Utilities.Logger.Info("Test finished");
            var driver = DriverFactory.GetWebBrowser(UiTestSettings.Browser, true);
            WebDriverExtensions.QuitBrowser(driver);
        }
    }
}
