using DataLakeBouncer.DLSGen2_Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLakeBouncer
{
    internal class Orchestrator
    {
        DirManager dm;

        public void InitializeSession(String storageName)
        {
            dm = new DirManager(storageName);
            if (dm == null)
            {
                //TODO
                //return error message, to check appsettings file
            }
        }

        public List<String> GetFileSystems()
        {
            return dm.GetFileSystems();
        }
    }
}
