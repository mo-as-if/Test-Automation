using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;
using System.Linq;

namespace CLassSelenium
{
    [TestClass]
    public class FirstDayInClass
    {
        public IWebDriver Driver;
        [TestInitialize]
        public void StartUp()
        {
            //Open remort Chrome Driver
            Driver = new ChromeDriver();
            //Going to App site
            Driver.Navigate().GoToUrl("https://usps.com");
            Driver.Manage().Window.Maximize();
            //Writeing the outcome
            Console.WriteLine("Opend driver and navigated to USPS Reg Page");
            Debug.WriteLine("Opend driver and navigated to USPS Reg Page");
        }
        //Language DropDown List 
        public IWebElement SiteLogo => Driver.FindElement(By.CssSelector("# g-navigation > div > a.global-logo"));

        //*[@id="g-navigation"]/div/a[1]
        public IWebElement likRegister_SignIN => Driver.FindElement(By.Id("login-register-header"));
        public IWebElement bntSignUpNOW => Driver.FindElement(By.Id("sign-up-button"));
        public IWebElement ddLanguage => Driver.FindElement(By.CssSelector("#slanguage"));
        public IWebElement txtUserName => Driver.FindElement(By.Id("tuserName"));
        public IWebElement rdAcountType => Driver.FindElement(By.XPath("//*[@id='for-rAccount1']"));
        public IWebElement USPS => Driver.FindElement(By.CssSelector("#cFrmUSPS"));
        public IWebElement USPSPartners => Driver.FindElement(By.CssSelector("#cFrmPartners"));
        
        public IWebElement txtUsername => Driver.FindElement(By.CssSelector("#tuserName"));
        public IWebElement txtPassword => Driver.FindElement(By.CssSelector("#tPassword"));
        public IWebElement txtRetypePassword => Driver.FindElement(By.CssSelector("#tPasswordRetype"));
        public IWebElement ddSecurityQ1 => Driver.FindElement(By.CssSelector("#ssec1"));
        public IWebElement txtAnswer1 => Driver.FindElement(By.CssSelector("#tsecAnswer1"));
        public IWebElement txtRetypeAnswer1 => Driver.FindElement(By.CssSelector("#tsecAnswer1Match"));
        public IWebElement ddSecurityQ2 => Driver.FindElement(By.CssSelector("#ssec2"));
        public IWebElement txtAnswer2 => Driver.FindElement(By.CssSelector("#tsecAnswer2"));
        public IWebElement txtRetypeAnswer2 => Driver.FindElement(By.CssSelector("#tsecAnswer2Match"));
        public IWebElement rdAccountType => Driver.FindElement(By.CssSelector("#rAccount1"));
        public IWebElement txtFirstName => Driver.FindElement(By.CssSelector("#tfName"));
        public IWebElement txtLastName => Driver.FindElement(By.CssSelector("#tlName"));
        public IWebElement txtEmail => Driver.FindElement(By.CssSelector("#temail"));
        public IWebElement txtRetypeEmail => Driver.FindElement(By.CssSelector("#temailRetype"));
        public IWebElement ddphoneType => Driver.FindElement(By.CssSelector("#sphoneType"));
        public IWebElement txtPhoneNumber => Driver.FindElement(By.CssSelector("#tphone"));
        public IWebElement ddCountry => Driver.FindElement(By.CssSelector("#scountry"));
        public IWebElement txtAddress => Driver.FindElement(By.CssSelector("#taddress"));
        public IWebElement txtCity => Driver.FindElement(By.CssSelector("#tcity"));
        public IWebElement ddState => Driver.FindElement(By.CssSelector("#sstate"));
        public IWebElement txtZipCode => Driver.FindElement(By.CssSelector("#tzip"));
        public IWebElement btnVerify => Driver.FindElement(By.CssSelector("#a-address-step1"));

        public class RadioButtons 
        { 
            public RadioButtons(ReadOnlyCollection<IWebElement> webElements)
            {
                WebElements = webElements;
            }
            protected ReadOnlyCollection<IWebElement> WebElements { get; } 
            public IWebElement SelectValue(string value)
            {
              return  WebElements.Single(WebElement => WebElement.GetAttribute("value") == value);

            } 
        }

        public void DDSelectElem(IWebElement Item, string value)
        {

        
                SelectElement ddItem = new SelectElement(Item);
                ddItem.SelectByText(value);
            
        }

        public enum RadioOpt
        {
            personal,
            business,

        }

        //Red-->Yellow-->Red-->Green
        [TestMethod]
        [TestCategory("Smoke Test")]
        [Description("We will sign up for USPS account, this will select Lang: by Text")]
        public void USPSRegProjectDay1()
        {
            try
            {
                GoToHomePage("https://www.usps.com/");
                GoToRegister_SignINPage("https://reg.usps.com");
                FillUpForm("https://reg.usps.com/entreg/RegistrationAction_input", "English", "Kabir Faisal", "QACLass");
                ////I Was able to connect to git

              
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
                //This will close chrome driver
                Driver.Close();
                //this will terminate Chromedriver.exe
                Driver.Quit();

        }

        private void FillUpForm(string TestDataURL,string Language, string UsersFullName ,string Passwords )
        {
            bntSignUpNOW.Click();
            VerifyURLS(TestDataURL);
            //Language DropDown List 
            DDSelectElem(ddLanguage, Language);  
            //UserName
            txtUserName.SendKeys(UsersFullName);
            //Password
            txtPassword.SendKeys(Passwords);
            //ReType Password
            txtRetypePassword.SendKeys(Passwords);
            //Account Type
            RadioButtons categories = new RadioButtons(rdAccountType.FindElements(By.TagName("input")));
            categories.SelectValue("business").Click();
            Assert.IsTrue(USPS.Selected && USPSPartners.Selected);
            IWebElement bntVerify = Driver.FindElement(By.CssSelector("#a-address-step1"));
            bntVerify.Click();
            Console.WriteLine("Test passed");

        }

        public void GoToRegister_SignINPage(string TestDataURL)
        {
            VerifyURLS(TestDataURL);

        }

        public void GoToHomePage(string TestDataURL)
        {
            VerifyURLS(TestDataURL);

        }

        public void VerifyURLS(string TestDataURL)
        {
            string GetCurrentURL = Driver.Url;
            Assert.IsTrue(GetCurrentURL == TestDataURL);
        }
    }
}
