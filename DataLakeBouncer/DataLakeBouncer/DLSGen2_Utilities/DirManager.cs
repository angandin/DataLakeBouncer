using Azure.Storage.Files.DataLake;
using Azure.Storage.Files.DataLake.Models;
using System;
using System.Collections.Generic;
using Azure;
using Azure.Storage;
using System.IO;
using System.Threading.Tasks;

namespace DataLakeBouncer.DLSGen2_Utilities
{
    public class DirManager
    {
        DataLakeServiceClient dlsc;

        public DirManager(String storageName)
        {
            try
            {
                string ak = PreferencesManager.GetAccessKey(storageName);
                if(ak != null)
                {
                    dlsc = Authenticator.GetDataLakeServiceClient(ref dlsc, storageName, ak);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Exception in authenticate to Storage Account: {ex}");
                throw;
            }
        }

        public List<String> GetFileSystems()
        {
            try
            {
                IEnumerator<FileSystemItem> fsEnum = dlsc.GetFileSystems().GetEnumerator();
                fsEnum.MoveNext();
                FileSystemItem fs = fsEnum.Current;

                List<String> fsList = new List<String>();
                while (fs != null)
                {
                    fsList.Add(fs.Name);

                    fsEnum.MoveNext();
                    fs = fsEnum.Current;
                }

                return fsList;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in retrieving File System List: {ex}");
                throw;
            }
            
        }
    }
}
