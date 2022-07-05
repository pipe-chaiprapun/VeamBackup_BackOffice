using Backup.ClassLibrary.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BackOffice.WebAPI.Models
{
    public class RegisCustomer
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string AddressPrefix { get; set; }
        public string City { get; set; }
        public string StateOrProvince { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }
        public bool resetPasswordLink { get; set; }
        public string company { get; set; }

        [Required]
        public int customer_type { get; set; } // 0 = Normal, 1 = Enterprise
    }
}