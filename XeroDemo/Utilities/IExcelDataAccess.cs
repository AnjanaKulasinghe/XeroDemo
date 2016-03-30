namespace XeroDemo.Utilities
{
    internal interface IExcelDataAccess
    {
        string GetValue(string workSheetName, string cellAddress);
    }
}