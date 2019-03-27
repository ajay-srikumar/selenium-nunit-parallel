using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;

namespace PartyboxJourneyTest.Framework
{
    public class Utilities
    {
       public static IConfigurationRoot Config;
       static string dir = $"{Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().IndexOf("bin"))}//TestResults//Screenshots//" ;
        
        public static void GetValueFromConfig()
        {
            Config = new ConfigurationBuilder().AddJsonFile("config//appsettings.Dev.json").Build(); 
        }
        
        public static void TakeScreenshot(IWebDriver driver, string testName)
        {
            var screenshotDriver = (ITakesScreenshot)driver;
            var image = screenshotDriver.GetScreenshot();
            string fileName = $"{testName}_{DateTime.Now:yy-MM-dd_hh-mm-ss-tt}.png";
            image.SaveAsFile(dir+fileName,ScreenshotImageFormat.Png );
        }

        public static void ClearDirectory()
        {
            DirectoryInfo di = new DirectoryInfo(dir);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete(); 
            }
        } 
        
        public static void CreateDirectory()
        {
           Directory.CreateDirectory(dir);
        }
    }
}