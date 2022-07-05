using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.WebAPI.Models
{
    public class m_ChangeStatusInvoice
    {
        public int invoice_no { get; set; }
        public int status_i { get; set; }
        public int user_type { get; set; }
    }
}