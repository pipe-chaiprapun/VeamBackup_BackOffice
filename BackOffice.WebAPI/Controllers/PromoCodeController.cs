using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using BackOffice.WebAPI.Authen;
using System.Web.Http;
using Backup.ClassLibrary.Abstract;
using Backup.ClassLibrary.Concrete;
using Backup.ClassLibrary.Entity;

namespace BackOffice.WebAPI.Controllers
{
    [JWTAuthorize("SuperAdmin", "Admin", "Supervisor", "Operator", "Manager")]
    public class PromoCodeController : ApiController
    {
        private IPromoCode _promo;
        private IAppRep _EFapp;
        public string ip_address = (System.Web.HttpContext.Current != null) ? System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString() : "No Ip";
        private BackOfficeDB db = new BackOfficeDB();

        public PromoCodeController(IPromoCode promo_, IAppRep EFapp_)
        {
            _promo = promo_;
            _EFapp = EFapp_;
        }

        [Route("api/GetAllPromo_code")]
        public IHttpActionResult GetAll()
        {
            var user = Authentication.User;
            _EFapp.save_logaction("GetAllPromo_code page", "GetAllRequest : " + user.emp_permission, ip_address, user.emp_id);

            //
            var ga = _promo.GetAll();
            return Json(ga);
        }

        [Route("api/GetAllPromo_code_history")]
        public IHttpActionResult GetPromoHistory()
        {
            var user = Authentication.User;
            _EFapp.save_logaction("GetAllPromo_code_history page", "GetAllRequest : " + user.emp_permission, ip_address, user.emp_id);

            //
            var v = _promo.GetPromoHistory;
            return Json(v);
        }

        [Route("api/GetByIdPromo_code")]
        public IHttpActionResult GetById(int Id)
        {
            var user = Authentication.User;
            _EFapp.save_logaction("GetByIdPromo_code page", "GetByIdRequest : " + user.emp_permission, ip_address, user.emp_id);

            //
            var gbi = _promo.GetById(Id);
            return Json(gbi);
        }

        [Route("api/InsertPromo_code")]
        public IHttpActionResult insert([FromBody] p_Promo value)
        {
            var user = Authentication.User;
            _EFapp.save_logaction("InsertPromo_code page", "InsertRequest : " + user.emp_permission, ip_address, user.emp_id);

            //
            if(_promo.check(value.promo_code)) {
                var ins = _promo.insert(value.promo_code, value.discount, value.expired_dt);
                return Json(ins);
            }

            return Json("PromoCode Duplicate!!");                
        }

        [Route("api/UpdatePromo_code")]
        public IHttpActionResult update([FromBody] p_PromoId value)
        {
            var user = Authentication.User;
            _EFapp.save_logaction("UpdatePromo_code page", "UpdateRequest : " + user.emp_permission, ip_address, user.emp_id);

            //
            if (_promo.checkupdate(value.promo_code, value.Id)) {
                var up = _promo.update(value.Id, value.promo_code, value.discount, value.expired_dt);
                return Json(up);
            }

            return Json("PromoCode Duplicate!!");            
        }

        

        [Route("api/RemovePromo_code")]
        [HttpGet]
        public IHttpActionResult Remove(int id)
        {
            var user = Authentication.User;
            _EFapp.save_logaction("RemovePromo_code page", "RemoveRequest : " + user.emp_permission, ip_address, user.emp_id);

            //
            var gbi = _promo.Remove(id);
            return Json(gbi);
        }

        [Route("api/GetByPromo_code")]
        public IHttpActionResult GetByPromo_code(string promo_code)
        {
            var user = Authentication.User;
            _EFapp.save_logaction("GetByPromo_code page", "GetByPromo_codeRequest : " + user.emp_permission, ip_address, user.emp_id);

            //
            var gbi = _promo.GetByPromo_code(promo_code);
            return Json(gbi);
        }
    }
} 

public class p_Promo
{
    //
    public string promo_code { get; set; }
    public float discount { get; set; }
    public DateTime expired_dt { get; set; }
}

public class p_PromoId
{
    //
    public int Id { get; set; }
    public string promo_code { get; set; }
    public float discount { get; set; }
    public DateTime expired_dt { get; set; }
}