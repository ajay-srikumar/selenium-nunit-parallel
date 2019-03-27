using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PartyboxJourneyTest.Framework
{
    public class BaseTest
    {
      
        private IWebDriver Driver;
        private string DriverDirectory;
        
        [OneTimeSetUp]
         public void Init()
         {
             Utilities.GetValueFromConfig();
             Utilities.CreateDirectory();
             Utilities.ClearDirectory();
             if(RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
             {
                 DriverDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                 
             }
             else if(RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
             {
                 DriverDirectory = Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().IndexOf("bin")) + "/Resources/";
             }
             
            
             ChromeOptions options = new ChromeOptions();
             options.AddArgument("--start-maximized");
             
            Driver =  new ChromeDriver(DriverDirectory, options);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
         }
        
        [OneTimeTearDown]
        public void KillBrowser()
        {
            Driver.Quit();          
        }

        [TearDown]
        public void CheckTestResult()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                Utilities.TakeScreenshot(Driver, TestContext.CurrentContext.Test.Name);
            }
        }
        
        protected IWebDriver GetDriver()
        {
            return Driver;
        }
        
        
    }
}