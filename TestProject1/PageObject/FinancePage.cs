using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ProjectPlanAutomation.PageObject
{
    public class FinancePage : SetUp
    {
        private string _year;
        private string _month;
        private string _info;
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
        private IWebElement _yearActuals => webDriver.FindElement(By.XPath("//div[contains(text(),'" + _year + "')]"));
        private IWebElement _monthActuals => webDriver.FindElement(By.XPath("//div[contains(text(),'" + _month + "')]"));
        private By _assertPopUp => By.XPath("//span[contains(text(),'"+_info+"')]");
        private By _deletequestion => By.XPath("//mat-dialog-content/p[contains(text(),'Are you sure you want to delete this information?')]");
        private By _deleteYesBTN => By.XPath("//mat-dialog-actions[1]/button[1]");
        private By _deleteNoBTN => By.XPath("//mat-dialog-actions[1]/button[2]");
        private IWebElement _averageRate => webDriver.FindElement(By.XPath("//form/mat-dialog-content/mat-form-field[2]/div/div[1]/div/input"));
        private IWebElement _revenue => webDriver.FindElement(By.XPath("//form/mat-dialog-content/mat-form-field[3]/div/div[1]/div[1]/input"));
        private IWebElement _revenuValue => webDriver.FindElement(By.XPath("//div/span[contains(text(),'£')]"));
        private IWebElement _saveActuals => webDriver.FindElement(By.XPath("//mat-dialog-actions/button[2]/span[contains(text(),'Save')]"));
        private IWebElement _cancelActuals => webDriver.FindElement(By.XPath("//mat-dialog-actions/button[1]/span[contains(text(),'Cancel')]"));
        private By _actualDateItem => By.XPath("//span[contains(text(),'"+_info+"')]");
        private IWebElement _editActual => webDriver.FindElement(By.XPath("//mat-table[1]/mat-row[" + _info + "]/mat-cell[4]/div[1]/i[1]"));
        private IWebElement _deleteActual => webDriver.FindElement(By.CssSelector("i.fas.fa-times-circle:nth-child(2)"));
        private By _errorMessage => By.XPath("//mat-error[contains(text(),'" + _info + "')]");
        public void OpenStatisticsCategory()
        {
            wait.Until(ExpectedConditions
                .ElementToBeClickable(_statisticsCategory))
                .Click();
            Thread.Sleep(2000);
        }

        public void GetStatisticsText(string expectedResult)
        {
            string actualResultStartText = wait.Until(ExpectedConditions
                .ElementIsVisible(_statisticsCategory))
                .Text;
            Assert.AreEqual(expectedResult, actualResultStartText);
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
        public void GetAddActualContainerText(string expectedResult)
        {
            string actualResultStartText = wait.Until(ExpectedConditions
                .ElementIsVisible(_addActualsText))
                .Text;
            Assert.AreEqual(expectedResult, actualResultStartText);
        }
        public void ClickToSelectDateFromField()
        {
            wait.Until(ExpectedConditions
                .ElementToBeClickable(_dateInput))
                .Click();
        }

        public void ChooseActualsYear(string year)
        {

            _year = year;
            wait.Until(ExpectedConditions
                .ElementToBeClickable(_yearActuals))
                .Click();
        }

        public void ChooseActualsMonth(string month)
        {
            _month = month;
            wait.Until(ExpectedConditions
                .ElementToBeClickable(_monthActuals))
                .Click();
        }


        public void WriteAverageRate(string average)
        {
            wait.Until(ExpectedConditions
                .ElementToBeClickable(_averageRate))
                .Clear();

            wait.Until(ExpectedConditions
                .ElementToBeClickable(_averageRate))
                .SendKeys(average);
        }

        public void WriteRevenue(string revenue)
        {
            wait.Until(ExpectedConditions
                .ElementToBeClickable(_revenue))
                .Clear();

            wait.Until(ExpectedConditions
                .ElementToBeClickable(_revenue))
                .SendKeys(revenue);

            wait.Until(ExpectedConditions
                .ElementToBeClickable(_revenuValue))
                .Click();

        }
        public void FindActuals(string info)
        {
            _info = info;

            string actualResultElement = wait.Until(ExpectedConditions
            .ElementIsVisible(_actualDateItem))
            .Text;
            Assert.AreEqual(info, actualResultElement);
        }
        public void ClickEditActuals(string info)
        {
            _info = info;
            wait.Until(ExpectedConditions
                .ElementToBeClickable(_editActual))
                .Click();
        }

        public void ClickDeleteActuals(string info)
        {
            _info = info;
            wait.Until(ExpectedConditions
                .ElementToBeClickable(_deleteActual))
                .Click();
        }
        public void CheckDeleteQuestion(string expectedResult)
        {
            _info = expectedResult;
            string actualResultPopUpConfirmation = wait.Until(ExpectedConditions
                .ElementIsVisible(_deletequestion))
                .Text;
            Assert.AreEqual(expectedResult, actualResultPopUpConfirmation);
           
            wait.Until(ExpectedConditions
                .ElementToBeClickable(_deleteYesBTN))
                .Click();
        }
        public void CheckDeleteQuestionAndClickNO(string expectedResult)
        {
            _info = expectedResult;
            string actualResultPopUpConfirmation = wait.Until(ExpectedConditions
                .ElementIsVisible(_deletequestion))
                .Text;
            Assert.AreEqual(expectedResult, actualResultPopUpConfirmation);

            wait.Until(ExpectedConditions
                .ElementToBeClickable(_deleteNoBTN))
                .Click();
        }

        public void ClickSaveBTN()
        {
            wait.Until(ExpectedConditions
                .ElementToBeClickable(_saveActuals))
                .Click();
        }

        public void ClickCancelBTN()
        {
            wait.Until(ExpectedConditions
                .ElementToBeClickable(_cancelActuals))
                .Click();
        }

        public void CheckConfirmationActuals(string expectedResult)
        {
            _info = expectedResult;
            string actualResultPopUpConfirmation = wait.Until(ExpectedConditions
                .ElementIsVisible(_assertPopUp))
                .Text;
            Assert.AreEqual(expectedResult, actualResultPopUpConfirmation);
        }

        public void CheckErrorMessage(string expectedResult)
        {
            _info = expectedResult;
            string actualResultError = wait.Until(ExpectedConditions
                .ElementIsVisible(_errorMessage))
                .Text;
            Assert.That(actualResultError, Does.Contain(expectedResult).IgnoreCase);
        }
    }
}
