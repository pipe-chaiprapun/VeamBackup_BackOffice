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
    public class RequestsHistoryController
    {
        private string token = string.Empty;
        private Mock<IRequestsHistory> req;
        private Mock<IAppRep> app;
        private BackOffice.WebAPI.Controllers.RequestsHistoryController package;

        [TestInitialize]
        public void Initialize()
        {
            token = Authentication.SetAuthenticated(DataMock.Employee, TimeSpan.FromMinutes(120).Minutes); //Set Authentication Mock
            req = new Mock<IRequestsHistory>();
            app = new Mock<IAppRep>();
            package = new BackOffice.WebAPI.Controllers.RequestsHistoryController(req.Object,app.Object);
        }

        [TestMethod]
        public void PostAllRequests()
        {
            req.Setup(s => s.getAllRequestsHistory).Returns(new List<VBackOfficeRequestsHistory>
            {
                new VBackOfficeRequestsHistory
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
                    internet_traffic = null,
                    pck_add_dt = DateTime.Parse("2017-07-22"),
                    pck_end_dt = DateTime.Parse("2017-08-22")

                },
                new VBackOfficeRequestsHistory
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
                    internet_traffic = null,
                    pck_add_dt = DateTime.Parse("2017-07-22"),
                    pck_end_dt = DateTime.Parse("2017-08-22")
                },
                new VBackOfficeRequestsHistory
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
                    internet_traffic = null,
                    pck_add_dt = DateTime.Parse("2017-07-22"),
                    pck_end_dt = DateTime.Parse("2017-08-22")
                }
            });

            var data = package.GetAllRequestsHistory();
            var objResult = data.GetType().GetProperty("Content").GetValue(data);
            string jsonData = JsonConvert.SerializeObject(objResult);
            List<VBackOfficeRequestsHistory> list = JsonConvert.DeserializeObject<List<VBackOfficeRequestsHistory>>(jsonData);
            Assert.IsNotNull(objResult);
            Assert.AreEqual(3, list.Count);
        }

        [TestMethod]
        public void PostfindRequests()
        {
            RequestsHistory_Find find = new RequestsHistory_Find
            {
                cust_id = 11149,
                pck_status = "",
                pck_add_dt = "2017-07-22",
                pck_end_dt = ""
,            };

            req.Setup(s => s.getAllRequestsHistory).Returns(new List<VBackOfficeRequestsHistory>
            {
                new VBackOfficeRequestsHistory
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
                    internet_traffic = null,
                    pck_add_dt = DateTime.Parse("2017-07-22"),
                    pck_end_dt = DateTime.Parse("2017-08-22")
                },
                new VBackOfficeRequestsHistory
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
                    internet_traffic = null,
                    pck_add_dt = DateTime.Parse("2017-07-22"),
                    pck_end_dt = DateTime.Parse("2017-08-22")
                }
            });
            /*req.Setup(s => s.filter_RequestsHistory(find)).Returns(new List<VBackOfficeRequestsHistory>
            {
                new VBackOfficeRequestsHistory
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
                    internet_traffic = null,
                    pck_add_dt = DateTime.Parse("2017-07-22"),
                    pck_end_dt = DateTime.Parse("2017-08-22")
                }
            });

            var data = package.filterRequestsHistory(find);
            var objResult = data.GetType().GetProperty("Content").GetValue(data);
            string jsonData = JsonConvert.SerializeObject(objResult);
            List<VBackOfficeRequestsHistory> list = JsonConvert.DeserializeObject<List<VBackOfficeRequestsHistory>>(jsonData);
            Assert.IsNotNull(objResult);
            Assert.AreEqual(1, list.Count);*/

        }

        [TestMethod]
        public void PostremoveRequests()
        {
            req.Setup(s => s.getAllRequestsHistory).Returns(new List<VBackOfficeRequestsHistory>
            {
                new VBackOfficeRequestsHistory
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
                    internet_traffic = null,
                    pck_add_dt = DateTime.Parse("2017-07-22"),
                    pck_end_dt = DateTime.Parse("2017-08-22")
                },
                new VBackOfficeRequestsHistory
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
                    internet_traffic = null,
                    pck_add_dt = DateTime.Parse("2017-07-22"),
                    pck_end_dt = DateTime.Parse("2017-08-22")
                }
            });
            req.Setup(s => s.RemoveReuestHistory(11149)).Returns("remove success");

            var data = package.remove(11149);
            var objResult = data.GetType().GetProperty("Content").GetValue(data);
            Assert.AreEqual("remove success", objResult);

        }

    }
}
