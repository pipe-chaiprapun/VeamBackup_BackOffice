using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backup.ClassLibrary.Abstract;
using Backup.ClassLibrary.Entity;
using System.Data.SqlClient;
using Backup.ClassLibrary.Models;

namespace Backup.ClassLibrary.Concrete
{
    public class Request : IRequest
    {
        private BackOfficeDB db = new BackOfficeDB();
    #region old code requst and updrage package 9/11/2017
        public IEnumerable<vBackOfficeRequest> getAllRequest()
        {
            return db.vBackOfficeRequest.SqlQuery("select * from [backup].[vBackOfficeRequest]");
        }

        public vBackOfficeRequest getNewVmAndStor(int id)
        {
           //var db.vBackOfficeRequest.FirstOrDefault(x => x.pck_id == id);
            return db.vBackOfficeRequest.FirstOrDefault(x => x.pck_id == id);
        }

        public string RemoveReuest(int id)
        {
                var remove = db.Packages2.FirstOrDefault(x => x.pck_id == id);
                remove.pck_status = "rm";
                int res = db.SaveChanges();
                if (res > 0)
                {
                    return "remove success";
                }
                return "failed remove";
        }

        public string upgradePackage(int id)
        {
            throw new NotImplementedException();
        }
        public bool SendMailRequest(string ToMail, string Subject, string Body) {
           var res = SendMail.Mail(ToMail, Subject, Body);
            return res;
        }

        public bool UpdatePackage(int id, int vm, uint storage)
        {
            UpgradePackage veeam = new UpgradePackage();
            var changePackage_status = db.Packages2.FirstOrDefault(x => x.pck_id == id);
            changePackage_status.pck_status = "et";
            int res = db.SaveChanges();
            if (res > 0)
            {
                var changeCart_status = db.Cart.FirstOrDefault(c => c.cart_id == changePackage_status.cart_id);
                changeCart_status.status = "et";
                int _res = db.SaveChanges();
                if (_res > 0)
                {
                    var findVcc_id = db.Veeam_Tenant.FirstOrDefault(v => v.pck_id == changePackage_status.pck_id_ref);
                    var Tenant = veeam.getCloudTenantsByUID(findVcc_id.tenant_id.ToString());
                    Tenant.Resources.CloudTenantResource.RepositoryQuota.Quota = Tenant.Resources.CloudTenantResource.RepositoryQuota.Quota + (storage * 1024);
                    var xmlScript = veeam.ConvertObjectToXmlString(Tenant);
                    var s = veeam.putEditTenant(findVcc_id.tenant_id.ToString(), xmlScript);
                    return true;
                }
            }
            return false;
        } 
        public bool UpdatePackageRep(int id, int storage, int processor, int memory, int networks)
        {
            UpgradePackage veeam = new UpgradePackage();
            var changePackage_status = db.Packages2.FirstOrDefault(x => x.pck_id == id);
            var connection = veeam.ConnectVCC_API();
            changePackage_status.pck_status = "et";
            int res = db.SaveChanges();
            if (res > 0)
            {
                var changeCart_status = db.Cart.FirstOrDefault(c => c.cart_id == changePackage_status.cart_id);
                changeCart_status.status = "et";
                int _res = db.SaveChanges();
                if (_res > 0)
                {
                    var findVcc_id = db.Veeam_Tenant.FirstOrDefault(v => v.pck_id == changePackage_status.pck_id_ref);
                    var HWUID = veeam.Get_UIDbyHardwareName(connection, findVcc_id.vcc_id.ToString());
                    if (HWUID != null)
                    {
                        var hw = veeam.Get_HardwarePlanByID(connection, HWUID.Replace("urn:veeam:CloudHardwarePlan:", ""));
                        System.Threading.Thread.Sleep(4000);
                        hw.ProcessorUsageLimitMhz += (ushort)(processor * 1024);
                        hw.MemoryUsageLimitMb += (ushort)(memory * 1024);
                        hw.HardwarePlanDetails.ViCloudHardwarePlan.Datastores.Datastore.QuotaGb += (ushort)storage;
                        hw.HardwarePlanDetails.ViCloudHardwarePlan.Network.CountWithoutInternet += (byte)networks;
                        var stringContent = veeam.Cv_CloudHardwarePlanToXmlStr(hw);
                        var editResponse = veeam.Put_EditHardwarePlan(connection, stringContent, HWUID.Replace("urn:veeam:CloudHardwarePlan:", ""));
                        return true;
                    }
                }
            }
            return false;
        }

