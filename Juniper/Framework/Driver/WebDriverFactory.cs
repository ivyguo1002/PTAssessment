using JuniperToys.Framework.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Text;

namespace JuniperToys.Framework.Driver
{
    public class WebDriverFactory
    {
        public static IWebDriver Build(BrowserType type)
        {
            switch (type)
            {
                case BrowserType.firefox:
                    var profile = new FirefoxProfile();
                    profile.SetPreference("intl.accept_languages", "en,en-US");
                    var firefoxOptions = new FirefoxOptions();
                    firefoxOptions.Profile = profile;
                    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                    return new FirefoxDriver(firefoxOptions);
                case BrowserType.chrome:
                    return new ChromeDriver();
                default:
                    throw new ArgumentOutOfRangeException("The specified browser type is out of range");
            }
        }
    }
}
