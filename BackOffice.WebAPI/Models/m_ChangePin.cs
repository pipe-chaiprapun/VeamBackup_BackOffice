using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.WebAPI.Models
{
    public class m_ChangePin
    {
        public string old_pin { get; set; }

        public string new_pin { get; set; }

        public string confrim_pin { get; set; }
    }
}