        IEnumerable<m_Invoices_veeam_backup> IRequest.GenerateInvoice(int pck_id, int stor_vb, int vm_vb, bool premiums_storage)
        {
            var res = db.Database.SqlQuery<m_Invoices_veeam_backup>("EXEC [backup].[s_bo_generate_invoice] @pck_id, @vm, @storage, @premiums_storage",
                new SqlParameter("@pck_id", pck_id),
                new SqlParameter("@vm", vm_vb),
                new SqlParameter("@storage", stor_vb),
                new SqlParameter("@premiums_storage", premiums_storage)
    );
            return res;
        }

        IEnumerable<m_Invoices_veeam_backup> IRequest.GenerateInvoice_email(int pck_id, int stor_vb, int vm_vb, bool premiums_storage)
        {
            var res = db.Database.SqlQuery<m_Invoices_veeam_backup>("EXEC [backup].[s_bo_generate_invoice_sendEmail] @pck_id, @vm, @storage, @premiums_storage",
                 new SqlParameter("@pck_id", pck_id),
                 new SqlParameter("@vm", vm_vb),
                 new SqlParameter("@storage", stor_vb),
                 new SqlParameter("@premiums_storage", premiums_storage)
             );
            return res;
        }

        public IEnumerable<vBackOfficeUPgrade> getAllRequestUp()
        {
            return db.vBackOfficeUPgrade.SqlQuery("select * from [backup].[vBackOfficeUPgrade]");
        }

        public IEnumerable<m_Invoices_veeam_replication> CalVeeamR(int pck_id,int vm, int storage, int processor, int ram, int ip_address, int networks, int traffic, bool premiums_storage)
        {
            var res = db.Database.SqlQuery<m_Invoices_veeam_replication>("EXEC [backup].[s_bo_generate_invoice_vr] @pck_id,@vm, @storage,@processor,@ram,@ip_address,@networks,@traffic,@premiums_storage",
                 new SqlParameter("@pck_id", pck_id),
                 new SqlParameter("@vm", vm),
                 new SqlParameter("@storage", storage),
                 new SqlParameter("@processor", processor),
                 new SqlParameter("@ram", ram),
                 new SqlParameter("@ip_address", ip_address),
                 new SqlParameter("@networks", networks),
                 new SqlParameter("@traffic", traffic),
                 new SqlParameter("@premiums_storage", premiums_storage)
             );
            return res;
        }
        public IEnumerable<m_Invoices_veeam_replication> saveInDBForVR(int pck_id, int vm, int storage, int processor, int ram, int ip_address, int networks, int traffic, bool premiums_storage)
        {
            var res = db.Database.SqlQuery<m_Invoices_veeam_replication>("EXEC [backup].[s_bo_generate_invoice_vr_sendEmail] @pck_id,@vm, @storage,@processor,@ram,@ip_address,@networks,@traffic,@premiums_storage",
                 new SqlParameter("@pck_id", pck_id),
                 new SqlParameter("@vm", vm),
                 new SqlParameter("@storage", storage),
                 new SqlParameter("@processor", processor),
                 new SqlParameter("@ram", ram),
                 new SqlParameter("@ip_address", ip_address),
                 new SqlParameter("@networks", networks),
                 new SqlParameter("@traffic", traffic),
                 new SqlParameter("@premiums_storage", premiums_storage)
             );
            return res;
        }


        public IEnumerable<Package_VeeamReplication> GetPackage_VeeamReplication(int pck_id)
        {
            var res = db.Package_VeeamReplication.Where(x => x.pck_id == pck_id).ToList();
            return res;
        }

        public IEnumerable<Package_VeeamBackup> GetPackage_VeeamBackup(int pck_id)
        {
            return db.Package_VeeamBackup.Where(x => x.pck_id == pck_id);
        }

        public bool DeletePackageInPackageTapVB(int pck_id)
        {
            UpgradePackage veeam = new UpgradePackage();
            var connection = veeam.ConnectVCC_API();
            var find_UID = db.Veeam_Tenant.FirstOrDefault(x => x.pck_id == pck_id);
            var deleteintenat = veeam.Delete_Tenant(connection, find_UID.tenant_id + "");
            System.Threading.Thread.Sleep(4000);
            var check_delete_tenat = veeam.getCloudTenantsByUID(find_UID.tenant_id + "");
            if (check_delete_tenat.ComputeResources == null){
                var findPack = db.Packages2.FirstOrDefault(x => x.pck_id == pck_id);
                findPack.pck_status = "rm";
                int res = db.SaveChanges();
                if (res > 0)return true;
            }
            return false;
        }

