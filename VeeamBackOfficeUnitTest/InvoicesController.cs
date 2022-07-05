using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Backup.ClassLibrary.Abstract;
using Moq;
using System.Collections.Generic;
using BackOffice.WebAPI.Models;
using Backup.ClassLibrary.Models;
using Newtonsoft.Json;
using BackOffice.WebAPI.Authen;
using VeeamBackOfficeUnit.Test.Models;
using Backup.ClassLibrary.Entity;

namespace VeeamBackOfficeUnit.Test
{
    [TestClass]
    public class InvoicesController
    {
        private string token = string.Empty;
        private BackOffice.WebAPI.Controllers.InvoicesController inv;
        private Mock<Iinvoices> _inv;
        private Mock<IAppRep> _EFapp;

        [TestInitialize]
        public void Initialize()
        {
            token = Authentication.SetAuthenticated(DataMock.Employee, TimeSpan.FromMinutes(120).Minutes); //Set Authentication Mock
            _inv = new Mock<Iinvoices>();
            _EFapp = new Mock<IAppRep>();
            inv = new BackOffice.WebAPI.Controllers.InvoicesController(_inv.Object, _EFapp.Object);
            inv.ip_address = "Run Test IP";
        }

        [TestMethod]
        public void PostInvoicesDetail()
        {
            m_InvoiceDetail req = new m_InvoiceDetail
            {
                cust_id = 10004,
                invoice_no = "1707311019",
                vcc_id = 52121212
            };

            //Get authentication from mock initialize authen token
            var user = Authentication.User;
            Assert.IsNotNull(user);


            _EFapp.Setup(s => s.save_logaction("Test PostInvoicesDetail", "Post Invoices Detail: " + user.emp_permission, inv.ip_address, user.emp_id)).Returns(true);
            _inv.Setup(s => s.getInvoiceDetail("1707311019", 10004, 52121212)).Returns(new List<vBOviewInvoiceTab> {
                new vBOviewInvoiceTab{
                     username = "VCC100011",
                     password = "RdRxjwXn9VlF9AbnrnMjdbUL3svgHIENAk2KAobW+Q7RB3F3lymzY0arEyYBTLyOKEDOkdUyjLon5qh22O3Y+7H187syUYYLP25fGsYhnqcrRtfLV/n22A+Q187E7G0/zU75esXK2boBNvWs5uDpwjXOlnDsqkQW11dn0AtIvYU=",
                     invoice_no = "1707311019",
                     issued = "2017-07-31 16:24:59.677",
                     due = "2017-08-30",
                     vm = 2,
                     vm_total_price = Decimal.Parse("19.80"),
                     storage = 1000,
                     storage_total_price = Decimal.Parse("90.00"),
                     fees = Decimal.Parse("7.686000"),
                     pck_start_dt = "2017-07-31",
                     pck_end_dt = "2017-08-30",
                     email = "t1@t1.com",
                     phone_num = "0123467894",
                     company_name = "Test Company",
                     firstname = "Test firstname",
                     lastname = "Test lastname",
                     address = "Test Address",
                     country = "Test Country",
                     city = "Test city",
                     province = "Test Province",
                     post_code = "34000",
                     vcc_id = 100011,
                     pck_id = 52121212
                }
            });
            var resps = inv.PostInvoicesDetail(req);

            var objResult = resps.GetType().GetProperty("Content").GetValue(resps);
            string jsonData = JsonConvert.SerializeObject(objResult);

            var result = JsonConvert.DeserializeObject<List<vBOviewInvoiceTab>>(jsonData);
            Assert.IsNotNull(result, "PostInvoicesDetail Pass");
            Assert.AreEqual(result[0].email, "t1@t1.com");
        }

        [TestMethod]
        public void PostInvoicesAll()
        {
            m_inv req = new m_inv
            {
                cust_id = 10004,
                invoice_no = "1707311019"
            };

            //Get authentication from mock initialize authen token
            var user = Authentication.User;
            Assert.IsNotNull(user);

            _EFapp.Setup(s => s.save_logaction("Test PostInvoicesDetail", "Post Invoices Detail: " + user.emp_permission, inv.ip_address, user.emp_id)).Returns(true);
            _inv.Setup(s => s.loadInvoiceAllBills).Returns(new List<v_BOinvoice> {
                new v_BOinvoice{
                     invoice_no = "1708011029",
                     invoice_price = decimal.Parse("54.9000"),
                     invoice_status = "Paid",
                     pck_start_dt = DateTime.Parse("2017-08-01"),
                     pck_end_dt = DateTime.Parse("2017-08-31"),
                     suspend = DateTime.Parse("2017-08-01 13:13:53.057"),
                     package_no = "PKB49",
                     pck_type_name = "Veeam Backup",
                     package_status = "Active",
                     cust_id = 10007,
                     email = "bossbojo445@hotmail.com",
                     firstname = "paramat",
                     lastname = "singkon",
                     company_name = "Addlink",
                     created = "system"
                },
                 new v_BOinvoice{
                     invoice_no = "1708011030",
                     invoice_price = decimal.Parse("60.9000"),
                     invoice_status = "Paid",
                     pck_start_dt = DateTime.Parse("2017-09-01"),
                     pck_end_dt = DateTime.Parse("2017-10-31"),
                     suspend = DateTime.Parse("2017-08-01 13:13:53.057"),
                     package_no = "PKB50",
                     pck_type_name = "Veeam Backup",
                     package_status = "Active",
                     cust_id = 10008,
                     email = "bobo@gmail.com",
                     firstname = "rinma",
                     lastname = "siampit",
                     company_name = "Awesta",
                     created = "manually"
                }
            });
            var resps = inv.PostInvoicesAll();

            var objResult = resps.GetType().GetProperty("Content").GetValue(resps);
            string jsonData = JsonConvert.SerializeObject(objResult);

            var result = JsonConvert.DeserializeObject<List<v_BOinvoice>>(jsonData);
            Assert.IsNotNull(result, "PostInvoicesAll Pass");
            Assert.AreEqual(result[0].invoice_no, "1708011029");
            Assert.AreEqual(result[1].invoice_no, "1708011030");
        }

