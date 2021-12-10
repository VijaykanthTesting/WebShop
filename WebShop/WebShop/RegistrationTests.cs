using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Base;
using BusinessFlow;

namespace WebShop
{
    [TestClass]
    public class RegistrationTests : BaseDriver
    {
       
        [TestMethod]
        public void VerifyUserRegistration()
        {
            try
            {
                UserRegistration _userRegistration = new UserRegistration(BaseDriver._driver, BaseDriver._reporthelper);
                Assert.IsTrue(_userRegistration.RegisterUser(), "Registration not Successfull");
            }
            catch(Exception ex)
            {
                Assert.IsFalse(true, "Registration not Successfull");
                _reporthelper.WriteSteps(TestContext.CurrentTestOutcome.ToString());
            }
        }

        [TestMethod]
        public void Verify_ValidationsInRegistrationForm()
        {
            try
            {
                UserRegistration _userRegistration = new UserRegistration(BaseDriver._driver, BaseDriver._reporthelper);
                Assert.IsTrue(_userRegistration.validate_RegistrationForm(), "Registration not Successfull");
            }
            catch (Exception ex)
            {
                Assert.IsFalse(true, "Validation in Registration form not Successfull");
                _reporthelper.WriteSteps(TestContext.CurrentTestOutcome.ToString());
            }
        }
    }
}
