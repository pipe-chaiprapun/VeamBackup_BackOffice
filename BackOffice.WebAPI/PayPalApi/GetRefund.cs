using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.WebAPI.PayPalApi
{
    public class GetRefund
    {
        public string id { get; set; }
        public DateTime create_time { get; set; }
        public DateTime update_time { get; set; }
        public string state { get; set; }
        public Amount amount { get; set; }
        public string sale_id { get; set; }
        public string parent_payment { get; set; }
        public string invoice_number { get; set; }
        public Link[] links { get; set; }
    }

    public class GetRefundResponse
    {
        public bool Status { get; set; }
        public GetRefund Refund { get; set; }
        public GetError Error { get; set; }
    }

}