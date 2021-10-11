using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Azure;
using Azure.Storage.Files.DataLake;
using Azure.Storage.Files.DataLake.Models;
using Azure.Storage;
using System.IO;


namespace DataLakeBouncer.DLSGen2_Utilities
{
    public class Authenticator
    {
        public static DataLakeServiceClient GetDataLakeServiceClient(ref DataLakeServiceClient dataLakeServiceClient,
    string accountName, string accountKey)
        {
            try
            {
                StorageSharedKeyCredential sharedKeyCredential =
                new StorageSharedKeyCredential(accountName, accountKey);

                string dfsUri = "https://" + accountName + ".dfs.core.windows.net";

                dataLakeServiceClient = new DataLakeServiceClient
                    (new Uri(dfsUri), sharedKeyCredential);

                return dataLakeServiceClient;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in authenticate with credential given: {ex}");
                throw;
            }
        }
    }
}
