using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backup.ClassLibrary.Models
{
    
    public class m_payments
    {
        public string PaymentNo { get; set; } = "";
        public string PaymentStatus { get; set; } = "0";
        public string Name { get; set; } = "";
        public string Family { get; set; } = "";
        public int PackageStatus { get; set; } = 0;
    }

    public class m_payments_inv
    {
        public string Payment_Id { get; set; }
        public string username { get; set; }
        public string invoice_no { get; set; }
    }

    public class m_payments_detail
    {
        public string txnId { get; set; } = string.Empty;
    }
}