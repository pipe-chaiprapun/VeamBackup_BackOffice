using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VeeamBackOfficeUnit.Test.Models;
using Moq;
using Backup.ClassLibrary.Abstract;
using BackOffice.WebAPI.Controllers;
using Backup.ClassLibrary.Entity;
using BackOffice.WebAPI.Models;
using System.Web;
using System.Collections.Generic;
using System.Web.Http.Results;
using Newtonsoft.Json;
using BackOffice.WebAPI.Authen;

namespace VeeamBackOfficeUnit.Test
{
    /// <summary>
    /// UnitTest AuthorizationController by FarkramDev
    /// </summary>
    [TestClass]
    public class AuthorizationController
    {
        public string token = string.Empty;
        private Mock<IAppRep> mockIAppREp = new Mock<IAppRep>();
        private Mock<IAuthorizationRep> mockAuthorization = new Mock<IAuthorizationRep>();
        private m_SignIn m_signIn = new m_SignIn { username = "Admin@addlink.com", password = "loem123", role = "Admin" };
        private BO_Employee emp = new BO_Employee
        {
            emp_id = 11,
            emp_email = "Admin@addlink.com",
            emp_username = "Admin@addlink.com",
            emp_password = "loem123",
            emp_pin = "123456",
            emp_fristname = "Farkram",
            emp_lastname = "addmin lastname",
            emp_permission = "Admin",
            emp_position = 1,
            emp_status = "a",
            register_date = DateTime.Parse("2017-05-30 12:05:38.000")
        };
        private BO_Log_Signin bolog = new BO_Log_Signin
        {
            acc_id = 11,
            browser = "Chrome 59.0",
            ip = "10.50.41.87",
            device_name = "WIN - U1R2NGOME1S, Windows,",
            country = ""
        };

        private BackOffice.WebAPI.Controllers.AuthorizationController auth;

        [TestInitialize]
        public void Initializize()
        {
            //Set Authentication Mock
            token = Authentication.SetAuthenticated(emp, TimeSpan.FromMinutes(120).Minutes);

            auth = new BackOffice.WebAPI.Controllers.AuthorizationController(mockAuthorization.Object, mockIAppREp.Object);
        }

        [TestMethod]
        public void Get()
        {
            if (DataMock.sessionMock != string.Empty)
            {
                Assert.AreEqual("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJkYXRhIjp7ImRhdGExIjoiMTEiLCJkYXRhMiI6IkFkbWluQGFkZGxpbmsuY29tIiwiZGF0YTMiOm51bGx9LCJleHAiOjYzNjM1Mzg5NzQ4MjgxMzQ2OH0.R1do_q1wj7sbVBoofjWGdNz7Ow6tqnL7g8Ys0vvlA3Q", DataMock.sessionMock);
            }
        }

        [TestMethod]
        public void GetInfo()
        {
            if (bolog.acc_id == emp.emp_id)
            {
                Assert.AreEqual(11, bolog.acc_id);
            }
        }

