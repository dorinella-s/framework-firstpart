using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectPlanAutomation
{
    public class SetUp
    {
        protected IWebDriver webDriver;
        protected WebDriverWait wait;

        [SetUp]
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
        }

        [TearDown]
        public void TearDown()
        {
            webDriver.Close();
            webDriver.Quit();
        }

    }
}
