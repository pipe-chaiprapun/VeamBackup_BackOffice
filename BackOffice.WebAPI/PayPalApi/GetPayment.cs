using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.WebAPI.PayPalApi
{
    public class GetPayment
    {
        public string id { get; set; }
        public DateTime create_time { get; set; }
        public DateTime update_time { get; set; }
        public string state { get; set; }
        public string intent { get; set; }
        public Payer payer { get; set; }
        public Transaction[] transactions { get; set; }
        public Link[] links { get; set; }
    }
}