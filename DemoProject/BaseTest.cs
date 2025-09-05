using Demo_Project.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            
            //driver.Manage().Window.Maximize();
            // Replace this line:
            // IJavaScriptExecutor js = (IJavaScriptExecutor)driver.getJavascriptExecutor();
            // With the following:
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(d => js.ExecuteScript("return document.readyState").Equals("complete"));
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
                    chromeOptions.UnhandledPromptBehavior = UnhandledPromptBehavior.Ignore;
                    var svc = ChromeDriverService.CreateDefaultService();
                    svc.Start();
                    string headlessWindowResolution = ConfigurationProvider.configuation["HeadlessWindowResolution"];
                    if (!String.IsNullOrEmpty(headlessWindowResolution))

                    {
                        string pattern = @"^[1-9][0-9]{2,3}x[1-9][0-9]{2,3}$";
                        Regex rg = new Regex(pattern, RegexOptions.IgnoreCase);

                        //format of providing the resolution would be 1920x1080
                        if (rg.Match(headlessWindowResolution).Success)
                        {
                            headlessWindowResolution = headlessWindowResolution.ToLower().Replace('x', ',');
                        }
                        else
                        {
                            //if user is not providing the resolution in 1920X1080 format then it will default it to 1920x1080
                            headlessWindowResolution = "1920,1080";
                        }
                    }
                    else
                    {
                        headlessWindowResolution = "1920,1080";
                    }
                    string uniqueUserDataDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
                    chromeOptions.AddArgument($"--user-data-dir={uniqueUserDataDir}");
                    chromeOptions.AddArgument("--headless=new");
                    chromeOptions.AddArgument("--no-sandbox");
                    chromeOptions.AddArgument("--disable-dev-shm-usage");
                    return new ChromeDriver(svc, chromeOptions);
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
