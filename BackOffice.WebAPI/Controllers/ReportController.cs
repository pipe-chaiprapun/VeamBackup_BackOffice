using BackOffice.WebAPI.Authen;
using BackOffice.WebAPI.Models;
using Backup.ClassLibrary.Abstract;
using Backup.ClassLibrary.Concrete.VeeamCloudConnect;
using Backup.ClassLibrary.Entity;
using Backup.ClassLibrary.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace BackOffice.WebAPI.Controllers
{
    [JWTAuthorize("SuperAdmin", "Admin", "Supervisor", "Manager")]
    public class ReportController : ApiController
    {
        private IReport _Report;
        private IAppRep _EFapp;
        private INakivoAPI nakivoAPI;
        private IVeeamCC2 veeamAPI;
        public string ip_address = (System.Web.HttpContext.Current != null) ? System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString() : "No Ip";

        public ReportController(IReport reportParam, IAppRep appRep, INakivoAPI nakivo, IVeeamCC2 veeam)
        {
            _Report = reportParam;
            _EFapp = appRep;
            nakivoAPI = nakivo;
            veeamAPI = veeam;
        }


        [Route("api/report-job-details")]
        [HttpPost]
        public IHttpActionResult PostJobInformations([FromBody]m_report value)
        {
            BO_Messareport_return zxxz = new BO_Messareport_return();

            try
            {
                var user = Authentication.User;
                _EFapp.save_logaction("report page", "report job details page user: " + user.emp_permission, ip_address, user.emp_id);

                if (string.IsNullOrEmpty(value.tenant_name)) { return null; }


                if (_Report.getTenantType(value.tenant_name) == 11)
                {
                  /*  ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

                    VeeamCC veeam = new VeeamCC(value.tenant_name);
                    var data_res = veeam.ReportDetails();
                    return Json(data_res);*/

                    HttpClient connection = veeamAPI.ConnectVCC_API();
                    var uid = veeamAPI.Get_UIDByTenantName(connection, value.tenant_name).Replace("urn:veeam:CloudTenant:", "");
                    var t = veeamAPI.Get_TenantByUID(connection, uid);
                    decimal Quota = t.Resources.CloudTenantResource.RepositoryQuota.Quota.ToString()!=null ? decimal.Parse(t.Resources.CloudTenantResource.RepositoryQuota.Quota.ToString()) : 0;
                    decimal UsedQuota = (!string.IsNullOrEmpty(t.Resources.CloudTenantResource.RepositoryQuota.UsedQuota.ToString())) ? decimal.Parse(t.Resources.CloudTenantResource.RepositoryQuota.UsedQuota.ToString()) : 0;
                    string QUOTA = (Math.Ceiling((Quota)) >= 1024 ? (Math.Ceiling((Quota)) / 1024).ToString("F") + "GB" : Math.Ceiling((Quota)).ToString("F") + "MB").ToString();
                    string FREESPACE = (Math.Ceiling((Quota)) >= 1024 ? ((Math.Ceiling(Quota) - Math.Ceiling(UsedQuota)) / 1024).ToString("F") + "GB" : (Math.Ceiling(Quota) - Math.Ceiling(UsedQuota)).ToString("F") + "MB");
                    string USEDSPACE = (Math.Ceiling((UsedQuota)) >= 1024 ? (Math.Ceiling((UsedQuota)) / 1024).ToString("F") + "GB" : Math.Ceiling((UsedQuota)).ToString("F") + "MB").ToString();
                    string USEDSPACEP = ((UsedQuota / Quota) * 100).ToString("N0") + "%";

                    VeeamReportModel model = new VeeamReportModel();
                    model.TENANT_NAME = t.Name;
                    model.QUOTA = QUOTA;
                    model.FREE_SPACE = FREESPACE;
                    model.USED_SPACE = USEDSPACE;
                    model.USED_SPACE_Percent = USEDSPACEP;
                    model.LAST_RESULT = t.LastResult;
                    model.LAST_ACTIVE = t.LastActive.ToString();
                    model.Repository = t.Resources.CloudTenantResource.RepositoryQuota.DisplayName;
                    model.DESCRIPTION = t.Description;
                    model.ThrottlingSpeedLimit = t.ThrottlingSpeedLimit.ToString();
                    model.ThrottlingSpeedUnit = t.ThrottlingSpeedUnit.ToString();
                    model.BackupCount = t.BackupCount.ToString();
                    model.ExpirationDate = t.LeaseOptions.ExpirationDate.ToString();

                    return Json(model);
                }
                else if(_Report.getTenantType(value.tenant_name) == 12)
                {
                    HttpClient connection = veeamAPI.ConnectVCC_API();
                    var uid = veeamAPI.Get_UIDByTenantName(connection, value.tenant_name).Replace("urn:veeam:CloudTenant:", "");
                    var t = veeamAPI.Get_TenantRepByUID(uid);

                    decimal Quota = t.ComputeResources.CloudTenantComputeResource.ComputeResourceStats.StorageResourceStats.StorageResourceStat.StorageLimitGb.ToString() != null ? decimal.Parse(t.ComputeResources.CloudTenantComputeResource.ComputeResourceStats.StorageResourceStats.StorageResourceStat.StorageLimitGb.ToString()) : 0;
                    decimal UsedQuota = (!string.IsNullOrEmpty(t.ComputeResources.CloudTenantComputeResource.ComputeResourceStats.StorageResourceStats.StorageResourceStat.StorageUsageGb.ToString())) ? decimal.Parse(t.ComputeResources.CloudTenantComputeResource.ComputeResourceStats.StorageResourceStats.StorageResourceStat.StorageUsageGb.ToString()) : 0;
                    decimal cpu = (!string.IsNullOrEmpty(t.ComputeResources.CloudTenantComputeResource.ComputeResourceStats.CPUCount.ToString())) ? decimal.Parse(t.ComputeResources.CloudTenantComputeResource.ComputeResourceStats.CPUCount.ToString()) : 0;
                    decimal memory = (!string.IsNullOrEmpty(t.ComputeResources.CloudTenantComputeResource.ComputeResourceStats.MemoryUsageMb.ToString())) ? decimal.Parse(t.ComputeResources.CloudTenantComputeResource.ComputeResourceStats.MemoryUsageMb.ToString()) : 0;
                    string QUOTA = (Math.Ceiling((Quota)) >= 1024 ? (Math.Ceiling((Quota)) / 1024).ToString("F") + "GB" : Math.Ceiling((Quota)).ToString("F") + "MB").ToString();
                    string FREESPACE = (Math.Ceiling((Quota)) >= 1024 ? ((Math.Ceiling(Quota) - Math.Ceiling(UsedQuota)) / 1024).ToString("F") + "GB" : (Math.Ceiling(Quota) - Math.Ceiling(UsedQuota)).ToString("F") + "MB");
                    string USEDSPACE = (Math.Ceiling((UsedQuota)) >= 1024 ? (Math.Ceiling((UsedQuota)) / 1024).ToString("F") + "GB" : Math.Ceiling((UsedQuota)).ToString("F") + "MB").ToString();
                    string useMemory = (Math.Ceiling((UsedQuota)) >= 1024 ? (Math.Ceiling((UsedQuota)) / 1024).ToString("F") + "GB" : Math.Ceiling((UsedQuota)).ToString("F") + "MB").ToString();
                    string USEDSPACEP = ((UsedQuota / Quota) * 100).ToString("N0") + "%";

                    VeeamReportModelRep model = new VeeamReportModelRep();
                    model.TENANT_NAME = t.Name;
                    model.QUOTA = QUOTA;
                    model.FREE_SPACE = FREESPACE;
                    model.USED_SPACE = USEDSPACE;
                    model.USED_SPACE_Percent = USEDSPACEP;
                    model.cpuCount = cpu.ToString("F") + "GB";
                    model.MemoryUsages = useMemory;
                    model.LAST_RESULT = t.LastResult;
                    model.LAST_ACTIVE = t.LastActive.ToString();
                    model.Repository = t.ComputeResources.CloudTenantComputeResource.ComputeResourceStats.StorageResourceStats.StorageResourceStat.StorageName;
                    model.DESCRIPTION = "";
                    model.ThrottlingSpeedLimit = t.ThrottlingSpeedLimit.ToString();
                    model.ThrottlingSpeedUnit = t.ThrottlingSpeedUnit.ToString();
                    model.ReplicaCount = t.ReplicaCount.ToString();
                    model.ExpirationDate = t.LeaseOptions.ExpirationDate.ToString();
                    // model.TENANT_NAME = t.nam
                    //return Json(veeamAPI.Get_TenantRepByUID(uid));
                    return Json(model);
                }
                else if (_Report.getTenantType(value.tenant_name) == 13)
                {
                    HttpClient connection = nakivoAPI.ConnectNakivo_API();
                    var tenant = nakivoAPI.getTenantByName(connection, value.tenant_name);
                    return Json(tenant.data.items.FirstOrDefault());
                }
                else
                    return null;
            }
            catch (Exception e)
            {
                zxxz.Message = "UnSuccessful";
                return Json(zxxz);
            }
        }


        [Route("api/report/getveeam")]
        [HttpGet]
        public IHttpActionResult Getrepository()
        {
            BO_Messareport_return zxxz = new BO_Messareport_return();

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
        [Route("api/report/failoverPlan")]
        [HttpGet]
        public IHttpActionResult GetFailOverPlans(string vcc)
        {
            var custObj = Authentication.User;
            //if (_Cart.veeamTenant.Where(vt => vt.cust_id == custObj.cust_id).Count() > 0)
            //{
            List<getFailoverPlan> getFailOver = new List<getFailoverPlan>();
            VeeamCC veeam = new VeeamCC(vcc);
            HttpClient connectVcc = veeam.ConnectVCC_API();
            var res = veeam.GetFailoverPlan(connectVcc, vcc);
            var failoverList = (CloudFailoverPlans)res;
            foreach (var f in failoverList.CloudFailoverPlan)
            {
                if (f.TenantName == vcc)
                {
                    getFailOver.Add(new getFailoverPlan
                    {
                        UID = f.UID.Replace("urn:veeam:CloudFailoverPlan:", ""),
                        name = f.Name,
                        type = f.Type,
                        description = f.Description,
                        TenantUid = f.TenantUid.Replace("urn:veeam:CloudTenant:", ""),
                        TenantName = f.TenantName,
                        VmId = f.CloudFailoverPlanInfo.Includes.CloudFailoveredVm.FailoverPlanVMId,
                        VmName = f.CloudFailoverPlanInfo.Includes.CloudFailoveredVm.Name,
                        order = f.CloudFailoverPlanInfo.Includes.CloudFailoveredVm.Order
                    });
                }
            }

            return Json(getFailOver);
        }
        [Route("api/report/replicaJobSession")]
        [HttpGet]
        public IHttpActionResult GetFailReplicaJobSession(string vcc)
        {
            var custObj = Authentication.User;
            //if (_Cart.veeamTenant.Where(vt => vt.cust_id == custObj.cust_id).Count() > 0)
            //{
            List<getFailoverPlan> getFailOver = new List<getFailoverPlan>();
            VeeamCC veeam = new VeeamCC(vcc);
            HttpClient connectVcc = veeam.ConnectVCC_API();
            var res = veeam.GetFailoverPlan(connectVcc, vcc);
            var failoverList = (CloudFailoverPlans)res;
            foreach (var f in failoverList.CloudFailoverPlan)
            {
                getFailOver.Add(new getFailoverPlan
                {
                    UID = f.UID.Replace("urn:veeam:CloudFailoverPlan:", ""),
                    name = f.Name,
                    type = f.Type,
                    description = f.Description,
                    TenantUid = f.TenantUid.Replace("urn:veeam:CloudTenant:", ""),
                    TenantName = f.TenantName,
                    VmId = f.CloudFailoverPlanInfo.Includes.CloudFailoveredVm.FailoverPlanVMId,
                    VmName = f.CloudFailoverPlanInfo.Includes.CloudFailoveredVm.Name,
                    order = f.CloudFailoverPlanInfo.Includes.CloudFailoveredVm.Order
                });
            }

            return Json(getFailOver);
        }
        [Route("api/report/backupTaskSession")]
        public IHttpActionResult GetTaskSession()
        {
            var custObj = Authentication.User;
            //
            HttpClient connection = veeamAPI.ConnectVCC_API();
            var res = veeamAPI.GetTaskSessions(connection);

            return Json(res);
            
        }

    }
    public class BO_Messareport_return
    {
        public string Message { get; set; }
    }
}