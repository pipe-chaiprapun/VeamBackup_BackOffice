using BackOffice.WebAPI.Authen;
using BackOffice.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Backup.ClassLibrary.Abstract;
using System.Globalization;

namespace BackOffice.WebAPI.Controllers
{
    //[JWTAuthorize("SuperAdmin", "Admin", "Supervisor", "Operator", "Manager")]
    public class GetDataTableController : ApiController
    {
        private IGetTable _GetTable;
        public GetDataTableController(IGetTable _GetTable)
        {
            this._GetTable = _GetTable;
        }
        [HttpPost]
        [Route("api/get/packagetap")]
        public IHttpActionResult GetPackageTap([FromBody] m_pagination_package_tap request)
        {
            try
            {
                var getdata = _GetTable.GetTableDataPackageTap(
                    request.now_page,
                    request.max_page,
                    request.Search_Package_No,
                    request.Search_Type,
                    request.Search_PackageStatus,
                    request.Search_ClientName,
                    request.Search_Lastname);
                var getRow = _GetTable.GetTableRowPackageTap(
                    request.max_page,
                    request.Search_Package_No,
                    request.Search_Type,
                    request.Search_PackageStatus,
                    request.Search_ClientName,
                    request.Search_Lastname);
                if (getdata != null && getRow != null)
                {
                    return Json(new { DataTable = getdata , Page = getRow });
                }
                else
                {
                    return Json(new { Error = "error foe get table please check request." });
                }
            }
            catch (Exception  ex) {
                return Json(ex.Message);
            }
            
        }


