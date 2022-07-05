using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Backup.ClassLibrary.Abstract;
using Moq;
using VeeamBackOfficeUnit.Test.Models;
using BackOffice.WebAPI.Authen;
using Newtonsoft.Json;
using System.Collections.Generic;
using Backup.ClassLibrary.Entity;
namespace VeeamBackOfficeUnit.Test
{
    [TestClass]
    public class RequestsNewPackageController
    {

        private string token = string.Empty;
        private Mock<IRequestNewPackage> req;
        private Mock<IAppRep> app;
        private BackOffice.WebAPI.Controllers.RequestsNewPackageController package;

        [TestInitialize]
        public void Initialize()
        {
            token = Authentication.SetAuthenticated(DataMock.Employee, TimeSpan.FromMinutes(120).Minutes); //Set Authentication Mock
            req = new Mock<IRequestNewPackage>();
            app = new Mock<IAppRep>();
            package = new BackOffice.WebAPI.Controllers.RequestsNewPackageController(req.Object,app.Object);

        }

        [TestMethod]
        public void PostAllRequests()
        {
            req.Setup(s => s.getallPackage).Returns(new List<VBackupBackOfficeRequestsNewPackage>
            {
                new VBackupBackOfficeRequestsNewPackage
                {
                    pck_id = 139,
                    pck_status = "re",
                    cust_id = 11149,
                    email = "t1@t1.com",
                    phone_num ="0885952673",
                    firstname = "pond",
                    lastname = "test",
                    company_name = "ADDLINK",
                    pck_type_name = "Veeam Backup",
                    vm = 1,
                    storage = 500,
                    processor = null,
                    ram = null,
                    ip_address = null,
                    networks = null,
                    internet_traffic = null
                },
                new VBackupBackOfficeRequestsNewPackage
                {
                    pck_id = 139,
                    pck_status = "re",
                    cust_id = 11149,
                    email = "t1@t1.com",
                    phone_num ="0885952673",
                    firstname = "pond",
                    lastname = "test",
                    company_name = "ADDLINK",
                    pck_type_name = "Veeam Backup",
                    vm = 1,
                    storage = 500,
                    processor = null,
                    ram = null,
                    ip_address = null,
                    networks = null,
                    internet_traffic = null
                },
                new VBackupBackOfficeRequestsNewPackage
                {
                    pck_id = 139,
                    pck_status = "re",
                    cust_id = 11149,
                    email = "t1@t1.com",
                    phone_num ="0885952673",
                    firstname = "pond",
                    lastname = "test",
                    company_name = "ADDLINK",
                    pck_type_name = "Veeam Backup",
                    vm = 1,
                    storage = 500,
                    processor = null,
                    ram = null,
                    ip_address = null,
                    networks = null,
                    internet_traffic = null
                }
            });

            var data = package.GetallPackage();
            var objResult = data.GetType().GetProperty("Content").GetValue(data);
            string jsonData = JsonConvert.SerializeObject(objResult);
            List<VBackupBackOfficeRequestsNewPackage> list = JsonConvert.DeserializeObject<List<VBackupBackOfficeRequestsNewPackage>>(jsonData);
            Assert.IsNotNull(objResult);
            Assert.AreEqual(3, list.Count);
        }

        [TestMethod]
        public void PostfindRequests()
        {
            RequestsPackage_Find find = new RequestsPackage_Find
            {
                cust_id = 11149,
                email = "",
                pck_status = ""
            };

            req.Setup(s => s.getallPackage).Returns(new List<VBackupBackOfficeRequestsNewPackage>
            {
                new VBackupBackOfficeRequestsNewPackage
                {
                    pck_id = 139,
                    pck_status = "re",
                    cust_id = 11149,
                    email = "t1@t1.com",
                    phone_num ="0885952673",
                    firstname = "pond",
                    lastname = "test",
                    company_name = "ADDLINK",
                    pck_type_name = "Veeam Backup",
                    vm = 1,
                    storage = 500,
                    processor = null,
                    ram = null,
                    ip_address = null,
                    networks = null,
                    internet_traffic = null
                },
                new VBackupBackOfficeRequestsNewPackage
                {
                    pck_id = 140,
                    pck_status = "re",
                    cust_id = 11150,
                    email = "t1@t1.com",
                    phone_num ="0885952673",
                    firstname = "pond",
                    lastname = "test",
                    company_name = "ADDLINK",
                    pck_type_name = "Veeam Backup",
                    vm = 1,
                    storage = 500,
                    processor = null,
                    ram = null,
                    ip_address = null,
                    networks = null,
                    internet_traffic = null
                }
            });
            /*req.Setup(s => s.filter_RequestsPackage(find)).Returns(new List<VBackupBackOfficeRequestsNewPackage>
            {
                new VBackupBackOfficeRequestsNewPackage
                {
                    pck_id = 139,
                    pck_status = "re",
                    cust_id = 11149,
                    email = "t1@t1.com",
                    phone_num ="0885952673",
                    firstname = "pond",
                    lastname = "test",
                    company_name = "ADDLINK",
                    pck_type_name = "Veeam Backup",
                    vm = 1,
                    storage = 500,
                    processor = null,
                    ram = null,
                    ip_address = null,
                    networks = null,
                    internet_traffic = null
                }
            });

            var data = package.RequestsPackage_Filter(find);
            var objResult = data.GetType().GetProperty("Content").GetValue(data);
            string jsonData = JsonConvert.SerializeObject(objResult);
            List<VBackupBackOfficeRequestsNewPackage> list = JsonConvert.DeserializeObject<List<VBackupBackOfficeRequestsNewPackage>>(jsonData);
            Assert.IsNotNull(objResult);
            Assert.AreEqual(1, list.Count);*/

        }

        [TestMethod]
        public void PostremoveRequests()
        {
            req.Setup(s => s.getallPackage).Returns(new List<VBackupBackOfficeRequestsNewPackage>
            {
                new VBackupBackOfficeRequestsNewPackage
                {
                    pck_id = 139,
                    pck_status = "re",
                    cust_id = 11149,
                    email = "t1@t1.com",
                    phone_num ="0885952673",
                    firstname = "pond",
                    lastname = "test",
                    company_name = "ADDLINK",
                    pck_type_name = "Veeam Backup",
                    vm = 1,
                    storage = 500,
                    processor = null,
                    ram = null,
                    ip_address = null,
                    networks = null,
                    internet_traffic = null
                },
                new VBackupBackOfficeRequestsNewPackage
                {
                    pck_id = 140,
                    pck_status = "re",
                    cust_id = 11150,
                    email = "t1@t1.com",
                    phone_num ="0885952673",
                    firstname = "pond",
                    lastname = "test",
                    company_name = "ADDLINK",
                    pck_type_name = "Veeam Backup",
                    vm = 1,
                    storage = 500,
                    processor = null,
                    ram = null,
                    ip_address = null,
                    networks = null,
                    internet_traffic = null
                }
            });
            req.Setup(s => s.RemoveReuestPackage(11149)).Returns("remove success");

            var data = package.remove(11149);
            var objResult = data.GetType().GetProperty("Content").GetValue(data);
            Assert.AreEqual("remove success", objResult);

        }

    }
}
