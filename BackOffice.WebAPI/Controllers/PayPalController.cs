using BackOffice.WebAPI.PayPalApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BackOffice.WebAPI.Controllers
{
    public class PayPalController : ApiController
    {
        [Route("api/paypal-getPayments")]
        public IHttpActionResult PostsgetPayments()
        {
            Api payment = new Api();
            var rs = payment.GetPayments();
            return Json(rs);
        }

        //[Route("api/paypal-getPayments-id")]
        //public IHttpActionResult PostsgetPaymentsId()
        //{
        //    Api payment = new Api();
        //    var rs = payment.GetPayment();
        //    return Json(rs);
        //}

    }
}