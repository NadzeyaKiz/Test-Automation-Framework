using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TestAutomation.Core.Browser;
using TestAutomation.Epam.PageObjects.Pages;
using TestAutomation.Utilities;

namespace TestAutomation.Tests.BDD.Steps
{
    public class BaseStep
    {
        protected IWebDriver Driver { get; set; }
        public BaseStep()
        {
            Driver = DriverFactory.GetWebBrowser(UiTestSettings.Browser, true);
        }
    }
}
