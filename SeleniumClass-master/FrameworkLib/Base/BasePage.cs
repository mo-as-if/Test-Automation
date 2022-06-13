using FrameworkLib.Base;
using OpenQA.Selenium;

namespace FrameworkLib
{
    public class BasePage
    {
        public WebBaseSupport CurrentPage { get; set; }
        public IWebDriver Driver { get; set; }

        public WebPage GetInstance<WebPage>() where WebPage: WebBaseSupport, new()
        {
            WebPage pageInstance = new WebPage()
            {
                Driver = DriverContext.Driver
            };
            return pageInstance;

        }

        public WebPage As<WebPage>() where WebPage : WebBaseSupport
        {
            return (WebPage)this;
        }
    }
}
