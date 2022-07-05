using Backup.ClassLibrary.Concrete.Security;
using Backup.ClassLibrary.Concrete.VeeamCloudConnect;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BackOffice.WebAPI.Controllers
{
    public class TestController : ApiController
    {

        [Route("api/sec/export")]
        [HttpGet]
        public IHttpActionResult GetExportKey()
        {
            App_Securities sec = new App_Securities();
            var rs = sec.ExportKeys();
            return Json(rs);
        }

        [Route("api/sec/importkey")]
        [HttpGet]
        public IHttpActionResult GetImportkey()
        {
            App_Securities sec = new App_Securities();
           var d = sec.ImportKeys();
            return Json(d);
        }

        [Route("api/sec/decrypt")]
        [HttpGet]
        public IHttpActionResult Decrypt([FromBody]chiperTextC value)
        {
            App_Securities sec = new App_Securities();
            //var key_pair = sec.ImportKeys();

            var chiperText = sec.Decrypt(value.chiperText);


            return Json(new { chiperText, sec.keypair });
        }

        [Route("api/sec/encrypt")]
        [HttpGet]
        public IHttpActionResult Encrypt(string word)
        {
            App_Securities sec = new App_Securities();
            //var key_pair = sec.ImportKeys();

            var pass_hash = sec.Encrypt(word);

            return Json(new { pass_hash, sec.keypair });
        }

        public class chiperTextC
        {
            public string chiperText { get; set; }
        }

        [Route("api/sec/genkey")]
        [HttpGet]
        public IHttpActionResult GetGenKey()
        {
            App_Securities sec = new App_Securities();
            var gen = sec.GenerateKeyPair();
            return Json(gen);
        }

        [Route("api/test33")]
        [HttpGet]
        public IHttpActionResult Getrepository()
        {
            VccGetStorage vcc_storage = new VccGetStorage();

            var data = vcc_storage.getGetStorageAll();
            var count = data.Entities.CloudTenants.Count();

            string str = "{";

            for(var i = 0; i < count; i++)
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
                if(data.Entities.CloudTenants[i].ComputeResources.CloudTenantComputeResource != null)
                {
                     MemoryUsageMb = data.Entities.CloudTenants[i].ComputeResources.CloudTenantComputeResource.ComputeResourceStats.MemoryUsageMb.ToString();
                     CPUCount = data.Entities.CloudTenants[i].ComputeResources.CloudTenantComputeResource.ComputeResourceStats.CPUCount.ToString();
                }
                else
                {
                     MemoryUsageMb = "0";
                     CPUCount = "0";
                }


                if(i == 0)
                {
                    str += "'"+name+"':"+"'/"+Convert.ToInt32(UsedQuota)/1024+"GB/"+CPUCount+"Ghz/"+Convert.ToInt32(MemoryUsageMb)/1024+"GB"+"'";
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

        [Route("api/sec/test1 ")]
        [HttpGet]
        public IHttpActionResult Gettest1()
        {
            string zz = "";

            return null;
        }

    }
}
