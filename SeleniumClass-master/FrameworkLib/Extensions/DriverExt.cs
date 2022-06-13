using FrameworkLib.Base;
using FrameworkLib.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FrameworkLib.Extensions
{
  public static class DriverExt
    {
        public static void VerifyURLS(string TestDataURL)
        {
            string GetCurrentURL = DriverContext.Driver.Url;
            Assert.IsTrue(GetCurrentURL.Contains(TestDataURL));

        }

        public static void DriverCleanUp()
        {
            DriverContext.Driver.Close();
            DriverContext.Driver.Quit();
            LogHelper.Write($"Closed the Driver");
        }

        public static void RefreshScreen()
        {
            DriverContext.Driver.Navigate().Refresh();
        }

        public static void GoBack()
        {
            DriverContext.Driver.Navigate().Back();
        }

        public static void GoForward()
        {
            DriverContext.Driver.Navigate().Forward();
        }


        public static void ScrollElementIntoView(IWebElement element)
        {
            LogHelper.Write($" Scrolling to {element.Text}");
            ((IJavaScriptExecutor)DriverContext.Driver).ExecuteScript("window.scroll(" + element.Location.X + "," + (element.Location.Y - 200) + ");");
        }

        public static string WebScreenShot(IWebDriver driver)

        {

            string screenShotName = DateTime.Now.ToString("ddMMyyyyHHmmssffff");
           Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();


            string screenShotPath =  $@"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\Desktop\AutomationQATestReport\Screenshots\SC" + DateTime.Now.ToString("dd_MM_yyyy");

            if (!Directory.Exists(screenShotPath))
            {
                Directory.CreateDirectory(screenShotPath);
            }

            screenShotPath = screenShotPath + "/" + screenShotName + ".png";

            string localpath = new Uri(screenShotPath).LocalPath;

            screenshot.SaveAsFile(screenShotPath, ScreenshotImageFormat.Png);
            LogHelper.Write($"Test Run Taking photo");
            return localpath;

        }


    }
}
