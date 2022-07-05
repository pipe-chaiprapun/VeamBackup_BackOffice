using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Backup.ClassLibrary.Entity;
using Backup.ClassLibrary.Concrete;
using Backup.ClassLibrary.Abstract;
using BackOffice.WebAPI.Authen;
using BackOffice.WebAPI.Models;
using Backup.ClassLibrary.Models;
using System.Threading.Tasks;

namespace BackOffice.WebAPI.Controllers
{
    [JWTAuthorize("SuperAdmin", "Admin", "Supervisor", "Operator", "Manager")]
    public class RequestController : ApiController
    {
        private IRequest _IReq;
        private IAppRep _EFapp;
        public string ip_address = (System.Web.HttpContext.Current != null) ? System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString() : "No Ip";
        private BackOfficeDB db = new BackOfficeDB();
        public RequestController(IRequest IReq_, IAppRep appref)
        {
            _IReq = IReq_;
            this._EFapp = appref;
        }
        //---------------------------------Request tap-----------------------------------------------------------
        [HttpGet]
        [Route("api/GetallRequest")]
        public IHttpActionResult GetallRequest()
        {
            var user = Authentication.User;
            _EFapp.save_logaction("Request page", "GetallRequest : " + user.emp_permission, ip_address, user.emp_id);

            var ResponseObject = _IReq.getAllRequest();
            return Json(ResponseObject);
        }
        [HttpGet]
        [Route("api/GetallRequestUP")]
        public IHttpActionResult GetallRequestUP()
        {
            var user = Authentication.User;
            _EFapp.save_logaction("Request page", "GetallRequestUP : " + user.emp_permission, ip_address, user.emp_id);

            var ResponseObject = _IReq.getAllRequestUp();
            return Json(ResponseObject);
        }
        [HttpGet]
        [Route("api/getNewVmAndStorAll")]
        public IHttpActionResult getNewVmAndStor(int id)
        {

            var user = Authentication.User;
            _EFapp.save_logaction("Request page", "getNewVmAndStorAll : " + user.emp_permission, ip_address, user.emp_id);

            return Json(_IReq.getNewVmAndStor(id));
        }
        [HttpDelete]
        [Route("api/RemovePack")]
        public IHttpActionResult removePack(int id)
        {

            var user = Authentication.User;
            _EFapp.save_logaction("Request page", "RemovePack : " + user.emp_permission, ip_address, user.emp_id);

            return Ok(_IReq.RemoveReuest(id));
        }
        [HttpPut]
        [Route("api/SendEmail_ganerateInvoiceVB")]
        public IHttpActionResult sendEmailVB([FromBody]getInvoicesDetail_NewInvoBO payload, string email) // send Email VB
        {

            var user = Authentication.User;
            _EFapp.save_logaction("Request page", "SendEmail_ganerateInvoice : " + user.emp_permission, ip_address, user.emp_id);

            var save = _IReq.GenerateInvoice_email(payload.pck_id, payload.storage, payload.vm, payload.premiums_storage);
            if (save.Count() != 0)
            {
                var msg = new m_MessageSend();
                var InvoiceBody = new getInvoiceEmailBody { vcc_id = payload.vcc_id, CustomerName = (payload.firstname + " " + payload.lastname), VMLicense = payload.vm, Storage = payload.storage };

                var res = System.Threading.Tasks.Task.Factory.StartNew(() => SendMail.MailAttachments(email, "9T YOU HAVE NEW INVOICE", msg.InvoiceBodyTemplateEnterpirse(InvoiceBody), msg.NewGennerateInvoiceAttachmentsTemplateEnterprise(payload)));

                return Json(res);
            }
            return Json("false");

        }
        [HttpPut]
        [Route("api/SendEmail_ganerateInvoiceVR")]
        public IHttpActionResult sendEmailVR([FromBody]getInvoicesDetail_Rep_saveAndUpgrade payload, string email) // send Email VR
        {

            var user = Authentication.User;
            _EFapp.save_logaction("Request page", "SendEmail_ganerateInvoice : " + user.emp_permission, ip_address, user.emp_id);

            var save = _IReq.saveInDBForVR(payload.pck_id,
                                            (int)payload.vm,
                                            (int)payload.storage,
                                            (int)payload.processor,
                                            (int)payload.ram,
                                            (int)payload.ip_address,
                                            (int)payload.networks,
                                            (int)payload.traffic,
                                            payload.premiums_storage);
                var msg = new m_MessageSend();
                var InvoiceBody = new getInvoiceEmailBody { vcc_id = payload.vcc_id, CustomerName = (payload.firstname + " " + payload.lastname), VMLicense = (int)payload.vm, Storage = (int)payload.storage };

                var res = System.Threading.Tasks.Task.Factory.StartNew(() => SendMail.MailAttachments(email, "9T YOU HAVE NEW INVOICE", msg.InvoiceBodyTemplateEnterpirse(InvoiceBody), msg.NewGennerateInvoiceAttachmentsTemplateEnterpriseVR(payload)));

                if(res.Result) return Json(res);
            return Json("false");

        }
        [HttpPost]
        [Route("api/UpdatePackageRequestVB")]
        public IHttpActionResult UpdatePackageRequestVB([FromBody]m_UpgredePackageVB value) //Update Package Request VB
        {

            var user = Authentication.User;
            _EFapp.save_logaction("Request page", "UpdatePackageRequest : " + user.emp_permission, ip_address, user.emp_id);

            var FindPack = _IReq.UpdatePackage(value.PckId, value.VM_licenses, (uint)value.storage);
            return Json(FindPack);
        }
        [HttpPost]
        [Route("api/UpdatePackageRequestVR")]
        public IHttpActionResult UpdatePackageRequestVR([FromBody]m_UpgredePackageVR payload)//Update Package Request VR
        {

            var user = Authentication.User;
            _EFapp.save_logaction("Request page", "UpdatePackageRequest : " + user.emp_permission, ip_address, user.emp_id);

            var FindPack = _IReq.UpdatePackageRep(payload.PckId, (int)payload.storage, (int)payload.Processor, (int)payload.RAM, (int)payload.Networks);
            return Json(FindPack);
        }
        //---------------------------------------------------------package upgrade---------------------------------------------------------------------------
        [HttpPost]
        [Route("api/Upgrade-packge-vb")]
        public IHttpActionResult UpgredePackageVB([FromBody] m_UpgredePackageVB value) //calculate invoice of VB
        {

            var user = Authentication.User;
            _EFapp.save_logaction("Request page", "UpdatePackageRequest : " + user.emp_permission, ip_address, user.emp_id);

            var s = _IReq.GenerateInvoice(value.PckId, value.storage, value.VM_licenses, value.premiums_storage);
            return Json(s);
        }
        [HttpPost]
        [Route("api/Upgrade-packge-vr")]
        public IHttpActionResult UpgredePackageVR([FromBody] m_UpgredePackageVR value) //calculate invoice of VR
        {

            var user = Authentication.User;
            _EFapp.save_logaction("Request page", "UpdatePackageRequest : " + user.emp_permission, ip_address, user.emp_id);

            var respon = _IReq.CalVeeamR(value.PckId, value.VM_licenses, value.storage, value.Processor, value.RAM, value.IP_Addresses, value.Networks, value.Internet_Traffice, value.premiums_storage);
            return Json(respon);
        }

