using Backup.ClassLibrary.Abstract;
using Backup.ClassLibrary.Concrete.Security;
using Backup.ClassLibrary.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup.ClassLibrary.Concrete
{
    public class AddUser : IAddUser
    {
        private BackOfficeDB db = new BackOfficeDB();
        

        public bool addUser(BO_Employee value)
        {

            String body = @"<div style='height: 145px;width: 300px;padding: 10px;background-color: #c6c6c6;'>
                  <div style = 'text-align:center;'>
                  <h3>detail for user</h3>
                  </div>
                  <div>
                  <div style='font - size: 18px; font - weight: 600; '>username :"+ value.emp_username+@"</div>
                  <div style='font - size: 18px; font - weight: 600; '>password:"+value.emp_password+@"<div>
                  <div style='font - size: 18px; font - weight: 600; '>pin :"+value.emp_pin+@"</div>
                   </div>
                   </div>";



            SendMail.Mail(value.emp_email+ "@addlink.com", "detail for user", body);
            value.emp_password = Security.App_Hash.PasswordHash(value.emp_password);
            value.emp_pin = Security.App_Hash.PasswordHash(value.emp_pin);

            db.BO_Employee.Add(value);
            int res = db.SaveChanges();
            return res > 0 ? true : false;

        }

        public bool putUser(BO_Employee value)
        {
            string has_password = Security.App_Hash.PasswordHash(value.emp_password);

            var EmployeeObj = db.BO_Employee.Where(x => x.emp_id == value.emp_id).FirstOrDefault();
            
            if (value.emp_password != "")
            {
                EmployeeObj.emp_password = has_password;
            }
            else
            {
                EmployeeObj.emp_password = EmployeeObj.emp_password;
            }

            EmployeeObj.emp_username = value.emp_username;
            EmployeeObj.emp_fristname = value.emp_fristname;
            EmployeeObj.emp_lastname = value.emp_lastname;
            EmployeeObj.emp_permission = value.emp_permission;
            EmployeeObj.emp_position = value.emp_position;
            EmployeeObj.emp_status = value.emp_status;
            EmployeeObj.emp_pin = EmployeeObj.emp_pin;
            int res = db.SaveChanges();
            return res > 0 ? true : false;
        }

        public bool blockUser(int ID)
        {
            var EmployeeObj = db.BO_Employee.Where(x => x.emp_id == ID).FirstOrDefault<BO_Employee>();
            var sss = EmployeeObj.emp_status;
            if(sss == "a")
            {
                EmployeeObj.emp_status = "b";
            }
            else
            {
                EmployeeObj.emp_status = "a";
            }
            int res = db.SaveChanges();
            return res > 0 ? true : false;
        }

        public bool delUser(int ID)
        {
            var EmployeeObj = db.BO_Employee.Where(x => x.emp_id == ID).FirstOrDefault<BO_Employee>();
            EmployeeObj.emp_status = "d";

            int res = db.SaveChanges();
            return res > 0 ? true : false;
        }



        public bool check_count(BO_Employee value)
        {
            var res = db.BO_Employee.Count(u => u.emp_username.Equals(value.emp_username));
            return res == 0 ? true : false;
        }
    }
}
