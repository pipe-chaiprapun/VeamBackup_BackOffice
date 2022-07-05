using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.WebAPI.PayPalApi
{
    public class GetSale
    {
        public string id { get; set; }
        public DateTime create_time { get; set; }
        public DateTime update_time { get; set; }
        public Amount amount { get; set; }
        public string payment_mode { get; set; }
        public string state { get; set; }
        public string protection_eligibility { get; set; }
        public string protection_eligibility_type { get; set; }
        public string parent_payment { get; set; }
        public Transaction_Fee transaction_fee { get; set; }
        public Link[] links { get; set; }
    }

}