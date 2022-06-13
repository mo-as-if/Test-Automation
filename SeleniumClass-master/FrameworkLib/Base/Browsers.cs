using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkLib.Base
{
    public class Browsers
    {
        private readonly IWebDriver _driver;
        public Browsers(IWebDriver Driver)
        {
            _driver = Driver;
        }

        public BrowserType ToolType {get; set;}
        public enum BrowserType
        {
            Chrome,
            InternetExplorer,
            FireFox,
            Edge
        }

        internal void GoToURL(string applicationURL)
        {
            DriverContext.Driver.Url = applicationURL;
        }
    }
}
