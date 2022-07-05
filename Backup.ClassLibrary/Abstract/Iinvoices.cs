using Backup.ClassLibrary.Entity;
using Backup.ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup.ClassLibrary.Abstract
{
    public interface Iinvoices
    {
        //IEnumerable<getInvoicesDetail> getInvoiceDetail(string invoice_no, int cust_id, int packageId);
        IEnumerable<vBOviewInvoiceTab> getInvoiceDetail(string invoice_no, int cust_id, int packageId);
        IEnumerable<v_BOinvoice> loadInvoiceAllBills { get; }
        string SuspendInvoice(m_suspend inv);
        string UnSuspendInvoice(m_suspend inv);
        string EditInvoiceStatus(string invoice_no, string status_i, int user_type);        
    }
}
