using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectPlanAutomation.PageObject
{
    class SignedInPage : SetUp
    {
        

        public SignedInPage(IWebDriver webDriver, WebDriverWait wait)
        {
            base.webDriver = webDriver;
            base.wait = wait;
        }

        private IWebElement _yesBTN => webDriver.FindElement(By.XPath("//input[@type = 'submit']"));
        public void ClickYesButton()
        {
            wait.Until(ExpectedConditions
                .ElementToBeClickable(_yesBTN))
                .Click();
        }


    }
}
