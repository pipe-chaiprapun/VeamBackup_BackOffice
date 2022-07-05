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
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Linq;

namespace BackOffice.WebAPI.Controllers
{
    [JWTAuthorize("SuperAdmin", "Admin", "Supervisor", "Operator", "Manager")]
    public class ClientController : ApiController
    {
        private IAuthorizationRep _EFAuthen;
        private IClients _IClients;
        private IAppRep _EFApp;

        public string ipaddress = (System.Web.HttpContext.Current != null) ? System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString() : "No Ip";
        private string browser = (System.Web.HttpContext.Current != null) ? System.Web.HttpContext.Current.Request.Browser.Browser + " " + System.Web.HttpContext.Current.Request.Browser.Version : "Unknow browser";

        public ClientController(IClients clients, IAppRep appRep, IAuthorizationRep IAuthorizRep)
        {
            _IClients = clients;
            _EFApp = appRep;
            _EFAuthen = IAuthorizRep;
        }

        #region Information Create Data
        [Route("api/create-client")]
        public IHttpActionResult PostCreateClient([FromBody]RegisCustomer values)
        {
            BO_Messageclients_return zxxz = new BO_Messageclients_return();
            var user = Authentication.User;
            _EFApp.save_logaction("clients page", "Create client: " + user.emp_permission, ipaddress, user.emp_id);

            if (ModelState.IsValid)
            {
                if (_EFAuthen.check_Email(values.Email) == 0)
                {
                    if (Regex.IsMatch(values.Password, @"(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9]).{8,20}$"))
                    {
                        var address = new Address
                        {
                            address = values.AddressPrefix,
                            city = values.City,
                            firstname = values.Name,
                            lastname = values.LastName,
                            country = values.Country,
                            phone_num = values.PhoneNumber,
                            post_code = values.PostCode,
                            province = values.StateOrProvince,
                            company_name = values.company,
                            cust_id = 0,
                        };

                        values.customer_type = 1; //HardCode Enterpirse Customer

                        //SignUp register new customer
                        int cust_id = _EFAuthen.SignUp(values.customer_type, values.Email, values.Password, address);

                        if (cust_id > 0)
                        {
                            address.cust_id = cust_id;
                            _EFApp.Sava_LogSignIn(new Clients().GetInfo(cust_id, browser, ipaddress), true);

                            //Verify User
                            var Token_Data = _EFApp.sendToken(cust_id, values.Email);

                            //Send Email Verify Account Register
                            Task.Factory.StartNew(() => SendMail.Mail(values.Email, "9T Support Confirm Account", new m_MessageSend().VerifyPayanAccountTemp(values.Name + ' ' + values.LastName, "/account-verified/" + Token_Data)));

                            //Send Email Reset Password Link
                            if (values.resetPasswordLink.Equals(true))
                            {
                                Task.Factory.StartNew(() => SendMail.Mail(values.Email, "9T Support Reset Password Link", new m_MessageSend().ResetPasswordCustomerLink(Token_Data, values.Email)));
                            }

                            var tempData3 = new m_TempData { data3 = cust_id };

                            var en_tem = Securities.Encode(tempData3);

                            //TempData เก็บ data3 เป็น cust_id
                            return Json(new { TempData = en_tem });
                        }
                        else
                        {
                            zxxz.Message = "SignUp Null";
                            return Json(zxxz);

                        }
                    }
                    else
                    {
                        zxxz.Message = "Password is invalid not match";
                        return Json(zxxz);

                    }
                }
                else
                {
                    zxxz.Message = "This email has already been registered";
                    return Json(zxxz);

                }
            }


            zxxz.Message = "UnSuccessful";
            return Json(zxxz);
        }
        #endregion

        #region Information Read Data
        [Route("api/client/information")]
        public IHttpActionResult PostClientInfo([FromBody]clientsInfo value)
        {
            var user = Authentication.User;
            _EFApp.save_logaction("clients page", "PostClientInfo: " + user.emp_permission, ipaddress, user.emp_id);
            var data = _IClients.getClientInfo(value.ClientId);
            if (data.Count() > 0)
            {
                return Json(data); //200
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent); // 204
            }
        }

        [Route("api/clients-all")]
        public IHttpActionResult PostAllClients()
        {
            try
            {
                var user = Authentication.User;
                _EFApp.save_logaction("clients page", "client all page user: " + user.emp_permission, ipaddress, user.emp_id);
                var model = _IClients.getAllClients;
                return Json(model);
            }
            catch (Exception e)
            {
                BO_Messageclients_return zxxz = new BO_Messageclients_return();
                zxxz.Message = "UnSuccessful";
                return Json(zxxz);
            }
        }
        [Route("api/clients-all-new")]
        public IHttpActionResult PostAllClients_new()
        {
            try
            {
                var user = Authentication.User;
                _EFApp.save_logaction("clients page", "client all page user: " + user.emp_permission, ipaddress, user.emp_id);
                var model = _IClients.getAllClients_new;
                return Json(model);
            }
            catch (Exception e)
            {
                BO_Messageclients_return zxxz = new BO_Messageclients_return();
                zxxz.Message = "UnSuccessful";
                return Json(zxxz);
            }
        }


