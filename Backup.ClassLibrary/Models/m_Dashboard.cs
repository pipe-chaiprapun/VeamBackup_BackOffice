using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup.ClassLibrary.Models
{
    public class m_Dashboard
    {
        public int clientID_by_orders { get; set; }
        public string transaction { get; set; }
        public string pck_type_name { get; set; }
        public string pck_details { get; set; }
        public decimal price { get; set; }
        public string currency { get; set; }
        public string status { get; set; }
        
        // custom
        public int clientID_by_client { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string phone_num { get; set; }
        public byte acc_status { get; set; }
    }
}
