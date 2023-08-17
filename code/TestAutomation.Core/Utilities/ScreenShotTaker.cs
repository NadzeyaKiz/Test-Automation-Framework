using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation.Core.Utilities
{
    internal class ScreenShotTaker
    {
        internal static void TakeScreenshot(IWebDriver driver, string testName, string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string screenFileName = $"{testName}_{DateTime.Now:ddMM_HHmmss}.png";
            string screenPath = Path.Combine(folderPath, screenFileName);           
        }

        public static void CaptureScreenshot(IWebDriver driver, string screenshotFilePath)
        {
            ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
            if (screenshotDriver != null)
            {
                Screenshot screenshot = screenshotDriver.GetScreenshot();
                screenshot.SaveAsFile(screenshotFilePath, ScreenshotImageFormat.Png);
            }
        }

        public static void CaptureElementScreenshot(IWebElement element, string screenshotFilePath)
        {
            if (element.Displayed)
            {
                Screenshot screenshot = ((ITakesScreenshot)element).GetScreenshot();
                screenshot.SaveAsFile(screenshotFilePath, ScreenshotImageFormat.Png);
            }
        }

    }
}