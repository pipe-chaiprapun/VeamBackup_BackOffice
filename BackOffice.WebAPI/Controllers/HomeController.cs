using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackOffice.WebAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return File("~/Frontend/index.html", "text/html");
        }

        public ActionResult GetAssets(string pathInfo)
        {
            var filePath = Server.MapPath($"~/Frontend/assets/{pathInfo}");
            var fileName = filePath.Split('.');
            if (System.IO.File.Exists(filePath))
            {
                var excName = fileName[fileName.Length - 1];
                var content_type = "text/html";
                switch (excName)
                {
                    case "css":
                        content_type = "text/css";
                        break;
                    case "js":
                        content_type = "text/javascript";
                        break;
                    case "svg":
                        content_type = "image/svg+xml";
                        break;
                }
                return File(filePath, content_type);
            }
            return HttpNotFound();
        }
    }
}
