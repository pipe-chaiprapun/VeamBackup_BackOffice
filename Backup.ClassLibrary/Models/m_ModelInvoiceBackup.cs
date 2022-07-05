using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup.ClassLibrary.Models
{
    public class m_ModelInvoiceBackup
    {
        public string name { get; set; }
        public int vcc_id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string invoice_no { get; set; }
        public DateTime? issued { get; set; }
        public DateTime? due { get; set; }
        public int? vm { get; set; }
        public decimal? vm_total_price { get; set; }
        public int? storage { get; set; }
        public decimal? storage_total_price { get; set; }
        public decimal? discount { get; set; }
        public decimal? fees { get; set; }
        public DateTime? pck_start_dt { get; set; }
        public DateTime? pck_end_dt { get; set; }
        public string email { get; set; }
        public string phone_num { get; set; }
        public string company_name { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string address { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string province { get; set; }
        public string post_code { get; set; }
        public int pck_id { get; set; }
        public bool premiums_storage { get; set; }
    }
}
