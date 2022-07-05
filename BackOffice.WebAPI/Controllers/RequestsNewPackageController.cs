using BackOffice.WebAPI.Authen;
using BackOffice.WebAPI.Models;
using Backup.ClassLibrary.Abstract;
using Backup.ClassLibrary.Concrete;
using Backup.ClassLibrary.Concrete.Security;
using Backup.ClassLibrary.Concrete.VeeamCloudConnect;
using Backup.ClassLibrary.Entity;
using Backup.ClassLibrary.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BackOffice.WebAPI.Controllers
{
    public class RequestsNewPackageController : ApiController
    {
        private IRequestNewPackage req ;
        private IAppRep _EFapp;
        public string ip_address = (System.Web.HttpContext.Current != null) ? System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString() : "No Ip";
        public RequestsNewPackageController(IRequestNewPackage req_, IAppRep appref)
        {
            req = req_;
            this._EFapp = appref;
        }
        [Route("api/getRequestPackage")]
        [HttpGet]
        public IHttpActionResult GetallPackage()
        {
            BO_Messapositioo_return zxxz = new BO_Messapositioo_return();

            try { 
            var user = Authentication.User;
            _EFapp.save_logaction("Request page", "getRequestPackage : " + user.emp_permission, ip_address, user.emp_id);
            return Json(req.getallPackage);
            }
            catch (Exception e)
            {
                zxxz.Message = "UnSuccessful";
                return Json(zxxz);
            }
        }

        [Route("api/deleteRequestPackage")]
        [HttpDelete]
        public IHttpActionResult remove(int id)
        {
            BO_Messapositioo_return zxxz = new BO_Messapositioo_return();
            try { 
            var user = Authentication.User;
            _EFapp.save_logaction("Request page", "deleteRequestPackage : " + user.emp_permission, ip_address, user.emp_id);
            return Ok(req.RemoveReuestPackage(id));
            }
            catch (Exception e)
            {
                zxxz.Message = "UnSuccessful";
                return Json(zxxz);
            }
        }


    }
    public class BO_Messapositioo_return
    {
        public string Message { get; set; }
    }
}