using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup.ClassLibrary.Models
{
    class m_RequestUpate
    {
        public int pck_id { get; set; }
        public bool? premiums_storage { get; set; }
        public string pck_status { get; set; }
        public int cust_id { get; set; }
        public string email { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string company_name { get; set; }
        public string pck_type_name { get; set; }
        public int? pck_id_ref { get; set; }
        public int? storage { get; set; }
        public int? vm { get; set; }
        public int? new_storage { get; set; }
        public int? new_vm { get; set; }



    }
}
