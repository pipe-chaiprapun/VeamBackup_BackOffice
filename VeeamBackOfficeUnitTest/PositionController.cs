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
    /// UnitTest PositionController by FarkramDev
    /// </summary>
    [TestClass]
    public class PositionController
    {
        private Mock<IPosition> _pos;
        private BackOffice.WebAPI.Controllers.PositionController pos;

        [TestInitialize]
        public void Initialize()
        {
            _pos = new Mock<IPosition>();
            pos = new BackOffice.WebAPI.Controllers.PositionController(_pos.Object);
        }

        [TestMethod]
        public void postPositionAll()
        {
            _pos.Setup(s => s.getPositionAll).Returns(new List<BO_Position>
            {
                new BO_Position{
                    position_id = 1,
                    position_name = "Supper Admin"
                },
                new BO_Position{
                    position_id = 2,
                    position_name = "Admin"
                },
                new BO_Position{
                    position_id = 3,
                    position_name = "Support specialist"
                }
            });
            var response = pos.postPositionAll();
            var objResult = response.GetType().GetProperty("Content").GetValue(response);
            string jsonData = JsonConvert.SerializeObject(objResult);
            List<BO_Position> list = JsonConvert.DeserializeObject<List<BO_Position>>(jsonData);
            Assert.IsNotNull(objResult);            
            Assert.AreEqual(3, list.Count);            
        }
    }
}
