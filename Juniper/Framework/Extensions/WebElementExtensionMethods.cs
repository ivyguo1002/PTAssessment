using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuniperToys.Framework.Extensions
{
    public static class WebElementExtensionMethods
    {
        public static void WaitForHidden(this IWebElement element, IWebDriver driver, int timeout = Config.JuniperToysConfig.PageLoadTimeOut)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                wait.Until(driver => element.GetCssValue("display").Equals("none"));

            }
            catch (WebDriverTimeoutException)
            {
                throw new WebDriverTimeoutException($"Exception in WaitForHidden:  the element not hidden within {timeout} seconds.");
            }
        }

        public static void WaitForDisplayed(this IWebElement element, IWebDriver driver, int timeout = Config.JuniperToysConfig.PageLoadTimeOut)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                wait.Until(d => element.Displayed);
            }
            catch (WebDriverTimeoutException)
            {
                throw new WebDriverException($"Wait for element {element}  to be displayed failed");
            }
        }
    }

}
