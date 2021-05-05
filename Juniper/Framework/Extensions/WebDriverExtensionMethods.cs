using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuniperToys.Framework.Extensions
{
    public static class WebDriverExtensionMethods
    {
        public static void WaitForPageLoaded(this IWebDriver driver,string path, string title, int timeout = Config.JuniperToysConfig.PageLoadTimeOut)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                wait.Until(driver => driver.Title.Contains(title, StringComparison.OrdinalIgnoreCase) && driver.Url.Contains(path, StringComparison.OrdinalIgnoreCase));

            }
            catch (WebDriverTimeoutException)
            {
                throw new WebDriverTimeoutException($"Exception in WaitForPageLoad:  the page path {title} not updated within {timeout} seconds.");
            }
        }
        public static IWebElement WaitForElement(this IWebDriver driver, By by, int timeOutInSeconds = Config.JuniperToysConfig.CommandTimeOut)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                return wait.Until(driver => driver.FindElement(by));
            }
            catch (WebDriverTimeoutException)
            {
                throw new WebDriverTimeoutException($"Find Element Failed By locator {by} in {timeOutInSeconds}");
            }

        }

        public static IList<IWebElement> WaitForElements(this IWebDriver driver, By by, int timeOutInSeconds = Config.JuniperToysConfig.CommandTimeOut)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                return wait.Until(driver => driver.FindElements(by));
            }
            catch (WebDriverTimeoutException)
            {
                throw new WebDriverTimeoutException($"Find Elements Failed By locator {by} in {timeOutInSeconds}");
            }

        }
    }
}
