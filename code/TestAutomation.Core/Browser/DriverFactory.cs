using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using System.Drawing;
using TestAutomation.Core.Enums;
using TestAutomation.Core.Utilities;
using TestAutomation.Utilities;

namespace TestAutomation.Core.Browser
{
    public static class DriverFactory
    {
        public static IWebDriver GetWebBrowser(BrowserType type)
        {
            Logger.Info($"Creating browser {type}");
            try
            {
                switch (type)
                {
                    case BrowserType.Chrome:
                        return GetChromeConfiguredBrowser();
                    case BrowserType.Safari:
                        return GetSafariConfiguredBrowser();
                    case BrowserType.Firefox:
                        return GetFirefoxConfiguredBrowser();
                    case BrowserType.Edge:
                        return GetEdgeConfiguredBrowser();
                    default:
                        return GetChromeConfiguredBrowser();
                }
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
            var service = ChromeDriverService.CreateDefaultService();
            var chromeDriver = new ChromeDriver(service, chromeOptions, TimeSpan.FromMinutes(2));
            //chromeDriver.Manage().Window.Maximize();
            chromeDriver.Manage().Window.Size = new Size(1280, 720);
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

