using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.WebAPI.Models
{
    public class m_Policy
    {
        public int product_id { get; set; }
        public decimal price { get; set; }

        public string unit { get; set; }
    }
}