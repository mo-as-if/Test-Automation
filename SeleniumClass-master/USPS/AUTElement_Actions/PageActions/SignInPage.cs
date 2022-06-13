using AventStack.ExtentReports;
using FrameworkLib.Extensions;
using static FrameworkLib.Extensions.ElementExt;

namespace USPS.AUTElement_Actions.PageActions
{
    public class SignInPage : AUTElements
    {
        
        internal SignUpPage GoToSignUpPage(string TestDataURL, ExtentTest report)

        {
            ClickOnElemnt(bntSignUpNOW);
          //  bntSignUpNOW.Click();
            DriverExt.VerifyURLS(TestDataURL);
            report.Log(Status.Info, "Going to SignUpPage");
            return GetInstance<SignUpPage>();
        }
    }


}
