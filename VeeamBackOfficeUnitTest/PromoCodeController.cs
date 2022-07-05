using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VeeamBackOfficeUnit.Test.Models;
using BackOffice.WebAPI.Controllers;
using Backup.ClassLibrary.Abstract;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Backup.ClassLibrary.Entity;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BackOffice.WebAPI.Authen;


namespace VeeamBackOfficeUnit.Test
{
    [TestClass]
    public class PromoCodeController
    {
        private string token = string.Empty;
        private Mock<IPromoCode> promo;
        private Mock<IAppRep> app;
        private BackOffice.WebAPI.Controllers.PromoCodeController promocode;

        [TestInitialize]
        public void Initialize()
        {
            token = Authentication.SetAuthenticated(DataMock.Employee, TimeSpan.FromMinutes(120).Minutes); //Authentication 
            promo = new Mock<IPromoCode>();
            app = new Mock<IAppRep>();
            promocode = new BackOffice.WebAPI.Controllers.PromoCodeController(promo.Object, app.Object);
        }

        [TestMethod]
        public void GetAllPromoCode()
        {
            promo.Setup(s => s.GetAll()).Returns(new List<Promo_code>
            {
                new Promo_code
                {
                    Id = 1,
                    promo_code = "A132SDFG",
                    discount = 20,
                    expired_dt = DateTime.Now,
                    add_dt = DateTime.Now,
                    staus = "ac"
                },
                new Promo_code
                {
                    Id = 1,
                    promo_code = "A132SDFG",
                    discount = 20,
                    expired_dt = DateTime.Now,
                    add_dt = DateTime.Now,
                    staus = "ac"
                },
                new Promo_code
                {
                    Id = 1,
                    promo_code = "A132SDFG",
                    discount = 20,
                    expired_dt = DateTime.Now,
                    add_dt = DateTime.Now,
                    staus = "ac"
                }
            });

            var data = promocode.GetAll();
            var objResult = data.GetType().GetProperty("Content").GetValue(data);
            string jsonData = JsonConvert.SerializeObject(objResult);
            List<Promo_code> list = JsonConvert.DeserializeObject<List<Promo_code>>(jsonData);
            Assert.IsNotNull(objResult);
            Assert.AreEqual(3, list.Count);
        }

        [TestMethod]
        public void GetById()
        {
            promo.Setup(s => s.GetById(1)).Returns(
            
                new Promo_code
                {
                    Id = 1,
                    promo_code = "A132SDFG",
                    discount = 20,
                    expired_dt = DateTime.Now,
                    add_dt = DateTime.Now,
                    staus = "ac"
                }
            );
            var data = promocode.GetById(1);
            var objResult = data.GetType().GetProperty("Content").GetValue(data);
            string jsondata = JsonConvert.SerializeObject(objResult);
            Option9T list = JsonConvert.DeserializeObject<Option9T>(jsondata);
            Assert.AreEqual(1, list.Id);
        }

        [TestMethod]
        public void InsertPromocode()
        {
            p_Promo model = new p_Promo
            {
                promo_code = "A132SDFG",
                discount = 20,
                expired_dt = DateTime.Now               
            };

            promo.Setup(s => s.check("A132SDFG")).Returns(true);
            promo.Setup(s => s.insert("A132SDFG", 20, DateTime.Now)).Returns(true);

            var data = promocode.insert(model);
            var objResult = data.GetType().GetProperty("Content").GetValue(data);
            Assert.AreEqual(false, objResult);

        }

        [TestMethod]
        public void UpdataPromoCode()
        {
            p_PromoId model = new p_PromoId
            {
                Id = 1,
                promo_code = "A132SDFG",
                discount = 20,
                expired_dt = DateTime.Now
            };

            promo.Setup(s => s.update(1, "A132SDFG", 20, DateTime.Now)).Returns(true);
            promo.Setup(s => s.checkupdate( model.promo_code, model.Id)).Returns(true);

            var data = promocode.update(model);
            var objResult = data.GetType().GetProperty("Content").GetValue(data);
            Assert.AreEqual(false, objResult);
        }

        [TestMethod]
        public void RemovePromoCode()
        {
            promo.Setup(s => s.Remove(1)).Returns(true);

            var data = promocode.Remove(1);
            var objResult = data.GetType().GetProperty("Content").GetValue(data);
            Assert.AreEqual(true, objResult);
        }

        [TestMethod]
        public void  GetByPromo_code()
        {
            promo.Setup(s => s.GetByPromo_code("A132SDFG")).Returns(
            
                new Promo_code
                {
                    Id = 1,
                    promo_code = "A132SDFG",
                    discount = 20,
                    expired_dt = DateTime.Now,
                    add_dt = DateTime.Now,
                    staus = "ac"
                }
            );

            var data = promocode.GetByPromo_code("A132SDFG");
            var objResult = data.GetType().GetProperty("Content").GetValue(data);
            string jsondata = JsonConvert.SerializeObject(objResult);
            Promo_code list = JsonConvert.DeserializeObject<Promo_code>(jsondata);
            Assert.AreEqual("A132SDFG", list.promo_code);
        }
    }
}
