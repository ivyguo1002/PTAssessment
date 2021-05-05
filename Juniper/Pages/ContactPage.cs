using JuniperToys.Framework.DataModel;
using JuniperToys.Framework.Extensions;
using OpenQA.Selenium;
using System;

namespace JuniperToys.Pages
{
    public class ContactPage : BasePage
    {
        public override Page Page => Framework.Config.JuniperToysConfig.Pages["ContactPage"];
        private IWebElement SubmitBtn => Driver.WaitForElement(By.CssSelector(".btn-contact"));
        private IWebElement ForeNameTextBox => Driver.WaitForElement(By.Id("forename"));
        private IWebElement EmailTextBox => Driver.WaitForElement(By.Id("email"));
        private IWebElement MessageTextArea => Driver.WaitForElement(By.Id("message"));
        public IWebElement ForenameError => Driver.WaitForElement(By.Id("forename-err"));
        public IWebElement EmailError => Driver.WaitForElement(By.Id("email-err"));
        public IWebElement MessageError => Driver.WaitForElement(By.Id("message-err"));

        public ContactPage(IWebDriver driver) : base(driver)
        {
        }

        public void SubmitContact()
        {
            SubmitBtn.Click();
        }

        public void FillContactForm(Contact contact)
        {
            ForeNameTextBox.SendKeys(contact.ForeName);
            EmailTextBox.SendKeys(contact.Email);
            MessageTextArea.SendKeys(contact.Message);
        }
    }
}