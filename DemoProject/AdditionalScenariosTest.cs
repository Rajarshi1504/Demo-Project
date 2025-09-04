using Demo_Project.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Project
{
    internal class AdditionalScenariosTest: BaseTest
    {
        private HomePage homePage;
        [SetUp]
        public new void SetUp()
        {
            homePage = new HomePage(GetDriver());
        }
        [Test]
        public void ScrollToElement()
        {
            homePage.enterName("Raj");
            homePage.scrollToElement(By.Id("country"));
            homePage.selectCountry("India");
            homePage.doubleClickCopyTextButton();
        }

        [Test]
        public void HandleAllertsAndConfirmations()
        {
            homePage.clickOnSimpleAlertButton();
            Thread.Sleep(2000);
            homePage.clickOnOKAlert();
            Thread.Sleep(2000);
            homePage.clickOnConfirmationAlertButton();
            //var confirmationPopup = GetDriver().FindElement(By.Id("confirmBtn"));
            homePage.clickOnCancelAlert();
            Thread.Sleep(2000);
        }
        [Test]
        public void handleWindows()
        {
            homePage.clickOnOpenWindowButton();
            Thread.Sleep(2000);
            homePage.switchToNewWindow();
            Thread.Sleep(2000);
            homePage.switchToParentWindow();
            Thread.Sleep(2000);
        }
    }
}
