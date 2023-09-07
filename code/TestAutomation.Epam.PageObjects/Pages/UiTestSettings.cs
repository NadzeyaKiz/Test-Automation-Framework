using NUnit.Framework;
using TestAutomation.Core.Enums;

namespace TestAutomation.Epam.PageObjects.Pages
{
    public class UiTestSettings
    {
        public static BrowserType Browser { get; protected set; }

        public static string ApplicationUrl { get; protected set; }

        public static bool RunHeadless { get; protected set; }
        public static void Init()
        {
            var value = TestContext.Parameters["Browser"];
            var browser = EnumUtils.ParseEnum<BrowserType>(value);
            Browser = browser;
            ApplicationUrl = TestContext.Parameters["ApplicationUrl"];

            bool runHeadless;
            if (bool.TryParse(TestContext.Parameters["RunHeadless"], out runHeadless))
            {
                RunHeadless = runHeadless;
            }
        }
        
    }
}
