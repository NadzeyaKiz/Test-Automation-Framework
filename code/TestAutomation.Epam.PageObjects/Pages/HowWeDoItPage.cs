using OpenQA.Selenium;
using TestAutomation.Core.Elements;

namespace TestAutomation.Epam.PageObjects.Pages
{
    public class HowWeDoItPage : BasePage
    {
        public HowWeDoItPage(IWebDriver driver) : base(driver)
        {
            PageUrl = "https://www.epam.com/how-we-do-it";
        }
    }
}
