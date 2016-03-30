using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using XeroDemo.Utilities;

namespace XeroDemo.Pages
{
    internal class RepeatingInvoicePage : BasePage
    {
        public char SplitableValue = '_';
        public string StaticElementText = ExcelData.Sales.GetValue("RepInvoPage", "E10");
        public string url = "RepeatTransactions/Edit.aspx?type=AR";

        public void GotoRepeatingInvoicePage()
        {
            Assert.True(VisitePage(url), "Navigating to Repeating Invoice Page failed.");
        }

        public void VerifyPage()
        {
            CheckPageTitle(ExcelData.Sales.GetValue("RepInvoPage", "B2"));
        }

        public void VerifyMessage(string message = "Default")
        {
            if (message == "Default")
                message = ExcelData.Sales.GetValue("RepInvoPage", "B17");

            Assert.True(CheckValueInThePage(message), "Expected Message not found.");
        }

        public void PlaceRepeatingInvoice(string value = "Successfull")
        {
            switch (value)
            {
                case "DueDate":
                    PlaceRepeatingInvoice(false, true, true, true);
                    break;
                case "ActionStatus":
                    PlaceRepeatingInvoice(true, false, true, true);
                    break;
                case "InvoiceTo":
                    PlaceRepeatingInvoice(true, true, false, true);
                    break;
                case "Item":
                    PlaceRepeatingInvoice(true, true, true, false);
                    break;
                case "Successfull":
                    PlaceRepeatingInvoice(true, true, true, true);
                    break;
                default:
                    Assert.Fail("Invalid selection.");
                    break;
            }
        }

        public void PlaceRepeatingInvoice(bool dueDate, bool actionStatus, bool invoiceTo, bool item)
        {
            // Set invoice due date
            if (dueDate)
                SetDueDate();

            // Set action status
            if (actionStatus)
                SetActionStatus();

            // Set Invoice to persn
            if (invoiceTo)
                SetInvoiceTo();

            // Set Item
            if (item)
                SetItem();

            // Submit repeating invoice
            SubmitRequest();
        }

        public void SubmitRequest()
        {
            ClickButton(By.XPath(ExcelData.Sales.GetValue("RepInvoPage", "E17")));
        }

        public void SetDueDate(string value = "Default")
        {
            if (value == "Default")
                value = ExcelData.Sales.GetValue("RepInvoPage", "B3");

            EnterValue(By.Id(ExcelData.Sales.GetValue("RepInvoPage", "E7")), value);
        }

        public void SetActionStatus(string value = "Default")
        {
            if (value == "Default")
                value = ExcelData.Sales.GetValue("RepInvoPage", "B8");

            if (value.Equals(ExcelData.Sales.GetValue("RepInvoPage", "B8")))
                FindElement(By.Id(ExcelData.Sales.GetValue("RepInvoPage", "E6"))).Click();

            if (value.Equals(ExcelData.Sales.GetValue("RepInvoPage", "B14")))
                FindElement(By.Id(ExcelData.Sales.GetValue("RepInvoPage", "E14"))).Click();

            if (value.Equals(ExcelData.Sales.GetValue("RepInvoPage", "B15")))
                FindElement(By.Id(ExcelData.Sales.GetValue("RepInvoPage", "E15"))).Click();
        }

        public void SetInvoiceTo(string value = "Default")
        {
            if (value == "Default")
                value = ExcelData.Sales.GetValue("RepInvoPage", "B9");

            ManageAutoFill(
                By.Id(ExcelData.Sales.GetValue("RepInvoPage", "E8") +
                      FindDynamicIdValue(StaticElementText, SplitableValue) +
                      ExcelData.Sales.GetValue("RepInvoPage", "E9")), value);
        }

        public void SetItem(string value = "Default")
        {
            if (value == "Default")
                value = ExcelData.Sales.GetValue("RepInvoPage", "B13");

            FindElement(By.ClassName(ExcelData.Sales.GetValue("RepInvoPage", "E16"))).Click();
            var itemElement = WebDriver.SwitchTo().ActiveElement();
            itemElement.SendKeys(value);
            Thread.Sleep(TimeSpan.FromSeconds(DefaultWaitSeconds));
            itemElement.SendKeys(Keys.Enter);
        }
    }
}