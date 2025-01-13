using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class LoginShopping
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://www.google.com/";
            verificationErrors = new StringBuilder();
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public void TheLoginShoppingTest()
        {
            driver.Navigate().GoToUrl("https://demowebshop.tricentis.com/");
            driver.FindElement(By.LinkText("Log in")).Click();
            driver.FindElement(By.Id("Email")).Clear();
            driver.FindElement(By.Id("Email")).SendKeys("changedemail@gmail.com");
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys("password");
            driver.FindElement(By.XPath("//input[@value='Log in']")).Click();
            driver.FindElement(By.XPath("//div[5]/div/div[2]/div[3]/div[2]/input")).Click();
            driver.FindElement(By.Id("main-product-img-16")).Click();
            driver.FindElement(By.XPath("//form[@id='product-details-form']/div/div[2]/div[2]/div[3]/div/div[2]/div[3]/div[2]/input")).Click();
            driver.FindElement(By.Id("add-to-cart-button-4")).Click();
            driver.FindElement(By.Id("giftcard_4_RecipientName")).Click();
            driver.FindElement(By.Id("giftcard_4_RecipientName")).Clear();
            driver.FindElement(By.Id("giftcard_4_RecipientName")).SendKeys("My Name Is");
            driver.FindElement(By.Id("add-to-cart-button-4")).Click();
            driver.FindElement(By.XPath("//li[@id='topcartlink']/a/span")).Click();
            driver.FindElement(By.Name("removefromcart")).Click();
            driver.FindElement(By.Id("CountryId")).Click();
            new SelectElement(driver.FindElement(By.Id("CountryId"))).SelectByText("Croatia");
            driver.FindElement(By.Id("StateProvinceId")).Click();
            driver.FindElement(By.Id("StateProvinceId")).Click();
            driver.FindElement(By.Id("ZipPostalCode")).Click();
            driver.FindElement(By.Id("ZipPostalCode")).Clear();
            driver.FindElement(By.Id("ZipPostalCode")).SendKeys("31000");
            driver.FindElement(By.Name("estimateshipping")).Click();
            driver.FindElement(By.Id("termsofservice")).Click();
            driver.FindElement(By.Id("checkout")).Click();
            driver.FindElement(By.Id("BillingNewAddress_CountryId")).Click();
            new SelectElement(driver.FindElement(By.Id("BillingNewAddress_CountryId"))).SelectByText("Croatia");
            driver.FindElement(By.Id("BillingNewAddress_City")).Click();
            driver.FindElement(By.Id("BillingNewAddress_City")).Clear();
            driver.FindElement(By.Id("BillingNewAddress_City")).SendKeys("Osijek");
            driver.FindElement(By.Id("BillingNewAddress_Address1")).Clear();
            driver.FindElement(By.Id("BillingNewAddress_Address1")).SendKeys("Vladimira Nazora 3");
            driver.FindElement(By.Id("BillingNewAddress_ZipPostalCode")).Clear();
            driver.FindElement(By.Id("BillingNewAddress_ZipPostalCode")).SendKeys("31000");
            driver.FindElement(By.Id("BillingNewAddress_PhoneNumber")).Clear();
            driver.FindElement(By.Id("BillingNewAddress_PhoneNumber")).SendKeys("091254128");
            driver.FindElement(By.XPath("//input[@value='Continue']")).Click();
            driver.FindElement(By.XPath("//div[@id='shipping-buttons-container']/input")).Click();
            driver.FindElement(By.XPath("//div[@id='shipping-method-buttons-container']/input")).Click();
            driver.FindElement(By.XPath("//div[@id='payment-method-buttons-container']/input")).Click();
            driver.FindElement(By.XPath("//div[@id='payment-info-buttons-container']/input")).Click();
            driver.FindElement(By.XPath("//input[@value='Confirm']")).Click();
            driver.FindElement(By.XPath("//input[@value='Continue']")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
