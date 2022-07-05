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
   [JWTAuthorize("SuperAdmin", "Admin", "Supervisor", "Operator", "Manager")]
    public class ResellerController : ApiController
    {
        private IReseller _RES;
        private IAppRep _EFapp;
        public string ip_address = (System.Web.HttpContext.Current != null) ? System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString() : "No Ip";

        public ResellerController(IReseller res, IAppRep appRep)
        {
            _RES = res;
            _EFapp = appRep;
        }

        [Route("api/Reseller-addnew")]
        public IHttpActionResult AddnewReseller([FromBody]from_reseller val)
        {
            var pass = val.password;
            try
            {
                var user = Authentication.User;
                _EFapp.save_logaction("reseller page", "reseller add new: " + user.emp_permission, ip_address, user.emp_id);
                var res = _RES.addReseller(val);
                if (res != null)
                {
                    return Json(true);
                }
                return Json(false);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        [HttpDelete]
        [Route("api/Reseller-remove")]
        public IHttpActionResult Remove(int id)
        {
            try
            {
                var user = Authentication.User;
                _EFapp.save_logaction("reseller page", "reseller remove: " + user.emp_permission, ip_address, user.emp_id);
                var res = _RES.removeReseller(id);
                return Json(res);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }

        }

        [Route("api/Reseller-update")]
        public IHttpActionResult UpdateReseller([FromBody]from_reseller_update val)
        {
            try
            {
                var user = Authentication.User;
                _EFapp.save_logaction("reseller page ", "reseller Upadate: " + user.emp_permission, ip_address, user.emp_id);
                var res = _RES.updateReseller(val);
                return Json(res);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }
        [Route("api/Reseller-block")]
        public IHttpActionResult BlockReseller([FromBody]from_reseller_Block val)
        {
            try
            {
                var user = Authentication.User;
                _EFapp.save_logaction("reseller page ", "reseller block: " + user.emp_permission, ip_address, user.emp_id);
                var res = _RES.blockReseller(val);
                if (res != null)
                {
                    return Json(res);
                }
                return Json(false);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        [Route("api/Reseller-approve")]
        public IHttpActionResult approve_Reseller([FromBody]from_approve val)
        {
            var from = new Reseller_Contract
            {
                id = 0,
                seller_id = val.seller_id,
                contract_num = val.contract_num,
                contract_period_from = val.contract_period_from,
                contract_period_to = val.contract_period_to,
                contract_comment = val.contract_comment,
                contract_discount = val.contract_discount
            };
            try
            {
                var user = Authentication.User;
                _EFapp.save_logaction("reseller page ", "reseller approve: " + user.emp_permission, ip_address, user.emp_id);
                var res = _RES.approve_Reseller(from);

                if (res != null)
                {
                    var token = _RES.setToken(res.email,res.seller_id);
                    m_MessageSend email = new m_MessageSend();
                    System.Threading.Tasks.Task.Factory.StartNew(() => SendMail.Mail(res.email, "Approve account", email.ResetPasswordReseller(res.seller_id, res.password,token)));

                    return Json(true);
                }

                return Json(false);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        [Route("api/Reseller")]
        public IHttpActionResult GetReseller()
        {
            try
            {
                var user = Authentication.User;
                _EFapp.save_logaction("reseller page ", "reseller get all: " + user.emp_permission, ip_address, user.emp_id);
                return Json(_RES.GetReseller);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }

        }

        [Route("api/Reseller-id")]
        public IHttpActionResult Get_Reseller(int id)
        {
            try
            {
                var user = Authentication.User;
                _EFapp.save_logaction("reseller page ", "reseller get id: " + user.emp_permission, ip_address, user.emp_id);
                return Json(_RES.Get_Reseller(id));
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }

        }

        [Route("api/Payment-bill")]
        public IHttpActionResult getPayment(string id)
        {
            try
            {
                var user = Authentication.User;
                _EFapp.save_logaction("reseller page ", "reseller approve: " + user.emp_permission, ip_address, user.emp_id);
                return Json(_RES.get_Payment(id));
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        [Route("api/Reseller-change")]
        public IHttpActionResult change_status([FromBody]from_change_status val)
        {
            try
            {
                var user = Authentication.User;
                _EFapp.save_logaction("reseller page ", "reseller change status: " + user.emp_permission, ip_address, user.emp_id);
                var res = _RES.change_status(val);
                if (res != null)
                {
                    _RES.Bill_was_paid_to_email(res.bill_No);
                    //_RES.add_noti_was_paid(res.bill_No, payment_id);
                    return Json(res);
                }
                return Json(false);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        [HttpPost]
        [Route("api/Reseller-bill")]
        public IHttpActionResult Getbill()
        {
            try
            {
                var user = Authentication.User;
                _EFapp.save_logaction("reseller page ", "reseller bill: " + user.emp_permission, ip_address, user.emp_id);
                var res = _RES.GetBill;
                return Json(res);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        [Route("api/Reseller-order")]
        public IHttpActionResult GetReseller_Order()
        {
            try
            {
                var user = Authentication.User;
                _EFapp.save_logaction("reseller page ", "reseller Order: " + user.emp_permission, ip_address, user.emp_id);
                var res = _RES.GetReseller_Order;
                return Json(res);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        [Route("api/bill/Reseller_SendBill")]
        public IHttpActionResult sendBill([FromBody]m_sendbill value)
        {
            try
            {
                var user = Authentication.User;
                _EFapp.save_logaction("reseller page ", "reseller send invoice bill: " + user.emp_permission, ip_address, user.emp_id);
                string re;
                if ((re = _RES.send(value.bill_no)) == "success")
                {
                    return Json(re);
                }
                return Json(re);
            }
            catch (Exception ex)
            {
                return Json("ERROR : "+ex.Message);
            }
        }

        [Route("api/Status")]
        public IHttpActionResult Get_status()
        {
            return Json(_RES.GetStatusCode());
        }

        [Route("api/bill/Reseller_viewBill")]
        public IHttpActionResult viewBill([FromBody]m_sendbill value)
        {
            try
            {
                var user = Authentication.User;
                _EFapp.save_logaction("reseller page ", "reseller view invoice bill: " + user.emp_permission, ip_address, user.emp_id);
                var bill = _RES.show_view_bill(value.bill_no);
                return Json(bill);
            }
            catch (Exception ex)
            {
                return Json("ERROR : " + ex.Message);
            }
        }
    }
}
