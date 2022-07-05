using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Backup.ClassLibrary.Abstract;
using Moq;
using Backup.ClassLibrary.Entity;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VeeamBackOfficeUnit.Test
{
    /// <summary>
    /// UnitTest LogAcitonController by FarkramDev
    /// </summary>
    [TestClass]
    public class LogAcitonController
    {
        private Mock<ILogAction> _log;
        private Mock<IAppRep> _AppR = new Mock<IAppRep>();
        private BackOffice.WebAPI.Controllers.LogAcitonController log;

        [TestInitialize]
        public void Init()
        {
            _log = new Mock<ILogAction>();
            log = new BackOffice.WebAPI.Controllers.LogAcitonController(_log.Object, _AppR.Object);
        }

        [TestMethod]
        public void PostAllLogAction()
        {
            _log.Setup(s => s.getAllLogAction).Returns(new List<vBackOfficeLogActions>
            {
               new vBackOfficeLogActions
               {
                   act_id = 1,
                   log_dt = DateTime.Parse("2017-07-24 13:57:59.693"),
                   type = null,
                   description = "SignIn page",
                   desc_of_entry = "SignIn user: superadmin",
                   ip_address = "10.50.41.87",
                   emp_username = "superadmin",
                   emp_fristname = "superaddlink",
                   emp_lastname = "superaddlink",
                   emp_permission = "SuperAdmin",
                   emp_position = 1
               },               
               new vBackOfficeLogActions
               {
                   act_id = 2,
                   log_dt = DateTime.Parse("2017-07-13 13:58:02.773"),
                   type = null,
                   description = "user page",
                   desc_of_entry = "user all page user: SuperAdmin",
                   ip_address = "10.50.41.87",
                   emp_username = "superadmin",
                   emp_fristname = "superaddlink",
                   emp_lastname = "superaddlink",
                   emp_permission = "SuperAdmin",
                   emp_position = 1
               },
               new vBackOfficeLogActions
               {
                   act_id = 5,
                   log_dt = DateTime.Parse("2017-07-13 14:33:07.287"),
                   type = null,
                   description = "SignIn page",
                   desc_of_entry = "SignIn user: superadmin",
                   ip_address = "10.50.41.128",
                   emp_username = "superadmin",
                   emp_fristname = "superaddlink",
                   emp_lastname = "superaddlink",
                   emp_permission = "SuperAdmin",
                   emp_position = 1
               }
            });
            var response = log.PostAllLogAction();
            var objResult = response.GetType().GetProperty("Content").GetValue(response);
            string jsonData = JsonConvert.SerializeObject(objResult);
            List<vBackOfficeLogActions> list = JsonConvert.DeserializeObject<List<vBackOfficeLogActions>>(jsonData);
            Assert.IsNotNull(objResult);
            Assert.AreEqual(3, list.Count);
        }

        [TestMethod]
        public void PostLogeByFilter()
        {
            /*BO_LogAction_Find req = new BO_LogAction_Find {
                date_from = "07/24/2017",
                date_to = "07/24/2017",
                role = ""
            };

            _log.Setup(s => s.filter_log(req)).Returns(new List<vBackOfficeLogActions>
            {
                new vBackOfficeLogActions
               {
                   act_id = 1,
                   log_dt = DateTime.Parse("2017-07-24 13:57:59.693"),
                   type = null,
                   description = "SignIn page",
                   desc_of_entry = "SignIn user: superadmin",
                   ip_address = "10.50.41.87",
                   emp_username = "superadmin",
                   emp_fristname = "superaddlink",
                   emp_lastname = "superaddlink",
                   emp_permission = "SuperAdmin",
                   emp_position = 1
               }
            });

            var response = log.PostLogeByFilter(req);

            var objResult = response.GetType().GetProperty("Content").GetValue(response);
            string jsonData = JsonConvert.SerializeObject(objResult);
            List<vBackOfficeLogActions> list = JsonConvert.DeserializeObject<List<vBackOfficeLogActions>>(jsonData);
            Assert.IsNotNull(objResult);
            Assert.AreEqual(1, list.Count);*/
        }
    }
}