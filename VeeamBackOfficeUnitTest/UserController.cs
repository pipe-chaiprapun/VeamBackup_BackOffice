using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Backup.ClassLibrary.Abstract;
using Backup.ClassLibrary.Entity;
using System.Linq;
using System.Collections.Generic;
using BackOffice.WebAPI.Authen;
using VeeamBackOfficeUnit.Test.Models;
using System.Web.Http;
using Newtonsoft.Json;

namespace VeeamBackOfficeUnit.Test
{
    /// <summary>
    /// UnitTest UserController by FarkramDev
    /// </summary>
    [TestClass]
    public class UserController
    {
        private string token = string.Empty;
        private Mock<IUser> _User = new Mock<IUser>();
        private Mock<IAddUser> _AddUser = new Mock<IAddUser>();
        private Mock<IAppRep> _EFApp = new Mock<IAppRep>();
        private BackOffice.WebAPI.Controllers.UsersController UserContr;

        [TestInitialize]
        public void Init()
        {
            token = Authentication.SetAuthenticated(DataMock.Employee, TimeSpan.FromMinutes(120).Minutes); //Set Authentication Mock
            _AddUser = new Mock<IAddUser>();
            _EFApp = new Mock<IAppRep>();
            UserContr = new BackOffice.WebAPI.Controllers.UsersController(_User.Object, _AddUser.Object, _EFApp.Object);
        }

        [TestMethod]
        public void PostAllUser()
        {
            //Get authentication from mock initialize authen token
            var user = Authentication.User;
            _EFApp.Setup(s => s.save_logaction("user page", "user all page user: " + user.emp_permission, UserContr.ip_address, user.emp_id)).Returns(true);

            if (user.emp_permission.Equals("Admin"))
            {
                Assert.AreEqual("Admin", user.emp_permission);
                _User.Setup(s => s.getUserAll).Returns(new List<vBackOfficeUser>
                {
                    new vBackOfficeUser{
                        position_name = "Supper Admin",
                        emp_id = 2,
                        emp_username = "superadmin",
                        emp_password = "7yGQ2LgNfbEF3J9LLbkJL2BD+ir5Aa5P:CnVMjXxYZLEzMm5yomTbvA==",
                        emp_fristname = "superaddlink",
                        emp_lastname = "superaddlink",
                        emp_permission = "Operator",
                        emp_position = 1,
                        emp_status = "a"
                    },
                    new vBackOfficeUser{
                        position_name = "Supper Admin",
                        emp_id = 3,
                        emp_username = "superadmin",
                        emp_password = "7yGQ2LgNfbEF3J9LLbkJL2BD+ir5Aa5P:CnVMjXxYZLEzMm5yomTbvA==",
                        emp_fristname = "superaddlink2",
                        emp_lastname = "superaddlink2",
                        emp_permission = "Supervisor",
                        emp_position = 2,
                        emp_status = "a"
                    }
                });

                var data = _User.Object.getUserAll.Where(x => x.emp_permission == "Operator" || x.emp_permission == "Supervisor");
                Assert.IsNotNull(data);
            }
            else if (user.emp_permission.Equals("SuperAdmin"))
            {
                Assert.AreEqual("SuperAdmin", user.emp_permission);
                _User.Setup(s => s.getUserAll).Returns(new List<vBackOfficeUser>
                {
                    new vBackOfficeUser{
                        position_name = "Supper Admin",
                        emp_id = 2,
                        emp_username = "superadmin",
                        emp_password = "7yGQ2LgNfbEF3J9LLbkJL2BD+ir5Aa5P:CnVMjXxYZLEzMm5yomTbvA==",
                        emp_fristname = "superaddlink",
                        emp_lastname = "superaddlink",
                        emp_permission = "Operator",
                        emp_position = 1,
                        emp_status = "a"
                    },
                    new vBackOfficeUser{
                        position_name = "Supper Admin",
                        emp_id = 3,
                        emp_username = "superadmin",
                        emp_password = "7yGQ2LgNfbEF3J9LLbkJL2BD+ir5Aa5P:CnVMjXxYZLEzMm5yomTbvA==",
                        emp_fristname = "superaddlink",
                        emp_lastname = "superaddlink",
                        emp_permission = "Supervisor",
                        emp_position = 2,
                        emp_status = "a"
                    },
                    new vBackOfficeUser{
                        position_name = "Supper Admin",
                        emp_id = 3,
                        emp_username = "superadmin",
                        emp_password = "7yGQ2LgNfbEF3J9LLbkJL2BD+ir5Aa5P:CnVMjXxYZLEzMm5yomTbvA==",
                        emp_fristname = "superaddlink",
                        emp_lastname = "superaddlink",
                        emp_permission = "Admin",
                        emp_position = 2,
                        emp_status = "a"
                    }
                });

                var data = _User.Object.getUserAll.Where(x => x.emp_permission == "Operator" || x.emp_permission == "Supervisor" || x.emp_permission == "Admin");
                Assert.IsNotNull(data);
            }
        }

