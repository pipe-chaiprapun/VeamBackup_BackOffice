using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.WebAPI.PayPalApi
{
    public class GetPayments
    {
        public Payment[] payments { get; set; }
        public int count { get; set; }
        public string next_id { get; set; }
    }
}