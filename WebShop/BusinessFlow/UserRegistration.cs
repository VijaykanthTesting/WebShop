using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumWrapper;
using Base;

namespace BusinessFlow
{
    public class UserRegistration
    {
        IWebDriver _driver = null;
        WebDriverWait wait = null;
        SeleniumHelper _seleniumhelper = null;

        public UserRegistration(IWebDriver _driverObj, ReportHelper _reporthelper)
        {
            _driver = _driverObj;
            wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(45));
            _seleniumhelper = new SeleniumHelper(_driver, _reporthelper);
            if (_driver != null)
            {
                PageFactory.InitElements(_driver, this);
            }
        }

        [FindsBy(How = How.XPath, Using = "//a[@class='ico-register']")]
        public IWebElement registerLink { get; set; }

        [FindsBy(How = How.Id, Using = "gender-male")]
        public IWebElement genderMale { get; set; }

        [FindsBy(How = How.Id, Using = "gender-female")]
        public IWebElement genderFemale { get; set; }

        [FindsBy(How = How.Id, Using = "FirstName")]
        public IWebElement FirstName { get; set; }

        [FindsBy(How = How.Id, Using = "LastName")]
        public IWebElement LastName { get; set; }

        [FindsBy(How = How.Id, Using = "Email")]
        public IWebElement Email { get; set; }
        
        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement Password { get; set; }        

        [FindsBy(How = How.Id, Using = "ConfirmPassword")]
        public IWebElement ConfirmPassword { get; set; }
        
        [FindsBy(How = How.Id, Using = "register-button")]
        public IWebElement RegisterButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@class='button-1 register-continue-button']")]
        public IWebElement success_button { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='result']")]
        public IWebElement success_message { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='header-links']//a[@class='account']")]
        public IWebElement loggedin_email { get; set; }


        [FindsBy(How = How.XPath, Using = "//span[@class='field-validation-error']/span[@for='FirstName']")]
        public IWebElement validation_FirstName { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class='field-validation-error']/span[@for='LastName']")]
        public IWebElement validation_LastName { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class='field-validation-error']/span[@for='Email']")]
        public IWebElement validation_Email { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class='field-validation-error']/span[@for='Password']")]
        public IWebElement validation_Password { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class='field-validation-error']/span[@for='ConfirmPassword']")]
        public IWebElement validation_ConfirmPassword { get; set; }

        public bool RegisterUser()
        {
            bool _registration = true;
            string _email = "Webshop_Test00@tmpmail.org";
            string _password = "Webshop@123";
            string _Fname = "Auto_First";
            string _Lname = "Auto_Last";
            _seleniumhelper.Click(registerLink);
            _seleniumhelper.Click(genderFemale);
            _seleniumhelper.SendKeys(FirstName, _Fname);
            _seleniumhelper.SendKeys(LastName, _Lname);
            _seleniumhelper.SendKeys(Email, _email);
            _seleniumhelper.SendKeys(Password, _password);
            _seleniumhelper.SendKeys(ConfirmPassword, _password);
            _seleniumhelper.Click(RegisterButton);
            _registration &= _seleniumhelper.verifystring(success_message, "Your registration completed");
            _seleniumhelper.Click(success_button);
            _registration &= _seleniumhelper.verifystring(loggedin_email, _email);            
            return _registration;
        }

        public bool validate_RegistrationForm()
        {
            bool val = true;
            _seleniumhelper.Click(registerLink);
            _seleniumhelper.Click(RegisterButton);
            val &= _seleniumhelper.verifystring(validation_FirstName, staticStringReader.StaticData.validation_FirstName);
            val &= _seleniumhelper.verifystring(validation_LastName, staticStringReader.StaticData.validation_LastName);
            val &= _seleniumhelper.verifystring(validation_Email, staticStringReader.StaticData.validation_Email);
            val &= _seleniumhelper.verifystring(validation_Password, staticStringReader.StaticData.validation_Password);
            val &= _seleniumhelper.verifystring(validation_ConfirmPassword, staticStringReader.StaticData.validation_Password);
            _seleniumhelper.SendKeys(Email, "123");
            _seleniumhelper.Click(RegisterButton);
            val &= _seleniumhelper.verifystring(validation_Email, staticStringReader.StaticData.validation_WrongEmail);
            _seleniumhelper.SendKeys(Password, "1");
            _seleniumhelper.Click(RegisterButton);
            val &= _seleniumhelper.verifystring(validation_Password, staticStringReader.StaticData.validation_PasswordLength);
            _seleniumhelper.SendKeys(Password, "123456");
            _seleniumhelper.SendKeys(ConfirmPassword, "654321");
            _seleniumhelper.Click(RegisterButton);
            val &= _seleniumhelper.verifystring(validation_ConfirmPassword, staticStringReader.StaticData.validation_ConfirmPassword);
            return val;
        }
    }
}
