using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumWrapper;
using Base;

namespace BusinessFlow
{
    public class CommonMethods
    {
        IWebDriver _driver = null;
        WebDriverWait wait = null;      
        SeleniumHelper _seleniumhelper = null;

        [FindsBy(How = How.XPath, Using = "//a[@class='ico-login']")]
        public IWebElement loginLink { get; set; }

        [FindsBy(How = How.Id, Using = "Email")]
        public IWebElement emailInput { get; set; }

        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement passwordInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@value,'Log in')]")]
        public IWebElement loginButton { get; set; }

        public CommonMethods(IWebDriver _driverObj, ReportHelper _reporthelper)
        {
            _driver = _driverObj;
            wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(45));
            _seleniumhelper = new SeleniumHelper(_driver, _reporthelper);
            if (_driver != null)
            {
                PageFactory.InitElements(_driver, this);
            }
        }

        public void LogintoApplication()
        {
            _seleniumhelper.ClickButton(loginLink);
            System.Threading.Thread.Sleep(1000);
            _seleniumhelper.SendKeys(emailInput, staticStringReader.StaticData.masterUsername);
            _seleniumhelper.SendKeys(passwordInput, staticStringReader.StaticData.masterPassword);
            _seleniumhelper.ClickButton(loginButton);
        }
    }
}
