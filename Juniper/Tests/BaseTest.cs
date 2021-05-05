using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuniperToys.Tests
{
    public class BaseTest
    {
        public IWebDriver Driver { get; set; }

        [SetUp]
        public void BeforeTest()
        {
            Driver = Framework.Driver.WebDriverFactory.Build(Framework.Config.JuniperToysConfig.Browser);
            Driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void AfterTest()
        {
            Driver.Quit();
        }

    }
}
