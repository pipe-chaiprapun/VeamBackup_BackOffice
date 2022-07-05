using Backup.ClassLibrary.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup.ClassLibrary.Abstract
{
    public interface IAddUser
    {
        bool addUser(BO_Employee value);
        bool putUser(BO_Employee value);
        bool delUser(int ID);
        bool blockUser(int ID);

        bool check_count(BO_Employee value);


    }
}
