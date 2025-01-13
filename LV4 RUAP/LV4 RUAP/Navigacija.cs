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
    public class Navigacija
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
        public void TheNavigacijaTest()
        {
            driver.Navigate().GoToUrl("https://demowebshop.tricentis.com/");
            driver.FindElement(By.XPath("//img[@alt='Tricentis Demo Web Shop']")).Click();
            driver.FindElement(By.LinkText("Desktops")).Click();
            driver.FindElement(By.XPath("//img[@alt='Picture of Build your own computer']")).Click();
            driver.FindElement(By.XPath("//img[@alt='Picture of 14.1-inch Laptop']")).Click();
            driver.FindElement(By.XPath("//img[@alt='Picture of Blue and green Sneaker']")).Click();
            driver.FindElement(By.LinkText("News")).Click();
            driver.FindElement(By.LinkText("My account")).Click();
            driver.FindElement(By.LinkText("Shipping & Returns")).Click();
            driver.FindElement(By.XPath("//img[@alt='Tricentis Demo Web Shop']")).Click();
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
