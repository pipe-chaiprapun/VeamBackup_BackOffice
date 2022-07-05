using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backup.ClassLibrary.Entity;
using Backup.ClassLibrary.Models;
namespace Backup.ClassLibrary.Abstract
{
    public interface IResallerInvoice
    {
        IEnumerable<v_Reseller_Invoices_BO> getInfoInvoResaller();
        IEnumerable<v_Reseller_Invoices_View_BO> getInfoInvoResallerById(int id);
        bool SuspendPackageResaller(int pck_id);

    }
}
