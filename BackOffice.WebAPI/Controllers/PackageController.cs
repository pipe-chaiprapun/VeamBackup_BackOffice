using BackOffice.WebAPI.Authen;
using BackOffice.WebAPI.Models;
using Backup.ClassLibrary.Abstract;
using Backup.ClassLibrary.Concrete;
using Backup.ClassLibrary.Concrete.Security;
using Backup.ClassLibrary.Concrete.VeeamCloudConnect;
using Backup.ClassLibrary.Entity;
using Backup.ClassLibrary.Models;
using Newtonsoft.Json.Linq;
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
    public class PackageController : ApiController
    {
        private IPackages _Packages;
        private IAppRep _EFapp;
        private Iinvoices _INV;
        private IUpgradePackage _Upgrade;
        public string ip_address = (System.Web.HttpContext.Current != null) ? System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString() : "No Ip";

        public PackageController(Iinvoices inv,IPackages packagesParam, IAppRep appRep, IUpgradePackage upgrade)
        {
            _Packages = packagesParam;
            _EFapp = appRep;
            _INV = inv;
            _Upgrade = upgrade;
        }
        [Route("api/packageById")]
        public IHttpActionResult GetPackageById(int id)
        {
            var find = _Packages.GetPackageByrefId(id);
            if (find.Count() > 0) {
                return Json(find);
            }
            return Ok("No Data for this ID");
        }
        [Route("api/package-all")]
        public IHttpActionResult PostAllPackages()
        {
            BO_Messagepackage_return zxxz = new BO_Messagepackage_return();

            try
            {
                var user = Authentication.User;
                _EFapp.save_logaction("package page", "package all page user: " + user.emp_permission, ip_address, user.emp_id);
                var v = _Packages.getAllPackages;
                return Json(v);
            }
            catch (Exception e)
            {
                zxxz.Message = "UnSuccessful";
                return Json(zxxz);
            }
        }

        [Route("api/package-type-all")]
        public IHttpActionResult PostAllTypePackages()
        {
            BO_Messagepackage_return zxxz = new BO_Messagepackage_return();

            try
            {
                var user = Authentication.User;
                _EFapp.save_logaction("package page", "package type all page user: " + user.emp_permission, ip_address, user.emp_id);
                return Json(_Packages.getAllTypePackages);
            }
            catch (Exception e)
            {
                zxxz.Message = "UnSuccessful";
                return Json(zxxz);
            }
        }
        #region package action 
        [Route("api/package-calculate")]
        public IHttpActionResult PostPackageCalculate([FromBody]PackageCalculator req)
        {
            BO_Messagepackage_return zxxz = new BO_Messagepackage_return();

            try
            {
                var user = Authentication.User;
                _EFapp.save_logaction("package page", "Post Calculate Package: " + user.emp_permission, ip_address, user.emp_id);
                var s = _Packages.PackageCalculator(req.vm, req.storage, req.preniums_storage, req.pck_type);
                return Json(s);
            }
            catch (Exception e)
            {
                zxxz.Message = "UnSuccessful";
                return Json(zxxz);
            }
        }


        [Route("api/package-block")]
        public IHttpActionResult PostPackagesBlock(BO_Packages_Block value)
        {
            BO_Messagepackage_return zxxz = new BO_Messagepackage_return();
            try
            {

                var user = Authentication.User;
                _EFapp.save_logaction("package page", " package Block : " + user.emp_permission, ip_address, user.emp_id);

                var tanTenant = _Packages.Post_Veeam_Tenant_Block(value);
                var cart = _Packages.Post_Cart_Block(value);
                var packages = _Packages.Post_Packages_Block(value);

                var status = "";
                long InvoiceId = 0;
                int PackageId = 0;
                int Cust_Id = value.cust_id;
                string tenant_id = "";
                string tenant_username = "";

                foreach (var aa in tanTenant)
                {
                    tenant_id = aa.tenant_id.ToString();
                    tenant_username = aa.username;
                }
                foreach (var bb in cart)
                {
                    string ss = bb.invoice_no;
                    InvoiceId = Convert.ToInt64(ss);
                    status = bb.status;
                }
                foreach (var cc in packages)
                {
                    PackageId = cc.pck_id;
                }

                m_suspend msp = new m_suspend();
                msp.InvoiceId = InvoiceId;
                msp.PackageId = PackageId;
                msp.Cust_Id = Cust_Id;
                msp.tenant_id = tenant_id;
                msp.tenant_username = tenant_username;


                if (status.Equals("pa"))
                {
                    _INV.SuspendInvoice(msp);
                    status = "ov";
                }
                else
                {
                    _INV.UnSuspendInvoice(msp);
                    status = "pa";
                }

                return Json(status); 
            }catch(Exception e)
            {
                zxxz.Message = "UnSuccessful";
                return Json(zxxz);
            }
        }


        [Route("api/packages/create-veeam-backup")]
        public IHttpActionResult PostCreateVeeamBackup([FromBody]create_inv_backup req)
        {
            BO_Messagepackage_return zxxz = new BO_Messagepackage_return();
            try
            {

                m_create_inv_backup value = new m_create_inv_backup
                {
                    cust_id = req.ClientId,
                    free_trial = 0,
                    premiums_storage = req.StorageBrand.Equals(true) ? 1 : 0,
                    storage = req.StorageGB,
                    vmQty = req.VMsQty,
                    pck_type = req.pck_type
                };
                var user = Authentication.User;
                _EFapp.save_logaction("package page", "Post Create Invoice Veeam Backup: " + user.emp_permission, ip_address, user.emp_id);
                var data = _Packages.addCreditInvoiceBackup(value);
                var cust_noti = _Packages.GetCustomer_Notification(value.cust_id);

                if (cust_noti.pck_sys_create == false) { return Json(data); }

                //Send Invoice to email customer enterpirse
                if (data != null && req.SendInvoice)
                {
                    vBOviewInvoiceTab payload = data.FirstOrDefault<vBOviewInvoiceTab>();

                    var email = new m_requst_senmail
                    {
                        pck_id = payload.pck_id,
                        email = payload.email,
                        vcc_id = payload.vcc_id
                    };

                    var da = _Upgrade.Get_Invoice_ById_PackageBackUp(email.pck_id);

                    var sta = "";
                    if (da.Invoice_status.Equals("pa"))
                    {
                        sta = "Paid";
                    }
                    else
                    {
                        sta = "UnPaid";
                    }

                    var msg = new m_MessageSend();
                    var InvoiceBody = new getInvoiceEmailBody { vcc_id = payload.vcc_id, CustomerName = (payload.firstname + " " + payload.lastname), VMLicense = payload.vm.Value, Storage = payload.storage.Value };

                    new System.Threading.Tasks.Task(delegate
                    {
                        SendMail.MailAttachments(payload.email, "9T YOUR REQUEST HAS BEEN PROCESSED", msg.InvoiceBodyTemplateEnterpirse(InvoiceBody), msg.InvoiceTemplateEnterpriseBackup(da,sta));
                    }).Start();

                    //Task.Factory.StartNew(() => SendMail.MailAttachments(payload.email, "9T YOUR REQUEST HAS BEEN PROCESSED", msg.InvoiceBodyTemplateEnterpirse(InvoiceBody), msg.InvoiceAttachmentsTemplateEnterprise(payload)));
                }
                return Json(data);
            }
            catch (Exception e)
            {
                zxxz.Message = "UnSuccessful";
                return Json(zxxz);
            }
        }
        [Route("api/packages/create-nakivo-backup")]
        public IHttpActionResult PostCreateNakivoBackup([FromBody]create_inv_backup req)
        {
            BO_Messagepackage_return zxxz = new BO_Messagepackage_return();
            try
            {

                m_create_inv_backup value = new m_create_inv_backup
                {
                    cust_id = req.ClientId,
                    free_trial = 0,
                    premiums_storage = req.StorageBrand.Equals(true) ? 1 : 0,
                    storage = req.StorageGB,
                    vmQty = req.VMsQty,
                    pck_type = req.pck_type
                };
                var user = Authentication.User;
                _EFapp.save_logaction("package page", "Post Create Invoice Nakivo Backup: " + user.emp_permission, ip_address, user.emp_id);
                var data = _Packages.addCreditInvoiceNakivoBackup(value);
                var cust_noti = _Packages.GetCustomer_Notification(value.cust_id);

                if (cust_noti.pck_sys_create == false) { return Json(data); }

                //Send Invoice to email customer enterpirse
                if (data != null && req.SendInvoice)
                {
                    vBOviewInvoiceTab payload = data.FirstOrDefault<vBOviewInvoiceTab>();

                    var email = new m_requst_senmail
                    {
                        pck_id = payload.pck_id,
                        email = payload.email,
                        vcc_id = payload.vcc_id
                    };

                    var da = _Upgrade.Get_Invoice_ById_PackageBackUp_Nakivo(email.pck_id);

                    var sta = "";
                    if (da.Invoice_status.Equals("pa"))
                    {
                        sta = "Paid";
                    }
                    else
                    {
                        sta = "UnPaid";
                    }

                    var msg = new m_MessageSend();
                    var InvoiceBody = new getInvoiceEmailBody { vcc_id = payload.vcc_id, CustomerName = (payload.firstname + " " + payload.lastname), VMLicense = payload.vm.Value, Storage = payload.storage.Value };

                    new System.Threading.Tasks.Task(delegate
                    {
                        SendMail.MailAttachments(payload.email, "9T YOUR REQUEST HAS BEEN PROCESSED", msg.InvoiceBodyTemplateEnterpirse(InvoiceBody), msg.InvoiceTemplateEnterpriseNakivoBackup(da,sta));
                    }).Start();

                    //Task.Factory.StartNew(() => SendMail.MailAttachments(payload.email, "9T YOUR REQUEST HAS BEEN PROCESSED", msg.InvoiceBodyTemplateEnterpirse(InvoiceBody), msg.InvoiceAttachmentsTemplateEnterprise(payload)));
                }
                return Json(data);
            }
            catch (Exception e)
            {
                zxxz.Message = "UnSuccessful";
                return Json(zxxz);
            }
        }

        [Route("api/packages/create-veeam-replication")]
        public IHttpActionResult PostCreateVeeamReplication([FromBody]create_inv_replication value)
        {
            BO_Messagepackage_return zxxz = new BO_Messagepackage_return();

            try { 
            //set data
            m_create_inv_replication req = new m_create_inv_replication
            {
                cust_id = value.cust_id,
                free_trial = 0,
                premiums_storage = 1,
                storage = value.storage,
                vmQty = value.vmQty,
                processor = value.processor,
                ram = value.ram,
                ipaddress = value.ipaddress,
                networks = value.networks,
                internet_traffic = value.internet_traffic,
                pck_type = value.pck_type
            };
            var user = Authentication.User;
            _EFapp.save_logaction("package page", "Post Create Invoice Veeam Backup: " + user.emp_permission, ip_address, user.emp_id);
            var data = _Packages.addCreditInvoiceReplication(req);
            var cust_noti = _Packages.GetCustomer_Notification(value.cust_id);

            if (cust_noti.pck_sys_create == false) { return Json(data); }

            //Send Invoice to email customer enterpirse
            if (data != null && value.SendInvoice)
            {
                vBOviewInvoiceTab payload = data.FirstOrDefault<vBOviewInvoiceTab>();

                    var email = new m_requst_senmail
                    {
                        pck_id = payload.pck_id,
                        email = payload.email,
                        vcc_id = payload.vcc_id
                    };

                    var da = _Upgrade.Get_Invoice_ById_PackageReplication(email.pck_id);

                    var sta = "";
                    if (da.Invoice_status.Equals("pa"))
                    {
                        sta = "Paid";
                    }
                    else
                    {
                        sta = "UnPaid";
                    }

                    var msg = new m_MessageSend();
                var InvoiceBody = new getInvoiceEmailBodyReplication { vcc_id = payload.vcc_id, CustomerName = (payload.firstname + " " + payload.lastname), VMLicense = payload.vm.Value, Storage = payload.storage.Value, processor = (int)payload.processor, ram = (int)payload.ram, ip_address = (int)payload.ip_address, networks = (int)payload.networks, traffic = (int)payload.internet_traffic };

                new System.Threading.Tasks.Task(delegate
                {
                    SendMail.MailAttachments(payload.email, "9T YOUR REQUEST HAS BEEN PROCESSED", msg.InvoiceBodyTemplateEnterpirseReplication(InvoiceBody), msg.InvoiceTemplateEnterpriseReplication(da,sta));
                }).Start();

            }

            return Json(data);
            }
            catch (Exception e)
            {
                zxxz.Message = "UnSuccessful";
                return Json(zxxz);
            }
        }

        [Route("api/packages/getveeam")]
        [HttpGet]
        public IHttpActionResult Getrepository()
        {
            BO_Messagepackage_return zxxz = new BO_Messagepackage_return();

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
                    str += "'" + name + "':" + "'/" + Convert.ToInt32(UsedQuota) / 1024 + "GB/" + CPUCount + "Ghz/" + Convert.ToInt32(MemoryUsageMb) / 1024 + "GB" + "'";
                }
                else
                {
                    str += ",'" + name + "':" + "'/" + Convert.ToInt32(UsedQuota) / 1024 + "GB/" + CPUCount + "Ghz/" + Convert.ToInt32(MemoryUsageMb) / 1024 + "GB" + "'";
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

        [Route("api/package-calculate-replication")]
        public IHttpActionResult PostPackageCalculate_rep([FromBody]PackageCalculator_rep req)
        {
            BO_Messagepackage_return zxxz = new BO_Messagepackage_return();

            try { 
            var user = Authentication.User;
            _EFapp.save_logaction("package page", "Post Calculate Package: " + user.emp_permission, ip_address, user.emp_id);
            var s = _Packages.PackageCalculatorReplication(req);
            return Json(s);
            }
            catch (Exception e)
            {
                zxxz.Message = "UnSuccessful";
                return Json(zxxz);
            }
        }
        #endregion

    }

    public class BO_Messagepackage_return
    {
        public string Message { get; set; }
    }
}