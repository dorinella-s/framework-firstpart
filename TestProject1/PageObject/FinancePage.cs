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
        private By _assertAdding => By.XPath("//span[contains(text(),'Actuals have successfully been created.')]");
        private By _assertDeleting => By.XPath("//span[.='Lead source deleted successfully']");
        private IWebElement _averageRate => webDriver.FindElement(By.XPath("//form/mat-dialog-content/mat-form-field[2]/div/div[1]/div/input"));
        private IWebElement _revenue => webDriver.FindElement(By.XPath("//form/mat-dialog-content/mat-form-field[3]/div/div[1]/div[1]/input"));
        private IWebElement _saveActuals => webDriver.FindElement(By.XPath("//mat-dialog-actions/button[2]/span[contains(text(),'Save')]"));
        private IWebElement _cancelActuals => webDriver.FindElement(By.XPath("//mat-dialog-actions/button[1]/span[contains(text(),'Cancel')]"));
        public void OpenStatisticsCategory()
        {
            wait.Until(ExpectedConditions
                .ElementToBeClickable(_statisticsCategory))
                .Click();
            Thread.Sleep(2000);
        }

        public void GetStatisticsText(string exceptedResult)
        {
            string actualResultStartText = wait.Until(ExpectedConditions
                .ElementIsVisible(_statisticsCategory))
                .Text;
            Assert.AreEqual(exceptedResult, actualResultStartText);
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
        public void ClickToSelectDateFromField()
        {
            wait.Until(ExpectedConditions
                .ElementToBeClickable(_dateInput))
                .Click();
        }

        //private Random gen = new Random();
        //DateTime RandomDay()
        //{
        //    DateTime start = new DateTime(1995, 1, 1);
        //    int range = (DateTime.Today - start).Days;
        //    return start.AddDays(gen.Next(range));
        //}
        //public string GetRandomYear()
        //{
        //    var random = new Random();
        //    string year = new string(Enumerable.Repeat("0123456789", 4)
        //               .Select(s => s[random.Next(s.Length)]).ToArray());
        //    return year;
        //}
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
                .SendKeys(average);
        }

        public void WriteRevenue(string revenue)
        {
            wait.Until(ExpectedConditions
                .ElementToBeClickable(_revenue))
                .SendKeys(revenue);
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

        public void CheckConfirmationAddActuals(string exceptedResult)
        {
            string actualResultPopUpConfirmation = wait.Until(ExpectedConditions
                .ElementIsVisible(_assertAdding))
                .Text;
            Assert.AreEqual(exceptedResult, actualResultPopUpConfirmation);
        }
    }
}
