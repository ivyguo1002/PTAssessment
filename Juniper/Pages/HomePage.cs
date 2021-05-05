using JuniperToys.Framework.DataModel;
using JuniperToys.Framework.Extensions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuniperToys.Pages
{
    public class HomePage : BasePage
    {
        public override Page Page => Framework.Config.JuniperToysConfig.Pages["HomePage"];
        private IWebElement ContactLink => Driver.WaitForElement(By.Id("nav-contact"));
        private IWebElement ShopLink => Driver.WaitForElement(By.Id("nav-shop"));

        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public ContactPage GoToContactPage()
        {
            ContactLink.Click();
            return new ContactPage(Driver);
        }

        public ShopPage GoToShopPage()
        {
            ShopLink.Click();
            return new ShopPage(Driver);
        }
    }
}
