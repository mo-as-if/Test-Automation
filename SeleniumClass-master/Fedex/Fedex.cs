using FrameworkLib;
using FrameworkLib.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fedex
{
    [TestClass]
    public class Fedex : HookInitialize
    {

        [TestInitialize]
        public void SetatEVeryRun()
        {
            NaviateSite("https://www.fedex.com/en-us/home.html");
          
        }
        [TestMethod]
        public void VerifyHomePageURL()
        {
            VerifyURLS("https://www.fedex.com/en-us/home.html");

        }

        public void VerifyURLS(string TestDataURL)
        {
            string GetCurrentURL = DriverContext.Driver.Url;
            Assert.IsTrue(GetCurrentURL == TestDataURL);
        }
    }
}
