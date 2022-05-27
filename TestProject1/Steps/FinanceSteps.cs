using ProjectPlanAutomation.PageObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace ProjectPlanAutomation.Steps
{
    [Binding]
    public sealed class FinanceSteps : SetUp
    {
        EmailPage emailPage;
        PasswordPage passwordPage;
        LogInPage logInPage;
        SignedInPage signedInPage;
        HomePage homePage;
        FinancePage financePage;

        [Given(@"i am logged into Advance")]
        public void GivenIAmLoggedIntoAdvance()
        {
            logInPage = new LogInPage(webDriver, wait);
            logInPage.ClickLogInButton();

            emailPage = new EmailPage(webDriver, wait);
            emailPage.WriteEmailText("automation.pp@amdaris.com");
            emailPage.PressNextBTN();

            passwordPage = new PasswordPage(webDriver, wait);
            passwordPage.WritePasswdText("10704-observe-MODERN-products-STRAIGHT-69112");
            passwordPage.PressNextBTN();

            signedInPage = new SignedInPage(webDriver, wait);
            signedInPage.ClickYesButton();

        }

        [Given(@"i am on Advance home page")]
        public void GivenIAmOnAdvanceHomePage()
        {
            homePage = new HomePage(webDriver, wait);
            homePage.GetUserHelloText("Hi Automation");
            
        }

        [When(@"i click Finance button")]
        public void WhenIClickFinanceButton()
        {
            homePage.ClickFinanceBTN();
        }

        [Then(@"i should see '(.*)' tab")]
        public void ThenIShouldSeeTab(string text)
        {
            financePage = new FinancePage(webDriver, wait);
            financePage.GetStatisticsText(text);
        }


        [When(@"i am on statistic page")]
        public void WhenIAmOnStatisticPage()
        {
            
            financePage.OpenActualsTab();
        }

        [When(@"i click Statistics tab")]
        public void WhenIClickStatisticsTab()
        {
            financePage = new FinancePage(webDriver, wait);
            financePage.OpenStatisticsCategory();
        }

        [When(@"i click Add Actual button")]
        public void WhenIClickAddActualButton()
        {
            financePage.ClickAddActualsBTN();
            financePage.GetAddActualContainerText("Add Actuals");
        }

        //[When(@"i choose year (.*) and month '(.*)'")]
        //public void WhenIChooseYearAndMonth(int year, string month)
        //{
            

        //}

        [When(@"i choose year and month")]
        public void WhenIChooseYearAndMonth()
        {
            financePage.ClickToSelectDateFromField();
            financePage.ChooseActualsYear();
            financePage.ChooseActualsMonth();
        }


        [When(@"i write average (.*)")]
        public void WhenIWrite(string average)
        {
            financePage.WriteAverageRate(average);
        }

        [When(@"i write revenue (.*)")]
        public void WhenIWriteRevenue(string revenue)
        {
            financePage.WriteRevenue(revenue);
        }

        [When(@"i click Save button")]
        public void WhenIClickSaveButton()
        {
            financePage.ClickSaveBTN();
        }

        [Then(@"i sould see confirmation popup with (.*)")]
        public void ThenISouldSeeConfirmationPopupWith(string popUptext)
        {
            financePage.CheckConfirmationAddActuals(popUptext);
        }





    }
}
