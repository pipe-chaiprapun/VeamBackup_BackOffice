using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup.ClassLibrary.Models
{
    public class m_Prolonged_package
    {
        public int vcc_id { get; set; }
        public Guid? tenant_id { get; set; }
        public int cust_id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public DateTime create_dt { get; set; }
        public DateTime start_dt { get; set; }
        public DateTime end_dt { get; set; }
        public int pck_id { get; set; }
        public int invo_no { get; set; }
    }
}
