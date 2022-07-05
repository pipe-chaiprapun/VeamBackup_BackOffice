using Backup.ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backup.ClassLibrary.Entity;

namespace Backup.ClassLibrary.Abstract
{
    public interface IUpgradePackage
    {
        IEnumerable<getPackageFromCart> getUpgradeForPackage();
        //-----------------code in 9/11/2017 by paramat singkon--------------------
        #region interface calculate invoice non-save in database
        //enterprise and normal user
        v_Get_InvoviceById_package_backup TryGanerateInvoiceForVeeamBackUp(int pck_id, int vm, int stor,bool premiums_storage);
        v_Get_InvoviceById_package_replication TryGanerateInvoiceForVeeamReplication(int pck_id, int vm, int storage, int processor, int ram, int ip_address, int networks, int traffic, bool premiums_storage);
        //Resaller
        v_Get_InvoviceById_package_backup_resaller TryGanerateInvoiceForVeeamBackUpResaller(int pck_id, int vm, int stor, bool premiums_storage);
        v_Get_InvoviceById_package_replication_resaller TryGanerateInvoiceForVeeamReplicationResaller(int pck_id, int vm, int storage, int processor, int ram, int ip_address, int networks, int traffic, bool premiums_storage);

        #endregion

        #region interface calculate invoice save in database
        Packages2 SaveGanerateInvoiceForVeeamBackUp(int pck_id, int stor, int vm, bool premiums_storage);
        Packages2 SaveGanerateInvoiceForVeeamReplication(int pck_id, int vm, int storage, int processor, int ram, int ip_address, int networks, int traffic, bool premiums_storage);
        Packages2 SaveGanerateInvoiceForVeeamBackUpResaller(int pck_id, int stor, int vm, bool premiums_storage);
        Packages2 SaveGanerateInvoiceForVeeamReplicationResaller(int pck_id, int vm, int storage, int processor, int ram, int ip_address, int networks, int traffic, bool premiums_storage);
        #endregion

        #region interface request upgrade package for enterprise
        Packages2 RequestSaveGanerateInvoiceForVeeamBackUpEnterprise(int pck_id, int stor, int vm, bool premiums_storage);
        Packages2 RequestSaveGanerateInvoiceForVeeamReplicationEnterprise(int pck_id, int vm, int storage, int processor, int ram, int ip_address, int networks, int traffic, bool premiums_storage);
        #endregion

        #region interface upgrade package in veeam tenant
        bool UpdatePackageVeeamBackUp(int pck_id, int vm, uint storage);
        bool UpdatePackageVeeamReplition(int pck_id, int storage, int processor, int memory, int networks);
        #endregion

        #region interface request enterprise upgrade package in veeam tenant
        bool UpdatePackageVeeamBackUpEnterprise(int pck_id, int vm, uint storage);
        bool UpdatePackageVeeamReplicationEnterprise(int pck_id, int storage, int processor, int memory, int networks);
        #endregion

        #region interface upgrade package in prolong 
        Packages2 ProlongUpgradeForVeeamBackUpEnterprise(int pck_id, int stor, int vm, bool premiums_storage);
        Packages2 ProlongUpgradeForVeeamReplicationEnterprise(int pck_id, int vm, int storage, int processor, int ram, int ip_address, int networks, int traffic, bool premiums_storage);
        Packages2 ProlongUpgradeForVeeamBackUpResaller(int pck_id, int stor, int vm, bool premiums_storage);
        Packages2 ProlongUpgradeForVeeamReplicationResaller(int pck_id, int vm, int storage, int processor, int ram, int ip_address, int networks, int traffic, bool premiums_storage);
        #endregion

        #region interface get invoice by id package
        v_Get_InvoviceById_package_backup Get_Invoice_ById_PackageBackUp(int pck_id);
        v_Get_InvoviceById_package_replication Get_Invoice_ById_PackageReplication(int pck_id);
        v_Get_InvoviceById_package_backup_resaller Get_Invoice_ById_PackageBackUpResaller(int pck_id);
        v_Get_InvoviceById_package_replication_resaller Get_Invoice_ById_PackageReplicationResaller(int pck_id);
        v_Get_InvoviceById_package_backup_Nakivo Get_Invoice_ById_PackageBackUp_Nakivo(int pck_id);
        v_Get_InvoviceById_package_backup_Nakivo_resaller Get_Invoice_ById_PackageBackUpResaller_Nakivo(int pck_id);
        #endregion

        #region interface get invoice by id Invoice
        v_Get_InvoviceById_package_backup Get_Invoice_ById_InvoiceBackUp(int invoice_no);
        v_Get_InvoviceById_package_replication Get_Invoice_ById_InvoiceReplication(int invoice_no);
        v_Get_InvoviceById_package_backup_resaller Get_Invoice_ById_InvoiceBackUpResaller(int invoice_no);
        v_Get_InvoviceById_package_replication_resaller Get_Invoice_ById_InvoiceReplicationResaller(int invoice_no);
        v_Get_InvoviceById_package_backup_Nakivo Get_Invoice_ById_InvoiceBackUp_Nakivo(int invoice_no);
        v_Get_InvoviceById_package_backup_Nakivo_resaller Get_Invoice_ById_InvoiceBackUpResaller_Nakivo(int invoice_no);
        #endregion

        #region interface get veeam tenant by id package
        Veeam_Tenant Get_Veeam_Tenant_ById_PackageBackUp(int pck_id);
        #endregion

        #region interface request upgrede enter prise
       // Packages2 GenerateInvoiceAndChangeStatusVeeamBackup();
       // Packages2 GenerateInvoiceAndChangeStatusVeeamReplication();
        #endregion
    }
}
