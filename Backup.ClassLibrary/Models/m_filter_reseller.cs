using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup.ClassLibrary.Models
{
    public class m_filter_reseller
    {
        public string reseller_id { get; set; }
        public string company { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string status { get; set; }
    }

    public class m_filter_bill
    {
        public string reseller_id { get; set; }
        public DateTime? month { get; set; }
        public string status { get; set; }
    }

    public class m_filter_order
    {
        public string reseller_id { get; set; }
        public int pck_id { get; set; }
        public string status { get; set; }
    }

    public class m_filter_invoice
    {
        public string client_id { get; set; }
        public string email { get; set; }
        public int invoice_id { get; set; }
        public string status { get; set; }
        public int Package_No { get; set; }
    }


}
