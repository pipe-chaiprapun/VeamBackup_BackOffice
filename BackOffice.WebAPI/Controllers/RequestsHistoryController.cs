using System.Web.Http;
using Backup.ClassLibrary.Entity;
using Backup.ClassLibrary.Concrete;
using Backup.ClassLibrary.Abstract;
using BackOffice.WebAPI.Authen;
using BackOffice.WebAPI.Models;
using System.Collections.Generic;
using System;
using System.Globalization;

namespace BackOffice.WebAPI.Controllers
{
    public class RequestsHistoryController : ApiController
    {
        private IRequestsHistory _IReq;
        private IAppRep _EFapp;
        public string ip_address = (System.Web.HttpContext.Current != null) ? System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString() : "No Ip";

        public RequestsHistoryController(IRequestsHistory r, IAppRep appref) {
            _IReq = r;
            this._EFapp = appref;
        }

        [Route("api/getRequestHistory")]
        [HttpGet]
        public IHttpActionResult GetAllRequestsHistory()
        {
            BO_MessaRequest_return zxxz = new BO_MessaRequest_return();
            try
            {
                var user = Authentication.User;
                _EFapp.save_logaction("Request page", "getRequestHistory : " + user.emp_permission, ip_address, user.emp_id);

                return Json(_IReq.getAllRequestsHistory);
            }
            catch (Exception e)
            {
                zxxz.Message = "UnSuccessful";
                return Json(zxxz);
            }
        }
        [Route("api/deleteRequestHistory")]
        [HttpDelete]
        public IHttpActionResult remove(int id)
        {
            BO_MessaRequest_return zxxz = new BO_MessaRequest_return();
            try { 
            var user = Authentication.User;
            _EFapp.save_logaction("Request page", "deleteRequestHistory : " + user.emp_permission, ip_address, user.emp_id);
            return Ok(_IReq.RemoveReuestHistory(id));
            }
            catch (Exception e)
            {
                zxxz.Message = "UnSuccessful";
                return Json(zxxz);
            }
        }

    }
    public class BO_MessaRequest_return
    {
        public string Message { get; set; }
    }
}
