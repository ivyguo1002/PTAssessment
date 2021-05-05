using JuniperToys.Framework.DataModel;
using JuniperToys.Framework.Extensions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace JuniperToys.Pages
{
    public class CartPage : BasePage
    {
        public override Page Page => Framework.Config.JuniperToysConfig.Pages["CartPage"];
        private IList<IWebElement> ItemRows => Driver.WaitForElements(By.CssSelector("table.cart-items>tbody>tr"));

        public CartPage(IWebDriver driver) : base(driver)
        {
        }

        public bool VerifyItemsInCarts(List<ShopItem> items)
        {
            if (ItemRows.Count != items.Count)
            {
                return false;
            }
            else
            {
                int i;
                for (i = 0; i < ItemRows.Count; i ++)
                {
                    var itemTds = ItemRows[i].FindElements(By.TagName("td"));
                    
                    if (itemTds[0].Text == items[i].ItemName &&
                        Convert.ToInt32(itemTds[2].FindElement(By.TagName("input")).GetAttribute("value")) == items[i].ItemQuatity)
                    {
                        continue;
                    }
                }

                if (i == ItemRows.Count)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}