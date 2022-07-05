using Backup.ClassLibrary.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup.ClassLibrary.Abstract
{
   public interface ISetting
    {
        BO_Employee valid_Password(string username, string password);

        bool change_Password(string username, string new_password);

        BO_Employee valid_PIN(string username, string PIN);
        bool Change_PIN(int cust_id, string new_pin);
    }
}
