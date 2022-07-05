using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BackOffice.WebAPI.Authen;
using BackOffice.WebAPI.Models;
using Backup.ClassLibrary.Abstract;
using System.Globalization;

namespace BackOffice.WebAPI.Controllers
{

    [JWTAuthorize("SuperAdmin", "Admin", "Supervisor", "Operator", "Manager")]
    public class ExportController : ApiController
    {
        private IExport _Ex;
        public ExportController(IExport _Ex)
        {
            this._Ex = _Ex;
        }

        [HttpPost]
        [Route("api/export/packagetap")]
        public IHttpActionResult GetPackageTap([FromBody] m_export_package_tap request)
        {
            try
            {
                var getdata = _Ex.ExportPackageTap(
                    request.Search_Package_No,
                    request.Search_Type,
                    request.Search_PackageStatus,
                    request.Search_ClientName,
                    request.Search_Lastname);

                return Json(new { DataTable = getdata });
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }

        [HttpPost]
        [Route("api/export/newrequesttab")]
        public IHttpActionResult GetNewRequestTap([FromBody] RequestsPackage_export request)
        {
            try
            {
                var getdata = _Ex.ExportNewRequestTap(
                    request.cust_id,
                    request.email,
                    request.pck_status);

                return Json(new { DataTable = getdata });
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }

        [HttpPost]
        [Route("api/export/invoicetab")]
        public IHttpActionResult GetInvoiceTap([FromBody] filter_invoice_export request)
        {
            try
            {
                var getdata = _Ex.ExportInvoiceTap(
                    request.cust_id,
                    request.email,
                    request.invoice_no,
                    request.invoice_status);

                return Json(new { DataTable = getdata });
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }

        [HttpPost]
        [Route("api/export/paypalrefundtab")]
        public IHttpActionResult GetPaypalRefundTap([FromBody] Refund_Find_export request)
        {
            try
            {
                var getdata = _Ex.ExportPaypalRefundTap(
                    request.cust_id,
                    request.email,
                    request.invoice_id,
                    request.pck_id,
                    request.pck_type_name);

                return Json(new { DataTable = getdata });
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }

        [HttpPost]
        [Route("api/export/paypalrefundprocessedtab")]
        public IHttpActionResult GetPaypalRefundProcessedTap([FromBody] Refund_Find_export request)
        {
            try
            {
                var getdata = _Ex.ExportPaypalRefundProcessedTap(
                    request.cust_id,
                    request.email,
                    request.invoice_id,
                    request.pck_id,
                    request.pck_type_name);

                return Json(new { DataTable = getdata });
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }

        [HttpPost]
        [Route("api/export/reporttab")]
        public IHttpActionResult GetReportTap([FromBody] Report_Find_export request)
        {
            try
            {
                var getdata = _Ex.ExportReportTap(
                    request.cust_id,
                    request.pck_status);

                return Json(new { DataTable = getdata });
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/export/clienttab")]
        public IHttpActionResult GetClientTap([FromBody] m_clients_export request)
        {
            try
            {
                int defaultsStatus = 0;
                int status = int.TryParse(request.statusFilter.ToString().Trim(), out defaultsStatus) ? request.statusFilter : 6;
                var getdata = _Ex.ExportClientFalseTap(
                    request.ID,
                    request.Email,
                    request.Name,
                    request.FName,
                    request.Company,
                    request.statusFilter,
                    request.exactmatch);
                return Json(new { DataTable = getdata });
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/export/logactiontab")]
        public IHttpActionResult GetLogActionTap([FromBody] LogAction_Find_export request)
        {
            try
            {
                var getdata = _Ex.ExportLogActionTap(
                    request.date_from,
                    request.date_to,
                    request.role);

                return Json(new { DataTable = getdata });
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }

        [HttpPost]
        [Route("api/export/requsetshistorytab")]
        public IHttpActionResult GetrequestsHistoryTap([FromBody] RequestsHistory_Find_export request)
        {
            try
            {
                var getdata = _Ex.ExportPaypalRequestsHistoryTap(
                    request.pck_add_dt,
                    request.pck_end_dt,
                    request.cust_id,
                    request.pck_status);

                return Json(new { DataTable = getdata });
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }

        [HttpPost]
        [Route("api/export/usertab")]
        public IHttpActionResult GetUserTap([FromBody] Employee_Find_export request)
        {
            try
            {
                var getdata = _Ex.ExportUserTap(
                    request.emp_id,
                    request.emp_username,
                    request.emp_fristname,
                    request.emp_position,
                    request.emp_lastname,
                    request.emp_status);

                return Json(new { DataTable = getdata });
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }

        [HttpPost]
        [Route("api/export/resellerinvoicetab")]
        public IHttpActionResult GetResellerInvoiceTap([FromBody] m_filter_invoice_export request)
        {
            try
            {
                var getdata = _Ex.ExportResellerInvoiceTap(
                    request.client_id,
                    request.email,
                    request.invoice_id,
                    request.status,
                    request.Package_No);

                return Json(new { DataTable = getdata });
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }


        [HttpPost]
        [Route("api/export/resellertab")]
        public IHttpActionResult GetResellerTap([FromBody] m_filter_reseller_export request)
        {
            try
            {
                var getdata = _Ex.ExportResellerTap(
                    request.reseller_id,
                    request.company,
                    request.email,
                    request.phone,
                    request.status);

                return Json(new { DataTable = getdata });
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }

        [HttpPost]
        [Route("api/export/resellerbilltab")]
        public IHttpActionResult GetResellerBillTap([FromBody] m_filter_bill_export request)
        {
            try
            {
                var mon = "";
                DateTimeFormatInfo mfi = new DateTimeFormatInfo();
                if (request.month != null)
                {
                    mon = mfi.GetMonthName(request.month.Value.Month).ToString();
                }
                var getdata = _Ex.ExportResellerBillTap(
                    request.reseller_id,
                    mon,
                    request.status);

                return Json(new { DataTable = getdata });
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }

        [HttpPost]
        [Route("api/export/resellerordertab")]
        public IHttpActionResult GetResellerOrderTap([FromBody] m_filter_order_export request)
        {
            try
            {
                var getdata = _Ex.ExportResellerOrderTap(
                    request.reseller_id,
                    request.pck_id,
                    request.status);

                return Json(new { DataTable = getdata });
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }

        [HttpPost]
        [Route("api/export/paymenttab")]
        public IHttpActionResult GetPaymentTap([FromBody] m_payments_export request)
        {
            try
            {
                var getdata = _Ex.ExportPaymentTap(
                    request.PaymentNo,
                    request.PaymentStatus,
                    request.Name,
                    request.Family,
                    request.PackageStatus);

                return Json(new { DataTable = getdata });
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }

    }
}
