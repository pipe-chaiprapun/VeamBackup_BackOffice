using Backup.ClassLibrary.Abstract;
using Backup.ClassLibrary.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup.ClassLibrary.Concrete
{
    public class App : IAppRep
    {
        private BackOfficeDB db = new BackOfficeDB();

        public static string RandomNum(int length = 6)
        {
            var chars = "0123456789";
            var stringChars = new char[length];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new string(stringChars);
        }

        public void save_logSignIn(BO_Log_Signin logObj, bool signined = false)
        {
            logObj.signin = signined;
            db.BO_Log_Signin.Add(logObj);
            db.SaveChanges();
        }

        public bool save_logaction(string description, string desc_of_entry, string ip_address, int cust_id)
        {
            var logActions = new BO_LogActionsEmployee
            {
                description = description,
                desc_of_entry = desc_of_entry,
                ip_address = ip_address,
                emp_id = cust_id
            };

            db.BO_LogActionsEmployee.Add(logActions);
            int res = db.SaveChanges();
            return res > 0 ? true : false;
        }

        public string get_username(int cust_id)
        {
            var qry = db.BO_Employee.FirstOrDefault(c => c.emp_id == cust_id).emp_username;

            return qry;
        }

        public int get_custID(string username)
        {
            var qry = db.BO_Employee.FirstOrDefault(c => c.emp_username.Equals(username)).emp_id;

            return qry;
        }

        public Address fyByIdCustId(int cust_id)
        {
            var qry = db.Address.FirstOrDefault(c => c.cust_id == cust_id);

            return qry;
        }

        public BO_Employee fyByIdEmpId(int emp_id)
        {
            var qry = db.BO_Employee.FirstOrDefault(c => c.emp_id == emp_id);
            return qry;
        }

        public void Sava_LogSignIn(Log_SignIn logObj, bool signined = false)
        {
            logObj.signin = signined;
            db.Log_SignIn.Add(logObj);
            db.SaveChanges();
        }

        public Guid sendToken(int cust_id, string email)
        {
            var res = db.EmailAddress.ToList();
            var key = res.Where(c => c.cust_id == cust_id && c.email.Equals(email)).LastOrDefault();

            if (key != null)
            {
                return key.token;
            }

            return new Guid();
        }
    }
}
