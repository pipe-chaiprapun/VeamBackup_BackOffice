using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backup.ClassLibrary.Abstract;
using Backup.ClassLibrary.Entity;
using System.Data.SqlClient;
using Backup.ClassLibrary.Models;

namespace Backup.ClassLibrary.Concrete
{
    public class Export : IExport
    {
        private BackOfficeDB db = new BackOfficeDB();

        public IEnumerable<vBackOfficeClients_new> ExportClientFalseTap(int cust_id, string email, string firstname, string lastname, string company_name, int status, bool exactmatch)
        {
            if (exactmatch)
            {
                var res = db.Database.SqlQuery<vBackOfficeClients_new>("EXEC [backoffice].[s_export_client_true_tap] @cust_id,@email,@firstname,@lastname,@company_name,@status",
                   new SqlParameter("@cust_id", cust_id),
                   new SqlParameter("@email", email == null ? "" : email),
                   new SqlParameter("@firstname", firstname == null ? "" : firstname),
                   new SqlParameter("@lastname", lastname == null ? "" : lastname),
                   new SqlParameter("@company_name", company_name == null ? "" : company_name),
                   new SqlParameter("@status", status)
                   ).ToList();
                return res;
            }
            else
            {
                var res = db.Database.SqlQuery<vBackOfficeClients_new>("EXEC [backoffice].[s_export_client_false_tap] @cust_id,@email,@firstname,@lastname,@company_name,@status",
                   new SqlParameter("@cust_id", cust_id),
                   new SqlParameter("@email", email == null ? "" : email),
                   new SqlParameter("@firstname", firstname == null ? "" : firstname),
                   new SqlParameter("@lastname", lastname == null ? "" : lastname),
                   new SqlParameter("@company_name", company_name == null ? "" : company_name),
                   new SqlParameter("@status", status)
                   ).ToList();
                return res;
            }
        }

        public IEnumerable<v_Invovice_tap> ExportInvoiceTap(int cust_id, string email, string invoice_no, string invoice_status)
        {
            var res = db.Database.SqlQuery<v_Invovice_tap>("EXEC [backoffice].[s_export_invoice_tap] @cust_id,@email,@invoice_no,@invoice_status",
               new SqlParameter("@cust_id", cust_id),
               new SqlParameter("@email", email == null ? "" : email),
               new SqlParameter("@invoice_no", invoice_no == null ? "" : invoice_no),
               new SqlParameter("@invoice_status", invoice_status == null ? "" : invoice_status)
               ).ToList();
            return res;
        }

        public IEnumerable<vBackOfficeLogActions> ExportLogActionTap(string date_from, string date_to, string role)
        {
            var res = db.Database.SqlQuery<vBackOfficeLogActions>("EXEC [backoffice].[s_export_LogAction_tap] @date_from,@date_to,@role",
               new SqlParameter("@date_from", date_from == null ? "" : date_from + " 00:00:00"),
               new SqlParameter("@date_to", date_to == null ? "" : date_to + " 23:59:59"),
               new SqlParameter("@role", role == null ? "" : role)
               ).ToList();
            return res;
        }

        public IEnumerable<VBackupBackOfficeRequestsNewPackage> ExportNewRequestTap(int cust_id, string email, string pck_status)
        {
            var res = db.Database.SqlQuery<VBackupBackOfficeRequestsNewPackage>("EXEC [backoffice].[s_export_GetNewPackageRequest_tap] @cust_id,@email,@pck_status",
               new SqlParameter("@cust_id", cust_id),
               new SqlParameter("@email", email == null ? "" : email),
               new SqlParameter("@pck_status", pck_status == null ? "" : pck_status)
               ).ToList();
            return res;
        }

        public IEnumerable<v_PackageTap> ExportPackageTap(int Search_Package_No, int Search_Type, string Search_PackageStatus, string Search_ClientName, string Lastname)
        {
            var res = db.Database.SqlQuery<v_PackageTap>("EXEC [backoffice].[s_export_package_tap] @Search_Package_No,@Search_Type, @Search_ClientName, @Search_Lastname, @Search_PackageStatus",
               new SqlParameter("@Search_Package_No", Search_Package_No),
               new SqlParameter("@Search_ClientName", Search_ClientName == null ? "" : Search_ClientName),
               new SqlParameter("@Search_Lastname", Lastname == null ? "" : Lastname),
               new SqlParameter("@Search_PackageStatus", Search_PackageStatus == null ? "" : Search_PackageStatus),
               new SqlParameter("@Search_Type", Search_Type)
               ).ToList();
            return res;
        }

        public IEnumerable<BackOfficePaypalRefund> ExportPaypalRefundProcessedTap(int cust_id, string email, int invoice_id, int pck_id, string pck_type_name)
        {
            var res = db.Database.SqlQuery<BackOfficePaypalRefund>("EXEC [backoffice].[s_export_PaypalRefundProcessed_tap] @cust_id,@email,@invoice_id,@pck_id,@pck_type_name",
              new SqlParameter("@cust_id", cust_id),
              new SqlParameter("@email", email == null ? "" : email),
              new SqlParameter("@invoice_id", invoice_id),
              new SqlParameter("@pck_id", pck_id),
              new SqlParameter("@pck_type_name", pck_type_name)
              ).ToList();
            return res;

        }

        public IEnumerable<BackOfficePaypalRefund> ExportPaypalRefundTap(int cust_id, string email, int invoice_id, int pck_id, string pck_type_name)
        {
            var res = db.Database.SqlQuery<BackOfficePaypalRefund>("EXEC [backoffice].[s_export_PaypalRefund_tap] @cust_id,@email,@invoice_id,@pck_id,@pck_type_name",
               new SqlParameter("@cust_id", cust_id),
               new SqlParameter("@email", email == null ? "" : email),
               new SqlParameter("@invoice_id", invoice_id),
               new SqlParameter("@pck_id", pck_id),
               new SqlParameter("@pck_type_name", pck_type_name)
               ).ToList();
            return res;
        }

