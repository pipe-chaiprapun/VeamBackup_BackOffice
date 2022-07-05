using BackOffice.WebAPI.Authen;
using BackOffice.WebAPI.Models;
using Backup.ClassLibrary.Abstract;
using Backup.ClassLibrary.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BackOffice.WebAPI.Controllers
{
    [JWTAuthorize("SuperAdmin", "Admin", "Supervisor", "Operator", "Manager")]
    public class PolicyController : ApiController
    {
        private Ipolicy _IPolicy;
        private IAppRep _EFapp;
        public string ipaddress = (System.Web.HttpContext.Current != null) ? System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString() : "No Ip";

        public PolicyController(Ipolicy policy, IAppRep appref)
        {
            this._IPolicy = policy;
            this._EFapp = appref;
        }

        [Route("api/policy-all")]
        public IHttpActionResult GetPolicyAll()
        {
            BO_Messagepolicy_return zxxz = new BO_Messagepolicy_return();

            try { 
            var user = Authentication.User;
            _EFapp.save_logaction("policy page", "Policy All : " + user.emp_permission, ipaddress, user.emp_id);

            return Json(_IPolicy.product_price);
            }
            catch (Exception e)
            {
                zxxz.Message = "UnSuccessful";
                return Json(zxxz);
            }
        }

        [Route("api/update-policyPrice")]
        public IHttpActionResult PostPutPolicyPrice([FromBody]m_Policy value)
        {
            BO_Messagepolicy_return zxxz = new BO_Messagepolicy_return();
            try {
                var user = Authentication.User;
                if ( value.product_id == 1104 || value.product_id == 1208 || value.product_id == 1304 || value.product_id == 1408) 
                {
                    if (value.product_id == 1104)
                    {                       
                        _EFapp.save_logaction("Veeam Backup page", "chancgh Buying : " + user.emp_permission, ipaddress, user.emp_id);
                        var add = _IPolicy.change_unit(value.product_id, value.unit);
                        if (add == true)
                            return Ok("Success" + " : change_unit " + value.product_id);   
                    }
                    else if(value.product_id == 1208)
                    {
                        _EFapp.save_logaction("Veeam Replicatino page", "chancgh Buying : " + user.emp_permission, ipaddress, user.emp_id);
                        var add = _IPolicy.change_unit(value.product_id, value.unit);
                        if (add == true)
                            return Ok("Success" + " : change_unit " + value.product_id);
                    }
                    else if (value.product_id == 1304)
                    {
                            _EFapp.save_logaction("Nakivo Backup page", "change Buying : " + user.emp_permission, ipaddress, user.emp_id);
                            var add = _IPolicy.change_unit(value.product_id, value.unit);
                            if (add == true)
                            return Ok("Success" + " : change_unit " + value.product_id);
                    }
                    else if(value.product_id == 1408)
                    {
                        _EFapp.save_logaction("Nakivo Replication page", "change Buying : " + user.emp_permission, ipaddress, user.emp_id);
                        var add = _IPolicy.change_unit(value.product_id, value.unit);
                        if (add == true)
                            return Ok("Success" + " : change_unit " + value.product_id);
                    }
                    zxxz.Message = "Unsuccessful" + " : change_unit "+ value.product_id;
                    return Json(zxxz);
                }
                else
                {
                    _EFapp.save_logaction("policy page", "Put Policy Price : " + user.emp_permission, ipaddress, user.emp_id);

                    var add = _IPolicy.change_policy(value.product_id, value.price);
                    if (add == true)
                    {
                        return Ok("Success" + " change_policy " + value.product_id);
                    }
                    else zxxz.Message = "UnSuccessful" + " : change_policy";
                        return Json(zxxz);
                }
            }
            catch (Exception e)
            {
                zxxz.Message = "UnSuccessful" + " : " + e.Message;
                return Json(zxxz);
            }

        }
    }
    public class BO_Messagepolicy_return
    {
        public string Message { get; set; }
    }
}