using Demo_Project.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Project
{
    internal class HomePageTest : BaseTest
    {
        private HomePage homePage;

        [SetUp]
        public void TestSetUp()
        {
            homePage = new HomePage(GetDriver());
        }
        [Category("TestWithoutAssertion")]
        [Test]
        public void SampleMethodwithDoubleClick()
        {
            Console.WriteLine("In Test1");

            homePage.doubleClickCopyTextButton();
            homePage.verifyTextCopied("Hello World!");
        }
        [Category("TestWithAssertion")]
        [Test]
        public void UsingSendKeysAndClear()
        {
            // This is a sample method for demonstration purposes.
            Console.WriteLine("In Test2");
            homePage.EnterName("Raj");
            homePage.clearText();
            Assert.That(GetDriver().FindElement(By.Id("name")).GetAttribute("value"), Is.EqualTo(""));
        }
        [Category("TestWithoutAssertion")]
        [Test]
        public void SelectDropdownTest()
        {
            Console.WriteLine("In Test3");
            homePage.selectCountry("India");
            homePage.verifySelectedCountry("India");
        }
        [Category("TestWithAssertion")]
        [Test]
        public void SelectCheckboxTest()
        {
            // This is a sample method for demonstration purposes.
            Console.WriteLine("In Test4");
            homePage.selectDay("Monday");
            //var daysCheckbox = GetDriver().FindElement(By.Id("sunday"));
            //if (!daysCheckbox.Selected)
            //{
            //    daysCheckbox.Click();
            //}
            
        }
    }
}
