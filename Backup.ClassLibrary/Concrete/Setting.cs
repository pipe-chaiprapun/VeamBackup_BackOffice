using Backup.ClassLibrary.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backup.ClassLibrary.Entity;

namespace Backup.ClassLibrary.Concrete
{
    public class Setting : ISetting
    {
        private BackOfficeDB db = new BackOfficeDB();

        public bool change_Password(string username, string new_password)
        {
            string h_password = Security.App_Hash.PasswordHash(new_password);
            var qry = db.BO_Employee.FirstOrDefault(u => u.emp_username == username);
            qry.emp_password = h_password;

            var res = db.SaveChanges();
            return res > 0 ? true : false;
        }

        public bool Change_PIN(int cust_id, string new_pin)
        {
            var h_pin = Security.App_Hash.PasswordHash(new_pin);
            var qry = db.BO_Employee.FirstOrDefault(u => u.emp_id == cust_id);
            qry.emp_pin = h_pin;

            var res = db.SaveChanges();
            return res > 0 ? true : false;
        }

        public BO_Employee valid_Password(string username, string password)
        {
            var qry = db.BO_Employee.FirstOrDefault(u => u.emp_username == username);
            if (qry == null) { return null; }

            if (Security.App_Hash.PasswordValid(password, qry.emp_password))
            {
                return qry;
            }
            else
            {
                return null;
            }
        }
    
        public BO_Employee valid_PIN(string username, string PIN)
        {
            var qry = db.BO_Employee.FirstOrDefault(u => u.emp_username == username);
            if (qry == null) { return null; }

            if (Security.App_Hash.PasswordValid(PIN, qry.emp_pin))
            {
                return qry;
            }
            else
            {
                return null;
            }
        }
    }
}
