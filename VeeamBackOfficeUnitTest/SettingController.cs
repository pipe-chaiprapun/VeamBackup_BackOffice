using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Backup.ClassLibrary.Abstract;
using BackOffice.WebAPI.Authen;
using VeeamBackOfficeUnit.Test.Models;
using BackOffice.WebAPI.Models;

namespace VeeamBackOfficeUnit.Test
{
    /// <summary>
    /// UnitTest SettingController by FarkramDev
    /// </summary>
    [TestClass]
    public class SettingController
    {
        private string token = string.Empty;
        private Mock<ISetting> _setting;
        private Mock<IAppRep> _AppR = new Mock<IAppRep>();
        private BackOffice.WebAPI.Controllers.SettingController setting;

        [TestInitialize]
        public void Init()
        {
            token = Authentication.SetAuthenticated(DataMock.Employee, TimeSpan.FromMinutes(120).Minutes); //Set Authentication Mock
            _setting = new Mock<ISetting>();
            setting = new BackOffice.WebAPI.Controllers.SettingController(_setting.Object, _AppR.Object);
        }

        [TestMethod]
        public void PostChangePassword()
        {
            m_Setting req = new m_Setting
            {
                confrim_password = "testPassword",
                new_password = "testPassword",
                old_password = "loem123"
            };

            //Get authentication from mock initialize authen token
            var user = Authentication.User;
            _setting.Setup(s => s.valid_Password(user.emp_username, req.old_password)).Returns(new Backup.ClassLibrary.Entity.BO_Employee
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
            });

            if (_setting.Object.valid_Password(user.emp_username, req.old_password) != null)
            {
                if (req.old_password != req.new_password)
                {
                    if (req.new_password.Equals(req.confrim_password))
                    {
                        _setting.Setup(s => s.change_Password(user.emp_username, req.new_password)).Returns(true);

                        Assert.IsTrue(_setting.Object.change_Password(user.emp_username, req.new_password), "Password Change Success");
                    }
                    else
                    {
                        Assert.IsFalse(req.new_password.Equals(req.confrim_password), "new password or confrim password not match");
                    }
                }
                else
                {
                    Assert.IsFalse((req.old_password != req.new_password), "old password match");
                }
            }
            else
            {
                Assert.IsFalse((_setting.Object.valid_Password(user.emp_username, req.old_password) != null), "password not match");
            }

            var data = setting.PostChangePassword(req);
            var objResult = data.GetType().GetProperty("Content").GetValue(data);
            Assert.AreEqual("Success", objResult);
        }

        [TestMethod]
        public void PostChangePIN()
        {
            m_ChangePin req = new m_ChangePin
            {
                new_pin = "55555",
                confrim_pin = "55555",
                old_pin = "123456"
            };

            //Get authentication from mock initialize authen token
            var user = Authentication.User;
            _setting.Setup(s => s.valid_PIN(user.emp_username, req.old_pin)).Returns(new Backup.ClassLibrary.Entity.BO_Employee
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
            });
            if (_setting.Object.valid_PIN(user.emp_username, req.old_pin) != null)
            {
                if (req.old_pin != req.new_pin)
                {
                    if (req.new_pin.Equals(req.confrim_pin))
                    {
                        _setting.Setup(s => s.Change_PIN(user.emp_id, req.new_pin)).Returns(true);

                        if (_setting.Object.Change_PIN(user.emp_id, req.new_pin))
                        {
                            Assert.IsTrue(_setting.Object.Change_PIN(user.emp_id, req.new_pin), "PIN Change Success");
                        }
                        else
                        {
                            Assert.IsFalse(_setting.Object.Change_PIN(user.emp_id, req.new_pin), "PIN Change Failed");
                        }
                    }
                    else
                    {
                        Assert.IsFalse(req.new_pin.Equals(req.confrim_pin), "new pin or confrim pin not match");
                    }
                }
                else
                {
                    Assert.IsFalse((req.old_pin != req.new_pin), "old pin match");
                }
            }
            else
            {
                Assert.IsFalse((_setting.Object.valid_Password(user.emp_username, req.old_pin) != null), "pin not match");
            }
            var data = setting.PostChangePIN(req);
            var objResult = data.GetType().GetProperty("Content").GetValue(data);
            Assert.AreEqual("Success", objResult);
        }
    }
}