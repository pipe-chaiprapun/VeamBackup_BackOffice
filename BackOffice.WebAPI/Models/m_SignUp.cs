using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.WebAPI.Models
{
    public class m_SignUp
    {
        public string confirm_pass { get; set; }

        public string username { get; set; }
        public string password { get; set; }
        public string fristname { get; set; }
        public string lastname { get; set; }
        public string role { get; set; }
        public byte position { get; set; }
        public string PIN { get; set; }
    }
}