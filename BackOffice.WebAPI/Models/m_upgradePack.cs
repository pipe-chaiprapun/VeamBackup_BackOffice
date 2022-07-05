using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.WebAPI.Models
{
    public class m_upgradePack
    {
        public int pck_id { get; set; }
        public uint new_storage { get; set; }
        // 0 เป็น Empoyee 1 เป็น customer
        public int new_vm { get; set; }
    }
}