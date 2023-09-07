using TechTalk.SpecFlow;
using TestAutomation.Epam.PageObjects.Pages;

namespace TestAutomation.Tests.BDD.Steps.ElementSteps
{
    [Binding]
    public class CookieBannerSteps : BaseStep
    {
        protected MainPage MainPage { get; set; }

        public CookieBannerSteps()
        {
            MainPage = new MainPage(Driver);
        }

        [Given(@"I accept all cookies on Epam site")]
        public void GivenIAcceptAllCookiesOnEpamSite()
        {
            MainPage.AcceptCoockies();
        }        
    }
}
