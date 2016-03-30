namespace XeroDemo.Utilities
{
    public class ExcelData
    {
        public static ClosedExcelDataAccess Login = new ClosedExcelDataAccess("Login.xlsx", ResourceController.Login);
        public static ClosedExcelDataAccess Sales = new ClosedExcelDataAccess("Sales.xlsx", ResourceController.Sales);
    }
}