using Backup.ClassLibrary.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backup.ClassLibrary.Entity;
using BackOffice.WebAPI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VeeamBackOfficeUnit.Test.Models
{
    public class DataMock
    {
        /// <summary>
        /// Authentication.SetAuthenticated
        /// </summary>
        public static string sessionMock = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJkYXRhIjp7ImRhdGExIjoiMTEiLCJkYXRhMiI6IkFkbWluQGFkZGxpbmsuY29tIiwiZGF0YTMiOm51bGx9LCJleHAiOjYzNjM1Mzg5NzQ4MjgxMzQ2OH0.R1do_q1wj7sbVBoofjWGdNz7Ow6tqnL7g8Ys0vvlA3Q";

        public static BO_Employee Employee = new BO_Employee
        {
            emp_id = 11,
            emp_email = "Admin@addlink.com",
            emp_username = "Admin@addlink.com",
            emp_password = "loem123",
            emp_pin = "123456",
            emp_fristname = "Farkram",
            emp_lastname = "addmin lastname",
            emp_permission = "Admin",
            emp_position = 1,
            emp_status = "a",
            register_date = DateTime.Parse("2017-05-30 12:05:38.000")
        };
    }

    public class TempDatas
    {
        public string TempData { get; set; }
    }
}