        public IEnumerable<VBackOfficeRequestsHistory> ExportPaypalRequestsHistoryTap(string pck_add_dt, string pck_end_dt, int cust_id, string pck_status)
        {
            var res = db.Database.SqlQuery<VBackOfficeRequestsHistory>("EXEC [backoffice].[s_export_requestsHistory_tap] @pck_add_dt,@pck_end_dt,@cust_id,@pck_status",
               new SqlParameter("@pck_add_dt", pck_add_dt == null ? "" : pck_add_dt + " 00:00:00"),
               new SqlParameter("@pck_end_dt", pck_end_dt == null ? "" : pck_end_dt + " 23:59:59"),
               new SqlParameter("@cust_id", cust_id),
               new SqlParameter("@pck_status", pck_status == null ? "" : pck_status)
               ).ToList();
            return res;
        }

        public IEnumerable<v_PackageTap> ExportReportTap(int cust_id, string pck_status)
        {
            var res = db.Database.SqlQuery<v_PackageTap>("EXEC [backoffice].[s_export_report_tap] @cust_id,@pck_status",
               new SqlParameter("@cust_id", cust_id),
               new SqlParameter("@pck_status", pck_status == null ? "" : pck_status)
               ).ToList();
            return res;
        }

        public IEnumerable<v_Reseller_Bill> ExportResellerBillTap(string reseller, string month, string status)
        {
            var res = db.Database.SqlQuery<v_Reseller_Bill>("EXEC [backoffice].[s_export_Reseller_Bill_tap] @reseller,@month,@status",
               new SqlParameter("@reseller", reseller == null ? "" : reseller),
               new SqlParameter("@month", month == null ? "" : month),
               new SqlParameter("@status", status == null ? "" : status)
               ).ToList();
            return res;
        }

        public IEnumerable<v_Reseller_Invoices_BO> ExportResellerInvoiceTap(string client_id, string email, int invoice_id, string status, int Package_No)
        {
            var res = db.Database.SqlQuery<v_Reseller_Invoices_BO>("EXEC [backoffice].[s_export_Reseller_invoice_tap] @client_id,@email,@invoice_id,@status,@Package_No",
               new SqlParameter("@client_id", client_id == null ? "" : client_id),
               new SqlParameter("@email", email == null ? "" : email),
               new SqlParameter("@invoice_id", invoice_id),
               new SqlParameter("@status", status == null ? "" : status),
               new SqlParameter("@Package_No", Package_No)
               ).ToList();
            return res;
        }

        public IEnumerable<v_Reseller_Order> ExportResellerOrderTap(string reseller, int pck_id, string status)
        {
            var res = db.Database.SqlQuery<v_Reseller_Order>("EXEC [backoffice].[s_export_Reseller_Order_tap] @reseller,@pck_id,@status",
               new SqlParameter("@reseller", reseller == null ? "" : reseller),
               new SqlParameter("@pck_id", pck_id),
               new SqlParameter("@status", status == null ? "" : status)
               ).ToList();
            return res;
        }

        public IEnumerable<v_Reseller> ExportResellerTap(string reseller, string company, string email, string phone, string status)
        {
            var sta = db.StatusCodes.FirstOrDefault(s => s.description.Equals(status));
            var res = db.Database.SqlQuery<v_Reseller>("EXEC [backoffice].[s_export_Reseller_tap] @reseller,@company,@email,@phone,@status",
               new SqlParameter("@reseller", reseller == null ? "" : reseller),
               new SqlParameter("@company", company == null ? "" : company),
               new SqlParameter("@email", email == null ? "" : email),
               new SqlParameter("@phone", phone == null ? "" : phone),
               new SqlParameter("@status", sta == null ? "" : sta.status)
               ).ToList();
            return res;
        }

        public IEnumerable<vBackOfficeUser> ExportUserTap(int ID, string USERNAME, string NAME, byte POSITIONS, string FAMILY, string STATUS)
        {
            var res = db.Database.SqlQuery<vBackOfficeUser>("EXEC [backoffice].[s_export_user_tap] @ID,@USERNAME,@NAME,@POSITIONS,@FAMILY,@STATUS",
               new SqlParameter("@ID", ID),
               new SqlParameter("@USERNAME", USERNAME == null ? "" : USERNAME),
               new SqlParameter("@NAME", NAME == null ? "" : NAME),
               new SqlParameter("@POSITIONS", POSITIONS),
               new SqlParameter("@FAMILY", FAMILY == null ? "" : FAMILY),
               new SqlParameter("@STATUS", STATUS == null ? "" : STATUS)
               ).ToList();
            return res;
        }

        public IEnumerable<vBackOfficePayments> ExportPaymentTap(string packageId, string payment_status, string client_name, string family_name, int package_status)
        {
            var res = db.Database.SqlQuery<vBackOfficePayments>("EXEC [backoffice].[s_export_payment_tap] @packageId,@payment_status,@client_name,@family_name,@package_status",
               new SqlParameter("@packageId", packageId == null ? "" : packageId),
               new SqlParameter("@payment_status", payment_status == null ? "0" : payment_status),
               new SqlParameter("@client_name", client_name == null ? "" : client_name),
               new SqlParameter("@family_name", family_name == null ? "" : family_name),
               new SqlParameter("@package_status", package_status)
               ).ToList();
            return res;
        }
    }
}
