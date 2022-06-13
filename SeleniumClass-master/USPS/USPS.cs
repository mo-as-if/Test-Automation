using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using USPS.AUTElement_Actions.PageActions;
using FrameworkLib;
using FrameworkLib.Extensions;
using AventStack.ExtentReports;
using FrameworkLib.Helpers;
using FrameworkLib.XLXPATH;
using FrameworkLib.Configuration;

namespace USPS
{
    [TestClass]
    public class USPS :  HookInitialize
    {
        string xlxFile = UtilityData.USPS;
        string sheetName = "FillUpFrom";
        ExtentReports rlog = ReportingHelpers.getExtentReports();
        ExtentTest report;
     

        [TestInitialize]
        public void SetatEVeryRun()
        {
           
            NaviateSite(SystemSetting.USPSURL);
        }

        [TestMethod]
        [TestCategory("Smoke Test")]
        [Description("We will sign up for USPS account, this will select Lang: by Text")]
        public void FillingUpReg()
        {
            try
            {
                report=rlog.CreateTest("FillingUpReg");
                WebExcelHelper.PopulateInCollection(xlxFile, sheetName);
                CurrentPage = GetInstance<HomePage>();
                CurrentPage.As<HomePage>().VerifyHomePageURL("https://www.usps.com/", report);
                CurrentPage= GetInstance<HomePage>().GoToSignPage("https://reg.usps.com", report);
                CurrentPage= GetInstance<SignInPage>().GoToSignUpPage("https://reg.usps.com/entreg/RegistrationAction_input", report);
                CurrentPage.As<SignUpPage>().FillUpForm(WebExcelHelper.ReadData(1, "Language"),"QAClass2022"/*WebExcelHelper.ReadData(1, "UserName")*/, WebExcelHelper.ReadData(1, "EnterPassword"),
                    WebExcelHelper.ReadData(1, "SecurtyQ1"), "New York",
                    "What is your favorite holiday?", "Eid","personal" ,"Mr", "Kabir", "Faisal", 
                    "someone@gmail.com", "US", "9172345678", "UNITED STATES", "123 Some St", "Brooklyn", "NY - New York", "11238", report); ; ;
              
                report.Log(Status.Pass, "Test Passed");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                LogHelper.Write($"{e}");
                report.Log(Status.Fail, $"Test Fail and the execption msg: {e}");
            }
  

        }


        [TestMethod]
        [TestCategory("Smoke Test")]
        [Description("We will sign up for USPS account, this will select Lang: by Text")]
        public void GoBack()
        {
            try
            {
                report = rlog.CreateTest("GoBack");
                CurrentPage = GetInstance<HomePage>();
                CurrentPage.As<HomePage>().VerifyHomePageURL("https://www.usps.com/", report);

                CurrentPage = GetInstance<HomePage>().GoToSignPage("https://reg.usps.com", report);
                DriverExt.RefreshScreen();
                CurrentPage = GetInstance<SignInPage>().GoToSignUpPage("https://reg.usps.com/entreg/RegistrationAction_input", report);
                CurrentPage.As<SignUpPage>().FillUpForm(WebExcelHelper.ReadData(1, "Language"), "root"/* WebExcelHelper.ReadData(1, "UserName")*/, WebExcelHelper.ReadData(1, "EnterPassword"),
                   WebExcelHelper.ReadData(1, "SecurtyQ1"), "New York",
                   "What is your favorite holiday?", "Eid", "business", "Mr", "Kabir", "Faisal",
                   "someone@gmail.com", "US", "9172345678", "UNITED STATES", "123 Some St", "Brooklyn", "NY - New York", "11238", report); 
                DriverExt.GoBack();
                CurrentPage = GetInstance<SignUpPage>().GoToSignPage("https://rg..com/entreg/RegistrationAction_input", report);
                report.Log(Status.Pass, "Test Passed");
              
            }
            catch (Exception e)
            {
                LogHelper.Write($"{e}");
                report.Log(Status.Fail, $"Test Fail and the execption msg: {e}");
            }


        }

        [TestMethod]
        [TestCategory("Smoke Test")]
        [Description("We will sign up for USPS account, this will select Lang: by Text")]
        public void FillingWithDBData()
        {
            try
            {
                report = rlog.CreateTest("FillingUpReg");
                WebExcelHelper.PopulateInCollection(xlxFile, sheetName);


                CurrentPage = GetInstance<HomePage>();
                CurrentPage.As<HomePage>().VerifyHomePageURL("https://www.usps.com/", report);
                CurrentPage = GetInstance<HomePage>().GoToSignPage("https://reg.usps.com", report);
                CurrentPage = GetInstance<SignInPage>().GoToSignUpPage("https://reg.usps.com/entreg/RegistrationAction_input", report);
                CurrentPage.As<SignUpPage>().FillUpForm(WebExcelHelper.ReadData(1, "Language"), "root1236425"/* WebExcelHelper.ReadData(1, "UserName")*/, WebExcelHelper.ReadData(1, "EnterPassword"),
                         WebExcelHelper.ReadData(1, "SecurtyQ1"), "New York",
                         "What is your favorite holiday?", "Eid", "business", "Mr", "Kabir", "Faisal",
                         "someone@gmail.com", "US", "9172345678", "UNITED STATES", "123 Some St", "Brooklyn", "NY - New York", "11238", report);
                report.Log(Status.Pass, "Test Passed");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                LogHelper.Write($"{e}");
                report.Log(Status.Fail, "Test Fail");
            }


        }

    

        [TestCleanup]
        public void CleanUp()
        {
            DriverExt.DriverCleanUp();
            rlog.Flush();
        }



        



    }
}

