using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Backup.ClassLibrary.Abstract;
using Moq;
using VeeamBackOfficeUnit.Test.Models;
using BackOffice.WebAPI.Authen;
using Newtonsoft.Json;
using System.Collections.Generic;
using Backup.ClassLibrary.Entity;
using Backup.ClassLibrary.Models;


namespace VeeamBackOfficeUnit.Test
{
    [TestClass]
    public class ResellerController
    {
        private string token = string.Empty;
        private Mock<IReseller> _RES;
        private Mock<IAppRep> _EFapp;
        private BackOffice.WebAPI.Controllers.ResellerController res;

        [TestInitialize]
        public void Initialize()
        {
            token = Authentication.SetAuthenticated(DataMock.Employee, TimeSpan.FromMinutes(120).Minutes); //Set Authentication Mock
            _RES = new Mock<IReseller>();
            _EFapp = new Mock<IAppRep>();
            res = new BackOffice.WebAPI.Controllers.ResellerController(_RES.Object , _EFapp.Object);
        }

        [TestMethod]
        public void PostaddReseller()
        {
            var user = Authentication.User;
            _EFapp.Setup(s => s.save_logaction("reseller page", "reseller add" + user.emp_permission, res.ip_address, user.emp_id)).Returns(true);
            var from = new from_reseller
            {
                company_name = "addlink",
                website = "www.addlink.com",
                company_email = "addlink@addlink.com",
                company_phone = "1234567890",
                company_country = "thai",
                company_provine = "thai",
                company_city = "thai",
                company_address = "thai",
                company_postcode = "34190",
                vat_id = "1234567890",
                first_name = "add",
                last_name = "link",
                reseller_email = "kiattisak6068@gmail.com",
                reseller_phone = "1234567890",
                reseller_country = "thai",
                reseller_provine = "thail",
                reseller_city = "thai",
                reseller_address = "thai",
                reseller_postcode = "34190",
                reseller_role = "programmer",
                password = "1234",
                send_email = false
            };

            _RES.Setup(r => r.addReseller(from)).Returns(new v_Reseller
            {
                seller_id = 100000000,
                company_name = "addlink",
                website = "www.addlink.com",
                company_email = "addlink@addlink.com",
                company_phone = "1234567890",
                company_country = "thai",
                company_provine = "thai",
                company_city = "thai",
                company_adderss = "thai",
                company_postcode = "34190",
                vat_id = "1234567890",
                first_name = "add",
                last_name = "link",
                reseller_email = "kiattisak6068@gmail.com",
                reseller_phone = "1234567890",
                reseller_country = "thai",
                reseller_provine = "thail",
                reseller_city = "thai",
                reseller_adderss = "thai",
                reseller_postcode = "34190",
                reseller_role = "programmer",
                password = "xcnYTbZwu2CmTVvwjIWXQnnsG+fupMlS:v4wIXT/+CJhsYDmLy51bvw=="
            });

            var data = res.AddnewReseller(from);
            var objResult = data.GetType().GetProperty("Content").GetValue(data);
            Assert.IsNotNull(objResult);
        }

        [TestMethod]
        public void PostupdateReseller()
        {
            var user = Authentication.User;
            _EFapp.Setup(s => s.save_logaction("reseller page", "reseller update" + user.emp_permission, res.ip_address, user.emp_id)).Returns(true);
            var from = new from_reseller_update
            {
                seller_id = 100000000,
                company_name = "addlink",
                website = "www.addlink.com",
                company_email = "addlink@addlink.com",
                company_phone = "1234567890",
                company_country = "thai",
                company_provine = "thai",
                company_city = "thai",
                company_address = "thai",
                company_postcode = "34190",
                vat_id = "1234567890",
                first_name = "add",
                last_name = "link",
                reseller_email = "kiattisak6068@gmail.com",
                reseller_phone = "1234567890",
                reseller_country = "thai",
                reseller_provine = "thail",
                reseller_city = "thai",
                reseller_address = "thai",
                reseller_postcode = "34190",
                reseller_role = "programmer"
            };

            _RES.Setup(r => r.updateReseller(from)).Returns(true);

            var data = res.UpdateReseller(from);
            var objResult = data.GetType().GetProperty("Content").GetValue(data);
            Assert.IsNotNull(objResult);
        }

        [TestMethod]
        public void PostRemove()
        {
            var user = Authentication.User;
            _EFapp.Setup(s => s.save_logaction("reseller page", "reseller remove" + user.emp_permission, res.ip_address, user.emp_id)).Returns(true);

            _RES.Setup(r => r.removeReseller(100000000)).Returns(true);
            var data = res.Remove(100000000);
            var objResult = data.GetType().GetProperty("Content").GetValue(data);
            Assert.AreEqual(true, objResult);
        }

