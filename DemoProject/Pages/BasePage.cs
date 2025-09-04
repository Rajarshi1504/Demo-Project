using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Demo_Project.Pages
{
    internal class BasePage
    {
        protected IWebDriver driver;
        protected BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        protected void ScrollToElement(By elementBy)
        {
            var element = driver.FindElement(elementBy);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            Thread.Sleep(500); // Optional: Pause to allow for scrolling animation
        }

        protected void acceptAlert()
        {
            try
            {
                var alert = driver.SwitchTo().Alert();
                alert.Accept();
            }
            catch (NoAlertPresentException)
            {
                // No alert to accept
            }
        }

        protected void dismissAlert()
        {
            try
            {
                var alert = driver.SwitchTo().Alert();
                alert.Dismiss();
            }
            catch (NoAlertPresentException)
            {
                // No alert to dismiss
            }
        }

        public void waitUntilElementPresent(By element, int timeinseconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeinseconds));
            wait.Until(ExpectedConditions.ElementIsVisible(element));
        }
    }
}
