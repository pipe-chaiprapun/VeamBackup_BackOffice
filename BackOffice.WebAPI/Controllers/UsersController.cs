using BackOffice.WebAPI.Authen;
using Backup.ClassLibrary.Abstract;
using Backup.ClassLibrary.Concrete;
using Backup.ClassLibrary.Concrete.Security;
using Backup.ClassLibrary.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BackOffice.WebAPI.Controllers
{
    [JWTAuthorize("SuperAdmin", "Admin")]
    public class UsersController : ApiController
    {
        private IUser _User;
        private IAddUser _AddUser;
        private IAppRep _EFApp;
        public string ip_address = (System.Web.HttpContext.Current != null) ? System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString() : "No Ip";

        public UsersController(IUser UserParam, IAddUser AddUserParam, IAppRep AppRep)
        {
            _User = UserParam;
            _AddUser = AddUserParam;
            _EFApp = AppRep;
        }

        [Route("api/user-all")]
        public IEnumerable<vBackOfficeUser> PostAllUser()
        {
            BO_Messausers_return zxxz = new BO_Messausers_return();

            try
            {
                var user = Authentication.User;
                _EFApp.save_logaction("user page", "user all page user: " + user.emp_permission, ip_address, user.emp_id);
                if (user.emp_permission.Equals("Admin"))
                {
                    var list_users = _User.getUserAll.Where(x => x.emp_permission == "Operator" || x.emp_permission == "Supervisor");
                    return list_users;
                }
                else if (user.emp_permission.Equals("SuperAdmin"))
                {
                    var list_users = _User.getUserAll.Where(x => x.emp_permission == "Operator" || x.emp_permission == "Supervisor" || x.emp_permission == "Admin");
                    return list_users;
                }
            }
            catch (Exception e)
            {
                return null; 
            }
            return null;
        }

        [Route("api/add-user")]
        public IHttpActionResult PostAddUser([FromBody]BO_Employee value)
        {
            BO_Messausers_return zxxz = new BO_Messausers_return();

            try
            {
                if (ModelState.IsValid)
                {
                    var count = _AddUser.check_count(value);
                    if (count == true)
                    {
                        var add = _AddUser.addUser(value);
                        if (add == true)
                        {
                            //SendMail.Mail(to, Subject, body);
                            var user = Authentication.User;
                            _EFApp.save_logaction("user page", "add user: " + value.emp_username, ip_address, user.emp_id);
                            return Ok("Success");
                        }
                        else  zxxz.Message = "UnSuccessful";
                        return Json(zxxz);
                    }
                    else 
                    zxxz.Message = "This Username has already been registered";
                    return Json(zxxz);
                }

                return BadRequest(ModelState);
            }
            catch (Exception e)
            {
                zxxz.Message = "UnSuccessful";
                return Json(zxxz);
            }
        }

        [Route("api/update-user")]
        public IHttpActionResult PostUpdateUser([FromBody]BO_Employee value)
        {
            BO_Messausers_return zxxz = new BO_Messausers_return();

            try
            {
                var add = _AddUser.putUser(value);
                if (add == true)
                {
                    var user = Authentication.User;
                    _EFApp.save_logaction("user page", "update user: " + value.emp_username, ip_address, user.emp_id);

                    return Ok("Success");
                }
                else zxxz.Message = "UnSuccessful";
                return Json(zxxz);
            }
            catch (Exception e)
            {
                zxxz.Message = "UnSuccessful";
                return Json(zxxz);
            }
        }

        [Route("api/block-user")]
        public IHttpActionResult PostBlockUser(int ID)
        {
            BO_Messausers_return zxxz = new BO_Messausers_return();
            try { 
            bool res = _AddUser.blockUser(ID);
            if (res)
            {
                var user = Authentication.User;
                var username = _EFApp.get_username(ID);
                _EFApp.save_logaction("user page", "block user: " + username, ip_address, user.emp_id);

                return Ok();
            }
            return BadRequest();
            }
            catch (Exception e)
            {
                zxxz.Message = "UnSuccessful";
                return Json(zxxz);
            }
        }

        [Route("api/del-user")]
        public IHttpActionResult PostDeleteUser(int ID)
        {
            BO_Messausers_return zxxz = new BO_Messausers_return();

            try { 
            bool res = _AddUser.delUser(ID);
            if (res)
            {
                var user = Authentication.User;
                var username = _EFApp.get_username(ID);
                _EFApp.save_logaction("user page", "block user: " + username, ip_address, user.emp_id);

                return Ok();
            }
            return BadRequest();
            }
            catch (Exception e)
            {
                zxxz.Message = "UnSuccessful";
                return Json(zxxz);
            }

        }

    }

    public class BO_Messausers_return
    {
        public string Message { get; set; }
    }

}