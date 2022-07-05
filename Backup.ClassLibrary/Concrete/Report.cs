using Backup.ClassLibrary.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backup.ClassLibrary.Entity;
using System.Data.SqlClient;



namespace Backup.ClassLibrary.Concrete
{
    public class Report : IReport
    {
        private BackOfficeDB db = new BackOfficeDB();



        public int getTenantType(string tName)
        {
          /*  return db.Database.SqlQuery<int>(@"select pck.pck_type_id from [backup].[Veeam_Tenant] as vt join
                                          [backup].[Packages] as pck on pck.pck_id = vt.pck_id
                                          where vt.username = @username",
                                          new SqlParameter("@username", tName)).FirstOrDefault();*/

            int type_id = (from vt in db.Veeam_Tenant
                           join pck in db.Packages2
                            on vt.pck_id equals pck.pck_id
                           where vt.username == tName
                           select pck.pck_type_id).FirstOrDefault();
            return type_id;
        }
    }
}
