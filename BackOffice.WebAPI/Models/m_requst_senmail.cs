using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.WebAPI.Models
{
    public class m_requst_senmail
    {
        public int pck_id { get; set; }
        public string email { get; set; }
        public int vcc_id { get; set; }
    }
}