        [TestMethod]
        public void Postblock()
        {
            var user = Authentication.User;
            _EFapp.Setup(s => s.save_logaction("reseller page", "reseller block" + user.emp_permission, res.ip_address, user.emp_id)).Returns(true);

            var from = new from_reseller_Block
            {
                seller_id = 100000000
            };

            _RES.Setup(r => r.blockReseller(from)).Returns(new Reseller
            {
                seller_id = 100000000,
                email = "kiattisak6068@gmail.com",
                password = "xcnYTbZwu2CmTVvwjIWXQnnsG+fupMlS:v4wIXT/+CJhsYDmLy51bvw==",
                status = "bo"
            });

            var data = res.BlockReseller(from);
            var objResult = data.GetType().GetProperty("Content").GetValue(data);
            string jsonData = JsonConvert.SerializeObject(objResult);
            Reseller list = JsonConvert.DeserializeObject<Reseller>(jsonData);
            Assert.IsNotNull(objResult);
            Assert.AreEqual("bo", list.status);
        }

        [TestMethod]
        public void Postapprove()
        {
            var user = Authentication.User;
            _EFapp.Setup(s => s.save_logaction("reseller page", "reseller block" + user.emp_permission, res.ip_address, user.emp_id)).Returns(true);


            var from2 = new from_approve
            {
                seller_id = 100000001,
                contract_num = "123456789",
                contract_period_from = DateTime.Now,
                contract_period_to = DateTime.Now,
                contract_comment = "asdasdas",
                contract_discount = 20
            };

            var from = new Reseller_Contract
            {
                id = 0,
                seller_id = from2.seller_id,
                contract_num = from2.contract_num,
                contract_period_from = from2.contract_period_from,
                contract_period_to = from2.contract_period_to,
                contract_comment = from2.contract_comment,
                contract_discount = from2.contract_discount
            };

            _RES.Setup(r => r.approve_Reseller(from)).Returns(new Reseller
            {
                seller_id = 100000001,
                email = "kiattisak6068@gmail.com",
                password = "xcnYTbZwu2CmTVvwjIWXQnnsG+fupMlS:v4wIXT/+CJhsYDmLy51bvw==",
                status = "ac"
            });

            var data = res.approve_Reseller(from2);
            var objResult = data.GetType().GetProperty("Content").GetValue(data);
            Assert.AreEqual(false, objResult);
        }

        [TestMethod]
        public void PostgetAll()
        {
            var user = Authentication.User;
            _EFapp.Setup(s => s.save_logaction("reseller page", "reseller get all" + user.emp_permission, res.ip_address, user.emp_id)).Returns(true);

            _RES.Setup(r => r.GetReseller).Returns(new List<v_Reseller> {
                new v_Reseller
                {
                seller_id = 100000000,
                company_name = "addlink",
                website = "www.addlink.com",
                company_email = "addlink@addlink.com",
                company_phone = "1234567890",
                company_country = "thai",
                company_provine = "thai",
                company_city = "thai",
                company_adderss = "thai",
                company_postcode = "34190",
                vat_id = "1234567890",
                first_name = "add",
                last_name = "link",
                reseller_email = "kiattisak6068@gmail.com",
                reseller_phone = "1234567890",
                reseller_country = "thai",
                reseller_provine = "thail",
                reseller_city = "thai",
                reseller_adderss = "thai",
                reseller_postcode = "34190",
                reseller_role = "programmer",
                password = "xcnYTbZwu2CmTVvwjIWXQnnsG+fupMlS:v4wIXT/+CJhsYDmLy51bvw=="
                },
                new v_Reseller
                {
                seller_id = 100000001,
                company_name = "addlink",
                website = "www.addlink.com",
                company_email = "addlink@addlink.com",
                company_phone = "1234567890",
                company_country = "thai",
                company_provine = "thai",
                company_city = "thai",
                company_adderss = "thai",
                company_postcode = "34190",
                vat_id = "1234567890",
                first_name = "add",
                last_name = "link",
                reseller_email = "kiattisak6068@gmail.com",
                reseller_phone = "1234567890",
                reseller_country = "thai",
                reseller_provine = "thail",
                reseller_city = "thai",
                reseller_adderss = "thai",
                reseller_postcode = "34190",
                reseller_role = "programmer",
                password = "xcnYTbZwu2CmTVvwjIWXQnnsG+fupMlS:v4wIXT/+CJhsYDmLy51bvw=="
                }
            });

            var data = res.GetReseller();
            var objResult = data.GetType().GetProperty("Content").GetValue(data);
            string jsonData = JsonConvert.SerializeObject(objResult);
            var list = JsonConvert.DeserializeObject<List<v_Reseller>>(jsonData);
            Assert.IsNotNull(objResult);
            Assert.AreEqual(2, list.Count);
        }

