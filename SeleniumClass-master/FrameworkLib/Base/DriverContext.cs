using OpenQA.Selenium;

namespace FrameworkLib.Base
{
    public static class DriverContext
    {
        private static IWebDriver _driver;
        public static IWebDriver Driver 
        {
            /*return the driver to child _driver */
            get
            {
                return _driver;
            }
            set
            {
                _driver = value;
            }
        
        
        }

        public static Browsers Browser { get; set; }
    }
}
