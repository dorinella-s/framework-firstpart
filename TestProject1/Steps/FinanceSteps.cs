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
        [Given(@"i am Logged in and i am on Finance page on Statistics category")]
        public void GivenIAmLoggedInAndIAmOnFinancePageOnStatisticsCategory()
        {
            logInPage.ClickLogInButton();

            emailPage.WriteEmailText("automation.pp@amdaris.com");
            emailPage.PressNextBTN();

            passwordPage.WritePasswdText("10704-observe-MODERN-products-STRAIGHT-69112");
            passwordPage.PressNextBTN();

            signedInPage.ClickYesButton();
            homePage.GetUserHelloText("Hi Automation");
            homePage.ClickFinanceBTN();
            financePage.OpenStatisticsCategory();


        }


        [When(@"i click Add Actual button")]
        public void WhenIClickAddActualButton()
        {
            financePage.ClickAddActualsBTN();
            financePage.GetAddActualContainerText("Add Actuals");
        }


        [When(@"i choose year '(.*)' and '(.*)' month")]
        public void WhenIChooseYearAndMonth(string year, string month)
        {
            financePage.ClickToSelectDateFromField();
            financePage.ChooseActualsYear(year);
            financePage.ChooseActualsMonth(month);
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
            financePage.CheckConfirmationActuals(popUptext);
        }


        [When(@"i click Edit button on existing actuals item '(.*)' (.*)")]
        public void WhenIClickEditButtonOnExistingActualsItem(string info, string id)
        {
            financePage.FindActuals(info);
            financePage.ClickEditActuals(id);

        }
        [When(@"i click Delete button on existing actuals item '(.*)' (.*)")]
        public void WhenIClickDeleteButtonOnExistingActualsItem(string info, string id)
        {
            financePage.FindActuals(info);
            financePage.ClickDeleteActuals(id);
        }

        [When(@"i click yes button on '(.*)' window")]
        public void WhenIClickYesButtonOnWindow(string question)
        {
            financePage.CheckDeleteQuestion(question);
        }






    }
}
