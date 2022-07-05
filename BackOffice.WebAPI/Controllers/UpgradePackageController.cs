using BackOffice.WebAPI.Authen;
using BackOffice.WebAPI.Models;
using Backup.ClassLibrary.Abstract;
using Backup.ClassLibrary.Concrete;
using Backup.ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BackOffice.WebAPI.Controllers
{
    public class UpgradePackageController : ApiController
    {
        private IUpgradePackage _UpPackage;
        private IAppRep _EFapp;
        public string ip_address = (System.Web.HttpContext.Current != null) ? System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString() : "No Ip";

        public UpgradePackageController(IUpgradePackage UpPackage, IAppRep appref)
        {
            _UpPackage = UpPackage;
            this._EFapp = appref;
        }

        [Route("api/upgrade/packages")]
        public IHttpActionResult GetPackages()
        {
            var user = Authentication.User;
            _EFapp.save_logaction("packages page", "upgrade packages : " + user.emp_permission, ip_address, user.emp_id);

            var s = _UpPackage.getUpgradeForPackage();
            return Json(s);
        }
        //------------------------------code in 9/11/2017 button action Upgrade in package tap----------------------------------------------

        #region calculate veeam non-save in database
        [HttpPost]
        [Route("api/calculate/veeam/backup")]
        public IHttpActionResult CalculateVeeamBackup([FromBody] m_TryCalculate_Veeam_Backup input)// try calculate veeam backup
        {
            try
            {
                var res = _UpPackage.TryGanerateInvoiceForVeeamBackUp(input.PckId, input.VM_licenses, input.storage, input.premiums_storage);
                if (res != null) {
                    return Json(res);
                }
                return BadRequest("model requst incorrent");
            }
            catch (Exception exc) {
                return BadRequest(exc.Message);
            }
        }
        [HttpPost]
        [Route("api/calculate/veeam/replication")]
        public IHttpActionResult CalculateVeeamReplication([FromBody]m_TryCalculate_Veeam_Replication input)// try calculate veeam replication
        {
            try
            {
                var res = _UpPackage.TryGanerateInvoiceForVeeamReplication(
                    input.PckId,
                    input.VM_licenses,
                    input.storage,
                    input.Processor,
                    input.RAM,
                    input.IP_Addresses,
                    input.Networks,
                    input.Internet_Traffice,
                    input.premiums_storage);
                if (res != null)
                {
                    return Json(res);
                }
                return BadRequest("model requst incorrent");
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }
        [HttpPost]
        [Route("api/calculate/veeam/backup/resaller")]
        public IHttpActionResult CalculateVeeamBackupResaller([FromBody] m_TryCalculate_Veeam_Backup input)// try calculate veeam backup
        {
            try
            {
                var res = _UpPackage.TryGanerateInvoiceForVeeamBackUpResaller(input.PckId, input.VM_licenses, input.storage, input.premiums_storage);
                if (res != null)
                {
                    return Json(res);
                }
                return BadRequest("model requst incorrent");
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }
        [HttpPost]
        [Route("api/calculate/veeam/replication/resaller")]
        public IHttpActionResult CalculateVeeamReplicationResaller([FromBody]m_TryCalculate_Veeam_Replication input)// try calculate veeam replication
        {
            try
            {
                var res = _UpPackage.TryGanerateInvoiceForVeeamReplicationResaller(
                    input.PckId,
                    input.VM_licenses,
                    input.storage,
                    input.Processor,
                    input.RAM,
                    input.IP_Addresses,
                    input.Networks,
                    input.Internet_Traffice,
                    input.premiums_storage);
                if (res != null)
                {
                    return Json(res);
                }
                return BadRequest("model requst incorrent");
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }
        #endregion

        #region calculate veeam save in database
        [HttpPost]
        [Route("api/calculate/save/veeam/backup")]
        public IHttpActionResult SaveCalculateVeeamBackup([FromBody] m_TryCalculate_Veeam_Backup input)// try calculate veeam backup
        {
            try
            {
                var res = _UpPackage.SaveGanerateInvoiceForVeeamBackUp(input.PckId, input.storage, input.VM_licenses, input.premiums_storage);
                if (res != null)
                {
                    return Json(res);
                }
                return BadRequest("model requst incorrent");
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }
        [HttpPost]
        [Route("api/calculate/save/veeam/replication")]
        public IHttpActionResult SaveCalculateVeeamReplication([FromBody]m_TryCalculate_Veeam_Replication input)// try calculate veeam replication
        {
            try
            {
                var res = _UpPackage.SaveGanerateInvoiceForVeeamReplication(
                    input.PckId,
                    input.VM_licenses,
                    input.storage,
                    input.Processor,
                    input.RAM,
                    input.IP_Addresses,
                    input.Networks,
                    input.Internet_Traffice,
                    input.premiums_storage);
                if (res != null)
                {
                    return Json(res);
                }
                return BadRequest("model requst incorrent");
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }
        [HttpPost]
        [Route("api/calculate/save/veeam/backup/resaller")]
        public IHttpActionResult SaveCalculateVeeamBackupResaller([FromBody] m_TryCalculate_Veeam_Backup input)// try calculate veeam backup
        {
            try
            {
                var res = _UpPackage.SaveGanerateInvoiceForVeeamBackUpResaller(input.PckId, input.storage, input.VM_licenses, input.premiums_storage);
                if (res != null)
                {
                    return Json(res);
                }
                return BadRequest("model requst incorrent");
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }
        [HttpPost]
        [Route("api/calculate/save/veeam/replication/resaller")]
        public IHttpActionResult SaveCalculateVeeamReplicationResaller([FromBody]m_TryCalculate_Veeam_Replication input)// try calculate veeam replication
        {
            try
            {
                var res = _UpPackage.SaveGanerateInvoiceForVeeamReplicationResaller(
                    input.PckId,
                    input.VM_licenses,
                    input.storage,
                    input.Processor,
                    input.RAM,
                    input.IP_Addresses,
                    input.Networks,
                    input.Internet_Traffice,
                    input.premiums_storage);
                if (res != null)
                {
                    return Json(res);
                }
                return BadRequest("model requst incorrent");
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }
        #endregion

        #region requst upgrade package for enterprise
        [HttpPost]
        [Route("api/requst/save/veeam/backup")]
        public IHttpActionResult SaveRequstVeeamBackup([FromBody] m_TryCalculate_Veeam_Backup input)// try calculate veeam backup
        {
            try
            {
                var res = _UpPackage.RequestSaveGanerateInvoiceForVeeamBackUpEnterprise(input.PckId, input.storage, input.VM_licenses, input.premiums_storage);
                if (res != null)
                {
                    return Json(res);
                }
                return BadRequest("model requst incorrent");
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }
        [HttpPost]
        [Route("api/requst/save/veeam/replication")]
        public IHttpActionResult SaveRequestVeeamReplication([FromBody]m_TryCalculate_Veeam_Replication input)// try calculate veeam replication
        {
            try
            {
                var res = _UpPackage.RequestSaveGanerateInvoiceForVeeamReplicationEnterprise(
                    input.PckId,
                    input.VM_licenses,
                    input.storage,
                    input.Processor,
                    input.RAM,
                    input.IP_Addresses,
                    input.Networks,
                    input.Internet_Traffice,
                    input.premiums_storage);
                if (res != null)
                {
                    return Json(res);
                }
                return BadRequest("model requst incorrent");
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }
        #endregion

        #region upgrade veeam in veeam tanant
        [HttpPost]
        [Route("api/upgrade/tenant/veeam/backup")]
        public IHttpActionResult UpgradeTenantCalculateVeeamBackup([FromBody] m_TryCalculate_Veeam_Backup input)// try calculate veeam backup
        {
            try
            {
                var res = _UpPackage.UpdatePackageVeeamBackUp(input.PckId, input.VM_licenses, (uint)input.storage);
                if (res)
                {
                    return Json(res);
                }
                return BadRequest("model requst incorrent");
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }
        [HttpPost]
        [Route("api/upgrade/tenant/veeam/replication")]
        public IHttpActionResult UpgradeTenantVeeamReplication([FromBody]m_TryCalculate_Veeam_Replication input)// try calculate veeam replication
        {
            try
            {
                var res = _UpPackage.UpdatePackageVeeamReplition(
                    input.PckId,
                    input.storage,
                    input.Processor,
                    input.RAM,
                    input.Networks
                    );
                if (res)
                {
                    return Json(res);
                }
                return BadRequest("model requst incorrent");
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }
        #endregion

        #region request enterprise upgrade veeam in veeam tanant
        [HttpPost]
        [Route("api/requst/enterprise/upgrade/tenant/veeam/backup")]
        public IHttpActionResult UpgradeTenantCalculateVeeamBackupEnterprise([FromBody] m_TryCalculate_Veeam_Backup input)
        {
            try
            {
                var res = _UpPackage.UpdatePackageVeeamBackUpEnterprise(input.PckId, input.VM_licenses, (uint)input.storage);
                if (res)
                {
                    return Json(res);
                }
                return BadRequest("model requst incorrent");
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }
        [HttpPost]
        [Route("api/requst/enterprise/upgrade/tenant/veeam/replication")]
        public IHttpActionResult UpgradeTenantVeeamReplicationEnterprise([FromBody]m_TryCalculate_Veeam_Replication input)
        {
            try
            {
                var res = _UpPackage.UpdatePackageVeeamReplicationEnterprise(
                    input.PckId,
                    input.storage,
                    input.Processor,
                    input.RAM,
                    input.Networks
                    );
                if (res)
                {
                    return Json(res);
                }
                return BadRequest("model requst incorrent");
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }
        #endregion

        #region prolong upgrade package
        [HttpPost]
        [Route("api/prolong/upgrade/veeam/backup/enterprise")]
        public IHttpActionResult ProlongUpgradeVeeamBackupEnterprise([FromBody] m_TryCalculate_Veeam_Backup input)// try calculate veeam backup
        {
            try
            {
                var res = _UpPackage.ProlongUpgradeForVeeamBackUpEnterprise(input.PckId, input.storage, input.VM_licenses, input.premiums_storage);
                if (res != null)
                {
                    return Json(_UpPackage.Get_Invoice_ById_PackageBackUp(res.pck_id));
                }
                return BadRequest("model requst incorrent");
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }
        [HttpPost]
        [Route("api/prolong/upgrade/veeam/replication/enterprise")]
        public IHttpActionResult ProlongUpgradeVeeamReplicationEnterprise([FromBody]m_TryCalculate_Veeam_Replication input)// try calculate veeam replication
        {
            try
            {
                var res = _UpPackage.ProlongUpgradeForVeeamReplicationEnterprise(
                    input.PckId,
                    input.VM_licenses,
                    input.storage,
                    input.Processor,
                    input.RAM,
                    input.IP_Addresses,
                    input.Networks,
                    input.Internet_Traffice,
                    input.premiums_storage);
                if (res != null)
                {
                    return Json(_UpPackage.Get_Invoice_ById_PackageReplication(res.pck_id));
                }
                return BadRequest("model requst incorrent");
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }
        [HttpPost]
        [Route("api/prolong/upgrade/veeam/backup/resaller")]
        public IHttpActionResult ProlongUpgradeVeeamBackupResaller([FromBody] m_TryCalculate_Veeam_Backup input)
        {
            try
            {
                var res = _UpPackage.ProlongUpgradeForVeeamBackUpResaller(input.PckId, input.storage, input.VM_licenses, input.premiums_storage);
                if (res != null)
                {
                    return Json(_UpPackage.Get_Invoice_ById_PackageBackUpResaller(res.pck_id));
                }
                return BadRequest("model requst incorrent");
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }
        [HttpPost]
        [Route("api/prolong/upgrade/veeam/replication/resaller")]
        public IHttpActionResult ProlongUpgradeVeeamReplicationResaller([FromBody]m_TryCalculate_Veeam_Replication input)
        {
            try
            {
                var res = _UpPackage.ProlongUpgradeForVeeamReplicationResaller(
                    input.PckId,
                    input.VM_licenses,
                    input.storage,
                    input.Processor,
                    input.RAM,
                    input.IP_Addresses,
                    input.Networks,
                    input.Internet_Traffice,
                    input.premiums_storage);
                if (res != null)
                {
                    return Json(_UpPackage.Get_Invoice_ById_PackageReplicationResaller(res.pck_id));
                }
                return BadRequest("model requst incorrent");
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }
        #endregion

        #region send email veeam 
        [HttpPost]
        [Route("api/upgrade/sendmail/veeam/backup")]
        public IHttpActionResult SendMailVeeamBackup([FromBody]m_requst_senmail input)
        {
            var data = _UpPackage.Get_Invoice_ById_PackageBackUp(input.pck_id);
            var msg = new m_MessageSend();

            var sta = "";
            if (data.Invoice_status.Equals("pa"))
            {
                sta = "Paid";
            }
            else
            {
                sta = "UnPaid";
            }

            var InvoiceBody = new getInvoiceEmailBody {
                vcc_id = input.vcc_id,
                CustomerName = (data.Firstname + " " + data.Lastname),
                VMLicense = (int)data.Vm,
                Storage = (int)data.Storage
            };

            var res = System.Threading.Tasks.Task.Factory.StartNew(() => SendMail.MailAttachments(input.email, "9T YOU HAVE NEW INVOICE FOR UPDATE PACKAGE VEEAM BACKUP", msg.InvoiceBodyTemplateEnterpirse(InvoiceBody), msg.InvoiceTemplateEnterpriseBackup(data,sta)));

            return Json(res);
        }

        [HttpPost]
        [Route("api/upgrade/sendmail/veeam/replication")]
        public IHttpActionResult SendMailVeeamReplication([FromBody]m_requst_senmail input)
        {
            var data = _UpPackage.Get_Invoice_ById_PackageReplication(input.pck_id);
            var msg = new m_MessageSend();

            var sta = "";
            if (data.Invoice_status.Equals("pa"))
            {
                sta = "Paid";
            }
            else
            {
                sta = "UnPaid";
            }

            var InvoiceBody = new getInvoiceEmailBodyReplication
            {
                vcc_id = input.vcc_id,
                CustomerName = (data.Firstname + " " + data.Lastname),
                VMLicense = (int)data.Vm,
                Storage = (int)data.Storage,
                processor = (int)data.Processor,
                ram = (int)data.Ram,
                ip_address = (int)data.IpAddress,
                networks = (int)data.Networks,
                traffic = (int)data.Traffic
            };
            var res = System.Threading.Tasks.Task.Factory.StartNew(() => SendMail.MailAttachments(input.email, "9T YOU HAVE NEW INVOICE FOR UPDATE PACKAGE VEEAM REPLICATION", msg.InvoiceBodyTemplateEnterpirseReplication(InvoiceBody), msg.InvoiceTemplateEnterpriseReplication(data,sta)));

            return Json(res);
        }

        [HttpPost]
        [Route("api/upgrade/sendmail/nakivo/backup")]
        public IHttpActionResult SendMailNakivoBackup([FromBody]m_requst_senmail input)
        {
            var data = _UpPackage.Get_Invoice_ById_PackageBackUp_Nakivo(input.pck_id);
            var msg = new m_MessageSend();

            var sta = "";
            if (data.Invoice_status.Equals("pa"))
            {
                sta = "Paid";
            }
            else
            {
                sta = "UnPaid";
            }

            var InvoiceBody = new getInvoiceEmailBody
            {
                vcc_id = input.vcc_id,
                CustomerName = (data.Firstname + " " + data.Lastname),
                VMLicense = (int)data.Vm,
                Storage = (int)data.Storage
            };

            var res = System.Threading.Tasks.Task.Factory.StartNew(() => SendMail.MailAttachments(input.email, "9T YOU HAVE NEW INVOICE FOR UPDATE PACKAGE NAKIVO BACKUP", msg.InvoiceBodyTemplateEnterpirse(InvoiceBody), msg.InvoiceTemplateEnterpriseNakivoBackup(data,sta)));

            return Json(res);
        }



        [HttpPost]
        [Route("api/upgrade/sendmail/veeam/backup/resaller")]
        public IHttpActionResult SendMailVeeamBackupResaller([FromBody]m_requst_senmail input)
        {
            var data = _UpPackage.Get_Invoice_ById_PackageBackUpResaller(input.pck_id);
            var msg = new m_MessageSend();

            var sta = "";
            if (data.Invoice_status.Equals("pa"))
            {
                sta = "Paid";
            }
            else
            {
                sta = "UnPaid";
            }

            var InvoiceBody = new getInvoiceEmailBody
            {
                vcc_id = input.vcc_id,
                CustomerName = (data.Firstname + " " + data.Lastname),
                VMLicense = (int)data.Vm,
                Storage = (int)data.Storage
            };

            var res = System.Threading.Tasks.Task.Factory.StartNew(() => SendMail.MailAttachments(input.email, "9T YOU HAVE NEW INVOICE FOR UPDATE PACKAGE VEEAM BACKUP", msg.InvoiceBodyTemplateEnterpirse(InvoiceBody), msg.InvoiceTemplateResallerBackup(data,sta)));

            return Json(res);
        }
        [HttpPost]
        [Route("api/upgrade/sendmail/veeam/replication/resaller")]
        public IHttpActionResult SendMailVeeamReplicationResaller([FromBody]m_requst_senmail input)
        {
            var data = _UpPackage.Get_Invoice_ById_PackageReplicationResaller(input.pck_id);
            var msg = new m_MessageSend();

            var sta = "";
            if (data.Invoice_status.Equals("pa"))
            {
                sta = "Paid";
            }
            else
            {
                sta = "UnPaid";
            }

            var InvoiceBody = new getInvoiceEmailBodyReplication
            {
                vcc_id = input.vcc_id,
                CustomerName = (data.Firstname + " " + data.Lastname),
                VMLicense = (int)data.Vm,
                Storage = (int)data.Storage,
                processor = (int)data.Processor,
                ram = (int)data.Ram,
                ip_address = (int)data.IpAddress,
                networks = (int)data.Networks,
                traffic = (int)data.Traffic
            };
            var res = System.Threading.Tasks.Task.Factory.StartNew(() => SendMail.MailAttachments(input.email, "9T YOU HAVE NEW INVOICE FOR UPDATE PACKAGE VEEAM REPLICATION", msg.InvoiceBodyTemplateEnterpirseReplication(InvoiceBody), msg.InvoiceTemplateResallerReplication(data,sta)));

            return Json(res);
        }


        [HttpPost]
        [Route("api/upgrade/sendmail/nakivo/backup/resaller")]
        public IHttpActionResult SendMailnakivoBackupResaller([FromBody]m_requst_senmail input)
        {
            var data = _UpPackage.Get_Invoice_ById_PackageBackUpResaller_Nakivo(input.pck_id);
            var msg = new m_MessageSend();

            var sta = "";
            if (data.Invoice_status.Equals("pa"))
            {
                sta = "Paid";
            }
            else
            {
                sta = "UnPaid";
            }

            var InvoiceBody = new getInvoiceEmailBody
            {
                vcc_id = input.vcc_id,
                CustomerName = (data.Firstname + " " + data.Lastname),
                VMLicense = (int)data.Vm,
                Storage = (int)data.Storage
            };

            var res = System.Threading.Tasks.Task.Factory.StartNew(() => SendMail.MailAttachments(input.email, "9T YOU HAVE NEW INVOICE FOR UPDATE PACKAGE NAKIVO BACKUP", msg.InvoiceBodyTemplateEnterpirse(InvoiceBody), msg.InvoiceTemplateResallerNakivoBackup(data,sta)));

            return Json(res);
        }

        #endregion

        #region get invoice by id package
        [HttpGet]
        [Route("api/GetInvoiceByIdPackage/Backup")]
        public IHttpActionResult GetInvoiceByIdPackageBackup(int pck_id) {
            return Json(_UpPackage.Get_Invoice_ById_PackageBackUp(pck_id));
        }
        [HttpGet]
        [Route("api/GetInvoiceByIdPackage/Replication")]
        public IHttpActionResult GetInvoiceByIdPackageReplication(int pck_id)
        {
            return Json(_UpPackage.Get_Invoice_ById_PackageReplication(pck_id));
        }
        [HttpGet]
        [Route("api/GetInvoiceByIdPackage/Backup/Resaller")]
        public IHttpActionResult GetInvoiceByIdPackageBackupResaller(int pck_id)
        {
            return Json(_UpPackage.Get_Invoice_ById_PackageBackUpResaller(pck_id));
        }
        [HttpGet]
        [Route("api/GetInvoiceByIdPackage/Replication/Resaller")]
        public IHttpActionResult GetInvoiceByIdPackageReplicationResaller(int pck_id)
        {
            return Json(_UpPackage.Get_Invoice_ById_PackageReplicationResaller(pck_id));
        }
        [HttpGet]
        [Route("api/GetInvoiceByIdPackage/Nakivo/Backup")]
        public IHttpActionResult GetInvoiceByIdPackageBackup_Nakivo(int pck_id)
        {
            return Json(_UpPackage.Get_Invoice_ById_PackageBackUp_Nakivo(pck_id));
        }
        [HttpGet]
        [Route("api/GetInvoiceByIdPackage/Nakivo/Backup/Resaller")]
        public IHttpActionResult GetInvoiceByIdPackageBackupResaller_Nakivo(int pck_id)
        {
            return Json(_UpPackage.Get_Invoice_ById_PackageBackUpResaller_Nakivo(pck_id));
        }
        #endregion

        #region get invoice by id InvoiceNo
        [HttpGet]
        [Route("api/GetInvoiceByIdInvoiceNo/Backup")]
        public IHttpActionResult GetInvoiceByIdInvoiceNoBackup(int InvoiceNo)
        {
            return Json(_UpPackage.Get_Invoice_ById_InvoiceBackUp(InvoiceNo));
        }
        [HttpGet]
        [Route("api/GetInvoiceByIdInvoiceNo/Replication")]
        public IHttpActionResult GetInvoiceByIdInvoiceNoReplication(int InvoiceNo)
        {
            return Json(_UpPackage.Get_Invoice_ById_InvoiceReplication(InvoiceNo));
        }
        [HttpGet]
        [Route("api/GetInvoiceByIdInvoiceNo/Backup/Resaller")]
        public IHttpActionResult GetInvoiceByIdInvoiceNoBackupResaller(int InvoiceNo)
        {
            return Json(_UpPackage.Get_Invoice_ById_InvoiceBackUpResaller(InvoiceNo));
        }
        [HttpGet]
        [Route("api/GetInvoiceByIdInvoiceNo/Replication/Resaller")]
        public IHttpActionResult GetInvoiceByIdInvoiceNoReplicationResaller(int InvoiceNo)
        {
            return Json(_UpPackage.Get_Invoice_ById_InvoiceReplicationResaller(InvoiceNo));
        }
        [HttpGet]
        [Route("api/GetInvoiceByIdInvoiceNo/Backup")]
        public IHttpActionResult GetInvoiceByIdInvoiceNoBackup_Nakivo(int InvoiceNo)
        {
            return Json(_UpPackage.Get_Invoice_ById_InvoiceBackUp_Nakivo(InvoiceNo));
        }
        [HttpGet]
        [Route("api/GetInvoiceByIdInvoiceNo/Backup/Resaller")]
        public IHttpActionResult GetInvoiceByIdInvoiceNoBackupResaller_Nakivo(int InvoiceNo)
        {
            return Json(_UpPackage.Get_Invoice_ById_InvoiceBackUpResaller_Nakivo(InvoiceNo));
        }
        #endregion
    }
}