        [HttpPut]
        [Route("api/SaveAndSendEEmail-Upgrade-veeamR")]
        public IHttpActionResult SaveAndSendEEmailUpgradeVeeamR([FromBody] getInvoicesDetail_Rep_saveAndUpgrade payload, int cust_type) //Upgrade package Veeam Rep
        {
            var finduser = db.Veeam_Tenant.FirstOrDefault(x => x.vcc_id == payload.vcc_id);
            if (cust_type == 1) //user enterprise
            {
                var FindPack = _IReq.UpdatePackageRep(payload.pck_id, (int)payload.storage, (int)payload.processor, (int)payload.ram, (int)payload.networks);
                if (FindPack)
                {
                    var save = _IReq.saveInDBForVR(payload.pck_id,
                                                    (int)payload.vm,
                                                    (int)payload.storage,
                                                    (int)payload.processor,
                                                    (int)payload.ram,
                                                    (int)payload.ip_address,
                                                    (int)payload.networks,
                                                    (int)payload.traffic,
                                                    payload.premiums_storage);
                    if (save.Count() != 0)
                    {
                        var msg = new m_MessageSend();
                        var InvoiceBody = new getInvoiceEmailBody { vcc_id = payload.vcc_id, CustomerName = (payload.firstname + " " + payload.lastname), VMLicense = (int)payload.vm, Storage = (int)payload.storage };

                        var res = System.Threading.Tasks.Task.Factory.StartNew(() => SendMail.MailAttachments(payload.email, "9T YOU HAVE NEW INVOICE", msg.InvoiceBodyTemplateEnterpirse(InvoiceBody), msg.NewGennerateInvoiceAttachmentsTemplateEnterpriseVR(payload)));

                        return Json(res);
                    }
                    return Json("false");
                }
            }
            else if (cust_type == 0) //user normal
            {
                var New_row_invo = _IReq.UpgradePackage_Normal_VR(finduser.cust_id, payload.vcc_id, (int)payload.vm, (int)payload.storage, (int)payload.processor, (int)payload.ram, (int)payload.ip_address, (int)payload.networks, (int)payload.traffic, payload.premiums_storage);
                if (New_row_invo)
                {
                    var save = _IReq.saveInDBForVR(payload.pck_id,
                                                    (int)payload.storage,
                                                    (int)payload.vm,
                                                    (int)payload.processor,
                                                    (int)payload.ram,
                                                    (int)payload.ip_address,
                                                    (int)payload.networks,
                                                    (int)payload.traffic,
                                                    payload.premiums_storage);
                    if (save.Count() != 0)
                    {
                        var msg = new m_MessageSend();
                        var InvoiceBody = new getInvoiceEmailBody { vcc_id = payload.vcc_id, CustomerName = (payload.firstname + " " + payload.lastname), VMLicense = (int)payload.vm, Storage = (int)payload.storage };

                        var res = System.Threading.Tasks.Task.Factory.StartNew(() => SendMail.MailAttachments(payload.email, "9T YOU HAVE NEW INVOICE", msg.InvoiceBodyTemplateEnterpirse(InvoiceBody), msg.NewGennerateInvoiceAttachmentsTemplateEnterpriseVR(payload)));

                        return Json(res);
                    }
                    return Json("false");
                }

                return Ok("false Upgrade Veeam Rep");
            }

            return Ok("success");
        }
        [HttpPut]
        [Route("api/SaveAndSendEEmail-Upgrade-veeamB")]
        public IHttpActionResult SaveAndSendEEmailUpgradeVeeamB([FromBody] getInvoicesDetail_NewInvoBO payload, int cust_type) // Upgrade package veeam backup
        {
            var finduser = db.Veeam_Tenant.FirstOrDefault(x => x.vcc_id == payload.vcc_id);
            //user enterprise == 1
            if (cust_type == 1)
            {
                uint storage = (uint)payload.storage;
                var save = _IReq.GenerateInvoice_email(payload.pck_id, payload.storage, payload.vm, payload.premiums_storage);
                if (save.Count() != 0)
                {
                    var FindPack = _IReq.UpdatePackage(payload.pck_id, payload.vm, storage);
                    if (FindPack)
                    {
                        var msg = new m_MessageSend();
                        var InvoiceBody = new getInvoiceEmailBody { vcc_id = payload.vcc_id, CustomerName = (payload.firstname + " " + payload.lastname), VMLicense = payload.vm, Storage = payload.storage };

                        var res = System.Threading.Tasks.Task.Factory.StartNew(() => SendMail.MailAttachments(payload.email, "9T YOU HAVE NEW INVOICE", msg.InvoiceBodyTemplateEnterpirse(InvoiceBody), msg.NewGennerateInvoiceAttachmentsTemplateEnterprise(payload)));

                        return Json(res);
                    }
                    return Ok("false Upgrade Veeam Backup in Veeam Tenant");
                }
                return Ok("false Upgrade Veeam Backup about save database");

                //user normal == 0
            }
            else if (cust_type == 0)
            {
                if (!(_IReq.StorageCal(payload.storage) && payload.vm > 0))
                {
                    return BadRequest("Incorrect Storage value.");
                }
                var status_pck = _IReq.getLastStatusPck(payload.vcc_id);
                if (!status_pck.Equals("ac") || !status_pck.Equals("re"))
                {
                    //var sum = _IReq.GetSumVmStorage(payload.pck_id);
                    var sum = _IReq.GetSumVmStorageServiceID(payload.vcc_id);
                    if (sum.vm < payload.vm || sum.storage < payload.storage)
                    {
                        var New_row_invo = _IReq.UpgradePackage_Normal_VB(finduser.cust_id, payload.vcc_id, payload.vm, payload.storage, payload.premiums_storage);
                        if (New_row_invo)
                        {
                            var msg = new m_MessageSend();
                            var InvoiceBody = new getInvoiceEmailBody { vcc_id = payload.vcc_id, CustomerName = (payload.firstname + " " + payload.lastname), VMLicense = payload.vm, Storage = payload.storage };

                            var res = System.Threading.Tasks.Task.Factory.StartNew(() => SendMail.MailAttachments(payload.email, "9T YOU HAVE NEW INVOICE", msg.InvoiceBodyTemplateEnterpirse(InvoiceBody), msg.NewGennerateInvoiceAttachmentsTemplateEnterprise(payload)));

                            return Json(res);
                            //  return Ok("Add Package to Cart");
                        }
                    }
                    else
                    {
                        return Ok("Please enter more quantity.");
                    }
                }
                return Ok("false Upgrade Veeam Backup");
            }
            return Ok("false");
        }
        /// <summary>
        /// type_pck = 'Veeam Replication','Veeam BackUp'
        /// </summary>
        /// <param name="pck_id"></param>
        /// <param name="type_pck"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("api/DeletePackageInPackageTap")]
        public IHttpActionResult PostDeletePackageInPackageTap(int pck_id, int type_pck)
        {

            var user = Authentication.User;
            _EFapp.save_logaction("Request page", "DeletePackageInPackageTap : " + user.emp_permission, ip_address, user.emp_id);


            if (type_pck == 12)
            {
                bool resDelete = _IReq.DeletePackageInPackageTapVR(pck_id);
                if (resDelete)
                {
                    return Ok("success");
                }
                return Ok("fail delete Veeam Replication");
            }
            else if (type_pck == 11)
            {
                bool resDelete = _IReq.DeletePackageInPackageTapVB(pck_id);
                if (resDelete)
                {
                    return Ok("success");
                }
                return Ok("fail delete Veeam BackUp");
            }
            else {
                return BadRequest("failed for delete");
            }

        }
    }
}
