using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Backup.ClassLibrary.Abstract;
using Moq;
using BackOffice.WebAPI.Authen;
using VeeamBackOfficeUnit.Test.Models;
using BackOffice.WebAPI.Controllers;
using Backup.ClassLibrary.Entity;
using System.Collections.Generic;
using Newtonsoft.Json;
using Backup.ClassLibrary.Models;

namespace VeeamBackOfficeUnit.Test
{
    /// <summary>
    /// UnitTest PaymentsController by FarkramDev
    /// </summary>
    [TestClass]
    public class PaymentsController
    {
        private string token = string.Empty;
        private Mock<IPayments> _payments;
        private Mock<IAppRep> _EFapp;
        private BackOffice.WebAPI.Controllers.PaymentsController payment;

        [TestInitialize]
        public void Initialize()
        {
            token = Authentication.SetAuthenticated(DataMock.Employee, TimeSpan.FromMinutes(120).Minutes); //Set Authentication Mock
            _payments = new Mock<IPayments>();
            _EFapp = new Mock<IAppRep>();
            payment = new BackOffice.WebAPI.Controllers.PaymentsController(_payments.Object, _EFapp.Object);
            payment.ipaddress = "Run Test IP";
        }

        [TestMethod]
        public void Payments_all()
        {
            //Get authentication from mock initialize authen token
            var user = Authentication.User;
            _EFapp.Setup(s => s.save_logaction("payments page", "payments all page user: " + user.emp_permission, payment.ipaddress, user.emp_id)).Returns(true);
            _payments.Setup(s => s.getAllPaymentsTx).Returns(new List<vBackOfficePayments>
            {
                new vBackOfficePayments{
                    payment_id = "PAY-75M48376GC338422",
                    username = "VCC100000",
                    password = "",
                    firstname = "manop",
                    lastname = "chayangkoor",
                    company_name = "addlink",
                    phone_num = "0804786449",
                    pck_statusId = "pa",
                    pck_end_dt = DateTime.Parse("2017-08-21"),
                    add_dt = DateTime.Parse("2017-07-22 10:29:26.497"),
                    cust_id = 10022,
                    pck_id = 519,
                    pck_status = "Paid",
                    pck_type_id = 11,
                    pck_type_name = "Veeam Backup",
                    storage = 4000,
                    total_price = decimal.Parse("54.9000"),
                    vm = 2
                },
                new vBackOfficePayments{
                    payment_id = "PAY-7NW220277P965245SLFZPFQA",
                    username = "VCC100016",
                    password = "",
                    firstname = "siamman",
                    lastname = "ubonrach",
                    company_name = "Bangkok Bank",
                    phone_num = "0885952673",
                    pck_statusId = "pa",
                    pck_end_dt = DateTime.Parse("2017-08-21"),
                    add_dt = DateTime.Parse("2017-07-22 13:05:25.060"),
                    cust_id = 10024,
                    pck_id = 537,
                    pck_status = "Paid",
                    pck_type_id = 11,
                    pck_type_name = "Veeam Backup",
                    storage = 500,
                    total_price = decimal.Parse("54.9000"),
                    vm = 1
                }
            });
            var data = payment.Payments_all();
            var objResult =  data.GetType().GetProperty("Content").GetValue(data);
            string jsonData = JsonConvert.SerializeObject(objResult);
            List<vBackOfficePayments> list = JsonConvert.DeserializeObject<List<vBackOfficePayments>>(jsonData);
            Assert.IsNotNull(objResult);
            if (list.Count > 0)
            {
                Assert.AreEqual(2, list.Count);
            }
        }

        [TestMethod]
        public void Payments_filters()
        {
            /*m_payments values = new m_payments
            {
                PaymentNo = "PAY-75M48376GC338422",
                PaymentStatus = "",
                Name = "",
                Family = "",
                PackageStatus = 0
            };
            
            //Get authentication from mock initialize authen token
            var user = Authentication.User;
            _EFapp.Setup(s => s.save_logaction("payments page", "payments filters page user: " + user.emp_permission, payment.ipaddress, user.emp_id)).Returns(true);
            _payments.Setup(s => s.filterPaymentsTx(values)).Returns(new List<vBackOfficePayments>
            {
                new vBackOfficePayments{
                    payment_id = "PAY-75M48376GC338422",
                    username = "VCC100000",
                    password = "",
                    firstname = "manop",
                    lastname = "chayangkoor",
                    company_name = "addlink",
                    phone_num = "0804786449",
                    pck_statusId = "pa",
                    pck_end_dt = DateTime.Parse("2017-08-21"),
                    add_dt = DateTime.Parse("2017-07-22 10:29:26.497"),
                    cust_id = 10022,
                    pck_id = 519,
                    pck_status = "Paid",
                    pck_type_id = 11,
                    pck_type_name = "Veeam Backup",
                    storage = 4000,
                    total_price = decimal.Parse("54.9000"),
                    vm = 2
                }
            });
            var data = payment.Payments_filters(values);
            var objResult = data.GetType().GetProperty("Content").GetValue(data);
            string jsonData = JsonConvert.SerializeObject(objResult);
            List<vBackOfficePayments> list = JsonConvert.DeserializeObject<List<vBackOfficePayments>>(jsonData);
            Assert.IsNotNull(objResult);
            if (list.Count > 0)
            {
                Assert.AreEqual(1, list.Count);
            }*/
        }