        [TestMethod]
        public void PostSignIn()
        {
            var m_signIn = new m_SignIn { username = "Admin@addlink.com", password = "loem123", role = "Admin" };

            var emp = new BO_Employee
            {
                emp_id = 11,
                emp_email = "Admin@addlink.com",
                emp_username = "Admin@addlink.com",
                emp_password = "loem123",
                emp_pin = "123456",
                emp_fristname = "Farkram",
                emp_lastname = "addmin lastname",
                emp_permission = "Admin",
                emp_position = 1,
                emp_status = "a",
                register_date = DateTime.Parse("2017-05-30 12:05:38.000")
            };

            mockAuthorization.Setup(m => m.check_Count("Admin@addlink.com")).Returns(1);//1
            mockAuthorization.Setup(g => g.get_custID("Admin@addlink.com")).Returns(11);//2
            mockAuthorization.Setup(b => b.employees).Returns(new List<BO_Employee>
            { new BO_Employee
                {
                    emp_id = 11,
                    emp_email = "Admin@addlink.com",
                    emp_username = "Admin@addlink.com",
                    emp_password = "b9peX6DLwx4ukyEBnXRVWZX3OyuDHQ52:qC0khfbyEvm3ughW2BV/hg==",
                    emp_pin = "123456",
                    emp_fristname = "Farkram",
                    emp_lastname = "addmin lastname",
                    emp_permission = "Admin",
                    emp_position = 1,
                    emp_status = "a",
                    register_date = DateTime.Parse("2017-05-30 12:05:38.000")
                }
            });

            mockAuthorization.Setup(chlog => chlog.check_login(emp.emp_username)).Returns(true);
            mockAuthorization.Setup(check => check.check_active(11)).Returns(true);//3
            mockAuthorization.Setup(valid => valid.valid_Password(emp.emp_username, emp.emp_password)).Returns(new BO_Employee
            {
                emp_id = 11,
                emp_email = "Admin@addlink.com",
                emp_username = "Admin@addlink.com",
                emp_password = "b9peX6DLwx4ukyEBnXRVWZX3OyuDHQ52:qC0khfbyEvm3ughW2BV/hg==",
                emp_pin = "123456",
                emp_fristname = "Farkram",
                emp_lastname = "addmin lastname",
                emp_permission = "Admin",
                emp_position = 1,
                emp_status = "a",
                register_date = DateTime.Parse("2017-05-30 12:05:38.000")
            });

            var target = auth.PostSignIn(m_signIn);

            string jsString = JsonConvert.SerializeObject(target.GetType().GetProperty("Content").GetValue(target));
            string data = JsonConvert.DeserializeObject<TempDatas>(jsString).TempData;

            Assert.AreEqual("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJkYXRhIjp7ImRhdGExIjoiMTEiLCJkYXRhMiI6IkFkbWluQGFkZGxpbmsuY29tIiwiZGF0YTMiOm51bGx9LCJleHAiOjYzNjM1Mzg5NzQ4MjgxMzQ2OH0.R1do_q1wj7sbVBoofjWGdNz7Ow6tqnL7g8Ys0vvlA3Q", DataMock.sessionMock);
        }

        [TestMethod]
        public void PostSignInPIN()
        {
            if (emp.emp_id > 0)
            {
                mockAuthorization.Setup(auth => auth.ValidPIN(emp.emp_id, emp.emp_pin)).Returns(emp);
                mockAuthorization.Setup(b => b.employees).Returns(new List<BO_Employee>
                { new BO_Employee
                    {
                        emp_id = 11,
                        emp_email = "Admin@addlink.com",
                        emp_username = "Admin@addlink.com",
                        emp_password = "b9peX6DLwx4ukyEBnXRVWZX3OyuDHQ52:qC0khfbyEvm3ughW2BV/hg==",
                        emp_pin = "123456",
                        emp_fristname = "Farkram",
                        emp_lastname = "addmin lastname",
                        emp_permission = "Admin",
                        emp_position = 1,
                        emp_status = "a",
                        register_date = DateTime.Parse("2017-05-30 12:05:38.000")
                    }
                });


                if (mockAuthorization.Object.employees != null)
                {
                    //Process save log signin 
                    mockIAppREp.Setup(sl => sl.save_logSignIn(new BO_Log_Signin
                    {
                        acc_id = 11,
                        browser = "Chrome 59.0",
                        ip = "10.50.41.87",
                        device_name = "WIN - U1R2NGOME1S, Windows,",
                        country = ""
                    }, true));
                    //return autherization permission
                    Assert.AreEqual("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJkYXRhIjp7ImRhdGExIjoiMTEiLCJkYXRhMiI6IkFkbWluQGFkZGxpbmsuY29tIiwiZGF0YTMiOm51bGx9LCJleHAiOjYzNjM1Mzg5NzQ4MjgxMzQ2OH0.R1do_q1wj7sbVBoofjWGdNz7Ow6tqnL7g8Ys0vvlA3Q", DataMock.sessionMock);
                }
            }
        }
    }
}
