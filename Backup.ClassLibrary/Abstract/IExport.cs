using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backup.ClassLibrary.Entity;
using Backup.ClassLibrary.Models;

namespace Backup.ClassLibrary.Abstract
{
    public interface IExport
    {
        //package tab
        IEnumerable<v_PackageTap> ExportPackageTap(int Search_Package_No, int Search_Type, string Search_PackageStatus, string Search_ClientName, string Lastname);
       
        //new request
        IEnumerable<VBackupBackOfficeRequestsNewPackage> ExportNewRequestTap(int cust_id, string email, string pck_status);

        //invoice
        IEnumerable<v_Invovice_tap> ExportInvoiceTap(int cust_id, string email, string invoice_no, string invoice_status);

        //PaypalRefund
        IEnumerable<BackOfficePaypalRefund> ExportPaypalRefundTap(int cust_id, string email, int invoice_id, int pck_id, string pck_type_name);

        //PaypalRefundProcessed
        IEnumerable<BackOfficePaypalRefund> ExportPaypalRefundProcessedTap(int cust_id, string email, int invoice_id, int pck_id, string pck_type_name);

        //report
        IEnumerable<v_PackageTap> ExportReportTap(int cust_id, string pck_status);

        //client
        IEnumerable<vBackOfficeClients_new> ExportClientFalseTap(int cust_id, string email, string firstname, string lastname, string company_name, int status, bool exactmatch);

        //LogAction
        IEnumerable<vBackOfficeLogActions> ExportLogActionTap(string date_from, string date_to, string role);

        //requestsHistory
        IEnumerable<VBackOfficeRequestsHistory> ExportPaypalRequestsHistoryTap(string pck_add_dt, string pck_end_dt, int cust_id, string pck_status);

        //User
        IEnumerable<vBackOfficeUser> ExportUserTap(int ID, string USERNAME, string NAME, byte POSITIONS, string FAMILY, string STATUS);

        //ResellerInvoice
        IEnumerable<v_Reseller_Invoices_BO> ExportResellerInvoiceTap(string client_id, string email, int invoice_id, string status, int Package_No);

        //Reseller
        IEnumerable<v_Reseller> ExportResellerTap(string reseller, string company, string email, string phone, string status);

        //ResellerBill
        IEnumerable<v_Reseller_Bill> ExportResellerBillTap(string reseller, string month, string status);

        //ResellerOrder
        IEnumerable<v_Reseller_Order> ExportResellerOrderTap(string reseller, int pck_id, string status);

        //Payment
        IEnumerable<vBackOfficePayments> ExportPaymentTap(string packageId, string payment_status, string client_name, string family_name, int package_status);
    }
}
