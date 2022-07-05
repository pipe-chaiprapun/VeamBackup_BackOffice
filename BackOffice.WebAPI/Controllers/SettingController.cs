using BackOffice.WebAPI.Authen;
using BackOffice.WebAPI.Models;
using Backup.ClassLibrary.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BackOffice.WebAPI.Controllers
{
    [JWTAuthorize("SuperAdmin", "Admin", "Supervisor", "Operator", "Manager")]
    public class SettingController : ApiController
    {
        private ISetting _Isetting;
        private IAppRep _EFapp;
        public string ip_address = (System.Web.HttpContext.Current != null) ? System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString() : "No Ip";

        public SettingController(ISetting settingRep, IAppRep appref)
        {
            _Isetting = settingRep;
            _EFapp = appref;
        }

        [Route("api/Setting/ChangePassword")]
        public IHttpActionResult PostChangePassword([FromBody]m_Setting value)
        {
            BO_MessaSetting_return zxxz = new BO_MessaSetting_return();
            try { 
            if (ModelState.IsValid)
            {
                var user = Authentication.User;
                _EFapp.save_logaction("Setting page", "Change Password : " + user.emp_permission, ip_address, user.emp_id);

                if (_Isetting.valid_Password(user.emp_username, value.old_password) != null)
                {
                    if(value.old_password != value.new_password)
                    {
                        if (value.new_password.Equals(value.confrim_password))
                        {
                            if(_Isetting.change_Password(user.emp_username, value.new_password))
                            {
                                return Ok("Success");
                            }
                                zxxz.Message = "Error code";
                                return Json(zxxz);
                            }
                            zxxz.Message = "new password or confrim password not match";
                            return Json(zxxz);
                        }
                        zxxz.Message = "old password match";
                        return Json(zxxz);
                    }
                    zxxz.Message = "password not match";
                    return Json(zxxz);
                }

                zxxz.Message = "UnSuccessful";
                return Json(zxxz);
            }
            catch (Exception e)
            {
                zxxz.Message = "UnSuccessful";
                return Json(zxxz);
            }
        }

        [Route("api/Setting/ChangePIN")]
        public IHttpActionResult PostChangePIN([FromBody]m_ChangePin value)
        {
            BO_MessaSetting_return zxxz = new BO_MessaSetting_return();
            try { 
            if (ModelState.IsValid)
            {
                var user = Authentication.User;
                _EFapp.save_logaction("Setting page", "Change PIN : " + user.emp_permission, ip_address, user.emp_id);

                if (_Isetting.valid_PIN(user.emp_username, value.old_pin) != null)
                {
                    if (value.old_pin != value.new_pin)
                    {
                        if (value.new_pin.Equals(value.confrim_pin))
                        {
                            if (_Isetting.Change_PIN(user.emp_id, value.new_pin))
                            {
                                return Ok("Success");
                            }
                                zxxz.Message = "Error code";
                                return Json(zxxz);
                            }
                            zxxz.Message = "new pin or confrim pin not match";
                            return Json(zxxz);
                        };
                        zxxz.Message = "old pin match";
                        return Json(zxxz);
                    }
                    zxxz.Message = "pin not match";
                    return Json(zxxz);
                }
                zxxz.Message = "UnSuccessful";
                return Json(zxxz);
            }
            catch (Exception e)
            {
                zxxz.Message = "UnSuccessful";
                return Json(zxxz);
            }
        }
    }
    public class BO_MessaSetting_return
    {
        public string Message { get; set; }
    }
}