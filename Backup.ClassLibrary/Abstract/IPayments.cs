using Backup.ClassLibrary.Entity;
using Backup.ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup.ClassLibrary.Abstract
{
    public interface IPayments
    {
        IEnumerable<vBackOfficePayments> getAllPaymentsTx { get; }


        IEnumerable<vBOInvoiceDetails> getInvoiceDetail(m_payments_inv value);

        IEnumerable<vPaymentDetails> getReportsDetail(string txn_id);

        IEnumerable<v_Repository> getAllRepository { get; }

    }
}
