using System;

namespace Backup.ClassLibrary.Models
{
    public class getInvoiceEmailBody
    {
        public int VMLicense { get; set; }
        public int Storage { get; set; }
        public string CustomerName { get; set; }
        public int vcc_id { get; set; }
    }
    public class getInvoiceEmailBodyReplication
    {
        public int VMLicense { get; set; }
        public int Storage { get; set; }
        public int processor { get; set; }
        public int ram { get; set; }
        public int ip_address { get; set; }
        public int networks { get; set; }
        public int traffic { get; set; }
        public string CustomerName { get; set; }
        public int vcc_id { get; set; }
    }


    //public class getInvoicesDetail
    //{
    //    public int vcc_id { get; set; }
    //    public string username { get; set; }
    //    public string password { get; set; }
    //    public string invoice_no { get; set; }
    //    public DateTime? issued { get; set; } 
    //    public DateTime? due { get; set; }
    //    public int vm { get; set; }
    //    public decimal vm_total_price { get; set; }
    //    public int storage { get; set; }
    //    public decimal storage_total_price { get; set; }
    //    public decimal fees { get; set; }
    //    public DateTime? pck_start_dt { get; set; }
    //    public DateTime? pck_end_dt { get; set; }
    //    public string email { get; set; }
    //    public string phone_num { get; set; }
    //    public string company_name { get; set; }       
    //    public string firstname { get; set; }
    //    public string lastname { get; set; }
    //    public string address { get; set; }
    //    public string country { get; set; }
    //    public string city { get; set; }
    //    public string province { get; set; }
    //    public string post_code { get; set; }
    //    public int pck_id { get; set; }
    //}

    public class getInvoicesDetail_NewInvoBO
    {
        public int vcc_id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string invoice_no { get; set; }
        public DateTime? issued { get; set; }
        public DateTime? due { get; set; }
        public int vm { get; set; }
        public decimal vm_total_price { get; set; }
        public int storage { get; set; }
        public decimal storage_total_price { get; set; }
        public decimal discount { get; set; }
        public decimal fees { get; set; }
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
        public string name { get; set; }
        
    }

    public class getInvoicesDetail_Rep
    {
        public int vcc_id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string invoice_no { get; set; }
        public DateTime? issued { get; set; }
        public DateTime? due { get; set; }
        public int vm { get; set; }
        public decimal vm_total_price { get; set; }
        public int storage { get; set; }
        public decimal storage_total_price { get; set; }
        public int processor { get; set; }
        public decimal processor_price { get; set; }
        public int ram { get; set; }
        public decimal ram_price { get; set; }
        public int ip_address { get; set; }
        public decimal ip_address_price { get; set; }
        public int networks { get; set; }
        public int internet_traffic { get; set; }
        public decimal internet_traffic_price { get; set; }
        public decimal fees { get; set; }
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
    }
    public class getInvoicesDetail_Rep_saveAndUpgrade
    {
        public int vcc_id { get; set; } //1
        public string username { get; set; } //2
        public string password { get; set; } //3
        public string invoice_no { get; set; } //4
        public DateTime? issued { get; set; } //5
        public DateTime? due { get; set; } //6

        public string name { get; set; }

        public int? vm { get; set; } //7
        public int? storage { get; set; } //8
        public int? processor { get; set; } //9
        public int? ram { get; set; } //10
        public int? ip_address { get; set; } //11
        public int? networks { get; set; } //12
        public int? traffic { get; set; } //13

        public decimal? total_price { get; set; } //14
        public decimal? total_vm_price { get; set; } //15
        public decimal? total_storage_price { get; set; } //16
        public decimal? total_processor_price { get; set; } //17
        public decimal? total_ram_price { get; set; } //18
        public decimal? total_ip_address_price { get; set; } //19
        public decimal? total_networks_price { get; set; } //20
        public decimal? total_traffic_price { get; set; } //21

        public decimal? discount { get; set; } //22
        public decimal? fees { get; set; } //23
        public DateTime? pck_start_dt { get; set; } //24
        public DateTime? pck_end_dt { get; set; } //25
        public string email { get; set; } //26
        public string phone_num { get; set; } //27
        public string company_name { get; set; } //28
        public string firstname { get; set; } //29
        public string lastname { get; set; } //30
        public string address { get; set; } //31
        public string country { get; set; } //32
        public string city { get; set; } //33
        public string province { get; set; } //34
        public string post_code { get; set; } //35
        public int pck_id { get; set; } //36
        public bool premiums_storage { get; set; } //37
    }
}