using JuniperToys.Framework.DataModel;
using JuniperToys.Framework.Extensions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace JuniperToys.Pages
{
    public class ShopPage : BasePage
    {

        public override Page Page => Framework.Config.JuniperToysConfig.Pages["ShopPage"];
        private IWebElement CartLink => Driver.WaitForElement(By.Id("nav-cart"));
        private IList<IWebElement> Products => Driver.WaitForElements(By.CssSelector("li.product div"));
        public ShopPage(IWebDriver driver) : base(driver)
        {
        }
        public IWebElement BuyBtn(string itemName) => Driver.WaitForElement(By.XPath($"//h4[contains(., '{itemName}')]//following::a[contains(@class, 'btn') and contains(., 'Buy')]"));

        public CartPage GoToCart()
        {
            CartLink.Click();
            return new CartPage(Driver);
        }

        public void WaitForProductLoaded()
        {
            foreach (var product in Products)
            {
                product.WaitForDisplayed(Driver);
            }
        }
    }
}