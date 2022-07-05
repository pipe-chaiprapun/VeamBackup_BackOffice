using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Backup.ClassLibrary.Abstract;
using Backup.ClassLibrary.Entity;
using VeeamBackOfficeUnit.Test.Models;
using BackOffice.WebAPI.Authen;
using System.Collections.Generic;
using Newtonsoft.Json;
using BackOffice.WebAPI.Models;
using Backup.ClassLibrary.Concrete.VeeamCloudConnect;
using Backup.ClassLibrary.Models;
using VeeamBackOfficeUnit.Test.HttpClientHandler;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using Moq.Protected;
using System.Threading.Tasks;
using System.Net;
using System.Threading;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using System.Web.Http;

namespace VeeamBackOfficeUnit.Test
{
    /// <summary>
    /// UnitTest ReportController by FarkramDev
    /// </summary>
    [TestClass]
    public class ReportController
    {
        private string token = string.Empty;
        private Mock<IReport> _Report;
        private Mock<IAppRep> _EFapp;
        private Mock<INakivoAPI> _Nakivo;
        private Mock<IVeeamCC2> _veeam;
        private BackOffice.WebAPI.Controllers.ReportController report;

        private IEnumerable<vBackOfficePackages> vPackages;

        [TestInitialize]
        public void Initialize()
        {
            token = Authentication.SetAuthenticated(DataMock.Employee, TimeSpan.FromMinutes(120).Minutes); //Set Authentication Mock
            _Report = new Mock<IReport>();
            _EFapp = new Mock<IAppRep>();
            _Nakivo = new Mock<INakivoAPI>();
            _veeam = new Mock<IVeeamCC2>();

            report = new BackOffice.WebAPI.Controllers.ReportController(_Report.Object, _EFapp.Object, _Nakivo.Object, _veeam.Object);
            vPackages = new List<vBackOfficePackages>
            {
               new vBackOfficePackages
               {
                   pck_id = 515,
                   total_price = decimal.Parse("379.80"),
                   vm = 2,
                   vm_total_price = decimal.Parse("19.80"),
                   pck_start_dt = DateTime.Parse("2017-07-22"),
                   pck_end_dt = DateTime.Parse("2017-08-21"),
                   firstname = "manop",
                   lastname = "chayangkoor",
                   company_name = "addlink",
                   storage = 500,
                   phone_num = "0804786449",
                   pck_type_id = 11,
                   pck_type_name = "Veeam Backup",
                   status = "pa",
                   cust_id = 10022,
                   cart_id = 1215,
                   payment_id = "PAY-1V980274GA084945",
                   //pck_status = "pa",
                   //username = "VCC100004"
               }
            };
        }

        [TestMethod]
        public void PostReportByFilter()
        {
            BO_Report_Find req = new BO_Report_Find { cust_id = 50, pck_status = "a" };
            var user = Authentication.User;
            _EFapp.Setup(s => s.save_logaction("report page", "report filters page user: " + user.emp_permission, report.ip_address, user.emp_id)).Returns(true);
            //_Report.Setup(r => r.filter_report(req)).Returns(new List<vBackOfficeReport>
            //{
            //   new vBackOfficeReport
            //   {
            //       pck_id = 515,
            //       total_price = decimal.Parse("379.80"),
            //       vm = 2,
            //       vm_total_price = decimal.Parse("19.80"),
            //       pck_start_dt = DateTime.Parse("2017-07-22"),
            //       pck_end_dt = DateTime.Parse("2017-08-21"),
            //       firstname = "manop",
            //       lastname = "chayangkoor",
            //       company_name = "addlink",
            //       storage = 500,
            //       phone_num = "0804786449",
            //       pck_type_id = 11,
            //       pck_type_name = "Veeam Backup",
            //       status = "pa",
            //       cust_id = 10022,
            //       cart_id = 1215,
            //       payment_id = "PAY-1V980274GA084945",
            //       pck_status = "pa",
            //       username = "VCC100004"
            //   }
            //});

            /*var data = report.PostReportByFilter(req);

            var objResult = data.GetType().GetProperty("Content").GetValue(data);
            string jsonData = JsonConvert.SerializeObject(objResult);
            List<vBackOfficePackages> list = JsonConvert.DeserializeObject<List<vBackOfficePackages>>(jsonData);
            Assert.IsNotNull(objResult);

            if (list.Count > 0)
            {
                Assert.AreEqual(1, list.Count);
            }*/
        }

