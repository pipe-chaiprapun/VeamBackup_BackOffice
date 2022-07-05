using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Backup.ClassLibrary.Abstract;
using Backup.ClassLibrary.Entity;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VeeamBackOfficeUnit.Test
{
    /// <summary>
    /// UnitTest PolicyController by FarkramDev
    /// </summary>
    [TestClass]
    public class PolicyController
    {
        private Mock<Ipolicy> _Ipolicy;
        private Mock<IAppRep> _AppR = new Mock<IAppRep>();
        private BackOffice.WebAPI.Controllers.PolicyController controller;

        [TestInitialize]
        public void Initialize()
        {
            _Ipolicy = new Mock<Ipolicy>();

            _Ipolicy.Setup(p => p.product_price).Returns(new List<v_Products_Price>{
                new v_Products_Price{ products_id = 1101, pck_type_id = 11, pck_type_name="Veeam Backup", products_name="VMs Licenses", price = Convert.ToDecimal("9.9000"), currency = "USD", quantity = Convert.ToDecimal("1.00"), unit = "VMs", update_dt = DateTime.Now },
                new v_Products_Price{ products_id = 1102, pck_type_id = 11, pck_type_name="Veeam Backup", products_name="Storage(QNAP)", price = Convert.ToDecimal("45.0000"), currency = "USD", quantity = Convert.ToDecimal("500.00"), unit = "GB", update_dt = DateTime.Now },
                new v_Products_Price{ products_id = 1103, pck_type_id = 11, pck_type_name="Veeam Backup", products_name="Storage(HP)", price = Convert.ToDecimal("55.0000"), currency = "USD", quantity = Convert.ToDecimal("500.00"), unit = "GB", update_dt = DateTime.Now },
                new v_Products_Price{ products_id = 1202, pck_type_id = 12, pck_type_name="Veeam Replication", products_name="Storage", price = Convert.ToDecimal("15.0000"), currency = "USD", quantity = Convert.ToDecimal("100.00"), unit = "GB", update_dt = DateTime.Now },
                new v_Products_Price{ products_id = 1203, pck_type_id = 12, pck_type_name="Veeam Replication", products_name="Ram", price = Convert.ToDecimal("0.8200"), currency = "USD", quantity = Convert.ToDecimal("1.00"), unit = "GB", update_dt = DateTime.Now },
                new v_Products_Price{ products_id = 1205, pck_type_id = 12, pck_type_name="Veeam Replication", products_name="IP Addresses", price = Convert.ToDecimal("5.5000"), currency = "USD", quantity = Convert.ToDecimal("1.00"), unit = "IP Addresses", update_dt = DateTime.Now },
                new v_Products_Price{ products_id = 1206, pck_type_id = 12, pck_type_name="Veeam Replication", products_name="Networks", price = Convert.ToDecimal("0.0000"), currency = "USD", quantity = Convert.ToDecimal("1.00"), unit = "Networks", update_dt = DateTime.Now },
                new v_Products_Price{ products_id = 1207, pck_type_id = 12, pck_type_name="Veeam Replication", products_name="Internet Traffic", price = Convert.ToDecimal("0.0500"), currency = "USD", quantity = Convert.ToDecimal("250.00"), unit = "GB", update_dt = DateTime.Now },
            });

            //Initialize constructor
            controller = new BackOffice.WebAPI.Controllers.PolicyController(_Ipolicy.Object, _AppR.Object);
        }

        [TestMethod]
        public void GetPolicyAll()
        {
            /*var response = controller.GetPolicyAll();
            var result = response.GetType().GetProperty("Content").GetValue(response);
            string jsonData = JsonConvert.SerializeObject(result);
            List<v_Products_Price> listPoc = JsonConvert.DeserializeObject<List<v_Products_Price>>(jsonData);
            Assert.IsNotNull(result, "GetPolicyAll Test OK");
            Assert.AreEqual(8, listPoc.Count);*/
        }

        [TestMethod]
        public void PostPutPolicyPrice()
        {
            /*var req = new BackOffice.WebAPI.Models.m_Policy { product_id = 1207, price = Convert.ToDecimal("0.1000") };
            _Ipolicy.Setup(o=>o.change_policy(req.product_id, req.price)).Returns(true);
            var add = _Ipolicy.Object.change_policy(req.product_id, req.price);
            Assert.IsTrue(add, "Success Test PostPutPolicyPrice"); //Response from chang_policy is true           
            var response = controller.PostPutPolicyPrice(req);
            var Content = response.GetType().GetProperty("Content").GetValue(response);
            Assert.IsNotNull(Content, "PostPutPolicyPrice Test OK");
            Assert.AreEqual("Success", Content);*/
        }
    }
}