        [Route("api/clients-all-vcc")]
        public IHttpActionResult PostAllClientsVcc()
        {

            try
            {
                var model = _IClients.getAllClientsVcc;

                string str = "{";
                var i = 0;
                foreach (var value in model)
                {

                    if (i == 0)
                    {
                        str += "'" + value.pck_id + "':'" + value.vcc_id + "'";
                    }
                    else
                    {
                        str += ",'" + value.pck_id + "':'" + value.vcc_id + "'";
                    }
                    i++;
                }
                str += "}";
                JObject json = JObject.Parse(str);

                return Json(json);
            }
            catch (Exception e)
            {
                BO_Messageclients_return zxxz = new BO_Messageclients_return();
                zxxz.Message = "UnSuccessful";
                return Json(zxxz);
            }
        }


        [Route("api/clients-action")]
        [HttpPost]
        public IHttpActionResult PostUserAction([FromBody]m_clients_user_action value)
        {
            try
            {
                var user = Authentication.User;
                _EFApp.save_logaction("clients page", "client action page user: " + user.emp_permission, ipaddress, user.emp_id);
                return Json(new { data = _IClients.UserAction(value.emp_id, value.cust_id, value.current_state, value.verify, value.block, value.freeze, value.delete) });
            }
            catch (Exception e)
            {
                BO_Messageclients_return zxxz = new BO_Messageclients_return();
                zxxz.Message = "UnSuccessful";
                return Json(zxxz);
            }
        }

        [Route("api/clients-reset")]
        [HttpPost]
        public IHttpActionResult PostUserReset([FromBody]m_client_reset_password value)
        {
            try
            {
                var user = Authentication.User;
                _EFApp.save_logaction("clients page", "client reset password: " + user.emp_permission, ipaddress, user.emp_id);
                var Token_Data = _EFApp.sendToken(value.cust_id, value.email);
                Task.Factory.StartNew(() => SendMail.Mail(value.email, "9T Support Reset Password Link", new m_MessageSend().ResetPasswordCustomerLink(Token_Data, value.email)));

                BO_Messageclients_return zxxz = new BO_Messageclients_return();
                zxxz.Message = "Successful";
                return Json(zxxz);
            }
            catch (Exception e)
            {
                BO_Messageclients_return zxxz = new BO_Messageclients_return();
                zxxz.Message = "UnSuccessful";
                return Json(zxxz);
            }
        }

        [Route("api/clients/reports/activity")]
        [HttpPost]
        public IHttpActionResult PostClientActivityReports([FromBody]m_rpt_clients value)
        {
            try {
                var user = Authentication.User;
                _EFApp.save_logaction("clients page", "client action page user: " + user.emp_permission, ipaddress, user.emp_id);
                return Json(new { data = _IClients.ClientActivityReports(value.customerId) });
            }
            catch (Exception e)
            {
                BO_Messageclients_return zxxz = new BO_Messageclients_return();
                zxxz.Message = "UnSuccessful";
                return Json(zxxz);
            }
        }

        [Route("api/clients/reports/payment")]
        [HttpPost]
        public IHttpActionResult PostClientPaymentReports([FromBody]m_rpt_clients value)
        {
            try
            {
                var user = Authentication.User;
                _EFApp.save_logaction("clients page", "client action page user: " + user.emp_permission, ipaddress, user.emp_id);
                return Json(new { data = _IClients.ClientPaymentReports(value.customerId) });
            }
            catch (Exception e)
            {
                BO_Messageclients_return zxxz = new BO_Messageclients_return();
                zxxz.Message = "UnSuccessful";
                return Json(zxxz);
            }
        }

        [Route("api/clients/reports/backups")]
        [HttpPost]
        public IHttpActionResult PostClientBackUpsReport([FromBody]m_rpt_clients value)
        {
            try {
                var user = Authentication.User;
                _EFApp.save_logaction("clients page", "client action page user: " + user.emp_permission, ipaddress, user.emp_id);
                return Json(new { data = _IClients.ClientBackupsReports(value.customerId) });
            }
            catch (Exception e)
            {
                BO_Messageclients_return zxxz = new BO_Messageclients_return();
                zxxz.Message = "UnSuccessful";
                return Json(zxxz);
            }
        }
        #endregion

        [Route("api/LogAction-page")]
        public IHttpActionResult PostLogeByall(BO_LogAction_page value)
        {
            BO_MessageLogActio_return zxxz = new BO_MessageLogActio_return();

            var user = Authentication.User;
            _EFApp.save_logaction(value.page + "page", value.pageaction + " page:" + user.emp_permission, ipaddress, user.emp_id);
            zxxz.Message = "UnSuccessful";
            return Json(zxxz);
        }
    }

    public class BO_Messageclients_return
    {
        public string Message { get; set; }
    }
}
