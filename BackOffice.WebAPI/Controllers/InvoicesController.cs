using BackOffice.WebAPI.Authen;
using BackOffice.WebAPI.Models;
using Backup.ClassLibrary.Abstract;
using Backup.ClassLibrary.Concrete;
using Backup.ClassLibrary.Entity;
using Backup.ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BackOffice.WebAPI.Controllers
{
    [JWTAuthorize("SuperAdmin", "Admin", "Supervisor", "Operator", "Manager")]
    public class InvoicesController : ApiController
    {
        private IAppRep _EFapp;
        private Iinvoices _INV;
        public string ip_address = (System.Web.HttpContext.Current != null) ? System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString() : "No Ip";

        public InvoicesController(Iinvoices inv, IAppRep AppRep)
        {
            _INV = inv;
            _EFapp = AppRep;
        }

        [System.Web.Http.Route("api/invoice-bill")]
        public IHttpActionResult PostInvoicesDetail([FromBody]m_InvoiceDetail values)
        {
            BO_MessageInvoice_return zxxz = new BO_MessageInvoice_return();

            try
            {
                var user = Authentication.User;
                _EFapp.save_logaction("Invoices Controller", "Get Invoices Detail: " + user.emp_permission, ip_address, user.emp_id);

                var res_inv = _INV.getInvoiceDetail(values.invoice_no, values.cust_id, values.vcc_id);
                return Json(res_inv);
            }
            catch (Exception e)
            {
                zxxz.Message = "UnSuccessful";
                return Json(zxxz);
            }
        }

        [System.Web.Http.Route("api/invoice-bill-all")]
        public IHttpActionResult PostInvoicesAll()
        {
            BO_MessageInvoice_return zxxz = new BO_MessageInvoice_return();

            try
            {
                var user = Authentication.User;
                _EFapp.save_logaction("Invoices Controller", "Load Invoices All Bills: " + user.emp_permission, ip_address, user.emp_id);

                var res_inv = _INV.loadInvoiceAllBills.OrderByDescending(o => o.add_dt);
                return Json(res_inv);
            }
            catch (Exception e)
            {
                zxxz.Message = "UnSuccessful";
                return Json(zxxz);
            }
        }

        [System.Web.Http.Route("api/invoice/suspend")]
        public IHttpActionResult PostInvoiceSuspend([FromBody]m_suspend inv)
        {
            BO_MessageInvoice_return zxxz = new BO_MessageInvoice_return();
            try
            {
                var user = Authentication.User;
                if (ModelState.IsValid && user != null)
                {
                    _EFapp.save_logaction("Invoices controller", "Package invoice suspend : " + user.emp_permission, ip_address, user.emp_id);
                    var res_inv = _INV.SuspendInvoice(inv);
                    return Json(res_inv);
                }
                zxxz.Message = "UnSuccessful";
                return Json(zxxz);
            }
            catch (Exception e)
            {
                zxxz.Message = "UnSuccessful";
                return Json(zxxz);
            }
        }

        [System.Web.Http.Route("api/invoice/edit")]
        public IHttpActionResult PostEditInvoiceStatus([FromBody]m_invedit inv_req)
        {
            BO_MessageInvoice_return zxxz = new BO_MessageInvoice_return();

            try
            {
                var user = Authentication.User;
                if (ModelState.IsValid && user != null)
                {
                    _EFapp.save_logaction("Invoices controller", "Edit invoice status from invoice id :+" + inv_req.invoice_no + "+ : " + user.emp_permission, ip_address, user.emp_id);
                    var res_inv = _INV.EditInvoiceStatus(inv_req.invoice_no,inv_req.status_i,inv_req.user_type);
                    return Json(res_inv);
                }
                zxxz.Message = "UnSuccessful";
                return Json(zxxz);
            }
            catch (Exception e)
            {
                zxxz.Message = e.Message;
                return Json(zxxz);
            }
        }

        [System.Web.Http.Route("api/invoice/send")]
        public IHttpActionResult PostSendInvoiceBill([FromBody]m_RetrySendInvoice values)
        {
            BO_MessageInvoice_return zxxz = new BO_MessageInvoice_return();

            try
            {

                var user = Authentication.User;
                if (ModelState.IsValid && user != null)
                {
                    _EFapp.save_logaction("Invoices controller", "Send invoice bill : " + user.emp_permission, ip_address, user.emp_id);

                    //Send Invoice to email customer enterpirse
                    if (values != null)
                    {
                        var res_inv = _INV.getInvoiceDetail(values.invoice_no, values.cust_id, values.packageId);

                        vBOviewInvoiceTab payload = res_inv.FirstOrDefault<vBOviewInvoiceTab>(s => s.pck_id.Equals(values.packageId));

                        var msg = new m_MessageSend();

                        var InvoiceBody = new getInvoiceEmailBody { vcc_id = payload.vcc_id, CustomerName = (payload.firstname + " " + payload.lastname), VMLicense = payload.vm.Value, Storage = payload.storage.Value };

                        System.Threading.Tasks.Task.Factory.StartNew(() =>
                            SendMail.MailAttachments(values.email, "9T YOUR REQUEST HAS BEEN PROCESSED", msg.InvoiceBodyTemplateEnterpirse(InvoiceBody), msg.InvoiceAttachmentsTemplateEnterprise(payload))
                        );

                        return Json(payload);
                    }
                }
                zxxz.Message = "UnSuccessful";
                return Json(zxxz);
            }
            catch (Exception e)
            {
                zxxz.Message = "UnSuccessful";
                return Json(zxxz);
            }
        }

        [HttpPost]
        [Route("api/invoice/update/status")]
        public IHttpActionResult UpdateStatusInvoice([FromBody]m_ChangeStatusInvoice request)
        {
            if (request.user_type == 0)
            {
                return Json(request);
            }
            else if (request.user_type == 1)
            {
                return Json(request);
            }
            else if (request.user_type == 2)
            {
                return Json(request);
            }
            else
            {
                return BadRequest("Type user incorrect (0 = normal user ,1 = enterprise,2 = resaller)");
            }
        }

    }

    public class BO_MessageInvoice_return
    {
        public string Message { get; set; }
    }
}