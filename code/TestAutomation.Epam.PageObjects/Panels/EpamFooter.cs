using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation.Epam.PageObjects.Panels
{
    public class EpamFooter
    {
        public static string footerPanelLocator = "//*[@class='footer-ui']";
        public static string investorsLinkLocator = "//*[@href='/about/investors']";
        public static string openSourceLinkLocator = "//*[@href='/open-source']";
        public static string privacyPolicyLinkLocator = "//*[@href='/privacy-policy']";
        public static string cookiePolicyLinkLocator = "//*[@href='/cookie-policy']";
        public static string InstagramLinkLocator = "//*[@class='footer__social-link' and @href='https://www.instagram.com/epamsystems/']";
    }
}
