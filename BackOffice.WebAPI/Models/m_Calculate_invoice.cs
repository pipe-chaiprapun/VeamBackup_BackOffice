using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.WebAPI.Models
{
    public class m_Calculate_invoice
    {
    }
    public class m_Calculate_invoice_veeam_backup
    {
        public int custID { get; set; }
        public int PckId { get; set; }
        public int vccId { get; set; }
        public int VM_licenses { get; set; }
        public int storage { get; set; }
        public bool premiums_storage { get; set; }
    }
    public class m_Calculate_invoice_veeam_replication
    {
        public int custID { get; set; }
        public int PckId { get; set; }
        public int vccId { get; set; }
        public int VM_licenses { get; set; }
        public int storage { get; set; }
        public int Processor { get; set; }
        public int RAM { get; set; }
        public int IP_Addresses { get; set; }
        public int Networks { get; set; }
        public int Internet_Traffice { get; set; }
        public bool premiums_storage { get; set; }
    }
}