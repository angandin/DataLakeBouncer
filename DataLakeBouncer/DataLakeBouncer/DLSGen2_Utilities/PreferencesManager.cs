using System;
using System.Collections.Generic;
using System.Configuration;
using System.Collections.Specialized;

namespace DataLakeBouncer.DLSGen2_Utilities
{
    public class PreferencesManager
    {
        public static List<String> GetSavedDataLake()
        {
            try
            {
                List<String> storageList = new List<string>();

                var cs = ConfigurationManager.AppSettings;
                foreach (var key in cs.AllKeys)
                {
                    storageList.Add(key);
                }

                return storageList;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Exception in retrieving AppSettings Config: {ex}");
                throw;
            }
        }

        public static String GetAccessKey(String storageName)
        {
            try
            {
                string ak = ConfigurationManager.AppSettings.Get(storageName);
                return ak;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Storage Name not found: {ex}");
                return null;
            }
        }
    }
}
