using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup.ClassLibrary.Models
{
    public class getFailoverPlan
    {
        public string UID { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string description { get; set; }
        public string TenantName { get; set; }
        public string TenantUid { get; set; }
        public string state { get; set; } = "ready";
        public string VmId { get; set; }
        public string VmName { get; set; }
        public byte order { get; set; }
    }
}
