using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BackOffice.WebAPI.Models
{
    public class m_packages
    {
        public string PackageNo { get; set; }
        public string Type { get; set; }
        public string ClientName { get; set; }
        public string FamilyName { get; set; }
        public string PackageStatus { get; set; }
    }

}