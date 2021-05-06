using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using JuniperToys.Pages;
using JuniperToys.Framework.DataModel;
using OpenQA.Selenium;
using JuniperToys.Framework.Extensions;
using System.Threading;

namespace JuniperToys.Tests
{
    [TestFixture]
    public class TestCases : BaseTest
    {

        [Test]
        [TestCase("We welcome your feedback - but we won't get it unless you complete the form correctly.", 
            "John", "jH@gmail.com", "Some suggestions", "Forename is required", "Email is required", "Message is required")]
        /* 1. From the home page go to contact page
         * 2. Click submit button
         * 3. Validate errors
         * 4. Populate mandatory fields
         * 5. Validate errors are gone
         */
        public void TestCase1(string error, string foreName, string email, string message, string foreNameError, string emailError, string messageError)
        {
            var homePage = new HomePage(Driver);
            homePage.Open();
            Assert.That(homePage.IsLoaded(), Is.True);

            var contactPage = homePage.GoToContactPage();
            Assert.That(contactPage.IsLoaded(), Is.True);

            contactPage.SubmitContact();
            Assert.Multiple(() =>
            {
                Assert.That(contactPage.GetAlertError(), Is.EqualTo(error));
                Assert.That(contactPage.ForenameError.Text, Is.EqualTo(foreNameError));
                Assert.That(contactPage.EmailError.Text, Is.EqualTo(emailError));
                Assert.That(contactPage.MessageError.Text, Is.EqualTo(messageError));
            });
            

            contactPage.FillContactForm(new Contact() { ForeName = foreName, Email = email, Message = message});
            Assert.That(() => contactPage.GetAlertError(), Throws.Exception.TypeOf<WebDriverTimeoutException>());
        }

        [Test]
        [TestCase("John", "jH@gmail.com", "Some suggestions", "Thanks John, we appreciate your feedback.")]
        /* 1. From the home page go to contact page
         * 2. Populate mandatory fields
         * 3. Click submit button
         * 4. Validate successful submission message
        */
        public void TestCase2(string foreName, string email, string message, string alertMsg)
        {
            var homePage = new HomePage(Driver);
            homePage.Open();
            Assert.That(homePage.IsLoaded(), Is.True);

            var contactPage = homePage.GoToContactPage();
            Assert.That(contactPage.IsLoaded(), Is.True);

            contactPage.FillContactForm(new Contact() { ForeName = foreName, Email = email, Message = message });
            contactPage.SubmitContact();
            Assert.That(contactPage.PopUpModal.Displayed, Is.True);
            contactPage.PopUpModal.WaitForHidden(Driver, 20);
            Assert.That(contactPage.GetAlertMessage(), Is.EqualTo(alertMsg));
        }

        [Test]
        [TestCase("John", "jH", "Some suggestions", "Please enter a valid email")]
        /*
         * 1. From the home page go to contact page
         * 2. Populate mandatory fields with invalid data
         * 3. Validate errors
        */
        public void TestCase3(string foreName, string invalidEmail, string message, string emailError)
        {
            var homePage = new HomePage(Driver);
            homePage.Open();
            Assert.That(homePage.IsLoaded(), Is.True);

            var contactPage = homePage.GoToContactPage();
            Assert.That(contactPage.IsLoaded(), Is.True);

            contactPage.FillContactForm(new Contact() { ForeName = foreName, Email = invalidEmail, Message = message });
            Assert.That(contactPage.EmailError.Text, Is.EqualTo(emailError));
        }

        [Test]
        [TestCase("Funny Cow", 2, "Fluffy Bunny", 1)]
        /*Test case 4:
         * 1. From the home page go to shop page
         * 2. Click buy button 2 times on “Funny Cow”
         * 3. Click buy button 1 time on “Fluffy Bunny”
         * 4. Click the cart menu
         * 5. Verify the items are in the cart
        */
        public void TestCase4(string itemName1, int item1Quatity, string itemName2, int item2Quantity)
        {
            var items = new List<ShopItem>()
            {
                new ShopItem { ItemName = itemName1, ItemQuatity = item1Quatity },
                new ShopItem { ItemName = itemName2, ItemQuatity = item2Quantity}
            };

            var homePage = new HomePage(Driver);
            homePage.Open();
            Assert.That(homePage.IsLoaded(), Is.True);

            var shopPage = homePage.GoToShopPage();
            Assert.That(shopPage.IsLoaded(), Is.True);
            // Synchronization


            foreach (var item in items)
            {
                for (int i = 1; i <= item.ItemQuatity; i++)
                {
                    shopPage.BuyBtn(item.ItemName).Click();
                }
            }

            var cartPage = shopPage.GoToCart();
            Assert.That(cartPage.IsLoaded(), Is.True, "Page title and path not updated");

            //Todo: if any other way to do the assert 
            Assert.That(cartPage.VerifyItemsInCarts(items), Is.True, "Shop items don't match");

        }
    }
}
