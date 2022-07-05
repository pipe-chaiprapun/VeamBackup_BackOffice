using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Backup.ClassLibrary.Abstract;
using BackOffice.WebAPI.Models;
using System.Collections.Generic;

namespace VeeamBackOfficeUnit.Test
{
    [TestClass]
    public class DashboardController
    {
        private BackOffice.WebAPI.Controllers.DashboardController dash;
        private Mock<IDashboard> _IDash;
        private Mock<IAppRep> _AppR = new Mock<IAppRep>();

        [TestInitialize]
        public void Initialize()
        {
            _IDash = new Mock<IDashboard>();
            dash = new BackOffice.WebAPI.Controllers.DashboardController(_IDash.Object, _AppR.Object);
        }

        [TestMethod]
        public void PostDashboardQuick()
        {
            var req = new m_Dashboard { quick = "", from = "", to = "" };

            //var data = payment.Payments_all();
            //var objResult = data.GetType().GetProperty("Content").GetValue(data);
            //string jsonData = JsonConvert.SerializeObject(objResult);
            //List<vBackOfficePayments> list = JsonConvert.DeserializeObject<List<vBackOfficePayments>>(jsonData);
            //Assert.IsNotNull(objResult);
            //if (list.Count > 0)
            //{
            //    Assert.AreEqual(2, list.Count);
            //}
        }
    }
}
