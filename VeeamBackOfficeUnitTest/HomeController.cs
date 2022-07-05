using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VeeamBackOfficeUnit.Test
{
    [TestClass]
    public class HomeConteoller
    {
        [TestMethod]
        public void Index()
        {
            //return File("~/Frontend/index.html", "text/html");
            //เช็คได้ก็ต่อเมื่อ deploy web แล้ว
           Assert.Inconclusive("No => ~/Frontend/index.html to test");
        }

        [TestMethod]
        public void GetAssets()
        {
            // var filePath = Server.MapPath($"~/Frontend/assets/{pathInfo}");
            //เช็คได้ก็ต่อเมื่อ deploy web แล้ว
            Assert.Inconclusive("No => ~/Frontend/assets/{pathInfo} to test");
        }
    }
}