        [TestMethod]
        public void PostAddUser()
        {
            var value = new BO_Employee
            {
                emp_email = "Admin@addlink.com",
                emp_username = "aaa",
                emp_password = "loem123",
                emp_pin = "123456",
                emp_fristname = "Farkram",
                emp_lastname = "addmin lastname",
                emp_permission = "SuperAdmin",
                emp_position = 1,
                emp_status = "a",
                register_date = DateTime.Parse("2017-05-30 12:05:38.000")
            };

            _AddUser.Setup(add => add.check_count(value)).Returns(true);
            bool checkCount = _AddUser.Object.check_count(value);

            if (checkCount)
            {
                Assert.IsTrue(checkCount);

                _AddUser.Setup(s=>s.addUser(value)).Returns(true);
                if (_AddUser.Object.addUser(value))
                {
                    //Get authentication from mock initialize authen token
                    var user = Authentication.User;
                    _EFApp.Setup(s => s.save_logaction("user page", "add user: " + user.emp_permission, UserContr.ip_address, user.emp_id)).Returns(true);

                    Assert.IsTrue(_AddUser.Object.addUser(value), "Success"); //Success Add User
                }
                else
                {
                    Assert.IsFalse(_AddUser.Object.addUser(value), "Error Code"); //False Add User
                }
            }
            else
            {
                Assert.IsFalse(checkCount, "This Username has already been registered");
            }

            var data = UserContr.PostAddUser(value);
            var objResult = data.GetType().GetProperty("Content").GetValue(data);
            Assert.AreEqual("Success", objResult);
        }

        [TestMethod]
        public void PostUpdateUser()
        {
            var value = new BO_Employee
            {
                emp_email = "Admin@addlink.com",
                emp_username = "aaa",
                emp_password = "loem123",
                emp_pin = "123456",
                emp_fristname = "Farkram",
                emp_lastname = "addmin lastname",
                emp_permission = "SuperAdmin",
                emp_position = 1,
                emp_status = "a",
                register_date = DateTime.Parse("2017-05-30 12:05:38.000")
            };

            _AddUser.Setup(add => add.putUser(value)).Returns(true);

            bool pushResp = _AddUser.Object.putUser(value);

            Assert.IsTrue(pushResp);

            if (pushResp)
            {
                var user = Authentication.User;
                _EFApp.Setup(s => s.save_logaction("user page", "update user: " + user.emp_permission, UserContr.ip_address, user.emp_id)).Returns(true);
                Assert.IsTrue(pushResp, "Success"); //Success putUser
            }
            else
            {
                Assert.IsFalse(pushResp, "Error Code"); //False putUser
            }
           
            var data = UserContr.PostUpdateUser(value);
            var objResult = data.GetType().GetProperty("Content").GetValue(data);
            Assert.AreEqual("Success", objResult);
            Assert.IsFalse(objResult.Equals("Error Code"), "Error Code");
        }

