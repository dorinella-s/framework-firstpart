using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectPlanAutomation.PageObject
{
    class PasswordPage : SetUp
    {
      
        public PasswordPage(IWebDriver webDriver, WebDriverWait wait)
        {
            base.webDriver = webDriver;
            base.wait = wait;
        }

        private By _passwdField => By.XPath("//input[@type = 'password']");
        private IWebElement _nextBTN => webDriver.FindElement(By.XPath("//input[@type = 'submit']"));
        private By _errorMessage => By.Id("passwordError");
        public void WritePasswdText(string passwd)
        {
            wait.Until(ExpectedConditions
                .ElementIsVisible(_passwdField))
                .SendKeys(passwd);
        }
        public void PressNextBTN()
        {
            wait.Until(ExpectedConditions
                .ElementToBeClickable(_nextBTN))
                .Click();
        }

        public void CheckErrorMessage(string exceptedResult)
        {
            string actualResultErrorMessage = wait.Until(ExpectedConditions
                .ElementIsVisible(_errorMessage))
                .Text;
            StringAssert.AreEqualIgnoringCase(exceptedResult, actualResultErrorMessage);
        }
    }
}

