using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup.ClassLibrary.Models
{
    public class getPackageFromCart
    {
        public int pck_id { get; set; }
        public string pck_name { get; set; }
        public int vm { get; set; }
        public int storage { get; set; }
        public bool premiums_storage { get; set; }
        public decimal amount { get; set; }
        public string currency { get; set; }
        public DateTime add_dt { get; set; }
    }
    public class getVmStorage
    {
        public string alias { get; set; }
        public int vm { get; set; }
        public int storage { get; set; }
        public string type = "BackUp";
    }
    public class getVmStorage_pck_id
    {
        public int vm { get; set; }
        public int storage { get; set; }
    }
}
