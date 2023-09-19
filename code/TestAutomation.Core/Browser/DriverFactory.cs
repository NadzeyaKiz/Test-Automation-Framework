using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Safari;
using System.Drawing;
using TestAutomation.Core.Enums;
using TestAutomation.Core.Utilities;
using TestAutomation.Utilities;

namespace TestAutomation.Core.Browser
{
    public static class DriverFactory
    {
        private static Dictionary<BrowserType, IWebDriver> DriverDictionary = new Dictionary<BrowserType, IWebDriver>();

        public static IWebDriver GetWebBrowser(BrowserType type, bool isSingleton=false)
        {
            IWebDriver driver;
            if (isSingleton && DriverDictionary.TryGetValue(type, out driver))
            {
                return driver;
            }

            Logger.Info($"Creating browser {type}");
            try
            {
                switch (type)
                {
                    case BrowserType.Chrome:
                        driver =  GetChromeConfiguredBrowser();
                        break;
                    case BrowserType.Safari:
                        driver = GetSafariConfiguredBrowser();
                        break;
                    case BrowserType.Firefox:
                        driver = GetFirefoxConfiguredBrowser();
                        break;
                    case BrowserType.Edge:
                        driver = GetEdgeConfiguredBrowser();
                        break;
                    default:
                        driver = GetChromeConfiguredBrowser();
                        break;
                }
                if (isSingleton)
                {
                    DriverDictionary[type] = driver;
                }
                return driver;
            }
            catch (Exception ex)
            {
                // todo: add logger later MyLogger.Error($"Failed to create browser instance, {ex.Message}");
                throw new Exception("Failed to create browser instance.", ex);
            }
        }

        private static IWebDriver GetChromeConfiguredBrowser()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--start-maximized");
            
            //chromeOptions.AddArgument("Headless");
            chromeOptions.AddArgument("window-size=1920,1080");
            var service = ChromeDriverService.CreateDefaultService();
            var chromeDriver = new ChromeDriver(service, chromeOptions, TimeSpan.FromMinutes(2));
            
            //chromeDriver.Manage().Window.Maximize();
            //chromeDriver.Manage().Window.Size = new Size(1280, 720);
            return chromeDriver;
        }

        private static IWebDriver GetSafariConfiguredBrowser()
        {
            var safariBrowser = new SafariDriver();
            safariBrowser.Manage().Window.Maximize();
            return safariBrowser;
        }

        private static IWebDriver GetFirefoxConfiguredBrowser()
        {
            var firefoxBrowser = new FirefoxDriver();
            firefoxBrowser.Manage().Window.Maximize();
            return firefoxBrowser;
        }
        private static IWebDriver GetEdgeConfiguredBrowser()
        {
            var firefoxBrowser = new EdgeDriver();
            firefoxBrowser.Manage().Window.Maximize();
            return firefoxBrowser;
        }
    }

}

