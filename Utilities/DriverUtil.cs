using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace XeroDemo.Utilities
{
    [Binding]
    public class DriverUtil : CommomUtil
    {
        public static IWebDriver WebDriver;
        public static string baseUrl = SystemDataDictionary[CommonConstants.BaseUrl];
        public static string loginUrl = SystemDataDictionary[CommonConstants.LoginUrl];

        [BeforeScenario]
        public static void DriverInitiation()
        {
            WebDriver = new ChromeDriver();
            WebDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            WebDriver.Navigate().GoToUrl(baseUrl);
        }

        [AfterScenario]
        public static void TearDown()
        {
            WebDriver.Quit();
        }
    }
}