        [TestMethod]
        public void PaymentInvoiceDetails()
        {
            m_payments_inv values = new m_payments_inv
            {
                Payment_Id = "PAY-5F2909308G732574"
            };

            //Get authentication from mock initialize authen token
            var user = Authentication.User;
            _EFapp.Setup(s => s.save_logaction("payments page", "Payment Invoice Details filters page user: " + user.emp_permission, payment.ipaddress, user.emp_id)).Returns(true);
            _payments.Setup(s => s.getInvoiceDetail(values)).Returns(new List<vBOInvoiceDetails>
            {
                new vBOInvoiceDetails{
                    payment_id = "PAY-5F2909308G732574",
                    invoice_no = "1707221216",
                    issued = "22/07/2017",
                    due = "22/07/2017",
                    vm = 1,
                    vm_total_price = decimal.Parse("9.9000"),
                    storage = 1000,
                    storage_total_price = decimal.Parse("90.0000"),
                    cart_total_price = decimal.Parse("99.9000"),
                    pck_start_dt = "22/07/2017",
                    pck_end_dt = "21/08/2017",
                    email = "alunsuza045@hotmail.com",
                    phone_num = "0804786449",
                    company_name = "addlink",
                    firstname = "manop",
                    lastname = "chayangkoor",
                    address = "251/17",
                    country = "Thailand",
                    city = "thai",
                    province = "Ubon Ratchathani",
                    post_code = "34000"
                }
            });

            var data = payment.PaymentInvoiceDetails(values);

            var objResult = data.GetType().GetProperty("Content").GetValue(data);
            string jsonData = JsonConvert.SerializeObject(objResult);
            List<vBOInvoiceDetails> list = JsonConvert.DeserializeObject<List<vBOInvoiceDetails>>(jsonData);
            Assert.IsNotNull(objResult);            
            Assert.AreEqual(1, list.Count);            
        }

        [TestMethod]
        public void PaymentDetails()
        {
            m_payments_detail values = new m_payments_detail
            {
                txnId = "PAY-09E81771YB799581WLFZNSGQ"
            };

            //Get authentication from mock initialize authen token
            var user = Authentication.User;
            _EFapp.Setup(s => s.save_logaction("payments page", "PaymentDetails page user: " + user.emp_permission, payment.ipaddress, user.emp_id)).Returns(true);
            _payments.Setup(s => s.getReportsDetail(values.txnId)).Returns(new List<vPaymentDetails>
            {
                new vPaymentDetails
                {
                    payment_id = "PAY-09E81771YB799581WLFZNSGQ",
                    invoice_no = "1707221226",
                    state = "approved",
                    payment_dt = DateTime.Parse("2017-07-22 11:50:09.507"),
                    payer_email = "personal@9t.com",
                    payer_status = "approved",
                    first_name = "Wanchaloem",
                    last_name = "Laoket",
                    address_name = "1 Main St",
                    address_street = "1 Main St",
                    address_city = "San Jose",
                    address_state = "CA",
                    address_country_code = "US",
                    address_zip = "95135",
                    residence_country = "US",
                    txn_id = "0E946022PR231360M",
                    mc_currency = "USD",
                    txn_type = "pending"
                }
            });
            var data = payment.PaymentDetails(values);
            var objResult = data.GetType().GetProperty("Content").GetValue(data);
            string jsonData = JsonConvert.SerializeObject(objResult);
            List<vPaymentDetails> list = JsonConvert.DeserializeObject<List<vPaymentDetails>>(jsonData);
            Assert.IsNotNull(objResult);
            Assert.AreEqual(1, list.Count);
        }
    }
}
