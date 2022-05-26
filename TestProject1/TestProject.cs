using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ProjectPlanAutomation.PageObject;
using SeleniumExtras.WaitHelpers;
using System.Threading;

namespace ProjectPlanAutomation
{
    public class ProjectPlanAutomation : SetUp
    {

        [Test]
        public void LoginSuccessfulIntoAdminAccount()
        {
            

            EmailPage emailPage = new EmailPage(webDriver, wait);


            PasswordPage passwordPage = new PasswordPage(webDriver, wait);


            SignedInPage signedInPage = new SignedInPage(webDriver, wait);
            signedInPage.ClickYesButton();

            HomePage homePage = new HomePage(webDriver, wait);
        }
        [Test]
        public void LoginWithInvalidEmail()
        {
            LogInPage logInPage = new LogInPage(webDriver, wait);
            logInPage.ClickLogInButton();

            EmailPage emailPage = new EmailPage(webDriver, wait);
            emailPage.WriteEmailText("hello @ . com");
            emailPage.PressNextBTN();
            emailPage.CheckErrorMessage("Enter a valid email address, phone number or Skype name.");
        }

        [Test]
        public void LoginWithInvalidPassword()
        {
            LogInPage logInPage = new LogInPage(webDriver, wait);
            logInPage.ClickLogInButton();

            EmailPage emailPage = new EmailPage(webDriver, wait);
            emailPage.WriteEmailText("automation.pp@amdaris.com");
            emailPage.PressNextBTN();

            PasswordPage passwordPage = new PasswordPage(webDriver, wait);
            passwordPage.WritePasswdText("aaaaaaaaaaaaaa123");
            passwordPage.PressNextBTN();

            passwordPage.CheckErrorMessage("Your account or password is incorrect. If you can't remember your password, reset it now.");
        }

        [Test]
        public void FilterNotificationByEntityType()
        {
            LoginSuccessfulIntoAdminAccount();

            HomePage homePage = new HomePage(webDriver, wait);
            homePage.ClickNotificationBTN();
            homePage.ClickFilterIcon();
            homePage.ClickEntityType();
            homePage.FindEntityType("Opportunity");
            homePage.ChooseOportunityType();
        }

        [Test]
        public void SearchProjectWithSpecificWord()
        {
            LoginSuccessfulIntoAdminAccount();

            ProjectPage projectPage = new ProjectPage(webDriver, wait);
            projectPage.OpenProjectPage();
            projectPage.WriteProjectName("Amdaris");
            projectPage.FindProjectByName("Amdaris");
            projectPage.CheckNumberOfResults();

        }
        [Test]
        public void SearchInexistingProject()
        {
            LoginSuccessfulIntoAdminAccount();

            ProjectPage projectPage = new ProjectPage(webDriver, wait);
            projectPage.OpenProjectPage();
            projectPage.WriteProjectName("----");
            projectPage.FindInexistingProject("No Such Projects");

        }
    }
}