using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BackOffice.WebAPI.Authen;
using Backup.ClassLibrary.Entity;
using Backup.ClassLibrary.Abstract;
using Backup.ClassLibrary.Concrete;


namespace BackOffice.WebAPI.Controllers
{
    [JWTAuthorize("SuperAdmin", "Admin", "Supervisor", "Operator", "Manager")]
    public class OptionController : ApiController
    {
        private IOption _Update;
        private IAppRep _EFapp;
        public string ip_address = (System.Web.HttpContext.Current != null) ? System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString() : "No Ip";
        private BackOfficeDB db = new BackOfficeDB();

        public OptionController(IOption Update, IAppRep EFapp)
        {          
            _Update = Update;
            _EFapp = EFapp;
        }
        /// <summary>
        /// Get all data for option
        /// </summary>
        [Route("api/GetAllOption9T")]
        public IHttpActionResult GetAll()
        {
            var user = Authentication.User;
            _EFapp.save_logaction("GetAllOption9T page", "GetAllRequest : " + user.emp_permission, ip_address, user.emp_id);

            var d = _Update.GetAll();
            return Json(d);
        }
        /// <summary>
        ///  value = [BUP,NKV,CBT,PMC]
        /// </summary>
        [AllowAnonymous]
        [Route("api/GetByIdOption9T")]
        public IHttpActionResult GetById(string value)
        {
            var user = Authentication.User;
            _EFapp.save_logaction("GetByIdOption9T page", "GetByIdRequest : " + user.emp_permission, ip_address, user.emp_id);


            var g = _Update.GetById(value);
            return Json(g);
        }
        /// <summary>
        /// value = 0 or 1 : 0 = false , 1 = true 
        /// </summary>
        [Route("api/UpdateOption9T")]
        public IHttpActionResult Update([FromBody]m_Option value)
        {
            var user = Authentication.User;
            _EFapp.save_logaction("UpdateOption9T page", "UpdateRequest : " + user.emp_permission, ip_address, user.emp_id);

            var p = _Update.Option_code(value.Id, value.Option_code);
            return Json(p);
        }
    }
}

public class m_Option
{
    /// <summary>
    /// id option code
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// value = 0 or 1 : 0 = false , 1 = true 
    /// </summary>
    public bool Option_code { get; set; }
}
