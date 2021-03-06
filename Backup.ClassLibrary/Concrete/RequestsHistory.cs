using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backup.ClassLibrary.Abstract;
using Backup.ClassLibrary.Entity;
using System.Data.SqlClient;
using System.Globalization;

namespace Backup.ClassLibrary.Concrete
{
    public class RequestsHistory : IRequestsHistory
    {
        BackOfficeDB db = new BackOfficeDB();



        public IEnumerable<VBackOfficeRequestsHistory> getAllRequestsHistory => db.VBackOfficeRequestsHistories.SqlQuery("select * from [backup].[VBackOfficeRequestsHistory]"); 
        

        public string RemoveReuestHistory(int id)
        {

            var remove = db.Packages2.FirstOrDefault(r => r.pck_id == id);
            if (remove != null)
            {
                remove.pck_status = "rm";
                int res = db.SaveChanges();
                if (res > 0)
                {
                    return "remove success";
                }
                return "failed remove";
            }
            return "remove success";

        }
    }
}
