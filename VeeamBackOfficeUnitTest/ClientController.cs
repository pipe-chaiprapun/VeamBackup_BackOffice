using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Backup.ClassLibrary.Entity;
using Backup.ClassLibrary.Abstract;
using Moq;
using System.Collections.Generic;
using BackOffice.WebAPI.Models;
using Backup.ClassLibrary.Models;
using BackOffice.WebAPI.Controllers;
using System.Web.Http.Results;
using Newtonsoft.Json;
using BackOffice.WebAPI.Authen;
using VeeamBackOfficeUnit.Test.Models;
using System.Text.RegularExpressions;

namespace VeeamBackOfficeUnit.Test
{
    /// <summary>
    /// UnitTest ClientController by FarkramDev
    /// </summary>
    [TestClass]
    public class ClientController
    {
        private string token = string.Empty;
        private Mock<IAuthorizationRep> _EFAuthen = new Mock<IAuthorizationRep>();
        private Mock<IClients> _IClients = new Mock<IClients>();
        private Mock<IAppRep> _EFapp = new Mock<IAppRep>();
        private BackOffice.WebAPI.Controllers.ClientController Clientcontroller;

        [TestInitialize]
        public void Initialize()
        {
            token = Authentication.SetAuthenticated(DataMock.Employee, TimeSpan.FromMinutes(120).Minutes); //Set Authentication Mock
            Clientcontroller = new BackOffice.WebAPI.Controllers.ClientController(_IClients.Object, _EFapp.Object, _EFAuthen.Object);
            _IClients.Setup(iclient => iclient.getAllClients).Returns(new List<vBackOfficeClients>
            {
                new vBackOfficeClients{
                    cust_id = 10000,
                    email = "alunsuza045@hotmail.com",
                    phone_num = "0804786449",
                    firstname = "manop",
                    familyName = "chayangkoor",
                    company = "Addlink",
                    verify = 1,
                    block = 2,
                    freeze = 0,
                    delete = 0,
                    pck_type_name = "Veeam Backup",
                    pck_start_dt = DateTime.Parse("2017-07-18"),
                    pck_end_dt = DateTime.Parse("2017-08-17"),
                    pck_id = 2,
                    acc_status = 2,
                    status = "Blocked"
                },
                new vBackOfficeClients{
                    cust_id = 10001,
                    email = "onepoint@google.com",
                    phone_num = "0320316449",
                    firstname = "Peerapong",
                    familyName = "Bangrak",
                    company = "Bankkok Bank",
                    verify = 1,
                    block = 0,
                    freeze = 0,
                    delete = 0,
                    pck_type_name = "Veeam Backup",
                    pck_start_dt = DateTime.Parse("2017-07-18"),
                    pck_end_dt = DateTime.Parse("2017-08-17"),
                    pck_id = 2,
                    acc_status = 1,
                    status = "Verified"
                },
                new vBackOfficeClients{
                    cust_id = 20000,
                    email = "openmen@hotmail.com",
                    phone_num = "0545265587",
                    firstname = "openmen",
                    familyName = "koppcip",
                    company = "KrungThai Bank",
                    verify = 1,
                    block = 0,
                    freeze = 0,
                    delete = 0,
                    pck_type_name = "Veeam Backup",
                    pck_start_dt = DateTime.Parse("2017-07-13"),
                    pck_end_dt = DateTime.Parse("2017-08-12"),
                    pck_id = 8,
                    acc_status = 1,
                    status = "Verified"
                },
                new vBackOfficeClients{
                    cust_id = 20005,
                    email = "thaisuply@hotmail.com",
                    phone_num = "08321002456",
                    firstname = "thaisub",
                    familyName = "global",
                    company = "Thai Subply Chain",
                    verify = 1,
                    block = 0,
                    freeze = 0,
                    delete = 0,
                    pck_type_name = "Veeam Backup",
                    pck_start_dt = DateTime.Parse("2017-07-13"),
                    pck_end_dt = DateTime.Parse("2017-08-12"),
                    pck_id = 2,
                    acc_status = 1,
                    status = "Verified"
                }
            });
        }

        [TestMethod]
        public void PostClientInfo()
        {
            var user = Authentication.User;
            _EFapp.Setup(s => s.save_logaction("clients page", "PostClientInfo: " + user.emp_permission, Clientcontroller.ipaddress, user.emp_id)).Returns(true);

            clientsInfo v = new clientsInfo { ClientId = 10020 };
            _IClients.Setup(o => o.getClientInfo(v.ClientId)).Returns(new List<ClientInfo>
            {
                new ClientInfo {
                    cust_id = 10020,
                    email = "farkram28@gmail.com",
                    firstname = "farkram",
                    lastname = "bs",
                    phone_num = "0875623120",
                    address = "Ubon",
                    city = "UB",
                    province = "Ubon Ratchathani",
                    country = "Thailand",
                    post_code = "34000"
                }
            });
            var resps = Clientcontroller.PostClientInfo(v);
            var objResult = resps.GetType().GetProperty("Content").GetValue(resps);
            string jsonData = JsonConvert.SerializeObject(objResult);

            var result = JsonConvert.DeserializeObject<List<ClientInfo>>(jsonData);
            Assert.IsNotNull(result, "PostClientInfo Pass");

            var ex = _IClients.Object.getClientInfo(v.ClientId);

            Assert.AreEqual(v.ClientId, ex.Single().cust_id);
        }

