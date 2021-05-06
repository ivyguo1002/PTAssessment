using JuniperToys.Framework.DataModel;
using JuniperToys.Framework.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuniperToys.Framework.Config
{
    public class JuniperToysConfig
    {
        public const string BaseUrl = "http://jupiter.cloud.planittesting.com/#";
        // Browser: chrome has some issues with webdriver wait
        public const BrowserType Browser = Enums.BrowserType.chrome;
        public const int CommandTimeOut = 10;
        public const int PageLoadTimeOut = 10;

        public static Dictionary<string, Page> Pages = new Dictionary<string, Page>
        {
            {
                "HomePage", new Page { Path = "", Title = "Jupiter Toys"}
            },
            {
                "ContactPage", new Page{Path = "/contact", Title = "Jupiter Toys"}
            },
            {
                "ShopPage", new Page {Path = "/shop", Title = "Jupiter Toys"}
            },
            {
                "CartPage", new Page {Path = "/cart", Title = "Jupiter Toys"}
            }
        };

    }

   
}
