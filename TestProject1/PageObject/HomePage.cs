using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectPlanAutomation.PageObject
{
    public class HomePage : SetUp
    {
      
        public HomePage(IWebDriver webDriver, WebDriverWait wait)
        {
            base.webDriver = webDriver;
            base.wait = wait;
        }
        private By helloUser => By.CssSelector("div .page-overview > div:nth-child(2)>div>div>h1");
        private IWebElement _notifcationBTN => webDriver.FindElement(By.CssSelector("button.notification-icon > span"));
        private IWebElement _filterIcon => webDriver.FindElement(By.CssSelector("div.actions > button:first-child"));
        private IWebElement _entityTypeItem => webDriver.FindElement(By.XPath("//mat-select[@formcontrolname = 'typeId' or @placeholder = 'Entity Type']"));
        private IWebElement _entityTypeElement => webDriver.FindElement(By.CssSelector("mat-option:nth-child(2)>span.mat-option-text"));
        private IWebElement _oportunityType => webDriver.FindElement(By.CssSelector("mat-option:nth-child(2)>span.mat-option-text"));
        private IWebElement _financeBTN => webDriver.FindElement(By.CssSelector("a#finance-tab"));
        public void GetUserHelloText(string exceptedResult)
        {
            string actualResultStartText = wait.Until(ExpectedConditions
                .ElementIsVisible(helloUser))
                .Text;
            Assert.AreEqual(exceptedResult, actualResultStartText);
        }

        public void ClickNotificationBTN()
        {
            wait.Until(ExpectedConditions
                .ElementToBeClickable(_notifcationBTN))
                .Click();
        }

        public void ClickFilterIcon()
        {
            wait.Until(ExpectedConditions
                .ElementToBeClickable(_filterIcon))
                .Click();
        }

        public void ClickEntityType()
        {
            wait.Until(ExpectedConditions
                .ElementToBeClickable(_entityTypeItem))
                .Click();
        }

        public void FindEntityType(string exceptedResult)
        {
            string actualResultFilterText = wait.Until(ExpectedConditions
                .ElementToBeClickable(_entityTypeElement))
                .Text;
            Assert.AreEqual(exceptedResult, actualResultFilterText);
        }
        public void ChooseOportunityType()
        {
            wait.Until(ExpectedConditions
                .ElementToBeClickable(_oportunityType))
                .Click();
        }

        public void ClickFinanceBTN()
        {
            wait.Until(ExpectedConditions
                .ElementToBeClickable(_financeBTN))
                .Click();
        }


    }
}
