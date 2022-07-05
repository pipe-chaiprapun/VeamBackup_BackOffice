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
    public class LogAction : ILogAction
    {
        private BackOfficeDB db = new BackOfficeDB();
        public IEnumerable<vBackOfficeLogActions> getAllLogAction
        {
            get { return db.Database.SqlQuery<vBackOfficeLogActions>("SELECT * from [backup].[vBackOfficeLogActions]"); }
        }

    }
}