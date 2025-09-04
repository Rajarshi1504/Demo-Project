using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Demo_Project.Pages
{
    internal class HomePage : BasePage
    {

        public HomePage(IWebDriver driver) : base(driver)
        {

        }
        private SelectElement country;

        private By name => By.Id("name");
        private By emailID => By.Id("email");
        private By phone => By.Id("phone");
        private By genderCheckbox(string gender) => By.XPath($"//label[text()='{gender}']");
        private By copyTextButton => By.XPath("//button[text()='Copy Text']");
        private By countryDropdown => By.XPath($"//select[@id='country']");
        private By simpleAlertButton => By.Id("alertBtn");
        private By confirmAlertButton => By.Id("confirmBtn");
        private By popupWindowButton => By.Id("PopUp");
        private By selectDayCheckbox(string day) => By.Id(day.ToLower());

        public void EnterName(string Name)
        {
            driver.FindElement(name).SendKeys(Name);
        }

        public void EnterEmailID(string EmailID)
        {
            driver.FindElement(emailID).SendKeys(EmailID);
        }

        public void EnterPhone(string Phone)
        {
            driver.FindElement(phone).SendKeys(Phone);
        }

        public void SelectGender(string gender)
        {
            driver.FindElement(genderCheckbox(gender)).Click();
        }

        public void doubleClickCopyTextButton()
        {
            //waitUntilElementPresent(copyTextButton, 10);
            var copyTextButtonElement = driver.FindElement(copyTextButton);
            var actions = new Actions(driver);
            actions.DoubleClick(copyTextButtonElement).Perform();
        }

        public void verifyTextCopied(string expectedText)
        {
            var copiedText = driver.FindElement(By.Id("field2")).GetAttribute("value");
            Assert.That(copiedText, Is.EqualTo(expectedText));
        }

        public void enterName(string Name)
        {
            //waitUntilElementPresent(name, 10);
            driver.FindElement(name).SendKeys(Name);
        }

        public void clearText()
        {
            var NameInputField = driver.FindElement(name);
            NameInputField.Clear();
        }

        public void selectCountry(string countryName)
        {
            //waitUntilElementPresent(countryDropdown, 10);
            var CountryDropDown = driver.FindElement(countryDropdown);
            country = new SelectElement(CountryDropDown);
            country.SelectByText(countryName);
        }

        public void selectDay(string day)
        {
            var daysCheckbox = driver.FindElement(selectDayCheckbox(day));
            //waitUntilElementPresent(selectDayCheckbox(day), 10);
            if (!daysCheckbox.Selected)
            {
                daysCheckbox.Click();
            }
            Assert.That(daysCheckbox.Selected, Is.True);
        }

        public void verifySelectedCountry(string expectedCountry)
        {
            var selectedCountry = country.SelectedOption.Text;
            Assert.That(selectedCountry, Is.EqualTo(expectedCountry));
        }

        public void scrollToElement(By elementBy)
        {
            ScrollToElement(elementBy);
        }

        public void clickOnSimpleAlertButton()
        {
            waitUntilElementPresent(simpleAlertButton, 10);
            driver.FindElement(simpleAlertButton).Click();
        }
        public void clickOnConfirmationAlertButton()
        {
            driver.FindElement(confirmAlertButton).Click();
        }
        public void clickOnOKAlert()
        {
            acceptAlert();
        }
        public void clickOnCancelAlert()
        {
            dismissAlert();
        }
        public void clickOnOpenWindowButton()
        {
            //waitUntilElementPresent(popupWindowButton, 10);
            var openWindowButton = driver.FindElement(popupWindowButton);
            openWindowButton.Click();
        }

        public void switchToNewWindow()
        {
            // driver.SwitchTo().NewWindow(WindowType.Window);
            var window2 = driver.CurrentWindowHandle;
            driver.SwitchTo().Window(window2);
        }

        public void switchToParentWindow()
        {
            var parentWindow = driver.WindowHandles.First();
            driver.SwitchTo().Window(parentWindow);
        }
    }
}
