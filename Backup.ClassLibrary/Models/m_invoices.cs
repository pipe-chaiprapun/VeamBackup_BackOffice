using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Backup.ClassLibrary.Models
{
    public class m_suspend
    {
        [Required]
        public long InvoiceId { get; set; }

        [Required]
        public int PackageId { get; set; }

        [Required]
        public int Cust_Id { get; set; }

        [Required]
        public string tenant_id { get; set; }

        [Required]
        public string tenant_username { get; set; }
    }

    public class m_inv
    {
        [Required]
        [StringLength(15)]
        public string invoice_no { get; set; }

        [Required]
        public int cust_id { get; set; }
    }

    public class m_InvoiceDetail
    {
        [Required]
        [StringLength(15)]
        public string invoice_no { get; set; }

        [Required]
        public int cust_id { get; set; }

        [Required]
        public int vcc_id { get; set; }
    }

    public class m_invedit
    {
        [Required]
        public string invoice_no { get; set; }

        [Required]
        public string status_i { get; set; }

        [Required]
        public int user_type { get; set; }
    }

    public class m_RetrySendInvoice
    {
        [Required]
        [StringLength(15)]
        public string invoice_no { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public int cust_id { get; set; }

        [Required]
        public int packageId { get; set; }
        
    }
}