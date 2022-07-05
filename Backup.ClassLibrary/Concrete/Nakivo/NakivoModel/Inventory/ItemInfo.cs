using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup.ClassLibrary.Concrete.Nakivo.NakivoModel.Inventory.Info
{

    public class ItemInfo
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
        public string host { get; set; }
        public string username { get; set; }
        public int port { get; set; }
        public string vid { get; set; }
        public string name { get; set; }
        public string state { get; set; }
        public string status { get; set; }
        public string changeStatus { get; set; }
        public bool preventModification { get; set; }
        public bool locked { get; set; }
        public bool wasDiscoveredOnce { get; set; }
        public bool wasEdited { get; set; }
        public int progress { get; set; }
        public string targetVid { get; set; }
        public int hostCount { get; set; }
        public int vmCount { get; set; }
        public object alertErrorCode { get; set; }
        public object alertTitle { get; set; }
        public object alertDescription { get; set; }
    }

}
