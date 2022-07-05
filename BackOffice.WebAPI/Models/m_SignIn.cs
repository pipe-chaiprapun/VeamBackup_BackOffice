using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BackOffice.WebAPI.Models
{
    public class m_SignIn
    {
        public string username { get; set; }

       // [Required]
       // [RegularExpression("(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9]).{8,20}$")]
        public string password { get; set; }
        public string role { get; set; }
    }

    public class m_validPIN
    {
        [Required]
        public string TempData { get; set; }

        [Required]
        [RegularExpression(@"^(\d){6}")]
        public string PIN { get; set; }
    }
}