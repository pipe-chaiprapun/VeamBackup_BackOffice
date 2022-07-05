using Backup.ClassLibrary.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backup.ClassLibrary.Entity;

namespace Backup.ClassLibrary.Concrete
{
    public class User : IUser
    {
        private BackOfficeDB db = new BackOfficeDB();

        
        public IEnumerable<vBackOfficeUser> getUserAll
        {
            
            get { return db.vBackOfficeUser; }
        }
    }
}