        public bool DeletePackageInPackageTapVR(int pck_id)
        {
            UpgradePackage veeam = new UpgradePackage();
            var connection = veeam.ConnectVCC_API();
            var find_UID = db.Veeam_Tenant.FirstOrDefault(x => x.pck_id == pck_id);
            var deleteintenat = veeam.Delete_Tenant(connection, find_UID.tenant_id + "");
            System.Threading.Thread.Sleep(4000);
            var check_delete_tenat = veeam.getCloudTenantsByUID(find_UID.tenant_id + "");
            if (check_delete_tenat.ComputeResources == null) {
                var findPack = db.Packages2.FirstOrDefault(x => x.pck_id == pck_id);
                findPack.pck_status = "rm";
                int res = db.SaveChanges();
                if (res > 0)return true;
            }
            return false;
        }

        public bool UpgradePackage_Normal_VB(int cust_id, int vcc_id, int vm, int storage, bool premiums_storage)
        {
            db.Database.ExecuteSqlCommand("EXEC [backup].[s_Cart_AddUpgradeBackupPck] @cust_id, @vm, @storage, @service_id, @premiums_storage",
                new SqlParameter("@cust_id", cust_id),
                new SqlParameter("@vm", vm),
                new SqlParameter("@storage", storage),
                new SqlParameter("@service_id", vcc_id),
                new SqlParameter("@premiums_storage", premiums_storage)
             );
            return true;
        }

        public bool UpgradePackage_Normal_VR(int cust_id, int vcc_id, int vm, int storage, int processor, int ram, int ip_address, int networks, int traffic, bool premiums_storage)
        {
            db.Database.ExecuteSqlCommand("EXEC [backup].[s_Cart_AddUpgradeRepPck] @cust_id, @service_id, @vm, @storage, @processor, @ram, @ip_address, @networks, @internet_traffic",
              new SqlParameter("@cust_id", cust_id),
              new SqlParameter("@service_id", vcc_id),
              new SqlParameter("@vm", vm),
              new SqlParameter("@storage", storage),
              new SqlParameter("@processor", processor),
              new SqlParameter("@ram", ram),
              new SqlParameter("@ip_address", ip_address),
              new SqlParameter("@networks", networks),
              new SqlParameter("@internet_traffic", traffic)
              );
            return true;
        }

        ///----------------------
        public bool StorageCal(int value)
        {
            int result = value % 500;
            if (result == 0 && value >= 500 && value <= 15000)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string getLastStatusPck(int service_id)
        {
            return db.Database.SqlQuery<string>("EXEC [backup].[s_Cart_getLastStatusPck] @service_id",
                            new SqlParameter("@service_id", service_id)).Single();

        }

        public getVmStorage_pck_id GetSumVmStorage(int pck_id)
        {
            return db.Database.SqlQuery<getVmStorage_pck_id>("SELECT * FROM [backup].[f_SumBackupPck_PckID] (@pck_id)",
               new SqlParameter("@pck_id", pck_id)).FirstOrDefault();
        }

        public getVmStorage GetSumVmStorageServiceID(int service_id)
        {
            return db.Database.SqlQuery<getVmStorage>("SELECT * FROM [backup].[f_SumBackupPck_ServiceID] (@service_id)",
                new SqlParameter("@service_id", service_id)).FirstOrDefault();
        }

        public IEnumerable<m_Invoices_veeam_replication> GenerateInvoice_emailVR(int pck_id, int vm, int storage, int processor, int ram, int ip_address, int networks, int traffic, bool premiums_storage)
        {
            var res = db.Database.SqlQuery<m_Invoices_veeam_replication>("EXEC [backup].[s_bo_generate_invoice_vr_sendEmail] @pck_id,@vm, @storage,@processor,@ram,@ip_address,@networks,@traffic,@premiums_storage",
           new SqlParameter("@pck_id", pck_id),
           new SqlParameter("@vm", vm),
           new SqlParameter("@storage", storage),
           new SqlParameter("@processor", processor),
           new SqlParameter("@ram", ram),
           new SqlParameter("@ip_address", ip_address),
           new SqlParameter("@networks", networks),
           new SqlParameter("@traffic", traffic),
           new SqlParameter("@premiums_storage", premiums_storage)
       );
            return res;
        }
#endregion
    
    }
}
