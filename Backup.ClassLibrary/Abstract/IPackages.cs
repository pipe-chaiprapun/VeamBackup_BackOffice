using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backup.ClassLibrary.Entity;
using Backup.ClassLibrary.Models;
using static Backup.ClassLibrary.Concrete.Security.App_Securities;

namespace Backup.ClassLibrary.Abstract
{
    public interface IPackages
    {
        IEnumerable<v_PackageTap> getAllPackages { get; }
        IEnumerable<Package_Type> getAllTypePackages { get; }
        IEnumerable<v_PackageTap_viewReport> GetPackageByrefId(int id_ref);
        IEnumerable<Veeam_Tenant> GetPackageVeeam_Tenant(int id_pck);
        IEnumerable<vBOviewInvoiceTab> addCreditInvoiceBackup(m_create_inv_backup value);
        getTotalAmountPck PackageCalculator(int vm, int storage, bool preniums_storage, int pck_type = 11);
        IEnumerable<vBOviewInvoiceTab> addCreditInvoiceReplication(m_create_inv_replication value);
        getTotalAmountPck_rep PackageCalculatorReplication(PackageCalculator_rep req);
        Customer_Notification GetCustomer_Notification(int id);

        IEnumerable<Veeam_Tenant> Post_Veeam_Tenant_Block(BO_Packages_Block value);
        IEnumerable<Cart> Post_Cart_Block(BO_Packages_Block value);
        IEnumerable<Packages2> Post_Packages_Block(BO_Packages_Block value);
        IEnumerable<vBOviewInvoiceTab> addCreditInvoiceNakivoBackup(m_create_inv_backup value);

        //SecurityKeyPair BaddCreditInvoiceBackup(m_create_inv_backup value);
    }
}