        [TestMethod]
        public void PostAllClients()
        {
            int expected = 4;

            if (_IClients.Object.getAllClients.Count() > 0)
                Assert.AreEqual(expected, _IClients.Object.getAllClients.Count());
            else
                Assert.AreNotEqual(expected, _IClients.Object.getAllClients.Count());

        }

        [TestMethod]
        public void PostClientByFilter()
        {
            m_clients m = new m_clients
            {
                ID = 20005,
                Email = "thaisuply@hotmail.com",
                Name = "thaisub",
                FName = "global",
                Company = "Thai Subply Chain",
                statusFilter = 1,
                exactmatch = false
            };

            var success = new vBackOfficeClients
            {
                cust_id = 20005,
                email = "thaisuply@hotmail.com",
                phone_num = "08321002456",
                firstname = "thaisub",
                familyName = "global",
                company = "Thai Subply Chain",
                verify = 1,
                block = 0,
                freeze = 0,
                delete = 0,
                pck_type_name = "Veeam Backup",
                pck_start_dt = DateTime.Parse("2017-07-13"),
                pck_end_dt = DateTime.Parse("2017-08-12"),
                pck_id = 2,
                acc_status = 1,
                status = "Verified"
            };

            var data = _IClients.Object.getAllClients.Where(w => w.cust_id.Equals(m.ID)).Single();

            Assert.AreEqual(success.cust_id, data.cust_id);
        }

        [TestMethod]
        public void PostUserAction()
        {
            //Test Block
            m_clients_user_action model = new m_clients_user_action { emp_id = 7, cust_id = 10001, current_state = 2, verify = 0, block = 2, freeze = 0, delete = 0 };
            _IClients.Setup(u => u.UserAction(model.emp_id, model.cust_id, model.current_state, model.verify, model.block, model.freeze, model.delete)).Returns(1);
            int rs = _IClients.Object.UserAction(model.emp_id, model.cust_id, model.current_state, model.verify, model.block, model.freeze, model.delete);
            Assert.AreEqual(1, rs);
        }

        [TestMethod]
        public void PostClientActivityReports()
        {
            //Test Block
            m_rpt_clients model = new m_rpt_clients { customerId = 10000 };
            ReportClientActivity datatest = new ReportClientActivity
            {
                cust_id = 10000,
                browser = "Browser(Chrome 59.0)",
                Placelocation = "Local(::1)",
                DateTimeDiff = "01:56 PM (1 weeks ago)",
                signin_dt = DateTime.Parse("2017-07-13 13:56:15.113")
            };

            _IClients.Setup(m => m.ClientActivityReports(model.customerId)).Returns(new List<ReportClientActivity>
            {
                new ReportClientActivity{
                    cust_id = 10000,
                    browser = "Browser(Chrome 59.0)",
                    Placelocation = "Local(::1)",
                    DateTimeDiff = "01:56 PM (1 weeks ago)",
                    signin_dt = DateTime.Parse("2017-07-13 13:56:15.113")
                }
            });

            var data = _IClients.Object.ClientActivityReports(10000).Single();
            //ClientController clientController = new ClientController(_IClients.Object, _EFapp.Object);
            //_EFapp.Setup(e => e.save_logaction("clients page", "client action page user", "127.0.0.1", datatest.cust_id)).Returns(true);
            //var rs = clientController.PostClientActivityReports(model);
            //ReportClientActivity json = JsonConvert.DeserializeObject<ReportClientActivity>(JsonConvert.SerializeObject(rs)); // Convert IHttpActionResult to Json Class
            Assert.AreEqual(datatest.cust_id, data.cust_id);
        }

