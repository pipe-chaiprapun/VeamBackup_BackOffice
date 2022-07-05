using BackOffice.WebAPI.Authen;
using BackOffice.WebAPI.Models;
using Backup.ClassLibrary.Abstract;
using Backup.ClassLibrary.Concrete;
using Backup.ClassLibrary.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BackOffice.WebAPI.Controllers
{
    [JWTAuthorize("SuperAdmin", "Admin", "Supervisor", "Manager")]
    public class DashboardController : ApiController
    {
        private IDashboard _IDash;
        private IAppRep _EFApp;
        private BackOfficeDB db = new BackOfficeDB();

        public string ipaddress = (System.Web.HttpContext.Current != null) ? System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString() : "No Ip";

        public DashboardController(IDashboard dashboard, IAppRep appref)
        {
            _IDash = dashboard;
            _EFApp = appref;
        }

        [Route("api/Dashboard/Search/quick")]
        public IHttpActionResult PostDashboardQuick([FromBody]m_Dashboard value)
        {

            BO_MessageDashboard_return zxxz = new BO_MessageDashboard_return();
            try {
                var user = Authentication.User;
                _EFApp.save_logaction("Dashboard page", "Dashboard Quick : " + user.emp_permission, ipaddress, user.emp_id);

                if (ModelState.IsValid)
                {
                    if (value.quick != null)
                    {
                        var quick_obj = _IDash.qry_Dashboard_quick(value.quick);

                        decimal price = 0;
                        int success = quick_obj.Count(p => p.status.Equals("pa"));
                        int not_success = quick_obj.Count(p => p.status.Equals("rm"));
                        int in_progress = quick_obj.Count(p => p.status.Equals("ac"));
                        int unpaid = quick_obj.Count(p => p.status.Equals("up"));
                        int unpaid_active = quick_obj.Count(p => p.status.Equals("au"));
                        int overdue = quick_obj.Count(p => p.status.Equals("ov"));
                        int overdue_active = quick_obj.Count(p => p.status.Equals("ao"));

                        foreach (var i in quick_obj)
                        {
                            price += i.price;
                        }

                        return Json(new { Data = quick_obj, Amount = price, Success = success, Not_success = not_success, In_progress = in_progress, Unpaid = unpaid, Unpaid_active = unpaid_active, Overdue = overdue, Overdue_active = overdue_active });
                    }


                    zxxz.Message = "UnSuccessful";
                    return Json(zxxz);
                }

                zxxz.Message = "UnSuccessful";
                return Json(zxxz);
            }
            catch(Exception e)
            {
                zxxz.Message = "UnSuccessful";
                return Json(zxxz);
            }
            }

        [Route("api/Dashboard/Search/custom")]
        public IHttpActionResult PostDashboardCustom([FromBody]m_Dashboard value)
        {
            BO_MessageDashboard_return zxxz = new BO_MessageDashboard_return();

            try {
                var user = Authentication.User;
                _EFApp.save_logaction("Dashboard page", "Dashboard Custom : " + user.emp_permission, ipaddress, user.emp_id);

                if (ModelState.IsValid)
                {
                    if (value.from != null && value.to != null)
                    {
                        var from_obj = _IDash.qry_Dashboard_from(value.from, value.to);

                        decimal price = 0;
                        int success = from_obj.Count(p => p.status.Equals("pa"));
                        int not_success = from_obj.Count(p => p.status.Equals("rm"));
                        int in_progress = from_obj.Count(p => p.status.Equals("ac"));
                        int unpaid = from_obj.Count(p => p.status.Equals("up"));
                        int unpaid_active = from_obj.Count(p => p.status.Equals("au"));
                        int overdue = from_obj.Count(p => p.status.Equals("ov"));
                        int overdue_active = from_obj.Count(p => p.status.Equals("ao"));

                        foreach (var i in from_obj)
                        {
                            price += i.price;
                        }

                        return Json(new { Data = from_obj, Amount = price, Success = success, Not_success = not_success, In_progress = in_progress, Unpaid = unpaid, Unpaid_active = unpaid_active, Overdue = overdue, Overdue_active = overdue_active });
                    }

                    zxxz.Message = "UnSuccessful";
                    return Json(zxxz);
                }

                zxxz.Message = "UnSuccessful";
                return Json(zxxz);
            }
            catch(Exception e)
            {
                zxxz.Message = "UnSuccessful";
                return Json(zxxz);
            }
        }
        [Route("api/Test")]
        [AllowAnonymous]
        public IHttpActionResult GetTest_inv()
        {
            return Json(db.v_Reseller_Invoices_View_BO.ToList<v_Reseller_Invoices_View_BO>());
        }


    }
    public class BO_MessageDashboard_return
    {
        public string Message { get; set; }
    }

}
