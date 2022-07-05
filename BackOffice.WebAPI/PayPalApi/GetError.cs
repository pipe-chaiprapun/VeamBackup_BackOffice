 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.WebAPI.PayPalApi
{
    public class GetError
    {

        public string name { get; set; }
        public string message { get; set; }
        public string information_link { get; set; }
        public string debug_id { get; set; }
    }
}