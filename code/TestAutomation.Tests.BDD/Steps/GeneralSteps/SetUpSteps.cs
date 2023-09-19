using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TestAutomation.Core.Browser;
using TestAutomation.Epam.PageObjects.Pages;
using TestAutomation.Utilities;

namespace TestAutomation.Tests.BDD.Steps.GeneralSteps
{
    [Binding]
    public class SetUpSteps
    {
        [BeforeFeature(Order = 1)]
        public static void SetUpLogger()
        {
            UiTestSettings.Init();
            Utilities.Logger.InitLogger("BDDLogger");
            ScreenShotTaker.InitScreenShotTaker();            
        }

        [BeforeScenario(Order = 1)]
        public static void SetUp()
        {
            DriverFactory.GetWebBrowser(UiTestSettings.Browser, true);
        }
    }
}
