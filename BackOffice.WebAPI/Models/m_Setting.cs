using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BackOffice.WebAPI.Models
{
    public class m_Setting
    {
        ////[Required]
        //[RegularExpression("(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9]).{8,20}$")]
        public string old_password { get; set; }
        ////[Required]
        //[RegularExpression("(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9]).{8,20}$")]
        public string new_password { get; set; }
        //[Required]
        //[RegularExpression("(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9]).{8,20}$")]
        public string confrim_password { get; set; }
    }
}