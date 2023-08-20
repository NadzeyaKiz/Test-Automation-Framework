using OpenQA.Selenium;
using TestAutomation.Core.Elements;
using TestAutomation.Core.Browser;

public class SearchPage : BasePage
{
    static SearchPage()
    {
        PageUrl = "https://www.epam.com/search";
    }

    public SearchPage(IWebDriver driver) : base(driver)
    {
    }

    public List<string> GetSearchItemList()
    {
        Driver.WaitForCondition(driver =>
        {
            var listOfArticles = driver.FindElements(By.XPath("//article"));
            driver.ScrollToElement(listOfArticles[listOfArticles.Count - 1]);
            var searchViewMoreLink = driver.FindElements(By.XPath("//a[@class='search-results__view-more button-text']"));

            if (searchViewMoreLink.Count == 1)
            {
                driver.ScrollToElement(searchViewMoreLink[0]);
            }
            return searchViewMoreLink.Count == 1;
        });
        return Driver.FindElements(By.XPath("//article"))
            .Select(x => x.Text)
            .ToList();  
    }
}