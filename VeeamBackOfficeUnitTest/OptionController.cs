using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;
using System.Collections.Generic;
using Backup.ClassLibrary.Abstract;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BackOffice.WebAPI.Authen;
using Backup.ClassLibrary.Entity;
using VeeamBackOfficeUnit.Test.Models;


namespace VeeamBackOfficeUnit.Test
{
    [TestClass]
    public class OptionController
    {
        private string token = string.Empty;
        private Mock<IOption> op;
        private Mock<IAppRep> app;
        private BackOffice.WebAPI.Controllers.OptionController option;

        [TestInitialize]
        public void Initialize()
        {
            token = Authentication.SetAuthenticated(DataMock.Employee, TimeSpan.FromMinutes(120).Minutes); //Authentication 
            op = new Mock<IOption>();
            app = new Mock<IAppRep>();
            option = new BackOffice.WebAPI.Controllers.OptionController(op.Object, app.Object);
        }

        [TestMethod]
        public void GetAllOption()
        {
            op.Setup(s => s.GetAll()).Returns(new List<Option9T>
            {
                new Option9T
                {
                    Id = 1,
                    Option_code = "BUP",
                    Option = "Business plan",
                    use = true,
                    update_dt = DateTime.Now,
                    add_dt = DateTime.Now
                },
                new Option9T
                {
                    Id = 2,
                    Option_code = "NKV",
                    Option = "Nakivo package",
                    use = false,
                    update_dt = DateTime.Now,
                    add_dt = DateTime.Now   
                },
                new Option9T
                {
                    Id = 3,
                    Option_code = "CBT",
                    Option = "Chatbot",
                    use = true,
                    update_dt = DateTime.Now,
                    add_dt = DateTime.Now
                }
            });
            var data = option.GetAll();
            var objResult = data.GetType().GetProperty("Content").GetValue(data);
            string jsondata = JsonConvert.SerializeObject(objResult);
            List<Option9T> list = JsonConvert.DeserializeObject<List<Option9T>>(jsondata);
            Assert.IsNotNull(objResult);
            Assert.AreEqual(3, list.Count);
        }

        [TestMethod]
        public void GetByIdOption()
        {
            op.Setup(s => s.GetById("BUP")).Returns(
                new Option9T
                {
                    Id = 1,
                    Option_code = "BUP",
                    Option = "Business plan",
                    use = true,
                    update_dt = DateTime.Now,
                    add_dt = DateTime.Now
                }
            );

            var data = option.GetById("BUP");
            var objResult = data.GetType().GetProperty("Content").GetValue(data);
            string jsondata = JsonConvert.SerializeObject(objResult);
            Option9T list = JsonConvert.DeserializeObject<Option9T>(jsondata);
            Assert.AreEqual("BUP", list.Option_code);
        }
        [TestMethod]
        public void UpdateOption()
        {
            m_Option up = new m_Option
            {                
                Option_code = true                
            };

            op.Setup(s => s.Option_code(1, true)).Returns(false);
            var data = option.Update(up);
            var objResult = data.GetType().GetProperty("Content").GetValue(data);
            Assert.AreEqual(false, objResult);
        }
    }

}