        /*[TestMethod]
        public void PostgetID()
        {
            var user = Authentication.User;
            _EFapp.Setup(s => s.save_logaction("reseller page", "reseller get id" + user.emp_permission, res.ip_address, user.emp_id)).Returns(true);

            _RES.Setup(r => r.Get_Reseller(100000001)).Returns(
                new v_Reseller
                {
                seller_id = 100000001,
                company_name = "addlink",
                website = "www.addlink.com",
                company_email = "addlink@addlink.com",
                company_phone = "1234567890",
                company_country = "thai",
                company_provine = "thai",
                company_city = "thai",
                company_adderss = "thai",
                company_postcode = "34190",
                vat_id = "1234567890",
                first_name = "add",
                last_name = "link",
                reseller_email = "kiattisak6068@gmail.com",
                reseller_phone = "1234567890",
                reseller_country = "thai",
                reseller_provine = "thail",
                reseller_city = "thai",
                reseller_adderss = "thai",
                reseller_postcode = "34190",
                reseller_role = "programmer",
                password = "xcnYTbZwu2CmTVvwjIWXQnnsG+fupMlS:v4wIXT/+CJhsYDmLy51bvw=="
                }
            );

            var data = res.Get_Reseller(100000001);
            var objResult = data.GetType().GetProperty("Content").GetValue(data);
            string jsonData = JsonConvert.SerializeObject(objResult);
            var list = JsonConvert.DeserializeObject<v_Reseller>(jsonData);
            Assert.IsNotNull(objResult);
            Assert.AreEqual(100000001, list.seller_id);
        }*/

        [TestMethod]
        public void Poststatus()
        {
            var user = Authentication.User;
            _EFapp.Setup(s => s.save_logaction("reseller page", "reseller status" + user.emp_permission, res.ip_address, user.emp_id)).Returns(true);

            from_change_status from = new from_change_status
            {
                bill_no = 1,
                status = "pa",
                comments = "Paid"
            };

            _RES.Setup(r => r.change_status(from)).Returns(
                new Reseller_Bills
                {
                    reseller_id = 100000001,
                    bill_No = 1,
                    month = "July",
                    amount = decimal.Parse("54.9000"),
                    sales = 1,
                    status = "pa",
                    comments = "Paid"
                });
            var data = res.change_status(from);
            var objResult = data.GetType().GetProperty("Content").GetValue(data);
            string jsonData = JsonConvert.SerializeObject(objResult);
            var list = JsonConvert.DeserializeObject<Reseller_Bills>(jsonData);
            Assert.IsNotNull(objResult);
            Assert.AreEqual("pa", list.status);

        }

        [TestMethod]
        public void Postpayment()
        {
            var user = Authentication.User;
            _EFapp.Setup(s => s.save_logaction("reseller page", "reseller status" + user.emp_permission, res.ip_address, user.emp_id)).Returns(true);

            _RES.Setup(r => r.get_Payment("500")).Returns(
                new Reseller_Payment
                {
                    bill_no = 100000001,
                    payment_number = "500",
                    date = DateTime.Now,
                    destination = "abc"
                });
            var data = res.getPayment("500");
            var objResult = data.GetType().GetProperty("Content").GetValue(data);
            string jsonData = JsonConvert.SerializeObject(objResult);
            var list = JsonConvert.DeserializeObject<Reseller_Payment>(jsonData);
            Assert.IsNotNull(objResult);
            Assert.AreEqual("500", list.payment_number);

        }

        [TestMethod]
        public void sendbill()
        {
            var user = Authentication.User;
            _EFapp.Setup(s => s.save_logaction("reseller page", "reseller status" + user.emp_permission, res.ip_address, user.emp_id)).Returns(true);

            var bill = new m_sendbill
            {
                bill_no = 51
            };

            _RES.Setup(r => r.send(bill.bill_no)).Returns("success");

            var data = res.sendBill(bill);
            var objResult = data.GetType().GetProperty("Content").GetValue(data);
            string jsonData = JsonConvert.SerializeObject(objResult);
            Assert.IsNotNull(objResult);
            Assert.AreEqual("\"success\"", jsonData);
        }
    }

}
