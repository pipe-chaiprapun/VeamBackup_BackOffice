using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backup.ClassLibrary.Entity;
using Backup.ClassLibrary.Models;
namespace Backup.ClassLibrary.Abstract
{
    public interface IGetTable
    {
        //package tab
        IEnumerable<v_PackageTap> GetTableDataPackageTap(int now_page, int max_page, int Search_Package_No,int Search_Type,string Search_PackageStatus, string Search_ClientName,string Lastname);
        m_Table_row GetTableRowPackageTap(int max_page, int Search_Package_No, int Search_Type, string Search_PackageStatus, string Search_ClientName, string Lastname);

        //promo tap
        IEnumerable<v_GetPackage_manage> GetTableDataPromoTap(int now_page, int max_page, int Search_Package_No, string Search_Promo_No);
        m_Table_row GetTableRowPromoTap(int max_page, int Search_Package_No, string Search_Promo_No);
        //promoCode tap
        IEnumerable<Promo_code> GetTableDataPromoCodeTap(int now_page, int max_page, string Search_Promo_code);
        m_Table_row GetTableRowPromoCodeTap(int max_page, string Search_Promo_code);

        //new request
        IEnumerable<VBackupBackOfficeRequestsNewPackage> GetTableDataNewRequestTap(int cust_id,string email,string pck_status,int page,int page_max);
        m_Table_row GetTableRowNewRequestTap(int cust_id, string email, string pck_status,int page_max);

        //invoice
        IEnumerable<v_Invovice_tap> GetTableDataInvoiceTap(int cust_id, string email, string invoice_no,string invoice_status, int page, int page_max);
        m_Table_row GetTableRowInvoiceTap(int cust_id, string email, string invoice_no, string invoice_status, int page_max);

        //PaypalRefund
        IEnumerable<BackOfficePaypalRefund> GetTableDataPaypalRefundTap(int cust_id, string email,int invoice_id,int pck_id,string pck_type_name, int page, int page_max);
        m_Table_row GetTableRowPaypalRefundTap(int cust_id, string email, int invoice_id, int pck_id, string pck_type_name, int page_max);

        //PaypalRefundProcessed
        IEnumerable<BackOfficePaypalRefund> GetTableDataPaypalRefundProcessedTap(int cust_id, string email, int invoice_id, int pck_id, string pck_type_name, int page, int page_max);
        m_Table_row GetTableRowPaypalRefundProcessedTap(int cust_id, string email, int invoice_id, int pck_id, string pck_type_name, int page_max);


        //report
        IEnumerable<v_PackageTap> GetTableDataReportTap(int cust_id,string pck_status, int page, int page_max);
        m_Table_row GetTableRowReportTap(int cust_id, string pck_status, int page_max);

        //client
        IEnumerable<vBackOfficeClients_new> GetTableDataClientFalseTap(int cust_id, string email,string firstname,string lastname,string company_name,int status, int page, int page_max, bool exactmatch);
        m_Table_row GetTableRowClientFalseTap(int cust_id, string email, string firstname, string lastname, string company_name, int status, int page_max, bool exactmatch);

        //LogAction
        IEnumerable<vBackOfficeLogActions> GetTableDataLogActionTap(string date_from, string date_to,string role, int page, int page_max);
        m_Table_row GetTableRowLogActionTap(string date_from, string date_to, string role, int page_max);

        //requestsHistory
        IEnumerable<VBackOfficeRequestsHistory> GetTableDataPaypalRequestsHistoryTap(string pck_add_dt,string pck_end_dt,int cust_id ,string pck_status, int page, int page_max);
        m_Table_row GetTableRowRequestsHistoryTap(string pck_add_dt, string pck_end_dt, int cust_id, string pck_status, int page_max);

        //User
        IEnumerable<vBackOfficeUser> GetTableDataUserTap(int ID,string USERNAME,string NAME, byte POSITIONS,string FAMILY,string STATUS, int page, int page_max);
        m_Table_row GetTableRowUserTap(int ID, string USERNAME, string NAME, byte POSITIONS, string FAMILY, string STATUS, int page_max);

        //ResellerInvoice
        IEnumerable<v_Reseller_Invoices_BO> GetTableDataResellerInvoiceTap(string client_id, string email, int invoice_id, string status,int Package_No, int page, int page_max);
        m_Table_row GetTableRowResellerInvoiceTap(string client_id, string email, int invoice_id, string status, int Package_No, int page_max);

        //Reseller
        IEnumerable<v_Reseller> GetTableDataResellerTap(string reseller, string company,string email,string phone,string status, int page, int page_max);
        m_Table_row GetTableRowResellerTap(string reseller, string company, string email, string phone, string status, int page_max);

        //ResellerBill
        IEnumerable<v_Reseller_Bill> GetTableDataResellerBillTap(string reseller, string month, string status, int page, int page_max);
        m_Table_row GetTableRowResellerBillTap(string reseller, string month, string status, int page_max);

        //ResellerOrder
        IEnumerable<v_Reseller_Order> GetTableDataResellerOrderTap(string reseller, int pck_id, string status, int page, int page_max);
        m_Table_row GetTableRowResellerOrderTap(string reseller, int pck_id, string status, int page_max);

        //Payment
        IEnumerable<vBackOfficePayments> GetTableDataPaymentTap(string packageId, string payment_status,string client_name,string family_name,int package_status, int page, int page_max);
        m_Table_row GetTableRowPaymentTap(string packageId, string payment_status, string client_name, string family_name, int package_status, int page_max);

    }
}
