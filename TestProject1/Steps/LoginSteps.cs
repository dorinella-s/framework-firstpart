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
            logInPage = new LogInPage(webDriver, wait);
        }


        [When(@"i click login button")]
        public void WhenIClickLoginButton()
        {
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


        [When(@"i press yes button on question page")]
        public void WhenIPressYesButtonOnQuestionPage()
        {
            signedInPage = new SignedInPage(webDriver, wait);
            signedInPage.ClickYesButton();
        }

        [When(@"i press no button on question page")]
        public void WhenIPressNoButtonOnQuestionPage()
        {
            signedInPage = new SignedInPage(webDriver, wait);
            signedInPage.ClickNoButton();
        }

        [Then(@"i can see (.*)")]
        public void ThenICanSeeHelloUserText(string helloUser)
        {
            homePage = new HomePage(webDriver, wait);
            homePage.GetUserHelloText(helloUser);
        }

        [When(@"i write invalid email '(.*)'")]
        public void WhenIWriteInvalidEmail(string email)
        {
            emailPage = new EmailPage(webDriver, wait);
            emailPage.WriteEmailText(email);
        }

        [Then(@"I Should See Error Message '(.*)' on the email page")]
        public void ThenIShouldSeeErrorMessageOnTheEmailPage(string errorMessage)
        {
            emailPage.CheckErrorMessage(errorMessage);
        }
        //invalid password test
        [When(@"i write invalid password '(.*)'")]
        public void WhenIWriteInvalidPassword(string password)
        {
            passwordPage = new PasswordPage(webDriver, wait);
            passwordPage.WritePasswdText(password);
        }

        [Then(@"I Should See Error Message on the password page '(.*)'")]
        public void ThenIShouldSeeErrorMessageOnThePasswordPageTRememberYourPasswordResetItNow_(string errorMessage)
        {
            passwordPage.CheckErrorMessage(errorMessage);
        }


    }
}
