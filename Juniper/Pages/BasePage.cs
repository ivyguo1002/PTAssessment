using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using JuniperToys.Framework.Extensions;
using JuniperToys.Framework.DataModel;

namespace JuniperToys.Pages
{
    public class BasePage
    {
        public IWebDriver Driver { get; set; }
        public virtual Page Page { get; set; }
        public string BaseUrl => Framework.Config.JuniperToysConfig.BaseUrl;
        private IWebElement AlertError => Driver.WaitForElement(By.CssSelector(".alert-error"));
        private IWebElement AlertMessage => Driver.WaitForElement(By.CssSelector(".alert"));

        public IWebElement PopUpModal => Driver.WaitForElement(By.CssSelector(".popup.modal"));
        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }
        public void Open()
        {
            Driver.Navigate().GoToUrl(BaseUrl + Page.Path);
        }

        public bool IsLoaded()
        {
            try
            {
                Driver.WaitForPageLoaded(Page.Path, Page.Title);
                return true;
            }
            catch (Exception)
            {
                return false; 
            }
           
        }
        public string GetAlertError()
        {
            return AlertError.Text;
        }

        public string GetAlertMessage()
        {
            return AlertMessage.Text;
        }
    }
}
