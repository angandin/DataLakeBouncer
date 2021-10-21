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

        public List<DirItem> GetNodes()
        {
            try
            {
                IEnumerator<FileSystemItem> fsEnum = dlsc.GetFileSystems().GetEnumerator();
                fsEnum.MoveNext();
                FileSystemItem fs = fsEnum.Current;
                
                List<DirItem> fsList = new List<DirItem>();
                while (fs != null)
                {
                    DirItem di = new DirItem(fs.Name, true, DirItem.ExplorerItemType.Folder);
                    DirItem diDumb = new DirItem("None", true, DirItem.ExplorerItemType.None);
                    di.Children.Add(diDumb);
                    fsList.Add(di);

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

        //public List<PathItem> GetDirItems(String fileSystemName)
        //{ 
        //    if(dlfsc == null)
        //        dlfsc = dlsc.GetFileSystemClient(fileSystemName);

        //}
    }
}