        [TestMethod]
        public void PostJobInformations()
        {
            string Authorization = Properties.Settings.Default.PassVeeam;

            string UriApi = string.Empty; UriApi = Properties.Settings.Default.VeeamAPI + "/api/sessionMngr/?v=v1_3";

            m_report param = new m_report { tenant_name = "VCC100020" };

            Assert.IsNotNull(param, "Test m_report request model OK");

            Mock<IVeeamCC> veeam = new Mock<IVeeamCC>();

            veeam.Setup(e => e.SetX_RestSvcSessionId("MGQ5YTMyZTktM2Y0OC00NWQxLWFiYjktMDE0MTM1NmE1M2Vh")).Returns("MGQ5YTMyZTktM2Y0OC00NWQxLWFiYjktMDE0MTM1NmE1M2Vh");

            veeam.Setup(e => e.FindHrefTenantEntity(param.tenant_name)).Returns("FindHrefTenantEntity");

            bool FindHrefTenantEntity = string.IsNullOrEmpty(veeam.Object.FindHrefTenantEntity(param.tenant_name));

            if (FindHrefTenantEntity)
            {
                Assert.IsTrue(FindHrefTenantEntity, "FindHrefTenantEntity Failed");
                Rootobject tanant = new Rootobject();
                tanant.CloudTenant.Resources.CloudTenantResource.RepositoryQuota.Quota = 0.ToString();
                tanant.CloudTenant.Resources.CloudTenantResource.RepositoryQuota.UsedQuota = 0.ToString();
                veeam.Setup(o => o.getCloudTenantsEntity(veeam.Object.FindHrefTenantEntity(veeam.Object.FindHrefTenantEntity(param.tenant_name)))).Returns(tanant);
            }
            else
            {
                Assert.IsFalse(FindHrefTenantEntity, "FindHrefTenantEntity Pass");
                Rootobject tanant = new Rootobject();
                tanant.CloudTenant = new Cloudtenant
                {
                    Resources = new Resources { CloudTenantResource = new Cloudtenantresource { RepositoryQuota = new Repositoryquota { Quota = 10240.ToString(), UsedQuota = 0.ToString() } } },
                    LeaseOptions = new Leaseoptions { ExpirationDate = DateTime.Parse("2017-07-13 13:57:59.693") }
                };
                decimal Quota = (!string.IsNullOrEmpty(tanant.CloudTenant.Resources.CloudTenantResource.RepositoryQuota.Quota)) ? decimal.Parse(tanant.CloudTenant.Resources.CloudTenantResource.RepositoryQuota.Quota) : 0;
                decimal UsedQuota = (!string.IsNullOrEmpty(tanant.CloudTenant.Resources.CloudTenantResource.RepositoryQuota.UsedQuota)) ? decimal.Parse(tanant.CloudTenant.Resources.CloudTenantResource.RepositoryQuota.UsedQuota) : 0;
                string QUOTA = (Math.Ceiling((Quota)) >= 1024 ? (Math.Ceiling((Quota)) / 1024).ToString("F") + "GB" : Math.Ceiling((Quota)).ToString("F") + "MB").ToString();
                string FREESPACE = (Math.Ceiling((Quota)) >= 1024 ? ((Math.Ceiling(Quota) - Math.Ceiling(UsedQuota)) / 1024).ToString("F") + "GB" : (Math.Ceiling(Quota) - Math.Ceiling(UsedQuota)).ToString("F") + "MB");
                string USEDSPACE = (Math.Ceiling((UsedQuota)) >= 1024 ? (Math.Ceiling((UsedQuota)) / 1024).ToString("F") + "GB" : Math.Ceiling((UsedQuota)).ToString("F") + "MB").ToString();
                string USEDSPACEP = ((UsedQuota / Quota) * 100).ToString("N0") + "%";
                VeeamReportModel model = new VeeamReportModel();
                model.TENANT_NAME = tanant.CloudTenant.Name;
                model.QUOTA = QUOTA;
                model.FREE_SPACE = FREESPACE;
                model.USED_SPACE = USEDSPACE;
                model.USED_SPACE_Percent = USEDSPACEP;
                model.LAST_RESULT = tanant.CloudTenant.LastResult;
                model.LAST_ACTIVE = tanant.CloudTenant.LastActive.ToString();
                model.Repository = tanant.CloudTenant.Resources.CloudTenantResource.RepositoryQuota.DisplayName;
                model.DESCRIPTION = tanant.CloudTenant.Description;
                model.ThrottlingSpeedLimit = tanant.CloudTenant.ThrottlingSpeedLimit;
                model.ThrottlingSpeedUnit = tanant.CloudTenant.ThrottlingSpeedUnit;
                model.BackupCount = tanant.CloudTenant.BackupCount;
                model.ExpirationDate = tanant.CloudTenant.LeaseOptions.ToString();
                List<VeeamReportModel> items = new List<VeeamReportModel>();
                items.Clear();
                items.Add(model);
                items.ToList();
                veeam.Setup(o => o.getCloudTenantsEntity(veeam.Object.FindHrefTenantEntity(veeam.Object.FindHrefTenantEntity(param.tenant_name)))).Returns(tanant);
            }

            veeam.Setup(vm => vm.ReportDetails()).Returns(new List<VeeamReportModel>
            {
               new VeeamReportModel{
                    TENANT_NAME = "VCC100020",
                    QUOTA = "10.0GB",
                    FREE_SPACE = "10.0GB",
                    USED_SPACE = "10.0GB",
                    USED_SPACE_Percent = "0%",
                    LAST_RESULT = "",
                    LAST_ACTIVE = "",
                    Repository = "VCC100020Repository",
                    DESCRIPTION = "Tenant account for ABC Company",
                    ThrottlingSpeedLimit = "0",
                    ThrottlingSpeedUnit = "Mbps",
                    BackupCount = "0",
                    ExpirationDate = "8/21/2017 12:00 AM"
               }
            });

            var a = new List<VeeamReportModel>
            {
               new VeeamReportModel{
                    TENANT_NAME = "VCC100020",
                    QUOTA = "10.0GB",
                    FREE_SPACE = "10.0GB",
                    USED_SPACE = "10.0GB",
                    USED_SPACE_Percent = "0%",
                    LAST_RESULT = "",
                    LAST_ACTIVE = "",
                    Repository = "VCC100020Repository",
                    DESCRIPTION = "Tenant account for ABC Company",
                    ThrottlingSpeedLimit = "0",
                    ThrottlingSpeedUnit = "Mbps",
                    BackupCount = "0",
                    ExpirationDate = "8/21/2017 12:00 AM"
               }
            };

            _Report.Setup(r => r.getTenantType(param.tenant_name)).Returns(11);

            Mock<VeeamReportModel> re = new Mock<VeeamReportModel>();

            System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);
            var client = new HttpClient();

