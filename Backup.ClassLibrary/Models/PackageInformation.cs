using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup.ClassLibrary.Models
{
    public class PackageInformation
    {
        public string Number { get; set; }
        public string DateTime { get; set; }
        public string Duration { get; set; }
        public string Status { get; set; }
        public string MBs { get; set; }
        public string Warnings { get; set; }
        public string Errors { get; set; }
    }

    public class m_create_inv_backup
    {
        public int cust_id { get; set; }
        public int vmQty { get; set; }
        public int storage { get; set; }
        public int premiums_storage { get; set; }
        public int pck_type { get; set; }
        public int free_trial { get; set; }
    }

    public class create_inv_backup
    {
        public int ClientId { get; set; }
        public int StorageGB { get; set; }
        public bool StorageBrand { get; set; }
        public int VMsQty { get; set; }
        public bool SendInvoice { get; set; }
        public int pck_type { get; set; }
    }

    public class PackageCalculator
    {
        public int vm { get; set; }
        public int storage { get; set; }
        public bool preniums_storage { get; set; }
        public int pck_type { get; set; }
    }

    public class getTotalAmountPck
    {
        public decimal total_price { get; set; }
        public decimal vm_total_price { get; set; }
        public decimal storage_total_price { get; set; }
    }

    public class m_create_inv_replication
    {
        public int cust_id { get; set; }
        public int vmQty { get; set; }
        public int storage { get; set; }
        public int premiums_storage { get; set; }
        public int free_trial { get; set; }
        public int processor { get; set; }
        public int ram { get; set; }
        public int ipaddress { get; set; }
        public int networks { get; set; }
        public int internet_traffic { get; set; }
        public int pck_type { get; set; }
    }

    public class create_inv_replication
    {
        public int cust_id { get; set; }
        public int vmQty { get; set; }
        public int storage { get; set; }
        public bool premiums_storage { get; set; }
        public bool SendInvoice { get; set; }
        public int processor { get; set; }
        public int ram { get; set; }
        public int ipaddress { get; set; }
        public int networks { get; set; }
        public int internet_traffic { get; set; }
        public int pck_type { get; set; }

    }

    public class PackageCalculator_rep
    {
        public int vm { get; set; }
        public int storage { get; set; }
        public int processor { get; set; }
        public int ram { get; set; }
        public int ip_address { get; set; }
        public int networks { get; set; }
        public int internet_traffic { get; set; }
        public bool preniums_storage { get; set; }
        public int pck_type { get; set; }
    }

    public class getTotalAmountPck_rep
    {
        public decimal total_price { get; set; }
        public decimal vm_total_price { get; set; }
        public decimal storage_total_price { get; set; }
        public decimal processor_total_price { get; set; }
        public decimal ram_total_price { get; set; }
        public decimal ipaddress_total_price { get; set; }
        public decimal networks_total_price { get; set; }
        public decimal internet_traffic_total_price { get; set; }
    }


}
