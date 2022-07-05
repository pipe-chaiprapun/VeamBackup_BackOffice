using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.WebAPI.Models
{
    public class m_GenInvo
    {
        public string startdate { get; set; }
        public int pck_id { get; set; }

        public int stor_vb { get; set; }

        public int vm_vb { get; set; }

        public bool premiums_storage { get; set; }
        
    }
}