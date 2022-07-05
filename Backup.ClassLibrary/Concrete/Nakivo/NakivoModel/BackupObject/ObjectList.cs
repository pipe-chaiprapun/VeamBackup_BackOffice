using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup.ClassLibrary.Concrete.Nakivo.NakivoModel.BackupObject
{

    public class ObjectList
    {
        public string action { get; set; }
        public string method { get; set; }
        public string tid { get; set; }
        public string type { get; set; }
        public object message { get; set; }
        public object where { get; set; }
        public object cause { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public Child[] children { get; set; }
    }

    public class Child
    {
        public int id { get; set; }
        public string uuid { get; set; }
        public string name { get; set; }
        public string hvType { get; set; }
        public DateTime updated { get; set; }
        public string repositoryVid { get; set; }
        public string transporterVid { get; set; }
        public string sourceUuid { get; set; }
        public int corrupted { get; set; }
        public bool lockedShared { get; set; }
        public bool lockedExclusive { get; set; }
        public object[] lockReasons { get; set; }
        public bool isAccessible { get; set; }
        public bool hasRootDisk { get; set; }
    }

}
