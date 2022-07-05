using Backup.ClassLibrary.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backup.ClassLibrary.Entity;
using Backup.ClassLibrary.Models;
using System.Data.SqlClient;
using Backup.ClassLibrary.Concrete.Security;

namespace Backup.ClassLibrary.Concrete
{
    public class Authorization : IAuthorizationRep
    {
        private BackOfficeDB db = new BackOfficeDB();

        public IEnumerable<BO_Employee> employees { get { return db.BO_Employee; } }

        public IEnumerable<BO_Position> position { get { return db.BO_Position; } }

        //public bool Create_user(string username, string password, string fristname, string lastname, string role, byte position, string PIN)
        //{
        //    var hash_pass = Security.App_Hash.PasswordHash(password);
        //    var hash_pin = Security.App_Hash.PasswordHash(PIN);
        //    var qry = new BO_Employee
        //    {
        //        emp_username = username,
        //        emp_password = hash_pass,
        //        emp_pin = hash_pin,
        //        emp_fristname = fristname,
        //        emp_lastname = lastname,
        //        emp_permission = role,
        //        emp_position = position
        //    };
        //    db.BO_Employee.Add(qry);
        //    var res = db.SaveChanges();
        //    return res > 0 ? true : false;

        //}

        public int get_custID(string username)
        {
            var qry = employees.Where(u => u.emp_username == username).FirstOrDefault().emp_id;
            return qry;
        }

        public int check_Count(string username)
        {
            var qry = employees.Count(u => u.emp_username == username);
            return qry;
        }

        public BO_Employee valid_Password(string username, string password)
        {
            var qry = employees.Where(u => u.emp_username == username).FirstOrDefault();
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

        public BO_Employee ValidPIN(int user_id, string PIN)
        {
            var qry = employees.Where(u => u.emp_id == user_id).FirstOrDefault();
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

        public int countSignin(int cust_id)
        {
            var s = db.Database.SqlQuery<getCountSignin>("EXEC [backup].[s_backoffice_CountSignIn] @cust_id",
                new SqlParameter("@cust_id", cust_id)).Single();
            return s.countSignin;
        }

        public bool check_active(int cust_id)
        {
            var qry = db.BO_Employee.FirstOrDefault(c => c.emp_id == cust_id);
            return qry.emp_status == "a" ? true : false;
        }

        public bool check_login(string username)
        {           

            int cust_id = db.BO_Employee.FirstOrDefault(u => u.emp_username.Equals(username)).emp_id;

            int count = db.UserOnline.Count(c => c.cust_id == cust_id);

            if (count >= 1)
            {
                bool status = db.UserOnline.FirstOrDefault(c => c.cust_id == cust_id).online_status;

                if (status == true)
                {
                    return false;
                }

                return true;
            }            

            return true;
        }

        public int check_Email(string email)
        {
            var res = db.Customer.Count(e => e.email == email);
            return res;
        }

        public int SignUp(int customer_type, string email, string password, Address address)
        {
            var h_password = Security.App_Hash.PasswordHash(password);

            if (address.phone_num.Length > 11)
            {
                string phone_number = "0" + address.phone_num.Substring(3, 9);

                var res = db.Database.SqlQuery<int>("EXEC [backup].[s_authen_signup] @email, @password, @company_name, @firstname, @lastname, @phone_num, @address, @country, @city, @province, @post_code, @cust_type_id",
                new SqlParameter("@email", email),
                new SqlParameter("@password", h_password),
                new SqlParameter("@company_name", address.company_name),
                new SqlParameter("@firstname", address.firstname),
                new SqlParameter("@lastname", address.lastname),
                new SqlParameter("@phone_num", phone_number),
                new SqlParameter("@address", address.address),
                new SqlParameter("@country", address.country),
                new SqlParameter("@city", address.city),
                new SqlParameter("@province", address.province),
                new SqlParameter("@post_code", address.post_code),
                new SqlParameter("@cust_type_id", customer_type)).Single();

                return res;
            }
            else
            {
                string phone_number = address.phone_num;

                var res = db.Database.SqlQuery<int>("EXEC [backup].[s_authen_signup] @email, @password, @company_name, @firstname, @lastname, @phone_num, @address, @country, @city, @province, @post_code, @cust_type_id",
                new SqlParameter("@email", email),
                new SqlParameter("@password", h_password),
                new SqlParameter("@company_name", address.company_name),
                new SqlParameter("@firstname", address.firstname),
                new SqlParameter("@lastname", address.lastname),
                new SqlParameter("@phone_num", phone_number),
                new SqlParameter("@address", address.address),
                new SqlParameter("@country", address.country),
                new SqlParameter("@city", address.city),
                new SqlParameter("@province", address.province),
                new SqlParameter("@post_code", address.post_code),
                new SqlParameter("@cust_type_id", customer_type)).Single();

                return res;
            }

        }
    }
}
