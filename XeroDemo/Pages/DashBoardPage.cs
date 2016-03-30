using XeroDemo.Utilities;

namespace XeroDemo.Pages
{
    public class DashBoardPage : BasePage
    {
        public void VerifyPage()
        {
            // Varify page
            CheckValueInThePage(ExcelData.Login.GetValue("LoginPage", "B4"));
        }
    }
}