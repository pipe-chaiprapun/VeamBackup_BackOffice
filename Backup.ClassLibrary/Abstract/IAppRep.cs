using Backup.ClassLibrary.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup.ClassLibrary.Abstract
{
    public interface IAppRep
    {
        void Sava_LogSignIn(Log_SignIn logObj, bool signined = false);

        Guid sendToken(int cust_id, string email);

        void save_logSignIn(BO_Log_Signin logObj, bool signined = false);
        bool save_logaction(string description, string desc_of_entry, string ip_address, int cust_id);

        string get_username(int cust_id);
        int get_custID(string username);

        Address fyByIdCustId(int cust_id);

        BO_Employee fyByIdEmpId(int emp_id);
    }
}
