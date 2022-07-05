using BackOffice.WebAPI.Authen;
using BackOffice.WebAPI.PayPalApi;
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
    public class RefundController : ApiController
    {
        private IRefund _refund;
        private IAppRep _EFapp;
        public string ip_address = (System.Web.HttpContext.Current != null) ? System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString() : "No Ip";

        public RefundController(IRefund refund, IAppRep appref)
        {
            this._refund = refund;
            this._EFapp = appref;
        }

        [Route("api/refund-all")]
        public IHttpActionResult PostRefund_all()
        {
            BO_Refund_return zz = new BO_Refund_return();
            try
            {
                var model = _refund.getAllPaypalRefund;
                return Json(model);
            }
            catch (Exception e)
            {
                zz.Message = "Successful";
                return Json(zz);
            }
        }

        [Route("api/refund-pamat")]
        public IHttpActionResult PostRefund_pamat(string pay )
        {
            BO_Refund_return zz = new BO_Refund_return();
            try { 

            Api payment = new Api();
            var rs = payment.GetPayment(pay);
            return Json(rs);
            }
            catch (Exception e)
            {
                zz.Message = "Successful";
                return Json(zz);
            }
        }



        [Route("api/refund-ByPck-id")]
        public IHttpActionResult PostRefundByID([FromBody]BO_Refund_Update value)
        {
            BO_Refund_return zzz = new BO_Refund_return();
            try
            {

                //value.pck_id = 295;
                var user = Authentication.User;
                _EFapp.save_logaction("refund page", "refund : " + user.emp_permission, ip_address, user.emp_id);
                var okok = _refund.ckackRefund(value.pck_id).ToList();
                int okokcount = okok.Count;

                if(okokcount == 1)
                {
                    foreach (var element in okok)
                    {
                        DateTime dateTime1 = DateTime.Now;
                        DateTime dateTime2 = element.pck_start_dt;
                        DateTime datee = dateTime2.AddDays(7);

                        if (dateTime1 <= datee)
                        {
                            var model = _refund.Refund_byId(value.pck_id);
                            var aa = model.FirstOrDefault();
                            var bb = aa.payment_id;
                            Api payment = new Api();
                            var rs = payment.GetPayment(bb);
                            var ss = rs.transactions[0];
                            var dd = ss.related_resources[0];
                            var ff = dd.sale.id;
                            var ww = payment.RefundSale(ff);
                            var status = ww.Status;
                            //var total = ww.Refund.amount.total;
                            //var currency = ww.Refund.amount.currency;
                            if (status.Equals(true))
                            {
                                var xx = _refund.UpdateRefund(value.vcc_id);
                                _refund.DeleteRefundtable(value.pck_id);
                                BO_Refund_return zz = new BO_Refund_return();
                                zz.Message = "Successful";
                                return Json(zz);
                            }
                            else
                            {
                                var xx = _refund.DeleteRefundFell(value.vcc_id);
                                BO_Refund_return zz = new BO_Refund_return();
                                zz.Message = "unsuccessful";
                                return Json(zz);
                            }
                        }
                        else
                        {
                            var xx = _refund.UpdateRefundFell(value.vcc_id);
                            zzz.Message = "Successful";
                            return Json(zzz);
                        }

                    }
                }
                else
                {
                    var xx = _refund.UpdateRefundFell(value.vcc_id);

                    BO_Refund_return zz = new BO_Refund_return();
                    zzz.Message = "Successful";
                    return Json(zzz);
                }
                zzz.Message = "Successful";
                return Json(zzz);
            }
            catch (PayPal.PayPalException ex)
            {
               // var xx = _refund.UpdateRefundFell(value.vcc_id);
                zzz.Message = "Successful";
                return Json(zzz);
            }
           
        }


        [Route("api/Delete-refund-ByPck-id")]
        public IHttpActionResult PostDeleteRefundByID([FromBody]BO_Refund_Update value)
        {
            try
            {

                var user = Authentication.User;
                _EFapp.save_logaction("refund page", "Delete refund : " + user.emp_permission, ip_address, user.emp_id);


                var xx = _refund.DeleteRefundFell(value.vcc_id);
                if (xx.Equals(true))
                {
                    BO_Refund_return zz = new BO_Refund_return();
                    zz.Message = "Successful";
                    return Json(zz);
                }
                else
                {
                    BO_Refund_return zz = new BO_Refund_return();
                    zz.Message = "unsuccessful";
                    return Json(zz);
                }
            }
            catch (Exception e)
            {
                var xx = _refund.UpdateRefundFell(value.vcc_id);
                BO_Refund_return zz = new BO_Refund_return();
                zz.Message = "Successful";
                return Json(zz);
            }

        }

        [Route("api/refund-comment")]
        public IHttpActionResult PostRefundCommen([FromBody]BO_Refund_Comment value)
        {
            try
            {

                var user = Authentication.User;
                _EFapp.save_logaction("refund page", "comment refund : " + user.emp_permission, ip_address, user.emp_id);


                var xx = _refund.RefundRefundComment(value);
                if (xx.Equals(true))
                {
                    BO_Refund_return zz = new BO_Refund_return();
                    zz.Message = "Successful";
                    return Json(zz);
                }
            }
            catch (Exception e)
            {
                BO_Refund_return zz = new BO_Refund_return();
                zz.Message = "UnSuccessful";
                return Json(zz);
            }

            BO_Refund_return zxxz = new BO_Refund_return();
            zxxz.Message = "UnSuccessful";
            return Json(zxxz);
        }


        public class BO_Refund_return
        {
            public string Message { get; set; }
        }


    }
}