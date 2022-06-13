using AventStack.ExtentReports;
using FrameworkLib.Base;
using FrameworkLib.Extensions;
using static FrameworkLib.Extensions.ElementExt;

namespace USPS.AUTElement_Actions.PageActions
{
    public class HomePage : AUTElements
    {

        public void VerifyHomePageURL(string TestDataURL, ExtentTest report)
        {
            DriverExt.VerifyURLS(TestDataURL);
            report.Log(Status.Info, "Verifyed HomePage");

        }



        internal SignInPage GoToSignPage(string TestDataURL, ExtentTest report)
        {
            ClickOnElemnt(likRegister_SignIN);
            DriverExt.VerifyURLS(TestDataURL);
            report.Log(Status.Info, "Going to SignInPage");
            return GetInstance<SignInPage>();
        }
    }
}
