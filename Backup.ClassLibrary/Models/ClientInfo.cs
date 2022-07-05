using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup.ClassLibrary.Models
{
    public class ClientInfo
    {
        public int cust_id { get; set; }
        public string email { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string phone_num { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string province { get; set; }
        public string country { get; set; }
        public string post_code { get; set; }
        public Int16 cust_type_id { get; set; }
        public byte acc_status { get; set; }

    }

    public class VCCAcc
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}
