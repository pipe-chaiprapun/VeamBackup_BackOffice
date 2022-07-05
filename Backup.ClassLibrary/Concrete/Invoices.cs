using Backup.ClassLibrary.Abstract;
using Backup.ClassLibrary.Concrete.VeeamCloudConnect;
using Backup.ClassLibrary.Entity;
using Backup.ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Backup.ClassLibrary.Concrete
{
    public class Invoices : Iinvoices
    {
        private BackOfficeDB db = new BackOfficeDB();
        //public IEnumerable<getInvoicesDetail> getInvoiceDetail(string invoice_no, int cust_id, int packageId)
        //{    
        //    

        //    return db.Database.SqlQuery<getInvoicesDetail>("EXEC [backup].[s_getInvoicesDetailBO] @invoice_no, @cust_id",
        //        new SqlParameter("@cust_id", cust_id),
        //        new SqlParameter("@invoice_no", invoice_no)).Where(e => e.pck_id.Equals(packageId));
        //}

        public IEnumerable<vBOviewInvoiceTab> getInvoiceDetail(string invoice_no, int cust_id, int vcc_id)
        {
            var qry = db.vBOviewInvoiceTab.Where(inv => inv.invoice_no.Equals(invoice_no) && inv.cust_id.Equals(cust_id) && inv.vcc_id.Equals(vcc_id)).OrderByDescending(o => o.add_dt);
            
            return qry;
        }

        public IEnumerable<v_BOinvoice> loadInvoiceAllBills
        {
            get { return db.v_BOinvoice.OrderByDescending(e => e.invoice_no); }
        }

        public string SuspendInvoice(m_suspend inv)
        {
            VeeamCC vm = new VeeamCC();
            Boolean aa = vm.DisableEnableTenant(inv.tenant_id.ToString(), inv.tenant_username, false);
            

            if (aa)
            {
                var affect = db.Database.ExecuteSqlCommand("EXEC [backup].[s_SuspendPackageInvoice] @InvoiceId, @PackageId",
               new SqlParameter("@InvoiceId", inv.InvoiceId), new SqlParameter("@PackageId", inv.PackageId));
                return affect > 0 ? "success" : "failed";
            }
            return "failed";
        }

        public string UnSuspendInvoice(m_suspend inv)
        {
            VeeamCC vm = new VeeamCC();
            Boolean aa = vm.DisableEnableTenant(inv.tenant_id.ToString(), inv.tenant_username, true);
            if (aa)
            {
                var affect = db.Database.ExecuteSqlCommand("EXEC [backup].[s_UnSuspendPackageInvoice] @InvoiceId, @PackageId",
               new SqlParameter("@InvoiceId", inv.InvoiceId), new SqlParameter("@PackageId", inv.PackageId));
                return affect > 0 ? "success" : "failed";
            }
            return "failed";
        }

        public string EditInvoiceStatus(string invoice_no, string status_i, int user_type)
        {
            if (user_type == 2)
            {
                int res = db.Database.ExecuteSqlCommand("update [backup].Reseller_sales set invo_status = @status where invoice_no = @invo_no",
                     new SqlParameter("@invo_no", invoice_no),
                     new SqlParameter("@status", status_i)
                 );
                return res > 0 ? "Success" : "failed";
            }
            else
            {
                int res = db.Database.ExecuteSqlCommand("update [backup].Cart set status = @status where invoice_no = @invo_no",
                    new SqlParameter("@invo_no", invoice_no),
                    new SqlParameter("@status", status_i)
                );
                return res > 0 ? "Success" : "failed";
            }
        }

    }
}

