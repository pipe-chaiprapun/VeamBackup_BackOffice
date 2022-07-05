using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backup.ClassLibrary.Abstract;
using Backup.ClassLibrary.Entity;
using Backup.ClassLibrary.Concrete.VeeamCloudConnect;
using Backup.ClassLibrary.Models;
using System.Data.SqlClient;

namespace Backup.ClassLibrary.Concrete
{
    public class ResallerInvoice : IResallerInvoice
    {
        private BackOfficeDB DB = new BackOfficeDB();



        public IEnumerable<v_Reseller_Invoices_BO> getInfoInvoResaller()
        {
            return DB.v_Reseller_Invoices_BO;
        }

        public IEnumerable<v_Reseller_Invoices_View_BO> getInfoInvoResallerById(int id)
        {
            return DB.v_Reseller_Invoices_View_BO.Where(c => c.Invoice_ID == id).ToList();
        }

        public bool SuspendPackageResaller(int pck_id)
        {
            VeeamCC vm = new VeeamCC();
            var findVeeam_Tenant = DB.Veeam_Tenant.Where(c => c.pck_id == pck_id).FirstOrDefault();
            var findpck = DB.Packages2.Where(c => c.pck_id == pck_id).FirstOrDefault();
            var findSaller = DB.Reseller_sales.Where(c => c.pck_id == pck_id).FirstOrDefault();
            Boolean disableVeeam = vm.DisableEnableTenant(findVeeam_Tenant.tenant_id.ToString(), findVeeam_Tenant.username, false);
            if (disableVeeam) {
                findpck.pck_status = "ov";
                findSaller.invo_status = "up";
                int res = DB.SaveChanges();
                return res > 0 ? true : false;
            }
            return false;
        }


    }
}
