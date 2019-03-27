using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PartyboxJourneyTest.Framework
{
    public class WebDriverExtension
    {
        private IWebDriver Driver;
        protected WebDriverExtension(IWebDriver driver)
        {
            Driver = driver;
        }
        
        protected void SetText(By selector, string value)
        { 
            try
            {           
                GetElement(selector).Clear();
                GetElement(selector).SendKeys(value);
                
            }
            catch (Exception e)
            {
                Assert.Fail("****************" + e.ToString() + "*********************");
                throw;
            }
            
        }   
        
        protected void RefreshPage()
        {
            Driver.Navigate().Refresh();
        }
        
        protected string getToken()
        {
           return Driver.Manage().Cookies.GetCookieNamed("RX_AUTH").Value;
        }

        protected void SetTextWithoutClearing(By selector, string value)
        {
            try
            {           
                GetElement(selector).SendKeys(value);
            }
            catch (Exception e)
            {
                Assert.Fail("****************" + e.ToString() + "*********************");
                throw;
            }
        }
        
        protected string GetText(IWebElement element)
        {
            try
            {
                return element.GetAttribute("textContent");
            }
            catch (Exception e)
            {
                Assert.Fail("****************" + e.ToString() + "*********************");
                throw;
            }
        }

        protected void WaitTillNotOnPage(By by, string message)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(50));
                wait.Until(driver => !driver.FindElements(by).Any());
            }
            catch (WebDriverTimeoutException e)
            {
                Console.WriteLine("\n ***************************  " + message + "  ****************************** \n");
                throw e;
            }
        }
        
        protected string GetAttributeValue(string attribute, IWebElement element)
        {
            try
            {
                return element.GetAttribute(attribute);
            }
            catch (Exception e)
            {
                Assert.Fail("****************" + e.ToString() + "*********************");
                throw;
            }
        }
        
        protected bool isTextPresent(string text)
        {
            try
            {
                Driver.FindElement(By.XPath("//*[contains(text()," + text +")]"));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        protected void SelectDropdownByValue(By selector, string value)
        {
            try
            {
                var selectElement = new SelectElement(GetElement(selector));
                selectElement.SelectByText(value);
            }
            catch (Exception e)
            {
                Assert.Fail("****************" + e.ToString() + "*********************");
                throw;
            }
        }
        
        
        protected bool isElementPresent(By selector)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                wait.Until(driver => Driver.FindElement(selector));
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
        
        protected bool isElementPresentWithoutWait(By selector)
        {
            try
            {
                Driver.FindElement(selector);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        protected bool isElementPresentWithLongWait(By selector)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(25));
                wait.Until(driver => Driver.FindElement(selector));
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        
        
        protected void waitForElementToBeLoaded(By selector)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                wait.Until(driver => GetElement(selector));  
            }
            catch (Exception e)
            {
                Assert.Fail("****************" + e.ToString() + "*********************");
                throw;
            }
        }
        
        protected void waitForElementToBeLoadedWithLongWait(By selector)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
                wait.Until(driver => GetElement(selector));  
            }
            catch (Exception e)
            {
                Assert.Fail("****************" + e.ToString() + "*********************");
                throw;
            }
        }
        
        protected IWebElement GetElement(By selector)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
                return wait.Until(driver => Driver.FindElement(selector));
            }
            catch (Exception e)
            {
                Assert.Fail("****************" + e.ToString() + "*********************");
                throw;
            }
        }
     
        protected IList<IWebElement> GetElements(By selector)
        {
            try
            {      
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(7));
                return wait.Until(driver => Driver.FindElements(selector));
            }
            catch (Exception e)
            {
                Assert.Fail("****************" + e.ToString() + "*********************");
                throw;
            }
        }
        
        protected void Click(By selector)
        {
            try
            {
                GetElement(selector).Click();
            }
            catch (Exception e)
            {
                Assert.Fail("****************" + e.ToString() + "*********************");
                throw;
            }
        }
        
        protected void Navigate(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }
    }
}