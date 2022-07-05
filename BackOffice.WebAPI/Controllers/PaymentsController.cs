using BackOffice.WebAPI.Authen;
using Backup.ClassLibrary.Abstract;
using Backup.ClassLibrary.Concrete.VeeamCloudConnect;
using Backup.ClassLibrary.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BackOffice.WebAPI.Controllers
{
    [JWTAuthorize("SuperAdmin", "Admin", "Supervisor", "Manager", "Operator")]
    public class PaymentsController : ApiController
    {
        private IPayments _payments;
        private IAppRep _EFapp;
        public string ipaddress = (System.Web.HttpContext.Current != null) ? System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString() : "No Ip";

        public PaymentsController(IPayments payments, IAppRep appRep)
        {
            _payments = payments;
            _EFapp = appRep;
        }

        [HttpPost]
        [Route("api/payments-all")]
        public IHttpActionResult Payments_all()
        {
            BO_Messagepayment_return zxxz = new BO_Messagepayment_return();

            try
            {
                var user = Authentication.User;
                _EFapp.save_logaction("payments page", "payments all page user: " + user.emp_permission, ipaddress, user.emp_id);

                var model = _payments.getAllPaymentsTx.OrderByDescending(f => f.add_dt);
                return Json(model);
            }catch(Exception e)
            {
                zxxz.Message = "UnSuccessful";
                return Json(zxxz);
            }
        }



        [HttpPost]
        [Route("api/invoice-details")]
        public IHttpActionResult PaymentInvoiceDetails([FromBody]m_payments_inv value)
        {
            BO_Messagepayment_return zxxz = new BO_Messagepayment_return();
            try { 

            var user = Authentication.User;
            _EFapp.save_logaction("payments page", "Payment Invoice Details filters page user: " + user.emp_permission, ipaddress, user.emp_id);

            var model = _payments.getInvoiceDetail(value);
            return Json(model);
            }
            catch (Exception e)
            {
                zxxz.Message = "UnSuccessful";
                return Json(zxxz);
            }
        }

        [HttpPost]
        [Route("api/payment-details")]
        public IHttpActionResult PaymentDetails([FromBody]m_payments_detail value)
        {
            BO_Messagepayment_return zxxz = new BO_Messagepayment_return();

            try { 
            var user = Authentication.User;
            _EFapp.save_logaction("payments page", "PaymentDetails page user: " + user.emp_permission, ipaddress, user.emp_id);

            if (string.IsNullOrEmpty(value.txnId)) return BadRequest("TxId not valid");

            var model = _payments.getReportsDetail(value.txnId);

            if (model == null)
                return BadRequest("BadRequest");
            else
                return Json(model);
            }
            catch (Exception e)
            {
                zxxz.Message = "UnSuccessful";
                return Json(zxxz);
            }
        }

        [Route("api/payment/getveeam")]
        [HttpGet]
        public IHttpActionResult Getrepository()
        {
            BO_Messagepayment_return zxxz = new BO_Messagepayment_return();

            try { 
            VccGetStorage vcc_storage = new VccGetStorage();

            var data = vcc_storage.getGetStorageAll();
            var count = data.Entities.CloudTenants.Count();

            string str = "{";

            for (var i = 0; i < count; i++)
            {
                var Quota = "";
                var UsedQuota = "";
                var MemoryUsageMb = "";
                var CPUCount = "";

                var name = data.Entities.CloudTenants[i].Name;

                if (data.Entities.CloudTenants[i].Resources.CloudTenantResource != null)
                {
                    Quota = data.Entities.CloudTenants[i].Resources.CloudTenantResource.RepositoryQuota.Quota.ToString();
                    UsedQuota = data.Entities.CloudTenants[i].Resources.CloudTenantResource.RepositoryQuota.UsedQuota.ToString();
                }
                else
                {
                    Quota = "0";
                    UsedQuota = "0";
                }
                if (data.Entities.CloudTenants[i].ComputeResources.CloudTenantComputeResource != null)
                {
                    MemoryUsageMb = data.Entities.CloudTenants[i].ComputeResources.CloudTenantComputeResource.ComputeResourceStats.MemoryUsageMb.ToString();
                    CPUCount = data.Entities.CloudTenants[i].ComputeResources.CloudTenantComputeResource.ComputeResourceStats.CPUCount.ToString();
                }
                else
                {
                    MemoryUsageMb = "0";
                    CPUCount = "0";
                }


                if (i == 0)
                {
                    str += "'" + name + "':" + "'/" + CPUCount + "Ghz/" + Convert.ToInt32(MemoryUsageMb) / 1024 + "GB" + "'";
                }
                else
                {
                    str += ",'" + name + "':" + "'/" + CPUCount + "Ghz/" + Convert.ToInt32(MemoryUsageMb) / 1024 + "GB" + "'";
                }


            }

            str += "}";

            JObject json = JObject.Parse(str);

            return Json(json);
            }
            catch (Exception e)
            {
                zxxz.Message = "UnSuccessful";
                return Json(zxxz);
            }
        }

        [Route("api/payment/Allrepository")]
        [HttpGet]
        public IHttpActionResult GetAllrepository()
        {
            BO_Messagepayment_return zxxz = new BO_Messagepayment_return();

            try { 
            var model = _payments.getAllRepository;
            var count = model.Count();
            var i = 0;
            string str = "{";
            foreach (var aa in model)
            {
                var name = aa.pck_id;

                if (i == 0)
                {

                    if (aa.pck_type_id == 11 || aa.pck_type_id == 13)
                    {
                        str += "'" + name + "':" + "'" + aa.vm + "VM/" + aa.storage + "GB" + "'";
                    }
                    else
                    {
                        str += "'" + name + "':" + "'" + aa.vm_vr + "VM/" + aa.storage_vr + "GB/" + aa.processor_vr + "Ghz/" + aa.ram_vr + "GB/" + aa.ip_address_vr + "Addresses/" + aa.networks_vr + "Networks/" + aa.internet_traffic_vr + "GB" + "'";
                    }

                }
                else
                {
                    if (aa.pck_type_id == 11 || aa.pck_type_id == 13)
                        {
                        str += ",'" + name + "':" + "'" + aa.vm + "VM/" + aa.storage + "GB" + "'";
                    }
                    else
                    {
                        str += ",'" + name + "':" + "'" + aa.vm_vr + "VM/" + aa.storage_vr + "GB/" + aa.processor_vr + "Ghz/" + aa.ram_vr + "GB/" + aa.ip_address_vr + "Addresses/" + aa.networks_vr + "Networks/" + aa.internet_traffic_vr + "GB" + "'";
                    }
                }


                i++;
            }
            str += "}";
            JObject json = JObject.Parse(str);

            return Json(json);
            }
            catch (Exception e)
            {
                zxxz.Message = "UnSuccessful";
                return Json(zxxz);
            }
        }

    }

    public class BO_Messagepayment_return
    {
        public string Message { get; set; }
    }
}
