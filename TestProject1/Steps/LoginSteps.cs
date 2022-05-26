using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ProjectPlanAutomation.PageObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ProjectPlanAutomation.Steps
{
    [Binding]
    public sealed class LoginSteps : SetUp
    {
        EmailPage emailPage;
        PasswordPage passwordPage;
        LogInPage logInPage;
        SignedInPage signedInPage;
        HomePage homePage;


        [Given(@"i am on Advance login page")]
        public void GivenIAmOnAdvanceLoginPage()
        {
            SetUpDriver();
        }


        [When(@"i click login button")]
        public void WhenIClickLoginButton()
        {
            logInPage = new LogInPage(webDriver, wait);
            logInPage.ClickLogInButton();
        }

        [When(@"i write email (.*)")]
        public void WhenIWriteEmail(string email)
        {
            emailPage = new EmailPage(webDriver, wait);
            emailPage.WriteEmailText(email);
        }

        [When(@"i press next button on email page")]
        public void WhenIPressNextButtonOnEmailPage()
        {
            emailPage.PressNextBTN();
        }

        [When(@"i write password (.*)")]
        public void WhenIWritePassword(string password)
        {
            passwordPage = new PasswordPage(webDriver, wait);
            passwordPage.WritePasswdText(password);
        }


        [When(@"i press next button on password page")]
        public void WhenIPressNextButtonOnPasswordPage()
        {
            passwordPage.PressNextBTN();
        }

        [When(@"i press next button on question page")]
        public void WhenIPressNextButtonOnQuestionPage()
        {
            signedInPage = new SignedInPage(webDriver, wait);
            signedInPage.ClickYesButton();
        }

        [Then(@"i can see (.*)")]
        public void ThenICanSeeHelloUserText(string helloUser)
        {
            homePage = new HomePage(webDriver, wait);
            homePage.GetUserHelloText(helloUser);
            TearDown();
        }

    }
}
