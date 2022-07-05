using Backup.ClassLibrary.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backup.ClassLibrary.Entity;
using System.Data.SqlClient;
using Backup.ClassLibrary.Models;

namespace Backup.ClassLibrary.Concrete
{
    public class Refund : IRefund
    {

        private BackOfficeDB db = new BackOfficeDB();
        public IEnumerable<BackOfficePaypalRefund> getAllPaypalRefund => db.Database.SqlQuery<BackOfficePaypalRefund>("SELECT * from [backup].[BackOfficePaypalRefund]");



        public IEnumerable<m_getRefund> Refund_byId(int ID)
        {
            var s = db.Database.SqlQuery<m_getRefund>("select * from [backup].[vBackOfficeGetPaypal]AS v WHERE v.pck_id=@pck_id",
            new SqlParameter("@pck_id", ID));
            return s;
        }

        public bool UpdateRefund(int ID)
        {
            //var Refun = db.Report_Refund.FirstOrDefault(x => x.vcc_id == ID);
            //Refun.refund_status = "successful";

            //int res = db.SaveChanges();

            var qry = db.Database.ExecuteSqlCommand("UPDATE [backup].[Report_Refund] SET refund_status = 'successful' WHERE vcc_id = @id", new SqlParameter("@id", ID));
            return qry > 0 ? true : false;
        }

        public bool UpdateRefundFell(int ID)
        {
            //var Refun = db.Report_Refund.FirstOrDefault(x => x.vcc_id == ID);
            //Refun.refund_status = "unsuccessful";
            var qry = db.Database.ExecuteSqlCommand("UPDATE [backup].[Report_Refund] SET refund_status = 'unsuccessful' WHERE vcc_id = @id", new SqlParameter("@id", ID));
            //int res = db.SaveChanges();
            return qry > 0 ? true : false;
        }


        public bool DeleteRefundFell(int ID)
        {
            //var Refun = db.Report_Refund.FirstOrDefault(x => x.vcc_id == ID);
            //Refun.refund_status = "Delete";
            //int res = db.SaveChanges();
            var qry = db.Database.ExecuteSqlCommand("UPDATE [backup].[Report_Refund] SET refund_status = 'Delete' WHERE vcc_id = @id", new SqlParameter("@id", ID));
            return qry > 0 ? true : false;
        }


        public bool DeleteRefundtable(int ID)
        {
            //var Refun = db.Report_Refund.FirstOrDefault(x => x.vcc_id == ID);
            //Refun.refund_status = "Delete";
            //int res = db.SaveChanges();
            var qry = db.Database.ExecuteSqlCommand("UPDATE [backup].[Packages] SET pck_status = 'st' WHERE pck_id = @pck_id", new SqlParameter("@pck_id", ID));
            return qry > 0 ? true : false;
        }
        public bool RefundRefundComment(BO_Refund_Comment value)
        {
            var qry = db.Database.ExecuteSqlCommand("UPDATE [backup].[Report_Refund] SET operator_comment = '"+value.operator_comment+"' WHERE vcc_id = @id", new SqlParameter("@id", value.vcc_id));
            return qry > 0 ? true : false;
        }

        public IEnumerable<Packages2> ckackRefund(int ID)
        {
            var s = db.Database.SqlQuery<Packages2>("select * from [backup].[Packages] WHERE pck_id_ref = @pck_id AND pck_status = 'pa'",
            new SqlParameter("@pck_id", ID));
            return s;


        }
    }

}
