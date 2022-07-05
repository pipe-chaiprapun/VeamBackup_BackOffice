using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup.ClassLibrary.Models
{
    public class m_getRefund
    {
        public int pck_id { get; set; }
        public int cart_id { get; set; }
        public string payment_id { get; set; }
        public string invoice_no { get; set; }
    }
}
