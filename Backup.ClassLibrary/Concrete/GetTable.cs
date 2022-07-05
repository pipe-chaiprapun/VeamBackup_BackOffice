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
    public class GetTable : IGetTable
    {
        private BackOfficeDB db = new BackOfficeDB();

        #region GetTableDataNewRequestTap
        public IEnumerable<VBackupBackOfficeRequestsNewPackage> GetTableDataNewRequestTap(int cust_id, string email, string pck_status, int page, int page_max)
        {
            var res = db.Database.SqlQuery<VBackupBackOfficeRequestsNewPackage>("EXEC [backoffice].[s_pagination_GetNewPackageRequest_tap] @cust_id,@email,@pck_status,@page,@page_max",
               new SqlParameter("@cust_id", cust_id),
               new SqlParameter("@email", email == null ? "" : email),
               new SqlParameter("@pck_status", pck_status == null ? "" : pck_status),
               new SqlParameter("@page", page),
               new SqlParameter("@page_max", page_max)
               ).ToList();
            return res;
        }

        public m_Table_row GetTableRowNewRequestTap(int cust_id, string email, string pck_status, int page_max)
        {
            var res = db.Database.SqlQuery<m_Table_row>("EXEC [backoffice].[s_pagination_GetNewPackageRequest_tap_row] @cust_id,@email,@pck_status,@page_max",
               new SqlParameter("@cust_id", cust_id),
               new SqlParameter("@email", email == null ? "" : email),
               new SqlParameter("@pck_status", pck_status == null ? "" : pck_status),
               new SqlParameter("@page_max", page_max)
               ).FirstOrDefault();
            return res;
        }
        #endregion

        #region GetTableDataPromoTap
        public IEnumerable<v_GetPackage_manage> GetTableDataPromoTap(int now_page, int max_page, int Search_Package_No, string Search_Promo_No)
        {
            var res = db.Database.SqlQuery<v_GetPackage_manage>("EXEC [backoffice].[s_pagination_promo_tap] @Search_Package_No,@Search_Promo_No,@page,@page_max",
               new SqlParameter("@Search_Package_No", Search_Package_No),
               new SqlParameter("@Search_Promo_No", Search_Promo_No == null ? "" : Search_Promo_No),
               new SqlParameter("@page", now_page),
               new SqlParameter("@page_max", max_page)).ToList();
            return res;
        }

        public m_Table_row GetTableRowPromoTap(int max_page, int Search_Package_No, string Search_Promo_No)
        {
            var res = db.Database.SqlQuery<m_Table_row>("EXEC [backoffice].[s_pagination_promo_tap_row] @Search_Package_No,@Search_Promo_No,@page_max",
               new SqlParameter("@Search_Package_No", Search_Package_No),
               new SqlParameter("@Search_Promo_No", Search_Promo_No == null ? "" : Search_Promo_No),
               new SqlParameter("@page_max", max_page)).FirstOrDefault();
            return res;
        }
        #endregion

        #region GetTableDataPromoCodeTap
        public IEnumerable<Promo_code> GetTableDataPromoCodeTap(int now_page, int max_page, string Search_Promo_code)
        {
            var res = db.Database.SqlQuery<Promo_code>("EXEC [backoffice].[s_pagination_promocode_tap] @Search_Promo_code,@page,@page_max",
               new SqlParameter("@Search_Promo_code", Search_Promo_code == null ? "" : Search_Promo_code),
               new SqlParameter("@page", now_page),
               new SqlParameter("@page_max", max_page)).ToList();
            return res;
        }

        public m_Table_row GetTableRowPromoCodeTap(int max_page, string Search_Promo_code)
        {
            var res = db.Database.SqlQuery<m_Table_row>("EXEC [backoffice].[s_pagination_promocode_tap_row] @Search_Promo_code,@page_max",
               new SqlParameter("@Search_Promo_code", Search_Promo_code == null ? "" : Search_Promo_code),
               new SqlParameter("@page_max", max_page)).FirstOrDefault();
            return res;
        }
        #endregion

        #region GetTableDataPackageTap
        public IEnumerable<v_PackageTap> GetTableDataPackageTap(int now_page, int max_page, int Search_Package_No, int Search_Type, string Search_PackageStatus, string Search_ClientName, string Lastname)
        {
            var res = db.Database.SqlQuery<v_PackageTap>("EXEC [backoffice].[s_pagination_package_tap] @Search_Package_No,@Search_Type, @Search_ClientName, @Search_Lastname, @Search_PackageStatus,@page,@page_max",
               new SqlParameter("@Search_Package_No", Search_Package_No),
               new SqlParameter("@Search_ClientName", Search_ClientName == null ? "":Search_ClientName),
               new SqlParameter("@Search_Lastname", Lastname == null ? "":Lastname),
               new SqlParameter("@Search_PackageStatus", Search_PackageStatus == null ? "" : Search_PackageStatus),
               new SqlParameter("@page", now_page),
               new SqlParameter("@Search_Type", Search_Type),
               new SqlParameter("@page_max", max_page)).ToList();
            return res;
        }

        public m_Table_row GetTableRowPackageTap(int max_page, int Search_Package_No, int Search_Type, string Search_PackageStatus, string Search_ClientName, string Lastname)
        {
            var res = db.Database.SqlQuery<m_Table_row>("EXEC [backoffice].[s_pagination_package_tap_row] @Search_Package_No,@Search_Type, @Search_ClientName, @Search_Lastname, @Search_PackageStatus,@page_max",
               new SqlParameter("@Search_Package_No", Search_Package_No),
               new SqlParameter("@Search_ClientName", Search_ClientName == null ? "" : Search_ClientName),
               new SqlParameter("@Search_Lastname", Lastname == null ? "" : Lastname),
               new SqlParameter("@Search_PackageStatus", Search_PackageStatus == null ? "" : Search_PackageStatus),
               new SqlParameter("@Search_Type", Search_Type),
               new SqlParameter("@page_max", max_page)).FirstOrDefault();
            return res;
        }
        #endregion

        #region GetTableDataInvoiceTap
        public IEnumerable<v_Invovice_tap> GetTableDataInvoiceTap(int cust_id, string email, string invoice_no, string invoice_status, int page, int page_max)
        {
            var res = db.Database.SqlQuery<v_Invovice_tap>("EXEC [backoffice].[s_pagination_invoice_tap] @cust_id,@email,@invoice_no,@invoice_status,@page,@page_max",
               new SqlParameter("@cust_id", cust_id),
               new SqlParameter("@email", email == null ? "" : email),
               new SqlParameter("@invoice_no", invoice_no == null ? "" : invoice_no),
               new SqlParameter("@invoice_status", invoice_status == null ? "" : invoice_status),
               new SqlParameter("@page", page),
               new SqlParameter("@page_max", page_max)
               ).ToList();
            return res;
        }
        public m_Table_row GetTableRowInvoiceTap(int cust_id, string email, string invoice_no, string invoice_status, int page_max)
        {
            var res = db.Database.SqlQuery<m_Table_row>("EXEC [backoffice].[s_pagination_invoice_tap_row] @cust_id,@email,@invoice_no,@invoice_status,@page_max",
                new SqlParameter("@cust_id", cust_id),
                new SqlParameter("@email", email == null ? "" : email),
                new SqlParameter("@invoice_no", invoice_no == null ? "" : invoice_no),
                new SqlParameter("@invoice_status", invoice_status == null ? "" : invoice_status),
                new SqlParameter("@page_max", page_max)
                ).FirstOrDefault();
            return res;
        }
        #endregion

        #region GetTableDataPaypalRefundTap
        public IEnumerable<BackOfficePaypalRefund> GetTableDataPaypalRefundTap(int cust_id, string email, int invoice_id, int pck_id, string pck_type_name, int page, int page_max)
        {
            var res = db.Database.SqlQuery<BackOfficePaypalRefund>("EXEC [backoffice].[s_pagination_PaypalRefund_tap] @cust_id,@email,@invoice_id,@pck_id,@pck_type_name,@page,@page_max",
               new SqlParameter("@cust_id", cust_id),
               new SqlParameter("@email", email == null ? "" : email),
               new SqlParameter("@invoice_id", invoice_id),
               new SqlParameter("@pck_id", pck_id),
               new SqlParameter("@pck_type_name", pck_type_name),
               new SqlParameter("@page", page),
               new SqlParameter("@page_max", page_max)
               ).ToList();
            return res;
        }
        public m_Table_row GetTableRowPaypalRefundTap(int cust_id, string email, int invoice_id, int pck_id, string pck_type_name, int page_max)
        {
            var res = db.Database.SqlQuery<m_Table_row>("EXEC [backoffice].[s_pagination_PaypalRefund_tap_row] @cust_id,@email,@invoice_id,@pck_id,@pck_type_name,@page_max",
               new SqlParameter("@cust_id", cust_id),
               new SqlParameter("@email", email == null ? "" : email),
               new SqlParameter("@invoice_id", invoice_id),
               new SqlParameter("@pck_id", pck_id),
               new SqlParameter("@pck_type_name", pck_type_name),
               new SqlParameter("@page_max", page_max)
               ).FirstOrDefault();
            return res;
        }
        #endregion

        #region GetTableDataReportTap
        public IEnumerable<v_PackageTap> GetTableDataReportTap(int cust_id, string pck_status, int page, int page_max)
        {
            var res = db.Database.SqlQuery<v_PackageTap>("EXEC [backoffice].[s_pagination_report_tap] @cust_id,@pck_status,@page,@row_page",
               new SqlParameter("@cust_id", cust_id),
               new SqlParameter("@pck_status", pck_status == null ? "" : pck_status),
               new SqlParameter("@page", page),
               new SqlParameter("@row_page", page_max)
               ).ToList();
            return res;
        }
        public m_Table_row GetTableRowReportTap(int cust_id, string pck_status, int page_max)
        {
            var res = db.Database.SqlQuery<m_Table_row>("EXEC [backoffice].[s_pagination_report_tap_row] @cust_id,@pck_status,@row_page",
               new SqlParameter("@cust_id", cust_id),
               new SqlParameter("@pck_status", pck_status == null ? "" : pck_status),
               new SqlParameter("@row_page", page_max)
               ).FirstOrDefault();
            return res;
        }
        #endregion

        #region GetTableDataClientFalseTap
        public IEnumerable<vBackOfficeClients_new> GetTableDataClientFalseTap(int cust_id, string email, string firstname, string lastname, string company_name, int status, int page, int page_max, bool exactmatch)
        {
            if (exactmatch)
            {
                var res = db.Database.SqlQuery<vBackOfficeClients_new>("EXEC [backoffice].[s_pagination_client_true_tap] @cust_id,@email,@firstname,@lastname,@company_name,@status,@page,@page_max",
                   new SqlParameter("@cust_id", cust_id),
                   new SqlParameter("@email", email == null ? "" : email),
                   new SqlParameter("@firstname", firstname == null ? "" : firstname),
                   new SqlParameter("@lastname", lastname == null ? "" : lastname),
                   new SqlParameter("@company_name", company_name == null ? "" : company_name),
                   new SqlParameter("@status", status),
                   new SqlParameter("@page", page),
                   new SqlParameter("@page_max", page_max)
                   ).ToList();
                return res;
            }
            else
            {
                var res = db.Database.SqlQuery<vBackOfficeClients_new>("EXEC [backoffice].[s_pagination_client_false_tap] @cust_id,@email,@firstname,@lastname,@company_name,@status,@page,@page_max",
                   new SqlParameter("@cust_id", cust_id),
                   new SqlParameter("@email", email == null ? "" : email),
                   new SqlParameter("@firstname", firstname == null ? "" : firstname),
                   new SqlParameter("@lastname", lastname == null ? "" : lastname),
                   new SqlParameter("@company_name", company_name == null ? "" : company_name),
                   new SqlParameter("@status", status),
                   new SqlParameter("@page", page),
                   new SqlParameter("@page_max", page_max)
                   ).ToList();
                return res;
            }
        }
        public m_Table_row GetTableRowClientFalseTap(int cust_id, string email, string firstname, string lastname, string company_name, int status, int page_max, bool exactmatch)
        {
            if (exactmatch)
            {
                var res = db.Database.SqlQuery<m_Table_row>("EXEC [backoffice].[s_pagination_client_true_tap_row] @cust_id,@email,@firstname,@lastname,@company_name,@status,@page_max",
                   new SqlParameter("@cust_id", cust_id),
                   new SqlParameter("@email", email == null ? "" : email),
                   new SqlParameter("@firstname", firstname == null ? "" : firstname),
                   new SqlParameter("@lastname", lastname == null ? "" : lastname),
                   new SqlParameter("@company_name", company_name == null ? "" : company_name),
                   new SqlParameter("@status", status),
                   new SqlParameter("@page_max", page_max)
                   ).FirstOrDefault();
                return res;
            }
            else
            {
                var res = db.Database.SqlQuery<m_Table_row>("EXEC [backoffice].[s_pagination_client_false_tap_row] @cust_id,@email,@firstname,@lastname,@company_name,@status,@page_max",
                   new SqlParameter("@cust_id", cust_id),
                   new SqlParameter("@email", email == null ? "" : email),
                   new SqlParameter("@firstname", firstname == null ? "" : firstname),
                   new SqlParameter("@lastname", lastname == null ? "" : lastname),
                   new SqlParameter("@company_name", company_name == null ? "" : company_name),
                   new SqlParameter("@status", status),
                   new SqlParameter("@page_max", page_max)
                   ).FirstOrDefault();
                return res;
            }
        }
        #endregion

        #region GetTableDataLogActionTap
        public IEnumerable<vBackOfficeLogActions> GetTableDataLogActionTap(string date_from, string date_to, string role, int page, int page_max)
        {
            var res = db.Database.SqlQuery<vBackOfficeLogActions>("EXEC [backoffice].[s_pagination_LogAction_tap] @date_from,@date_to,@role,@page,@page_max",
               new SqlParameter("@date_from", date_from == null ? "" : date_from + " 00:00:00"),
               new SqlParameter("@date_to", date_to == null ? "" : date_to + " 23:59:59"),
               new SqlParameter("@role", role == null ? "" : role),
               new SqlParameter("@page", page),
               new SqlParameter("@page_max", page_max)
               ).ToList();
            return res;
        }
        public m_Table_row GetTableRowLogActionTap(string date_from, string date_to, string role, int page_max)
        {
            var res = db.Database.SqlQuery<m_Table_row>("EXEC [backoffice].[s_pagination_LogAction_tap_row] @date_from,@date_to,@role,@page_max",
               new SqlParameter("@date_from", date_from == null ? "" : date_from + " 00:00:00"),
               new SqlParameter("@date_to", date_to == null ? "" : date_to + " 23:59:59"),
               new SqlParameter("@role", role == null ? "" : role),
               new SqlParameter("@page_max", page_max)
               ).FirstOrDefault();
            return res;
        }
        #endregion

        #region GetTableDataPaypalRefundProcessedTap
        public IEnumerable<BackOfficePaypalRefund> GetTableDataPaypalRefundProcessedTap(int cust_id, string email, int invoice_id, int pck_id, string pck_type_name, int page, int page_max)
        {
            var res = db.Database.SqlQuery<BackOfficePaypalRefund>("EXEC [backoffice].[s_pagination_PaypalRefundProcessed_tap] @cust_id,@email,@invoice_id,@pck_id,@pck_type_name,@page,@page_max",
               new SqlParameter("@cust_id", cust_id),
               new SqlParameter("@email", email == null ? "" : email),
               new SqlParameter("@invoice_id", invoice_id),
               new SqlParameter("@pck_id", pck_id),
               new SqlParameter("@pck_type_name", pck_type_name),
               new SqlParameter("@page", page),
               new SqlParameter("@page_max", page_max)
               ).ToList();
            return res;
        }
        public m_Table_row GetTableRowPaypalRefundProcessedTap(int cust_id, string email, int invoice_id, int pck_id, string pck_type_name, int page_max)
        {
            var res = db.Database.SqlQuery<m_Table_row>("EXEC [backoffice].[s_pagination_PaypalRefundProcessed_tap_row] @cust_id,@email,@invoice_id,@pck_id,@pck_type_name,@page_max",
               new SqlParameter("@cust_id", cust_id),
               new SqlParameter("@email", email == null ? "" : email),
               new SqlParameter("@invoice_id", invoice_id),
               new SqlParameter("@pck_id", pck_id),
               new SqlParameter("@pck_type_name", pck_type_name),
               new SqlParameter("@page_max", page_max)
               ).FirstOrDefault();
            return res;
        }
        #endregion

        #region GetTableDataPaypalRequestsHistoryTap
        public IEnumerable<VBackOfficeRequestsHistory> GetTableDataPaypalRequestsHistoryTap(string pck_add_dt, string pck_end_dt, int cust_id, string pck_status, int page, int page_max)
        {
            var res = db.Database.SqlQuery<VBackOfficeRequestsHistory>("EXEC [backoffice].[s_pagination_requestsHistory_tap] @pck_add_dt,@pck_end_dt,@cust_id,@pck_status,@page,@page_max",
               new SqlParameter("@pck_add_dt", pck_add_dt == null ? "" : pck_add_dt + " 00:00:00"),
               new SqlParameter("@pck_end_dt", pck_end_dt == null ? "" : pck_end_dt + " 23:59:59"),
               new SqlParameter("@cust_id", cust_id),
               new SqlParameter("@pck_status", pck_status == null ? "" : pck_status),
               new SqlParameter("@page", page),
               new SqlParameter("@page_max", page_max)
               ).ToList();
            return res;
        }
        public m_Table_row GetTableRowRequestsHistoryTap(string pck_add_dt, string pck_end_dt, int cust_id, string pck_status, int page_max)
        {
            var res = db.Database.SqlQuery<m_Table_row>("EXEC [backoffice].[s_pagination_requestsHistory_tap_row] @pck_add_dt,@pck_end_dt,@cust_id,@pck_status,@page_max",
               new SqlParameter("@pck_add_dt", pck_add_dt == null ? "" : pck_add_dt + " 00:00:00"),
               new SqlParameter("@pck_end_dt", pck_end_dt == null ? "" : pck_end_dt + " 23:59:59"),
               new SqlParameter("@cust_id", cust_id),
               new SqlParameter("@pck_status", pck_status == null ? "" : pck_status),
               new SqlParameter("@page_max", page_max)
               ).FirstOrDefault();
            return res;
        }
        #endregion

        #region GetTableDataResellerInvoiceTap
        public IEnumerable<v_Reseller_Invoices_BO> GetTableDataResellerInvoiceTap(string client_id, string email, int invoice_id, string status, int Package_No, int page, int page_max)
        {
            var res = db.Database.SqlQuery<v_Reseller_Invoices_BO>("EXEC [backoffice].[s_pagination_Reseller_invoice_tap] @client_id,@email,@invoice_id,@status,@Package_No,@page,@page_max",
               new SqlParameter("@client_id", client_id == null ? "" : client_id),
               new SqlParameter("@email", email == null ? "" : email),
               new SqlParameter("@invoice_id", invoice_id),
               new SqlParameter("@status", status == null ? "" : status),
               new SqlParameter("@Package_No", Package_No),
               new SqlParameter("@page", page),
               new SqlParameter("@page_max", page_max)
               ).ToList();
            return res;
        }
        public m_Table_row GetTableRowResellerInvoiceTap(string client_id, string email, int invoice_id, string status, int Package_No, int page_max)
        {
            var res = db.Database.SqlQuery<m_Table_row>("EXEC [backoffice].[s_pagination_Reseller_invoice_tap_row] @client_id,@email,@invoice_id,@status,@Package_No,@page_max",
               new SqlParameter("@client_id", client_id == null ? "" : client_id),
               new SqlParameter("@email", email == null ? "" : email),
               new SqlParameter("@invoice_id", invoice_id),
               new SqlParameter("@status", status == null ? "" : status),
               new SqlParameter("@Package_No", Package_No),
               new SqlParameter("@page_max", page_max)
               ).FirstOrDefault();
            return res;
        }
        #endregion

        #region GetTableDataUserTap
        public IEnumerable<vBackOfficeUser> GetTableDataUserTap(int ID, string USERNAME, string NAME, byte POSITIONS, string FAMILY, string STATUS, int page, int page_max)
        {
            var res = db.Database.SqlQuery<vBackOfficeUser>("EXEC [backoffice].[s_pagination_user_tap] @ID,@USERNAME,@NAME,@POSITIONS,@FAMILY,@STATUS,@page,@page_max",
               new SqlParameter("@ID", ID),
               new SqlParameter("@USERNAME", USERNAME == null ? "" : USERNAME),
               new SqlParameter("@NAME", NAME == null ? "" : NAME),
               new SqlParameter("@POSITIONS", POSITIONS),
               new SqlParameter("@FAMILY", FAMILY == null ? "" : FAMILY),
               new SqlParameter("@STATUS", STATUS == null ? "" : STATUS),
               new SqlParameter("@page", page),
               new SqlParameter("@page_max", page_max)
               ).ToList();
            return res;
        }
        public m_Table_row GetTableRowUserTap(int ID, string USERNAME, string NAME, byte POSITIONS, string FAMILY, string STATUS, int page_max)
        {
            var res = db.Database.SqlQuery<m_Table_row>("EXEC [backoffice].[s_pagination_user_tap_row] @ID,@USERNAME,@NAME,@POSITIONS,@FAMILY,@STATUS,@page_max",
               new SqlParameter("@ID", ID),
               new SqlParameter("@USERNAME", USERNAME == null ? "" : USERNAME),
               new SqlParameter("@NAME", NAME == null ? "" : NAME),
               new SqlParameter("@POSITIONS", POSITIONS),
               new SqlParameter("@FAMILY", FAMILY == null ? "" : FAMILY),
               new SqlParameter("@STATUS", STATUS == null ? "" : STATUS),
               new SqlParameter("@page_max", page_max)
               ).FirstOrDefault();
            return res;
        }
        #endregion

        #region GetTableDataResellerTap
        public IEnumerable<v_Reseller> GetTableDataResellerTap(string reseller, string company, string email, string phone, string status, int page, int page_max)
        {
            var sta = db.StatusCodes.FirstOrDefault(s => s.description.Equals(status));
            var res = db.Database.SqlQuery<v_Reseller>("EXEC [backoffice].[s_pagination_Reseller_tap] @reseller,@company,@email,@phone,@status,@page,@page_max",
               new SqlParameter("@reseller", reseller == null ? "" : reseller),
               new SqlParameter("@company", company == null ? "" : company),
               new SqlParameter("@email", email == null ? "" : email),
               new SqlParameter("@phone", phone == null ? "" : phone),
               new SqlParameter("@status", sta == null ? "" : sta.status),
               new SqlParameter("@page", page),
               new SqlParameter("@page_max", page_max)
               ).ToList();
            return res;
        }
        public m_Table_row GetTableRowResellerTap(string reseller, string company, string email, string phone, string status, int page_max)
        {
            var res = db.Database.SqlQuery<m_Table_row>("EXEC [backoffice].[s_pagination_Reseller_tap_row] @reseller,@company,@email,@phone,@status,@page_max",
               new SqlParameter("@reseller", reseller == null ? "" : reseller),
               new SqlParameter("@company", company == null ? "" : company),
               new SqlParameter("@email", email == null ? "" : email),
               new SqlParameter("@phone", phone == null ? "" : phone),
               new SqlParameter("@status", status == null ? "" : status),
               new SqlParameter("@page_max", page_max)
               ).FirstOrDefault();
            return res;
        }
        #endregion

        #region GetTableDataResellerBillTap
        public IEnumerable<v_Reseller_Bill> GetTableDataResellerBillTap(string reseller, string month, string status, int page, int page_max)
        {
            var res = db.Database.SqlQuery<v_Reseller_Bill>("EXEC [backoffice].[s_pagination_Reseller_Bill_tap] @reseller,@month,@status,@page,@page_max",
               new SqlParameter("@reseller", reseller == null ? "" : reseller),
               new SqlParameter("@month", month == null ? "" : month),
               new SqlParameter("@status", status == null ? "" : status),
               new SqlParameter("@page", page),
               new SqlParameter("@page_max", page_max)
               ).ToList();
            return res;
        }
        public m_Table_row GetTableRowResellerBillTap(string reseller, string month, string status, int page_max)
        {
            var res = db.Database.SqlQuery<m_Table_row>("EXEC [backoffice].[s_pagination_Reseller_Bill_tap_row] @reseller,@month,@status,@page_max",
               new SqlParameter("@reseller", reseller == null ? "" : reseller),
               new SqlParameter("@month", month == null ? "" : month),
               new SqlParameter("@status", status == null ? "" : status),
               new SqlParameter("@page_max", page_max)
               ).FirstOrDefault();
            return res;
        }
        #endregion

        #region GetTableDataResellerOrderTap
        public IEnumerable<v_Reseller_Order> GetTableDataResellerOrderTap(string reseller, int pck_id, string status, int page, int page_max)
        {
            var res = db.Database.SqlQuery<v_Reseller_Order>("EXEC [backoffice].[s_pagination_Reseller_Order_tap] @reseller,@pck_id,@status,@page,@page_max",
               new SqlParameter("@reseller", reseller == null ? "" : reseller),
               new SqlParameter("@pck_id", pck_id),
               new SqlParameter("@status", status == null ? "" : status),
               new SqlParameter("@page", page),
               new SqlParameter("@page_max", page_max)
               ).ToList();
            return res;
        }
        public m_Table_row GetTableRowResellerOrderTap(string reseller, int pck_id, string status, int page_max)
        {
            var res = db.Database.SqlQuery<m_Table_row>("EXEC [backoffice].[s_pagination_Reseller_Order_tap_row] @reseller,@pck_id,@status,@page_max",
               new SqlParameter("@reseller", reseller == null ? "" : reseller),
               new SqlParameter("@pck_id", pck_id),
               new SqlParameter("@status", status == null ? "" : status),
               new SqlParameter("@page_max", page_max)
               ).FirstOrDefault();
            return res;
        }
        #endregion

        #region GetTableDataPaymentTap
        public IEnumerable<vBackOfficePayments> GetTableDataPaymentTap(string packageId, string payment_status, string client_name, string family_name, int package_status, int page, int page_max)
        {
            var res = db.Database.SqlQuery<vBackOfficePayments>("EXEC [backoffice].[s_pagination_payment_tap] @packageId,@payment_status,@client_name,@family_name,@package_status,@page,@page_max",
               new SqlParameter("@packageId", packageId == null ? "" : packageId),
               new SqlParameter("@payment_status", payment_status == null ? "" : payment_status),
               new SqlParameter("@client_name", client_name == null ? "" : client_name),
               new SqlParameter("@family_name", family_name == null ? "" : family_name),
               new SqlParameter("@package_status", package_status),
               new SqlParameter("@page", page),
               new SqlParameter("@page_max", page_max)
               ).ToList();
            return res;
        }
        public m_Table_row GetTableRowPaymentTap(string packageId, string payment_status, string client_name, string family_name, int package_status, int page_max)
        {
            var res = db.Database.SqlQuery<m_Table_row>("EXEC [backoffice].[s_pagination_payment_tap_row] @packageId,@payment_status,@client_name,@family_name,@package_status,@page_max",
               new SqlParameter("@packageId", packageId == null ? "" : packageId),
               new SqlParameter("@payment_status", payment_status == null ? "" : payment_status),
               new SqlParameter("@client_name", client_name == null ? "" : client_name),
               new SqlParameter("@family_name", family_name == null ? "" : family_name),
               new SqlParameter("@package_status", package_status),
               new SqlParameter("@page_max", page_max)
               ).FirstOrDefault();
            return res;
        }

        
        #endregion
    }
}
