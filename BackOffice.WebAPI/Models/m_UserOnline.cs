using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.WebAPI.Models
{
    public class m_UserOnline
    {
        public string conID { get; set; }
        public string username { get; set; }
        // 0 เป็น Empoyee 1 เป็น customer
        public string typeLogin { get; set; }
    }
}