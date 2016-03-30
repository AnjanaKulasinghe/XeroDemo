using System.Collections.Generic;

namespace XeroDemo.Utilities
{
    public class CommomUtil
    {
        public static Dictionary<string, string> SystemDataDictionary =
            DataMapperUtil.SetDataDictionary(CommonConstants.DataPrompts);
    }
}