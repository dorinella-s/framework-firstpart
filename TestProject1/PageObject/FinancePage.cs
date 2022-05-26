using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ProjectPlanAutomation.PageObject
{
    class FinancePage : SetUp
    {
        public FinancePage(IWebDriver webDriver, WebDriverWait wait)
        {
            base.webDriver = webDriver;
            base.wait = wait;
        }

        private By _statisticsCategory => By.XPath("//div/a/h5/span[contains(text(),'Statistics')]");
        private IWebElement _actualsTab => webDriver.FindElement(By.CssSelector("div.mat-tab-links > a.mat-tab-link:nth-child(1)"));
        private IWebElement _budgetTab => webDriver.FindElement(By.CssSelector("div.mat-tab-links > a.mat-tab-link:nth-child(2)"));
        private IWebElement _addActualsBTN => webDriver.FindElement(By.XPath("//div/div/span[contains(text(),'Add Actuals')]"));
        private IWebElement _addBudgetBTN => webDriver.FindElement(By.XPath("//div/div/span[contains(text(),'Add Budget')]"));
        private By _addActualsText => By.CssSelector("h2>strong");
        private IWebElement _dateInput => webDriver.FindElement(By.XPath("//input[@placeholder='Select the month and the year']"));
        private IWebElement _dateInputText => webDriver.FindElement(By.XPath("//span[contains(text(),'Select the month and the year')]"));
        private IWebElement _errorMesage => webDriver.FindElement(By.XPath("//mat-error[contains(text(),'This field is required')]"));

        public void OpenStatisticsCategory()
        {
            wait.Until(ExpectedConditions
                .ElementToBeClickable(_statisticsCategory))
                .Click();
            Thread.Sleep(2000);
        }

        public void OpenActualsTab()
        {
            wait.Until(ExpectedConditions
                .ElementToBeClickable(_actualsTab))
                .Click();

        }
        public void ClickAddActualsBTN()
        {
            wait.Until(ExpectedConditions
                .ElementToBeClickable(_addActualsBTN))
                .Click();
        }
        public void GetAddActualContainerText(string exceptedResult)
        {
            string actualResultStartText = wait.Until(ExpectedConditions
                .ElementIsVisible(_addActualsText))
                .Text;
            Assert.AreEqual(exceptedResult, actualResultStartText);
        }
        public void SelectDateFromField()
        {
            wait.Until(ExpectedConditions
                .ElementToBeClickable(_dateInput))
                .Click();
        }
    }
}
