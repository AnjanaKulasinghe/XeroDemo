using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using XeroDemo.Utilities;

namespace XeroDemo.Pages
{
    public class BasePage : DriverUtil
    {
        public const int DefaultWaitSeconds = 3;
        public const int DefaultRetyAttempts = 10;

        public bool VisitePage(string urlApender)
        {
            var Url = baseUrl + urlApender;
            try
            {
                WebDriver.Navigate().GoToUrl(Url);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool VisiteLoginPage()
        {
            var Url = loginUrl;
            try
            {
                WebDriver.Navigate().GoToUrl(Url);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IWebElement FindElement(By element)
        {
            for (var i = 0; i < DefaultRetyAttempts; i++)
            {
                var webElement = WebDriver.FindElement(element);
                if (webElement.Displayed)
                {
                    return webElement;
                }
                Thread.Sleep(TimeSpan.FromSeconds(DefaultWaitSeconds));
            }
            Assert.Fail("Expected element not found..");
            return null;
        }

        public void ClickButton(By element)
        {
            FindElement(element).Click();
        }

        public IWebElement EnterValue(By element, string value)
        {
            FindElement(element).Clear();
            FindElement(element).SendKeys(value);
            return FindElement(element);
        }

        public void ManageAutoFill(By element, string value)
        {
            EnterValue(element, value);
            Thread.Sleep(TimeSpan.FromSeconds(DefaultWaitSeconds));
            FindElement(element).SendKeys(Keys.Enter);
        }

        public bool CheckValueInThePage(string value)
        {
            for (var i = 0; i < DefaultRetyAttempts; i++)
            {
                if (WebDriver.PageSource.Contains(value))
                {
                    return true;
                }
                Thread.Sleep(TimeSpan.FromSeconds(DefaultWaitSeconds));
            }
            return false;
        }

        public bool CheckPageTitle(string pageTitle)
        {
            for (var i = 0; i < DefaultRetyAttempts; i++)
            {
                if (WebDriver.Title.Contains(pageTitle))
                {
                    return true;
                }
                Thread.Sleep(TimeSpan.FromSeconds(DefaultWaitSeconds));
            }
            return false;
        }

        public string FindDynamicIdValue(string staticElementText, char splitableValue)
        {
            var webElement = FindElement(By.XPath("//*[contains(@id,'" + staticElementText + "')]"));
            var elementId = webElement.GetAttribute("id");
            return elementId.Split(splitableValue)[1];
        }
    }
}