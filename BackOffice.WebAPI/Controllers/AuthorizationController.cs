using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BackOffice.WebAPI.Models;
using Backup.ClassLibrary.Abstract;
using Backup.ClassLibrary.Entity;
using BackOffice.WebAPI.Authen;

namespace BackOffice.WebAPI.Controllers
{
    public class AuthorizationController : ApiController
    {
        private IAuthorizationRep _EFAuthen;
        private IAppRep _EFApp;
        public string ipaddress = (System.Web.HttpContext.Current != null) ? System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString() : "No Ip";

        public AuthorizationController(IAuthorizationRep AuthenRep, IAppRep AppRep)
        {
            this._EFAuthen = AuthenRep;
            this._EFApp = AppRep;
        }

        [JWTAuthorize("SuperAdmin", "Admin", "Supervisor", "Operator", "Manager")]
        public IHttpActionResult Get()
        {
            var res = Authentication.User;
            var authen = Authentication.SetAuthenticated(res.emp_username);
            return Json(new { Token = authen, Username = res.emp_fristname, Role = res.emp_permission, EmpId = res.emp_id });
        }

        public BO_Log_Signin GetInfo(int cust_id)
        {
            string ip_address = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
            string country = "";
            string browser = (System.Web.HttpContext.Current != null) ? System.Web.HttpContext.Current.Request.Browser.Browser + " " + System.Web.HttpContext.Current.Request.Browser.Version : "Unknow browser";
            string OS = "Windows";
            string device_name = System.Environment.MachineName;

            BO_Log_Signin logObj = new BO_Log_Signin
            {
                acc_id = cust_id,
                browser = browser,
                ip = ip_address,
                device_name = device_name + ", " + OS,
                country = country
            };

            return logObj;
        }

        //[Route("api/TestSignUp")]
        //public IHttpActionResult PostTestSignUp([FromBody]m_SignUp value)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (_EFAuthen.check_Count(value.username) == 0)
        //        {
        //            if (value.password.Equals(value.confirm_pass))
        //            {
        //                if (_EFAuthen.Create_user(value.username, value.password, value.fristname, value.lastname, value.role, value.position, value.PIN) == true)
        //                {
        //                    return Ok("Success");
        //                }
        //                else{  return BadRequest("Function problem"); }
        //            }
        //            else{ return BadRequest("Password and confirm password not match."); }

        //        }
        //        else{ return BadRequest("This Username has already been registered."); }
        //    }
        //    return BadRequest(ModelState);
        //}

        //Signin V.1/2 Check 
        [Route("api/SignIn")]
        public IHttpActionResult PostSignIn([FromBody]m_SignIn value)
        {
            if (ModelState.IsValid)
            {
                if (_EFAuthen.check_Count(value.username) != 0)
                {
                    //Check signin
                    //if (_EFAuthen.check_login(value.username))
                    //{
                        int emp_id = _EFAuthen.get_custID(value.username);
                        if (_EFAuthen.check_active(emp_id))
                        {

                            //int signin_time = _EFAuthen.countSignin(cust_id);

                            var res_users = _EFAuthen.valid_Password(value.username, value.password);

                            if (res_users != null)
                            {
                                //if (res_users.emp_permission.Equals(value.role))
                                //{
                                    // เก็บค่า cust_ID และ username ไวใน TempData  
                                    m_TempData TempDt = new m_TempData { data1 = res_users.emp_id.ToString(), data2 = res_users.emp_username };
                                    return Json(new { TempData = Securities.Encode(TempDt) });
                               // }
                               // else
                               // {
                               //     _EFApp.save_logSignIn(GetInfo(emp_id));
                               //     return BadRequest("Incorrect Role");
                               //}
                            }
                            else
                            {
                                _EFApp.save_logSignIn(GetInfo(emp_id));
                                return BadRequest("Incorrect password");
                            }
                        }
                        else { return BadRequest("Not active"); }
                    //}
                    //else { return BadRequest("Has been login"); }
                }
                else { return BadRequest("Not found email."); }
            }
            return BadRequest(ModelState);
        }

        [Route("api/SignIn/PIN")]
        public IHttpActionResult PostSignInPIN([FromBody]m_validPIN value)
        {
            if (ModelState.IsValid)
            {
                var TempDt = Securities.Decode<m_TempData>(value.TempData);
                int user_id = Convert.ToInt32(TempDt.data1);

                if (user_id > 0)
                {
                    var res = _EFAuthen.ValidPIN(user_id, value.PIN);
                    if (res != null)
                    {
                        _EFApp.save_logSignIn(GetInfo(user_id), true);
                        string username = _EFApp.get_username(user_id);
                        _EFApp.save_logaction("SignIn page", "SignIn user: " + username, ipaddress, user_id);

                        var authen = Authentication.SetAuthenticated(res.emp_username);
                        return Json(new { Token = authen, Username = res.emp_fristname, Role = res.emp_permission, EmpId = res.emp_id });
                    }
                    else
                    {
                        _EFApp.save_logSignIn(GetInfo(user_id));
                        return BadRequest("Incorrect PIN");
                    }
                }
                else { return BadRequest("Not found value."); }
            }
            return BadRequest(ModelState);
        }

    }
}