        [HttpPost]
        [Route("api/get/promotap")]
        public IHttpActionResult GetPromoTap([FromBody] m_pagination_promo_tap request)
        {
            try
            {
                var getdata = _GetTable.GetTableDataPromoTap(
                    request.now_page,
                    request.max_page,
                    request.Search_Package_No,
                    request.Search_Promo_No);
                var getRow = _GetTable.GetTableRowPromoTap(
                    request.max_page,
                    request.Search_Package_No,
                    request.Search_Promo_No);
                if (getdata != null && getRow != null)
                {
                    return Json(new { DataTable = getdata, Page = getRow });
                }
                else
                {
                    return Json(new { Error = "error foe get table please check request." });
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }

        [HttpPost]
        [Route("api/get/promocodetap")]
        public IHttpActionResult GetPromocodeTap([FromBody] m_pagination_promocode_tap request)
        {
            try
            {
                var getdata = _GetTable.GetTableDataPromoCodeTap(
                    request.now_page,
                    request.max_page,
                    request.Search_Promo_code);
                var getRow = _GetTable.GetTableRowPromoCodeTap(
                    request.max_page,
                    request.Search_Promo_code);
                if (getdata != null && getRow != null)
                {
                    return Json(new { DataTable = getdata, Page = getRow });
                }
                else
                {
                    return Json(new { Error = "error foe get table please check request." });
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }


        [HttpPost]
        [Route("api/get/newrequesttab")]
        public IHttpActionResult GetNewRequestTap([FromBody] RequestsPackage_tab request)
        {
            try
            {
                var getdata = _GetTable.GetTableDataNewRequestTap(
                    request.cust_id,
                    request.email,
                    request.pck_status,
                    request.now_page,
                    request.max_page);
                var getRow = _GetTable.GetTableRowNewRequestTap(
                    request.cust_id,
                    request.email,
                    request.pck_status,
                    request.max_page);
                if (getdata != null && getRow != null)
                {
                    return Json(new { DataTable = getdata, Page = getRow });
                }
                else
                {
                    return Json(new { Error = "error foe get table please check request." });
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }

        [HttpPost]
        [Route("api/get/invoicetab")]
        public IHttpActionResult GetInvoiceTap([FromBody] filter_invoice_tab request)
        {
            try
            {
                var getdata = _GetTable.GetTableDataInvoiceTap(
                    request.cust_id,
                    request.email,
                    request.invoice_no,
                    request.invoice_status,
                    request.now_page,
                    request.max_page);
                var getRow = _GetTable.GetTableRowInvoiceTap(
                    request.cust_id,
                    request.email,
                    request.invoice_no,
                    request.invoice_status,
                    request.max_page);
                if (getdata != null && getRow != null)
                {
                    return Json(new { DataTable = getdata, Page = getRow });
                }
                else
                {
                    return Json(new { Error = "error foe get table please check request." });
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }

        [HttpPost]
        [Route("api/get/paypalrefundtab")]
        public IHttpActionResult GetPaypalRefundTap([FromBody] Refund_Find_tab request)
        {
            try
            {
                var getdata = _GetTable.GetTableDataPaypalRefundTap(
                    request.cust_id,
                    request.email,
                    request.invoice_id,
                    request.pck_id,
                    request.pck_type_name,
                    request.now_page,
                    request.max_page);
                var getRow = _GetTable.GetTableRowPaypalRefundTap(
                    request.cust_id,
                    request.email,
                    request.invoice_id,
                    request.pck_id,
                    request.pck_type_name,
                    request.max_page);
                if (getdata != null && getRow != null)
                {
                    return Json(new { DataTable = getdata, Page = getRow });
                }
                else
                {
                    return Json(new { Error = "error foe get table please check request." });
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }

        [HttpPost]
        [Route("api/get/paypalrefundprocessedtab")]
        public IHttpActionResult GetPaypalRefundProcessedTap([FromBody] Refund_Find_tab request)
        {
            try
            {
                var getdata = _GetTable.GetTableDataPaypalRefundProcessedTap(
                    request.cust_id,
                    request.email,
                    request.invoice_id,
                    request.pck_id,
                    request.pck_type_name,
                    request.now_page,
                    request.max_page);
                var getRow = _GetTable.GetTableRowPaypalRefundProcessedTap(
                    request.cust_id,
                    request.email,
                    request.invoice_id,
                    request.pck_id,
                    request.pck_type_name,
                    request.max_page);
                if (getdata != null && getRow != null)
                {
                    return Json(new { DataTable = getdata, Page = getRow });
                }
                else
                {
                    return Json(new { Error = "error foe get table please check request." });
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }

        [HttpPost]
        [Route("api/get/reporttab")]
        public IHttpActionResult GetReportTap([FromBody] Report_Find_tab request)
        {
            try
            {
                var getdata = _GetTable.GetTableDataReportTap(
                    request.cust_id,
                    request.pck_status,
                    request.now_page,
                    request.max_page);
                var getRow = _GetTable.GetTableRowReportTap(
                    request.cust_id,
                    request.pck_status,
                    request.max_page);
                if (getdata != null && getRow != null)
                {
                    return Json(new { DataTable = getdata, Page = getRow });
                }
                else
                {
                    return Json(new { Error = "error foe get table please check request." });
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }

        [HttpPost]
        [Route("api/get/clienttab")]
        public IHttpActionResult GetClientTap([FromBody] m_clients_tab request)
        {
            try
            {
                int defaultsStatus = 0;
                int status = int.TryParse(request.statusFilter.ToString().Trim(), out defaultsStatus) ? request.statusFilter : 6;
                var getdata = _GetTable.GetTableDataClientFalseTap(
                    request.ID,
                    request.Email,
                    request.Name,
                    request.FName,
                    request.Company,
                    request.statusFilter,
                    request.now_page,
                    request.max_page,
                    request.exactmatch);
                var getRow = _GetTable.GetTableRowClientFalseTap(
                    request.ID,
                    request.Email,
                    request.Name,
                    request.FName,
                    request.Company,
                    request.statusFilter,
                    request.max_page,
                    request.exactmatch);
                if (getdata != null && getRow != null)
                {
                    return Json(new { DataTable = getdata, Page = getRow });
                }
                else
                {
                    return Json(new { Error = "error foe get table please check request." });
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }

        [HttpPost]
        [Route("api/get/logactiontab")]
        public IHttpActionResult GetLogActionTap([FromBody] LogAction_Find_tab request)
        {
            try
            {
                var getdata = _GetTable.GetTableDataLogActionTap(
                    request.date_from,
                    request.date_to,
                    request.role,
                    request.now_page,
                    request.max_page);
                var getRow = _GetTable.GetTableRowLogActionTap(
                    request.date_from,
                    request.date_to,
                    request.role,
                    request.max_page);
                if (getdata != null && getRow != null)
                {
                    return Json(new { DataTable = getdata, Page = getRow });
                }
                else
                {
                    return Json(new { Error = "error foe get table please check request." });
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }

        [HttpPost]
        [Route("api/get/requsetshistorytab")]
        public IHttpActionResult GetrequestsHistoryTap([FromBody] RequestsHistory_Find_tab request)
        {
            try
            {
                var getdata = _GetTable.GetTableDataPaypalRequestsHistoryTap(
                    request.pck_add_dt,
                    request.pck_end_dt,
                    request.cust_id,
                    request.pck_status,
                    request.now_page,
                    request.max_page);
                var getRow = _GetTable.GetTableRowRequestsHistoryTap(
                    request.pck_add_dt,
                    request.pck_end_dt,
                    request.cust_id,
                    request.pck_status,
                    request.max_page);
                if (getdata != null && getRow != null)
                {
                    return Json(new { DataTable = getdata, Page = getRow });
                }
                else
                {
                    return Json(new { Error = "error foe get table please check request." });
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }

        [HttpPost]
        [Route("api/get/usertab")]
        public IHttpActionResult GetUserTap([FromBody] Employee_Find_tab request)
        {
            try
            {
                var getdata = _GetTable.GetTableDataUserTap(
                    request.emp_id,
                    request.emp_username,
                    request.emp_fristname,
                    request.emp_position,
                    request.emp_lastname,
                    request.emp_status,
                    request.now_page,
                    request.max_page);
                var getRow = _GetTable.GetTableRowUserTap(
                    request.emp_id,
                    request.emp_username,
                    request.emp_fristname,
                    request.emp_position,
                    request.emp_lastname,
                    request.emp_status,
                    request.max_page);
                if (getdata != null && getRow != null)
                {
                    return Json(new { DataTable = getdata, Page = getRow });
                }
                else
                {
                    return Json(new { Error = "error foe get table please check request." });
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }

        [HttpPost]
        [Route("api/get/resellerinvoicetab")]
        public IHttpActionResult GetResellerInvoiceTap([FromBody] m_filter_invoice_tab request)
        {
            try
            {
                var getdata = _GetTable.GetTableDataResellerInvoiceTap(
                    request.client_id,
                    request.email,
                    request.invoice_id,
                    request.status,
                    request.Package_No,
                    request.now_page,
                    request.max_page);
                var getRow = _GetTable.GetTableRowResellerInvoiceTap(
                    request.client_id,
                    request.email,
                    request.invoice_id,
                    request.status,
                    request.Package_No,
                    request.max_page);
                if (getdata != null && getRow != null)
                {
                    return Json(new { DataTable = getdata, Page = getRow });
                }
                else
                {
                    return Json(new { Error = "error foe get table please check request." });
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }

        [HttpPost]
        [Route("api/get/resellertab")]
        public IHttpActionResult GetResellerTap([FromBody] m_filter_reseller_tab request)
        {
            try
            {
                var getdata = _GetTable.GetTableDataResellerTap(
                    request.reseller_id,
                    request.company,
                    request.email,
                    request.phone,
                    request.status,
                    request.now_page,
                    request.max_page);
                var getRow = _GetTable.GetTableRowResellerTap(
                    request.reseller_id,
                    request.company,
                    request.email,
                    request.phone,
                    request.status,
                    request.max_page);
                if (getdata != null && getRow != null)
                {
                    return Json(new { DataTable = getdata, Page = getRow });
                }
                else
                {
                    return Json(new { Error = "error foe get table please check request." });
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }

        [HttpPost]
        [Route("api/get/resellerbilltab")]
        public IHttpActionResult GetResellerBillTap([FromBody] m_filter_bill_tab request)
        {
            try
            {
                var mon = "";
                DateTimeFormatInfo mfi = new DateTimeFormatInfo();
                if (request.month != null)
                {
                    mon = mfi.GetMonthName(request.month.Value.Month).ToString();
                }
                var getdata = _GetTable.GetTableDataResellerBillTap(
                    request.reseller_id,
                    mon,
                    request.status,
                    request.now_page,
                    request.max_page);
                var getRow = _GetTable.GetTableRowResellerBillTap(
                    request.reseller_id,
                    mon,
                    request.status,
                    request.max_page);
                if (getdata != null && getRow != null)
                {
                    return Json(new { DataTable = getdata, Page = getRow });
                }
                else
                {
                    return Json(new { Error = "error foe get table please check request." });
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }

        [HttpPost]
        [Route("api/get/resellerordertab")]
        public IHttpActionResult GetResellerOrderTap([FromBody] m_filter_order_tab request)
        {
            try
            {
                var getdata = _GetTable.GetTableDataResellerOrderTap(
                    request.reseller_id,
                    request.pck_id,
                    request.status,
                    request.now_page,
                    request.max_page);
                var getRow = _GetTable.GetTableRowResellerOrderTap(
                    request.reseller_id,
                    request.pck_id,
                    request.status,
                    request.max_page);
                if (getdata != null && getRow != null)
                {
                    return Json(new { DataTable = getdata, Page = getRow });
                }
                else
                {
                    return Json(new { Error = "error foe get table please check request." });
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }

        [HttpPost]
        [Route("api/get/paymenttab")]
        public IHttpActionResult GetPaymentTap([FromBody] m_payments_tab request)
        {
            try
            {
                var getdata = _GetTable.GetTableDataPaymentTap(
                    request.PaymentNo,
                    request.PaymentStatus,
                    request.Name,
                    request.Family,
                    request.PackageStatus,
                    request.now_page,
                    request.max_page);
                var getRow = _GetTable.GetTableRowPaymentTap(
                    request.PaymentNo,
                    request.PaymentStatus,
                    request.Name,
                    request.Family,
                    request.PackageStatus,
                    request.max_page);
                if (getdata != null && getRow != null)
                {
                    return Json(new { DataTable = getdata, Page = getRow });
                }
                else
                {
                    return Json(new { Error = "error foe get table please check request." });
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }

    }
}
