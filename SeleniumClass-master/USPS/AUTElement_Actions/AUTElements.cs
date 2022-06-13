using FrameworkLib;

using OpenQA.Selenium;

using System.ComponentModel;


namespace USPS.AUTElement_Actions
{
   public  class AUTElements : WebBaseSupport
    {
        [DisplayName("Site Logo")]
        public IWebElement SiteLogo => Driver.FindElement(By.CssSelector("# g-navigation > div > a.global-logo"));

        [DisplayName("Register and Sign in Link")]
        public IWebElement likRegister_SignIN => Driver.FindElement(By.Id("login-register-header"));

        [DisplayName("Sign Up button")]
        public IWebElement bntSignUpNOW => Driver.FindElement(By.Id("sign-up-button"));

        [DisplayName("Language Drop-Down")]
        public IWebElement ddLanguage => Driver.FindElement(By.CssSelector("#slanguage"));

        [DisplayName("Username field")]
        public IWebElement txtUserName => Driver.FindElement(By.Id("tuserName"));


        public IWebElement UserErrorMSG => Driver.FindElement(By.CssSelector("#error-tuserName > span"));

        public IWebElement SuggestionUser => Driver.FindElement(By.CssSelector("#alternate-alias"));
      
        public IWebElement UserNameAvaiable => Driver.FindElement(By.XPath("//*[@id='check-username-available']"));
        [DisplayName("Radio Button Locator")]
        public IWebElement rdAcountType => Driver.FindElement(By.XPath("//*[@id='account-types-section']/div[2]/div")); //*[@id="account-types-section"]/div[2]/div

        [DisplayName("Locator for first checkbox")]
        public IWebElement NonUSPS => Driver.FindElement(By.CssSelector("#cFrmUSPS"));

        [DisplayName("Locator for second checkbox")]
        public IWebElement USPSPartners => Driver.FindElement(By.CssSelector("#cFrmPartners"));

        [DisplayName("Password field")]
        public IWebElement txtPassword => Driver.FindElement(By.CssSelector("#tPassword"));

        [DisplayName("Retype Password field")]
        public IWebElement txtRetypePassword => Driver.FindElement(By.CssSelector("#tPasswordRetype"));

        [DisplayName("First Security Question Dropdown")]
        public IWebElement ddSecurityQ1 => Driver.FindElement(By.CssSelector("#ssec1"));

        [DisplayName("First Security Question Answer")]
        public IWebElement txtAnswer1 => Driver.FindElement(By.CssSelector("#tsecAnswer1"));

        [DisplayName("First Security Question Retype Answer")]
        public IWebElement txtRetypeAnswer1 => Driver.FindElement(By.CssSelector("#tsecAnswer1Match"));

        [DisplayName("Second Security Question Dropdown")]
        public IWebElement ddSecurityQ2 => Driver.FindElement(By.CssSelector("#ssec2"));

        [DisplayName("Second Security Question Answer")]
        public IWebElement txtAnswer2 => Driver.FindElement(By.CssSelector("#tsecAnswer2"));

        [DisplayName("Second Security Question Retype Answer")]
        public IWebElement txtRetypeAnswer2 => Driver.FindElement(By.CssSelector("#tsecAnswer2Match"));

        [DisplayName("Dropdown name title selector")]
        public IWebElement ddTitle => Driver.FindElement(By.Id("stitle"));

        [DisplayName("First Name field")]
        public IWebElement txtFirstName => Driver.FindElement(By.Id("tfName"));

        [DisplayName("Last Name field")]
        public IWebElement txtLastName => Driver.FindElement(By.CssSelector("#tlName"));

        [DisplayName("Email field")]
        public IWebElement txtEmail => Driver.FindElement(By.CssSelector("#temail"));

        [DisplayName("Retype Email field")]
        public IWebElement txtRetypeEmail => Driver.FindElement(By.CssSelector("#temailRetype"));

        [DisplayName("Dropdown Phone Number type")]
        public IWebElement ddphoneType => Driver.FindElement(By.CssSelector("#sphoneType"));

        [DisplayName("Phone Number field")]
        public IWebElement txtPhoneNumber => Driver.FindElement(By.CssSelector("#tphone"));

        [DisplayName("Dropdown Country selector")]
        public IWebElement ddCountry => Driver.FindElement(By.CssSelector("#scountry"));

        [DisplayName("Address field")]
        public IWebElement txtAddress => Driver.FindElement(By.CssSelector("#taddress"));

        [DisplayName("City field")]
        public IWebElement txtCity => Driver.FindElement(By.CssSelector("#tcity"));

        [DisplayName("Dropdown State selector")]
        public IWebElement ddState => Driver.FindElement(By.CssSelector("#sstate"));

        [DisplayName("Zip Code field")]
        public IWebElement txtZipCode => Driver.FindElement(By.CssSelector("#tzip"));

        [DisplayName("Submit Button locator")]
        public IWebElement btnVerify => Driver.FindElement(By.CssSelector("#a-address-step1"));
      
    }
}
