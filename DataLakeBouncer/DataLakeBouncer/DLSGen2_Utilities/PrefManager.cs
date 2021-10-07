using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataLakeBouncer.DLSGen2_Utilities
{
    public class PreferencesManager
    {
        public Dictionary<String, String> GetSavedDataLake()
        {
            Dictionary<String, String> dlsDict = new Dictionary<string, string>();

            dlsDict.Add("gandodlsgen2", "");

            return dlsDict;
        }
    }
}
