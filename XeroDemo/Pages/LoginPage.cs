using NUnit.Framework;
using OpenQA.Selenium;
using XeroDemo.Utilities;

namespace XeroDemo.Pages
{
    public class LoginPage : BasePage
    {
        public string url = "";

        public void GotoLoginPage()
        {
            Assert.True(VisiteLoginPage(), "Navigating to Login page failed.");
        }

        public void LoginToTheSystem(string userName = "Default", string password = "Default")
        {
            // Set value for UserName field
            if (userName.Equals("Default"))
                userName = ExcelData.Login.GetValue("LoginPage", "B2");

            // Set value for Password field
            if (password.Equals("Default"))
                password = ExcelData.Login.GetValue("LoginPage", "B3");

            // Login to the application
            FindElement(By.Id(ExcelData.Login.GetValue("LoginPage", "E2"))).SendKeys(userName);
            FindElement(By.Id(ExcelData.Login.GetValue("LoginPage", "E3"))).SendKeys(password);
            FindElement(By.Id(ExcelData.Login.GetValue("LoginPage", "E4"))).Click();
        }
    }
}