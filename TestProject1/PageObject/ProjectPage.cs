using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectPlanAutomation.PageObject
{
    public class ProjectPage : SetUp
    {
        
        public ProjectPage(IWebDriver webDriver, WebDriverWait wait)
        {
            base.webDriver = webDriver;
            base.wait = wait;
        }
        private IWebElement _projectBTN => webDriver.FindElement(By.CssSelector("a#projects-tab"));
        private IWebElement _searchField => webDriver.FindElement(By.CssSelector("input.input-search"));
        private IWebElement _searchResult => webDriver.FindElement(By.CssSelector("app-project-item > div > div > a > h5 > span"));
        private IWebElement _searchNotFound => webDriver.FindElement(By.XPath(("//div[contains(text(),'No Such Projects')]")));
        private By _numberOfResults => By.CssSelector("div.num");
        public void OpenProjectPage()
        {
            wait.Until(ExpectedConditions
                .ElementToBeClickable(_projectBTN))
                .Click();
        }

        public void WriteProjectName(string name)
        {
            wait.Until(ExpectedConditions
                .ElementToBeClickable(_searchField))
                .SendKeys(name);
        }
        public void FindProjectByName(string expectedResult)
        {
            string actualSearchResult = wait.Until(ExpectedConditions
                                            .ElementToBeClickable(_searchResult))
                                            .Text;
            Assert.That(actualSearchResult, Does.Contain(expectedResult).IgnoreCase);
        }

        public void CheckNumberOfResults()
        {
            string actualSearchResult = wait.Until(ExpectedConditions
                .ElementIsVisible(_numberOfResults))
                .Text;
            Assert.IsNotNull(actualSearchResult);
        }

        public void FindInexistingProject(string expectedResult)
        {
            string actualSearchResult = wait.Until(ExpectedConditions
                                            .ElementToBeClickable(_searchNotFound))
                                            .Text;
            Assert.That(actualSearchResult, Does.Contain(expectedResult).IgnoreCase);
        }


    }
}
