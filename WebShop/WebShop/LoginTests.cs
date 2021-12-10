using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Base;
using BusinessFlow;

namespace WebShop
{
    [TestClass]
    public class LoginTests : BaseDriver
    {
       
        [TestMethod]
        public void Verify_Login()
        {
            try
            {
                CommonMethods _commonmethod = new CommonMethods(BaseDriver._driver, BaseDriver._reporthelper);
                _commonmethod.LogintoApplication();
            }
            catch(Exception ex)
            {
                Assert.IsFalse(true, "login failed");
            }
        }        
    }
}