        [TestMethod]
        public void PostInvoiceSuspend()
        {
            m_suspend suspend_req = new m_suspend
            {
                InvoiceId = 10004,
                PackageId = 17073
            };

            //Get authentication from mock initialize authen token
            var user = Authentication.User;
            Assert.IsNotNull(user);

            _EFapp.Setup(s => s.save_logaction("Test PostInvoiceSuspend", "Post invoice suspend package: " + user.emp_permission, inv.ip_address, user.emp_id)).Returns(true);

            _inv.Setup(s => s.SuspendInvoice(suspend_req)).Returns("success");

            var resps = inv.PostInvoiceSuspend(suspend_req);

            var Result = resps.GetType().GetProperty("Content").GetValue(resps);

            Assert.AreEqual("success", Result);
        }

        [TestMethod]
        public void PostEditInvoiceStatus()
        {
            /*m_invedit inv_req = new m_invedit { cart_id = 15200554, cust_id = 52200, pck_id = 11111, status = "pa" };
            //Get authentication from mock initialize authen token
            var user = Authentication.User;
            Assert.IsNotNull(user);
            _EFapp.Setup(s => s.save_logaction("Invoices controller", "Edit invoice status from PackageId:+" + inv_req.pck_id + "+ : " + user.emp_permission, inv.ip_address, user.emp_id)).Returns(true);
            _inv.Setup(s => s.EditInvoiceStatus(inv_req)).Returns("success");
            var result = inv.PostEditInvoiceStatus(inv_req);
            var actual = result.GetType().GetProperty("Content").GetValue(result);
            Assert.AreEqual("success", actual);*/
        }

        [TestMethod]
        public void PostSendInvoiceBill()
        {
            m_RetrySendInvoice values = new m_RetrySendInvoice { cust_id = 10000, email = "t1@t1.com", invoice_no = "29082519" };

            List<vBOviewInvoiceTab> ListInvoicesDetail = new List<vBOviewInvoiceTab> {
                new vBOviewInvoiceTab{
                  vcc_id = 100011,
                  username = "VCC100011",
                  password = "RdRxjwXn9VlF9AbnrnMjdbUL3svgHIENAk2KAobW+Q7RB3F3lymzY0arEyYBTLyOKEDOkdUyjLon5qh22O3Y+7H187syUYYLP25fGsYhnqcrRtfLV/n22A+Q187E7G0/zU75esXK2boBNvWs5uDpwjXOlnDsqkQW11dn0AtIvYU=",
                  invoice_no = "29082519",
                  issued = "2017-07-31 16:24:59.677",
                  due = "2017-08-30",
                  vm = 2,
                  vm_total_price = decimal.Parse("19.8000"),
                  storage = 1000,
                  storage_total_price = decimal.Parse("90.0000"),
                  fees = decimal.Parse("7.686000"),
                  pck_start_dt = "2017-07-31",
                  pck_end_dt = "2017-08-30",
                  email = "t1@t1.com",
                  phone_num = "0123467894",
                  company_name = "Awesta",
                  firstname = "loveyoutest",
                  lastname = "kobori",
                  address = "68/111",
                  country = "Afghanistan",
                  city =  "merng",
                  province = "Badakhshan",
                  post_code = "34555"
                },
                new vBOviewInvoiceTab{
                  vcc_id = 100041,
                  username = "VCC100041",
                  password = "MkbLeUrvy5+mQd/cgtcQKXGgd4fvoZZPZFvgPDY/MNfii7Zah8XLLY0Fur6EaStNjutji12whGUVh+WmNVzdFQkj+ZrTE3T+8aMO+Bs1mQwKHFd3ED91sTSqrmLEvV2YEJn3rk3uy6BZoFcfBstYxKYWrwZolLh0omNO2JehLQ8=",
                  invoice_no = "29082519",
                  issued = "2017-08-02 08:51:04.233",
                  due = "2017-09-01",
                  vm = 1,
                  vm_total_price = decimal.Parse("9.9000"),
                  storage = 500,
                  storage_total_price = decimal.Parse("45.0000"),
                  fees = decimal.Parse("3.843000"),
                  pck_start_dt = "2017-08-02",
                  pck_end_dt = "2017-09-01",
                  email = "kasama.m279@gmail.com",
                  phone_num = "0827813529",
                  company_name = "Awesta",
                  firstname = "arttt",
                  lastname = "kobori",
                  address = "68/111",
                  country = "Thailand",
                  city =  "moung",
                  province = "Ubon Ratchathani",
                  post_code = "34000",
                  
                }
            };

            //Get authentication from mock initialize authen token
            var user = Authentication.User;
            Assert.IsNotNull(user);

            Assert.IsNotNull(values);

            _EFapp.Setup(s => s.save_logaction("Invoices controller", "Post Send Invoice Bill : " + user.emp_permission, inv.ip_address, user.emp_id)).Returns(true);

            _inv.Setup(s => s.getInvoiceDetail(values.invoice_no, values.cust_id, values.packageId)).Returns(ListInvoicesDetail.FindAll(delegate (vBOviewInvoiceTab iv_detail)
            {
                return (iv_detail.email.Equals(values.email) && iv_detail.invoice_no.Equals(values.invoice_no));
            }));

            var result = inv.PostSendInvoiceBill(values);
            Assert.IsNotNull(result);
        }

    }
}
