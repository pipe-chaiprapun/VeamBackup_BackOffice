using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup.ClassLibrary.Models
{
    class m_GetPaypal
    {
        public int? pck_id { get; set; }
        public int? cust_id { get; set; }
        public string payment_id { get; set; }
        public string invoice_no { get; set; }
    }
}
