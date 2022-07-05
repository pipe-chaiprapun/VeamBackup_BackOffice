using Backup.ClassLibrary.Entity;
using Backup.ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup.ClassLibrary.Abstract
{
    public interface IRefund
    {
        IEnumerable<BackOfficePaypalRefund> getAllPaypalRefund { get; }

        IEnumerable<m_getRefund> Refund_byId(int ID);

        IEnumerable<Packages2> ckackRefund(int ID);
        bool UpdateRefund(int ID);

        bool UpdateRefundFell(int ID);

        bool DeleteRefundFell(int ID);

        bool DeleteRefundtable(int ID);

        bool RefundRefundComment(BO_Refund_Comment value);
    }
}
