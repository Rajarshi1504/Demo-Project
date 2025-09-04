using Demo_Project.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Project
{
    internal class BaseTest
    {
        private IWebDriver driver;
        protected IWebDriver GetDriver() { 
            return driver; 
        }


        [SetUp]
        public void SetUp()
        {
            // This is a sample setup method for demonstration purposes.
            Console.WriteLine("Hello, World!");
            driver = CreateDriver(ConfigurationProvider.configuation["browser"]);
            driver.Navigate().GoToUrl("https://testautomationpractice.blogspot.com/");
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            // This is a sample teardown method for demonstration purposes.
            Console.WriteLine("Test completed.");
            // NUnit1032: Dispose the driver in TearDown
            if (driver   != null)
            {
                driver.Quit();
                driver.Dispose();
                driver = null;
            }
        }

        private IWebDriver CreateDriver(string BrowserName)
        {
            switch (BrowserName)
            {
                case "Chrome":
                    var chromeOptions = new ChromeOptions();
                    // Uncomment below if you need a unique user data dir for each session
                    string uniqueUserDataDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
                    chromeOptions.AddArgument($"--user-data-dir={uniqueUserDataDir}");
                    return new ChromeDriver(chromeOptions);
                case "FireFox":
                    return new FirefoxDriver();
                case "Edge":
                    return new OpenQA.Selenium.Edge.EdgeDriver();
                // Add cases for other browsers as needed
                default:
                    throw new ArgumentException($"Unsupported browser: {BrowserName}");
            }
        }
    }
}
