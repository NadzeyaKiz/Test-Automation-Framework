using OpenQA.Selenium;
using TestAutomation.Core.Elements;
using TestAutomation.Core.Browser;

public class SearchPage : BasePage
{
    public static string searchResultArticlesLocator = "//article";
    public static string viewMoreButtonLocator = "//a[@class='search-results__view-more button-text']";
    public static string searchResultTitlesLinkLocator= "//div[@class='search-results__items']/article//a";
    public static string searchResultItemsLocator = "//*[@class='search-results__item']";


    public SearchPage(IWebDriver driver) : base(driver)
    {
        PageUrl = "https://www.epam.com/search";
    }

    public List<string> GetSearchItemList()
    {
        Driver.WaitForCondition(driver =>
        {
            var listOfArticles = driver.FindElements(By.XPath(searchResultArticlesLocator));
            driver.ScrollToElement(listOfArticles[listOfArticles.Count - 1]);
            var searchViewMoreLink = driver.FindElements(By.XPath(viewMoreButtonLocator));

            if (searchViewMoreLink.Count == 1)
            {
                driver.ScrollToElement(searchViewMoreLink[0]);
            }
            return searchViewMoreLink.Count == 1;
        });
        return Driver.FindElements(By.XPath(searchResultArticlesLocator))
            .Select(x => x.Text)
            .ToList();  
    }
    public List<string> GetCollectionArticlesOnSearchPage()
    {      
        return Driver.FindElements(By.XPath(searchResultTitlesLinkLocator))
            .Select(x => x.Text)
            .ToList();
    }

    public List<IWebElement> GetWebElementsCollectionOnSearchPage()
    {
        IReadOnlyCollection<IWebElement> elements = Driver.FindElements(By.XPath(searchResultTitlesLinkLocator));
        return elements.ToList();
    }

    public List<string> GetCollectionArticlesDescriptionOnSearchPage()
    {
        return Driver.FindElements(By.XPath(searchResultItemsLocator))
            .Select(x => x.Text)
            .ToList();
    }

}