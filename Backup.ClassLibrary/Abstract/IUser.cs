using Backup.ClassLibrary.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup.ClassLibrary.Abstract
{
    public interface IUser
    {
        IEnumerable<vBackOfficeUser> getUserAll { get; } 

    }
}