        [TestMethod]
        public void PostClientPaymentReports()
        {
            //Params for test
            m_rpt_clients model = new m_rpt_clients { customerId = 10000 };

            //Model dataTest
            ReportPayment datatest = new ReportPayment
            {
                PAYMENT_ID = 10000,
                DUEDATE = "",
                TOTAL = 0,
                OUTSTANDING = 0,
                STATUS = ""
            };

            //Mock Data
            _IClients.Setup(m => m.ClientPaymentReports(model.customerId)).Returns(new List<ReportPayment>
            {
                new ReportPayment{
                    PAYMENT_ID = 10000,
                    DUEDATE = "",
                    TOTAL = 0,
                    OUTSTANDING =0,
                    STATUS = ""
                },
                new ReportPayment{
                    PAYMENT_ID = 20000,
                    DUEDATE = "",
                    TOTAL = 0,
                    OUTSTANDING =0,
                    STATUS = ""
                }
            });

            //Implement method
            var data = _IClients.Object.ClientPaymentReports(10000).Where(w => w.PAYMENT_ID.Equals(datatest.PAYMENT_ID)).Single();

            Assert.AreEqual(datatest.PAYMENT_ID, data.PAYMENT_ID);
        }

        [TestMethod]
        public void PostClientBackUpsReport()
        {
            //Params for test
            m_rpt_clients model = new m_rpt_clients { customerId = 10000 };

            //Model dataTest
            ReportClientBackUps datatest = new ReportClientBackUps
            {
                DateTimes = "",
                Duration = "",
                Errors = "",
                MBs = "",
                Number = 0,
                Status = "",
                Warnnings = ""
            };

            //Mock Data
            _IClients.Setup(m => m.ClientBackupsReports(model.customerId)).Returns(new List<ReportClientBackUps>
            {
                new ReportClientBackUps{
                    DateTimes = "",
                    Duration = "",
                    Errors = "",
                    MBs = "",
                    Number = 0,
                    Status = "",
                    Warnnings = ""
                },
                new ReportClientBackUps{
                    DateTimes = "",
                    Duration = "",
                    Errors = "",
                    MBs = "",
                    Number = 1,
                    Status = "",
                    Warnnings = ""
                }
            });

            //Implement method
            var data = _IClients.Object.ClientBackupsReports(10000).Where(w => w.Number.Equals(datatest.Number)).Single();

            Assert.AreEqual(datatest.Number, data.Number);
        }

        [TestMethod]
        public void PostCreateClient()
        {
            var req = new RegisCustomer
            {
                Email = "maisuna11@gmail.com",
                Password = "@123456FARkram",
                Name = "farkramName",
                LastName = "LastNameTest",
                PhoneNumber = "0875326031",
                AddressPrefix = "address",
                City = "city",
                StateOrProvince = "Ubon",
                Country = "MoungUbon",
                PostCode = "34000",
                resetPasswordLink = true,
                company = "Company Test",
                customer_type = 0
            };

            _EFAuthen.Setup(o => o.check_Email(req.Email)).Returns(1); 

            It.IsRegex(req.Password, RegexOptions.Singleline);            
            bool ValidationPassword = Regex.IsMatch(req.Password, @"(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9]).{8,20}$");
            Assert.IsTrue(ValidationPassword, "Validation password is OK");
            if (ValidationPassword)
            {
                var address = new Address
                {
                    address = req.AddressPrefix,
                    city = req.City,
                    firstname = req.Name,
                    lastname = req.LastName,
                    country = req.Country,
                    phone_num = req.PhoneNumber,
                    post_code = req.PostCode,
                    province = req.StateOrProvince,
                    company_name = string.Empty,
                    cust_id = 0
                };

                _EFAuthen.Setup(o=>o.SignUp(req.customer_type, req.Email, req.Password, address)).Returns(46); //return cust_id
                int cust_id = _EFAuthen.Object.SignUp(req.customer_type, req.Email, req.Password, address);
                var cust_id_compare = cust_id > 0;
                Assert.IsTrue(cust_id_compare, "SignUp success");
                if (cust_id_compare)
                {
                    address.cust_id = cust_id;
                    Log_SignIn logsignin = new Log_SignIn {
                        cust_id = cust_id,
                        browser = "Chrome 59.0",
                        ip = "127.0.0.1-Test",
                        device_name = System.Environment.MachineName + ", " + "Windows",
                        country = string.Empty
                    };

                    _IClients.Setup(c => c.GetInfo(cust_id, logsignin.browser, logsignin.ip)).Returns(logsignin);

                    _EFapp.Setup(o=>o.Sava_LogSignIn(logsignin, true));                    

                    _EFapp.Object.Sava_LogSignIn(logsignin, true); //Use Sava_LogSignIn

                    var guid = new EmailAddress {
                        email_id = 46,
                        cust_id = 10045,
                        email = "maisuna11@gmail.com",
                        status =1,
                        email_primary = true,
                        token = new Guid("015b8cbf-9057-4003-867d-be155e7b292e"),
                        add_dt = DateTime.Parse("2017-08-05 10:59:52.800")
                    };

                    _EFapp.Setup(s=>s.sendToken(cust_id, req.Email)).Returns(guid.token);

                    Assert.IsNotNull(_EFapp.Object.sendToken(cust_id, req.Email), "Token is Ok ready Send Mail");
                }
            }
        }
    }
}