            client.BaseAddress = new Uri("http://10.50.18.4:9399");
            client.DefaultRequestHeaders.Add("Authorization", "Basic VmVlYW1BcGk6QWRkbGluazEyMyE=");
            HttpResponseMessage sessionResponse = client.PostAsync("/api/sessionMngr/?v=v1_3", null).Result;
            XmlDocument sessionResponseDoc = new XmlDocument();
            sessionResponseDoc.LoadXml(sessionResponse.Content.ReadAsStringAsync().Result);
            sessionResponseDoc.DocumentElement.RemoveAllAttributes();
            var ss = sessionResponse.Headers.Where(x => x.Key == "X-RestSvcSessionId").FirstOrDefault().Value.First();

            System.Net.ServicePointManager.ServerCertificateValidationCallback += delegate { return true; };
            client.DefaultRequestHeaders.Add("X-RestSvcSessionId", ss);

            _veeam.Setup(c => c.ConnectVCC_API()).Returns(client);

            re.SetReturnsDefault(a);

            /*var data = report.PostJobInformations(param);

            var objResult = data.GetType().GetProperty("Content").GetValue(data);
            string jsonData = JsonConvert.SerializeObject(objResult);
            List<VeeamReportModel> list = JsonConvert.DeserializeObject<List<VeeamReportModel>>(jsonData);
            Assert.IsNotNull(objResult);
            if (list.Count > 0)
            {
                Assert.AreEqual(1, list.Count);
            }*/
        }
    }
}