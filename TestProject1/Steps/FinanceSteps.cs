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
        

        [Given(@"i am logged into Advance")]
        public void GivenIAmLoggedIntoAdvance()
        {
            logInPage.ClickLogInButton();
      
            emailPage.WriteEmailText("automation.pp@amdaris.com");
            emailPage.PressNextBTN();
    
            passwordPage.WritePasswdText("10704-observe-MODERN-products-STRAIGHT-69112");
            passwordPage.PressNextBTN();

            signedInPage.ClickYesButton();

        }

        [Given(@"i am on Advance home page")]
        public void GivenIAmOnAdvanceHomePage()
        {
            
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
            financePage.CheckConfirmationAddActuals(popUptext);
        }





    }
}
