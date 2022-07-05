using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.WebAPI.Models
{
    public class m_pagination_package_tap
    {
        //page
        public int now_page { get; set; }
        public int max_page { get; set; }
        //search
        public int Search_Package_No { get; set; }
        public int Search_Type { get; set; }
        public string Search_ClientName { get; set; }
        public string Search_PackageStatus { get; set; }
        public string Search_Lastname { get; set; }
    }

    public class m_pagination_promo_tap
    {
        //page
        public int now_page { get; set; }
        public int max_page { get; set; }
        //search
        public int Search_Package_No { get; set; }
        public string Search_Promo_No { get; set; }
    }

    public class m_pagination_promocode_tap
    {
        //page
        public int now_page { get; set; }
        public int max_page { get; set; }
        //searc
        public string Search_Promo_code { get; set; }
    }

    public class RequestsPackage_tab
    {
        public int now_page { get; set; }
        public int max_page { get; set; }
        public int cust_id { get; set; }
        public string email { get; set; }
        public string pck_status { get; set; }

    }

    public class filter_invoice_tab
    {
        public int cust_id { get; set; }
        public string invoice_no { get; set; }
        public string email { get; set; }
        public string invoice_status { get; set; }
        public int now_page { get; set; }
        public int max_page { get; set; }
    }

    public partial class Refund_Find_tab
    {
        public int cust_id { get; set; }
        public string email { get; set; }
        public int invoice_id { get; set; }
        public int pck_id { get; set; }
        public string pck_type_name { get; set; }
        public int now_page { get; set; }
        public int max_page { get; set; }
    }

    public partial class Report_Find_tab
    {
        public int cust_id { get; set; }
        public string pck_status { get; set; }
        public int now_page { get; set; }
        public int max_page { get; set; }
    }

    public class m_clients_tab
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string FName { get; set; }
        public string Company { get; set; }
        public int statusFilter { get; set; }
        public bool exactmatch { get; set; }
        public int now_page { get; set; }
        public int max_page { get; set; }
    }

    public partial class LogAction_Find_tab
    {
        public string date_from { get; set; }
        public string date_to { get; set; }
        public string role { get; set; }
        public int now_page { get; set; }
        public int max_page { get; set; }
    }

    public class RequestsHistory_Find_tab
    {
        public string pck_add_dt { get; set; }
        public string pck_end_dt { get; set; }
        public int cust_id { get; set; }
        public string pck_status { get; set; }
        public int now_page { get; set; }
        public int max_page { get; set; }
    }

    public class Employee_Find_tab
    {

        public int emp_id { get; set; }
        public string emp_username { get; set; }

        public string emp_fristname { get; set; }

        public string emp_lastname { get; set; }

        public byte emp_position { get; set; }

        public string emp_status { get; set; }

        public string emp_email { get; set; }
        public int now_page { get; set; }
        public int max_page { get; set; }

    }

    public class m_filter_invoice_tab
    {
        public string client_id { get; set; }
        public string email { get; set; }
        public int invoice_id { get; set; }
        public string status { get; set; }
        public int Package_No { get; set; }
        public int now_page { get; set; }
        public int max_page { get; set; }
    }

    public class m_filter_reseller_tab
    {
        public string reseller_id { get; set; }
        public string company { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string status { get; set; }
        public int now_page { get; set; }
        public int max_page { get; set; }
    }

    public class m_filter_bill_tab
    {
        public string reseller_id { get; set; }
        public DateTime? month { get; set; }
        public string status { get; set; }
        public int now_page { get; set; }
        public int max_page { get; set; }
    }

    public class m_filter_order_tab
    {
        public string reseller_id { get; set; }
        public int pck_id { get; set; }
        public string status { get; set; }
        public int now_page { get; set; }
        public int max_page { get; set; }
    }

    public class m_payments_tab
    {
        public string PaymentNo { get; set; } = "";
        public string PaymentStatus { get; set; } = "0";
        public string Name { get; set; } = "";
        public string Family { get; set; } = "";
        public int PackageStatus { get; set; } = 0;
        public int now_page { get; set; }
        public int max_page { get; set; }
    }
}