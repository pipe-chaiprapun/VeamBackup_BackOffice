using BackOffice.WebAPI.Authen;
using Backup.ClassLibrary.Abstract;
using Backup.ClassLibrary.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BackOffice.WebAPI.Controllers
{
    [JWTAuthorize("SuperAdmin", "Admin")]
    public class LogAcitonController : ApiController
    {
        private ILogAction _ILogAction;
        private IAppRep _EFApp;

        public string ipaddress = (System.Web.HttpContext.Current != null) ? System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString() : "No Ip";

        public LogAcitonController(ILogAction LogAction, IAppRep appref)
        {
            _ILogAction = LogAction;
            _EFApp = appref;
        }

        [Route("api/LogAction-all")]
        public IHttpActionResult PostAllLogAction()
        {
            BO_MessageLogActio_return zxxz = new BO_MessageLogActio_return();

            try
            {
                var user = Authentication.User;
                _EFApp.save_logaction("Log page", "Log : " + user.emp_permission, ipaddress, user.emp_id);

                var model = _ILogAction.getAllLogAction;
                return Json(model);
            }catch(Exception e)
            {
                zxxz.Message = "UnSuccessful";
                return Json(zxxz);
            }
        }

    }


    



    public class BO_MessageLogActio_return
    {
        public string Message { get; set; }
    }
}