using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup.ClassLibrary.Concrete.Nakivo.NakivoModel.Tenant
{
    public class ListTenant
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
        public Item[] items { get; set; }
        public int total { get; set; }
    }

    public class Item
    {
        public int id { get; set; }
        public string name { get; set; }
        public string uuid { get; set; }
        public int allocated { get; set; }
        public int allocatedDesired { get; set; }
        public int allocatedEc2Instances { get; set; }
        public int allocatedEc2InstancesDesired { get; set; }
        public object[] labels { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        public string address { get; set; }
        public string logo { get; set; }
        public bool showName { get; set; }
        public bool enabled { get; set; }
        public string state { get; set; }
        public string status { get; set; }
        public string changeStatus { get; set; }
        public string alarmState { get; set; }
        public bool lockedShared { get; set; }
        public bool lockedExclusive { get; set; }
        public bool wasEdited { get; set; }
        public bool wasDiscoveredOnce { get; set; }
        public int progress { get; set; }
        public int[] alarmCounters { get; set; }
        public int usedVms { get; set; }
        public int usedSockets { get; set; }
        public int usedEc2Instances { get; set; }
        public object alertErrorCode { get; set; }
        public object alertTitle { get; set; }
        public object alertDescription { get; set; }
    }
}
