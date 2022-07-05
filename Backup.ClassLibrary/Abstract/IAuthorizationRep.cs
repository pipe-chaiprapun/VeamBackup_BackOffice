using Backup.ClassLibrary.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup.ClassLibrary.Abstract
{
    public interface IAuthorizationRep
    {
        IEnumerable<BO_Employee> employees { get; }
        IEnumerable<BO_Position> position { get; }

        int get_custID(string username);

        int check_Count(string username);

        BO_Employee valid_Password(string username, string password);

        BO_Employee ValidPIN(int user_id, string PIN);

        int countSignin(int cust_id);

        bool check_active(int cust_id);

        bool check_login(string username);

        /// <summary>
        /// Check Email of Customer
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        int check_Email(string email);
        int SignUp(int customer_type, string email, string password, Address address);

    }
}
