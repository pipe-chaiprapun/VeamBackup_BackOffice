using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Backup.ClassLibrary.Abstract;
using Backup.ClassLibrary.Models;

namespace BackOffice.WebAPI.Controllers
{
    public class ResallerInvoiceController : ApiController
    {
        private IResallerInvoice IResallerInvoice_;
        public ResallerInvoiceController(IResallerInvoice _IResallerInvoice) {
            IResallerInvoice_ = _IResallerInvoice;
        }
        [HttpGet]
        [Route("api/GetInfoInvoiceResaller")]
        public IHttpActionResult GetInfoInvoiceResaller() {

            return Json(IResallerInvoice_.getInfoInvoResaller());
        }
        [HttpGet]
        [Route("api/GetInfoInvoiceById")]
        public IHttpActionResult GetInfoInvoiceById(int invoice_no)
        {

            return Json(IResallerInvoice_.getInfoInvoResallerById(invoice_no));
        }
        [HttpGet]
        [Route("api/SuspendPackageReseller")]
        public IHttpActionResult SuspendPackageReseller(int pck_id) {
            
            return IResallerInvoice_.SuspendPackageResaller(pck_id)? Ok("Success"): Ok("failed suspend") ;
        }

    }
}
