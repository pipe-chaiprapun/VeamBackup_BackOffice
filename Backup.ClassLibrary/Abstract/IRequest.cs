using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backup.ClassLibrary.Entity;
using Backup.ClassLibrary.Models;

namespace Backup.ClassLibrary.Abstract
{
    public interface IRequest
    {
        IEnumerable<vBackOfficeRequest> getAllRequest();
        IEnumerable<vBackOfficeUPgrade> getAllRequestUp();
        vBackOfficeRequest getNewVmAndStor(int id);

        string RemoveReuest(int id);
        IEnumerable<m_Invoices_veeam_backup> GenerateInvoice(int pck_id, int stor_vb, int vm_vb, bool premiums_storage);
        IEnumerable<m_Invoices_veeam_backup> GenerateInvoice_email(int pck_id, int stor_vb, int vm_vb, bool premiums_storage);
        IEnumerable<m_Invoices_veeam_replication> GenerateInvoice_emailVR(int pck_id, int vm, int storage, int processor, int ram, int ip_address, int networks, int traffic, bool premiums_storage);
        IEnumerable<m_Invoices_veeam_replication> CalVeeamR(int pck_id,int vm, int storage,int processor,int ram,int ip_address,int networks,int traffic, bool premiums_storage);
        IEnumerable<m_Invoices_veeam_replication> saveInDBForVR(int pck_id, int vm, int storage, int processor, int ram, int ip_address, int networks, int traffic, bool premiums_storage);
        IEnumerable<Package_VeeamReplication> GetPackage_VeeamReplication(int pck_id);
        IEnumerable<Package_VeeamBackup> GetPackage_VeeamBackup(int pck_id);
        string upgradePackage(int id);
        bool SendMailRequest(string ToMail, string Subject, string Body);
        bool UpdatePackage(int id,int vm, uint storage);
        bool UpdatePackageRep(int id, int storage, int processor, int memory, int networks);
        bool DeletePackageInPackageTapVB(int pck_id);
        bool DeletePackageInPackageTapVR(int pck_id);
        bool UpgradePackage_Normal_VB(int cust_id,int vcc_id,int vm ,int storage,bool premiums_storage);
        bool UpgradePackage_Normal_VR(int cust_id, int vcc_id, int vm, int storage, int processor, int ram, int ip_address, int networks, int traffic, bool premiums_storage);

        //------------
        bool StorageCal(int value);
        string getLastStatusPck(int service_id);
        getVmStorage_pck_id GetSumVmStorage(int pck_id);
        getVmStorage GetSumVmStorageServiceID(int service_id);
    }
}
