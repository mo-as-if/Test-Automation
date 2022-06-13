using AventStack.ExtentReports;
using FrameworkLib.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using static FrameworkLib.Extensions.ElementExt;


namespace USPS.AUTElement_Actions.PageActions
{

    public class SignUpPage : AUTElements
    {
    

        public void FillUpForm( string Language, string UsersFullName, string Passwords,string Question1, string Answer1, string Question2, string Answer2,string AccountTypes, string title,
            string UsersFIrstName, string UserLastName, string Email, string PhoneDD, string Phone, string Country, string Address, string City, string State, string ZipCode, ExtentTest report)
        {


           
            DDSelectElem(ddLanguage, Language);

         
            EnterUserName(UsersFullName, report);
            PickPassword(Passwords, report);
            SecurityQuestions(Question1, Answer1, Question2, Answer2, report);

            AccountType(AccountTypes, report);
            
    

            report.Log(Status.Info, "Testing 123");
            report.AddScreenCaptureFromPath(DriverExt.WebScreenShot(Driver));

            DDSelectElem(ddTitle, title);
            SendValue(txtFirstName,UsersFIrstName);
            SendValue(txtLastName,UserLastName);

            //bool EmailInFile= 
            Assert.IsTrue(VerifyEmail(Email, report));
           
       

            DDSelectElem(ddphoneType, PhoneDD);
            SendValue(txtPhoneNumber, Phone);

            ClickOnElemnt(NonUSPS);
            ClickOnElemnt(USPSPartners);


            DDSelectElem(ddCountry, Country);
            SendValue(txtAddress, Address);
            SendValue(txtCity, City);
            DDSelectElem(ddState, State);
            SendValue(txtZipCode, ZipCode);

            ClickOnElemnt(btnVerify);
           report.Log(Status.Info, "Was able to fill up from");

        }

        private void AccountType(string accountTypes, ExtentTest report)
        {
            //Account Type
            RadioButtons categories = new RadioButtons(rdAcountType.FindElements(By.TagName("input")));
            categories.SelectValue(accountTypes/*"business"*/).Click();
            if (accountTypes == "business")
            {
                Assert.IsTrue(NonUSPS.Selected && USPSPartners.Selected);
            }
            else
            {
                Assert.IsFalse(NonUSPS.Selected && USPSPartners.Selected);
            }
        }

        private void SecurityQuestions(string question1, string answer1, string question2, string answer2, ExtentTest report)
        {
            DriverExt.ScrollElementIntoView(ddSecurityQ1);
            DDSelectElem(ddSecurityQ1, question1);
            SendValue(txtAnswer1, answer1);
            SendValue(txtRetypeAnswer1, answer1);
            DDSelectElem(ddSecurityQ2, question2);
            SendValue(txtAnswer2, answer2);
            SendValue(txtRetypeAnswer2, answer2);
        }

        private void PickPassword(string passwords, ExtentTest report)
        {
            SendValue(txtPassword, passwords);
            SendValue(txtRetypePassword, passwords);
        }

        private void EnterUserName(string UserName, ExtentTest report)
        {
            SendValue(txtUserName, UserName);
            txtPassword.Click();
          
            //if (UserErrorMSG.Displayed && UserErrorMSG.Text.Equals("Looks like that name is already in use."))
            //{
            //    Assert.IsTrue(SuggestionUser.Displayed);
            //}
            //else if (UserName.Length < 6 && UserErrorMSG.Displayed)
            //{
            //    UserErrorMSG.Text.Equals("Your Username must be at least 6 characters long.");
            //}
            report.Log(Status.Info, "Verify UserName Filed");
            Assert.IsTrue(UserNameAvaiable.Displayed);


        }

        private bool VerifyEmail(string email, ExtentTest report)
        {
            bool flag = false;
            Dictionary<int, string> UserInfo = DBQuery.DBQuery.PersonInfo(email);
            for (int rowNumber = 0; rowNumber <= UserInfo.Count; rowNumber++)
            {
                string[] item = UserInfo[rowNumber].Split('|');

                if(item[2].Contains(email))
                {
                    report.Log(Status.Info, $"Given E-mail: {email} is already in use");
                    report.Log(Status.Info, $"You wiill be expected to see an error");
                    break;
                }
        
            }
            SendValue(txtEmail, email);
            SendValue(txtRetypeEmail, email);

            return flag;

        }

        internal SignInPage GoToSignPage(string TestDataURL, ExtentTest report)
        {
            ClickOnElemnt(likRegister_SignIN);
           // likRegister_SignIN.Click();

            DriverExt.VerifyURLS(TestDataURL);
            report.Log(Status.Info, "Going back to Sign in page");
            return GetInstance<SignInPage>();
        }




        public enum RadioOpt
        {
            personal,
            business,

        }

    }
}
