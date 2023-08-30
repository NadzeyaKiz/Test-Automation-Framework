using OpenQA.Selenium;
using Serilog;
using System.IO.Enumeration;

namespace TestAutomation.Utilities
{
    public class ScreenShotTaker
    {
        public static string FolderPath { get; private set; }

        public static void InitScreenShotTaker(string folderPath = null)
        {
            FolderPath = folderPath;
            if (FolderPath == null)
            {
                FolderPath = Path.Combine(Path.GetDirectoryName(Environment.CurrentDirectory), "screenshots");
            }

            Directory.CreateDirectory(FolderPath);
        }

        public static void CaptureScreenshot(IWebDriver driver, string testName)
        {
            ITakesScreenshot? screenshotDriver = driver as ITakesScreenshot;
            if (screenshotDriver == null)
            {
                throw new Exception("Driver does not support interface to capture screenshots");
            }

            var path = GetScreenshotFilePath(testName);
            screenshotDriver
                .GetScreenshot()
                .SaveAsFile(path, ScreenshotImageFormat.Png);
        }

        public static void CaptureElementScreenshot(IWebElement element, string testName)
        {
            if (!element.Displayed)
            {
                throw new Exception($"Element {element.TagName} is not visible. Screenshot can not be taken");
            }

            ITakesScreenshot? screenshotTaker = element as ITakesScreenshot;
            if (screenshotTaker == null)
            {
                throw new Exception("Driver does not support interface to capture screenshots");
            }

            var path = GetScreenshotFilePath(testName);
            screenshotTaker
                .GetScreenshot()
                .SaveAsFile(path, ScreenshotImageFormat.Png);
        }

        internal static string GetScreenshotFilePath(string testName)
        {
            var fileName = string.Concat(testName.Split(Path.GetInvalidFileNameChars()));
            string screenFileName = $"{fileName}_{DateTime.Now:ddMM_HHmmss}.png";
            return Path.Combine(FolderPath, screenFileName);
        }
    }
}