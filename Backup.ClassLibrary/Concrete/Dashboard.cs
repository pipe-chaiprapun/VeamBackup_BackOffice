using Backup.ClassLibrary.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backup.ClassLibrary.Models;
using System.Data.SqlClient;

namespace Backup.ClassLibrary.Concrete
{
    public class Dashboard : IDashboard
    {
        private BackOfficeDB db = new BackOfficeDB();

        public IEnumerable<m_Dashboard> qry_Dashboard_from(string from, string to)
        {
            var res = db.Database.SqlQuery<m_Dashboard>("EXEC [backup].[s_Dashboard] @quick, @from, @to",
                        new SqlParameter("@quick", ""),      
                        new SqlParameter("@from", from + " " + "00:00:00"),
                        new SqlParameter("@to", to + " " + "23:59:59")).ToList();
            return res;
        }

        public IEnumerable<m_Dashboard> qry_Dashboard_quick(string value)
        {
            var res = db.Database.SqlQuery<m_Dashboard>("EXEC [backup].[s_Dashboard] @quick",
                      new SqlParameter("@quick", value)).ToList();
            return res;
        }
    }
}
