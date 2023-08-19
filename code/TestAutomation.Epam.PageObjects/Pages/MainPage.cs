using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomation.Core.Browser;
using TestAutomation.Core.Elements;

namespace TestAutomation.Epam.PageObjects.Pages
{
    public class MainPage : BasePage
    {
        public MainPage(IWebDriver driver) : base(driver)
        {
        }

        public override bool IsOpened() => GetPageUrl().Equals(UiTestSettings.ApplicationUrl);
    }
}
