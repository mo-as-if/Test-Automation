using FrameworkLib.Configuration;
using OpenQA.Selenium.Chrome;
using System;
using static FrameworkLib.Base.Browsers;

namespace FrameworkLib.Base
{
    public abstract class TestInitializeHook : BasePage
    {
        private readonly BrowserType Browser;

        public TestInitializeHook(BrowserType browser)
        {
            Browser = browser;
        }

        public void InitizalizeSettings()
        {
            xmlConfigReader.AUTAppSettingsReader("AppAUTConfig.xml");
            //Open Browser
            OpenBrowser(Browser);
        }

        private void OpenBrowser(BrowserType browserType = BrowserType.Chrome)
        {
           switch(browserType)
            {
                case BrowserType.Chrome:
                    DriverContext.Driver = new ChromeDriver();
                    DriverContext.Browser = new Browsers(DriverContext.Driver);
                    DriverContext.Driver.Manage().Window.Maximize();
                    break;
                case BrowserType.Edge:
                    DriverContext.Driver = new ChromeDriver();
                    DriverContext.Browser = new Browsers(DriverContext.Driver);
                    break;
                case BrowserType.FireFox:
                    DriverContext.Driver = new ChromeDriver();
                    DriverContext.Browser = new Browsers(DriverContext.Driver);
                    break;
                case BrowserType.InternetExplorer:
                    DriverContext.Driver = new ChromeDriver();
                    DriverContext.Browser = new Browsers(DriverContext.Driver);
                    break;

            }
        }

        public virtual void NaviateSite(string ApplicationURL)
        {
            DriverContext.Browser.GoToURL(ApplicationURL);
        }
    }
}
