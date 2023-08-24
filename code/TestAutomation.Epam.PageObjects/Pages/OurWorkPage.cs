using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomation.Core.Elements;

namespace TestAutomation.Epam.PageObjects.Pages
{
    public class OurWorkPage : BasePage
    {
        public OurWorkPage(IWebDriver driver) : base(driver)
        {
            PageUrl = "https://www.epam.com/our-work";
        }
    }
}
