using Backup.ClassLibrary.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backup.ClassLibrary.Entity;
using Backup.ClassLibrary.Models;
using System.Data.SqlClient;


namespace Backup.ClassLibrary.Concrete
{
    public class Payments : IPayments
    {
        private BackOfficeDB db = new BackOfficeDB();

        public IEnumerable<vBackOfficePayments> getAllPaymentsTx => db.Database.SqlQuery<vBackOfficePayments>("SELECT * from [backup].[vBackOfficePayments]");

        public IEnumerable<vBOInvoiceDetails> getInvoiceDetail(m_payments_inv value)
        {
            return db.Database.SqlQuery<vBOInvoiceDetails>("SELECT * from [backup].[vBOInvoiceDetails] AS v WHERE v.payment_id=@payment_id AND v.username=@username AND v.invoice_no=@invoice_no",
            new SqlParameter("@payment_id", value.Payment_Id),
            new SqlParameter("@username", value.username),
             new SqlParameter("@invoice_no", value.invoice_no)).ToList();
        }



        public IEnumerable<vPaymentDetails> getReportsDetail(string txn_id)
        {
            if (string.IsNullOrEmpty(txn_id)) return null;

            return db.Database.SqlQuery<vPaymentDetails>("SELECT * from [backup].[vPaymentDetails] AS v WHERE v.payment_id=@txn_id",
            new SqlParameter("@txn_id", txn_id));
        }

        public IEnumerable<v_Repository> getAllRepository => db.Database.SqlQuery<v_Repository>("SELECT * from [backup].[v_Repository]").ToList();


    }
}