        [TestMethod]
        public void PostBlockUser()
        {
            var value = new BO_Employee
            {
                emp_id = 25,
                emp_email = "Admin@addlink.com",
                emp_username = "aaa",
                emp_password = "loem123",
                emp_pin = "123456",
                emp_fristname = "Farkram",
                emp_lastname = "addmin lastname",
                emp_permission = "SuperAdmin",
                emp_position = 1,
                emp_status = "a",
                register_date = DateTime.Parse("2017-05-30 12:05:38.000")
            };

            _AddUser.Setup(add => add.blockUser(value.emp_id)).Returns(true);
            bool blockUserResp = _AddUser.Object.blockUser(value.emp_id);

            Assert.IsTrue(blockUserResp);
            if (blockUserResp)
            {
                var user = Authentication.User;
                _EFApp.Setup(s=>s.get_username(value.emp_id)).Returns(value.emp_username);
                _EFApp.Setup(s => s.save_logaction("user page", "block user: " + _EFApp.Object.get_username(value.emp_id), UserContr.ip_address, user.emp_id)).Returns(true);

                Assert.IsTrue(blockUserResp, "Success PostBlockUser"); //Success PostBlockUser
            }
            else
            {
                Assert.IsFalse(blockUserResp, "Error PostBlockUser"); //False PostBlockUser
            }
           
            var data = UserContr.PostBlockUser(value.emp_id);
            Assert.IsNotNull(data);
        }

        [TestMethod]
        public void PostDeleteUser()
        {
            var value = new BO_Employee
            {
                emp_id = 25,
                emp_email = "Admin@addlink.com",
                emp_username = "aaa",
                emp_password = "loem123",
                emp_pin = "123456",
                emp_fristname = "Farkram",
                emp_lastname = "addmin lastname",
                emp_permission = "SuperAdmin",
                emp_position = 1,
                emp_status = "a",
                register_date = DateTime.Parse("2017-05-30 12:05:38.000")
            };

            _AddUser.Setup(add => add.delUser(value.emp_id)).Returns(true);
            bool UserResp = _AddUser.Object.delUser(value.emp_id);
            Assert.IsTrue(UserResp);

            if (UserResp)
            {
                var user = Authentication.User;
                _EFApp.Setup(s => s.get_username(value.emp_id)).Returns(value.emp_username);
                _EFApp.Setup(s => s.save_logaction("user page", "block user: " + _EFApp.Object.get_username(value.emp_id), UserContr.ip_address, user.emp_id)).Returns(true);

                Assert.IsTrue(UserResp, "Success PostDeleteUser"); //Success PostDeleteUser
            }
            else
            {
                Assert.IsFalse(UserResp, "Error PostDeleteUser"); //False PostDeleteUser
            }

            var data = UserContr.PostDeleteUser(value.emp_id);
            Assert.IsNotNull(data);
        }

        [TestMethod]
        public void PostFindUser()
        {
            /*BO_Employee_Find value = new BO_Employee_Find
            {
                emp_username = "Opor",
                emp_fristname = "Rusame",
                emp_lastname = "Meemak",
                emp_position = 2,
                emp_status = "a"
            };
            var user = Authentication.User;
            _EFApp.Setup(s => s.save_logaction("user page", "find user: " + value.emp_username, UserContr.ip_address, user.emp_id)).Returns(true);
            _AddUser.Setup(s=>s.filter_user(value, user.emp_permission)).Returns(new List<vBackOfficeUser>
                {
                    new vBackOfficeUser{
                        position_name = "Operator",
                        emp_id = 2,
                        emp_username = "Opor",
                        emp_password = "7yGQ2LgNfbEF3J9LLbkJL2BD+ir5Aa5P:CnVMjXxYZLEzMm5yomTbvA==",
                        emp_fristname = "Rusame",
                        emp_lastname = "Meemak",
                        emp_permission = "Operator",
                        emp_position = 2,
                        emp_status = "a"
                    }
                });

            var resps = UserContr.PostFindUser(value);
            var objResult = resps.GetType().GetProperty("Content").GetValue(resps);
            string jsonData = JsonConvert.SerializeObject(objResult);
            var Actual = JsonConvert.DeserializeObject<IEnumerable<vBackOfficeUser>>(jsonData).Single();
          
            Assert.AreEqual("7yGQ2LgNfbEF3J9LLbkJL2BD+ir5Aa5P:CnVMjXxYZLEzMm5yomTbvA==", Actual.emp_password);*/
        }
    }
}