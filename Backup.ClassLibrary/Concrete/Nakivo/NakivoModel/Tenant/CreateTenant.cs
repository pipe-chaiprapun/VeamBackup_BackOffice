using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup.ClassLibrary.Concrete.Nakivo.NakivoModel.Tenant
{
    public class CreateTenant
    {
        public string action { get; set; } = "MultitenancyManagement";
        public string method { get; set; } = "save";
        public Datum[] data { get; set; }
        public string type { get; set; } = "rpc";
        public int tid { get; set; } = 86;
    }

    public class Datum
    {
        public string sessionUuid { get; set; }
        public Tenant tenant { get; set; }
        public Userrequest[] userRequests { get; set; }
    }

    public class Tenant
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        public string address { get; set; }
        public string allocated { get; set; }
        public string allocatedEc2Instances { get; set; }
        public bool showName { get; set; }
        public object[] labels { get; set; }
    }

    public class Userrequest
    {
        public string type { get; set; }
        public Attributes attributes { get; set; }
    }

    public class Attributes
    {
        public string login { get; set; }
        public bool enabled { get; set; }
        public string password { get; set; }
        public string currentPassword { get; set; }
        public string email { get; set; }
        public object[] permissions { get; set; }
    }
}
