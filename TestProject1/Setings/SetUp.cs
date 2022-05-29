using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using ProjectPlanAutomation.PageObject;

namespace ProjectPlanAutomation
{
    public class SetUp
    {
        protected IWebDriver webDriver;
        protected WebDriverWait wait;
        protected LogInPage logInPage;
        protected EmailPage emailPage;
        protected PasswordPage passwordPage;
        protected SignedInPage signedInPage;
        protected HomePage homePage;
        protected FinancePage financePage;

        [BeforeScenario]
        public void SetUpDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");
            options.AddArguments("--disable-default-apps");
            options.AddArguments("--incognito");
            webDriver = new ChromeDriver(options);
            webDriver.Navigate().GoToUrl("https://projectplanappweb-stage.azurewebsites.net/login");
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
            wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(30));
            logInPage = new LogInPage(webDriver, wait);
            emailPage = new EmailPage(webDriver, wait);
            passwordPage = new PasswordPage(webDriver, wait);
            signedInPage = new SignedInPage(webDriver, wait);
            homePage = new HomePage(webDriver, wait);
            financePage = new FinancePage(webDriver, wait);
        }
        
        [AfterScenario]
        public void TearDown()
        {
            webDriver.Close();
            webDriver.Quit();
        }

    }
}
