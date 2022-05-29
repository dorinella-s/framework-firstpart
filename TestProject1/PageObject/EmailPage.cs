using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectPlanAutomation.PageObject
{
    public class EmailPage : SetUp
    {
       

        public EmailPage(IWebDriver webDriver, WebDriverWait wait)
        {
            base.webDriver = webDriver;
            base.wait = wait;
        }

        private IWebElement _emailField => webDriver.FindElement(By.XPath("//input[@type = 'email']"));
        private IWebElement _nextBTN => webDriver.FindElement(By.XPath("//input[@type = 'submit']"));
        private By _errorMessage => By.Id("usernameError");

        public void WriteEmailText(string email)
        {
            wait.Until(ExpectedConditions
                .ElementToBeClickable(_emailField))
                .Clear();

            wait.Until(ExpectedConditions
                .ElementToBeClickable(_emailField))
                .SendKeys(email);
        }
        public void PressNextBTN()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(_nextBTN)).Click();
        }

        public void CheckErrorMessage(string exceptedResult)
        {
            string actualResultErrorMessage = wait.Until(ExpectedConditions
                .ElementIsVisible(_errorMessage))
                .Text;
            Assert.AreEqual(exceptedResult, actualResultErrorMessage);
        }
    }
}
