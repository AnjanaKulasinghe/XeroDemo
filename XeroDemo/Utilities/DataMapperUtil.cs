using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace XeroDemo.Utilities
{
    public static class DataMapperUtil
    {
        public static Dictionary<string, string> SetDataDictionary(string fileName)
        {
            var data = new Dictionary<string, string>();
            foreach (var row in File.ReadAllLines("./DataFiles/" + fileName))
                data.Add(row.Split('=')[0], string.Join("=", row.Split('=').Skip(1).ToArray()));
            return data;
        }
    }
}