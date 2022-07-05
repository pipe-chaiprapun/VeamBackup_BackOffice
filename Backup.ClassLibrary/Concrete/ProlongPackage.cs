using Backup.ClassLibrary.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backup.ClassLibrary.Models;
using Backup.ClassLibrary.Entity;
using System.Data.SqlClient;
using Backup.ClassLibrary.Concrete.VeeamCloudConnect;
using Backup.ClassLibrary.Concrete.Security;
using System.Data;
using System.Net.Http;

namespace Backup.ClassLibrary.Concrete
{
    public class ProlongPackage : IProlongPackage
    {
        private BackOfficeDB db = new BackOfficeDB();
        //Prolong Package VeeamBackup Enterprise
        public v_Get_InvoviceById_package_backup ProlongPackage_VeeamBackup(int cust_id, int vcc_id) 
        {
            try {
                //create package in table
                var Datareturn = db.Database.SqlQuery<Packages2>("[backup].[s_EnterpriseProlong_VeeamBackup_BO] @cust_id, @vcc_id",
                         new SqlParameter("@cust_id", cust_id),
                         new SqlParameter("@vcc_id", vcc_id)
                         ).FirstOrDefault();
                if (Datareturn != null)
                {
                    VeeamCC vm = new VeeamCC();
                    var getDate = db.Veeam_Tenant.Where(c => c.vcc_id == vcc_id).FirstOrDefault();
                    string tenantName = "VCC" + vcc_id.ToString();
                    HttpClient connectVcc = vm.ConnectVCC_API();
                    var UID = vm.Get_UIDByTenantName(connectVcc, tenantName);
                    var GetTenent = vm.Get_TenantByUID(connectVcc, UID);
                    GetTenent.LeaseOptions.ExpirationDate = getDate.end_dt;
                    var objClose = vm.Cv_CloudTenantToXmlStr(GetTenent);
                    var status = vm.Put_EditTenant(connectVcc, objClose, UID);
                    System.Threading.Thread.Sleep(8000);
                    if (status != null)
                    {
                        //get invoice for prolong
                        var invo = db.v_Get_InvoviceById_package_backup.Where(c => c.temp_pck_id == Datareturn.pck_id).FirstOrDefault();
                        return invo;
                    }
                }
                //get invoice for prolong
                return null;
            }
            catch (Exception exp) {
               
                return null;
            }

            
        }
        //Prolong Package Replication Enterprise
        public v_Get_InvoviceById_package_replication ProlongPackage_VeeamReplication(int cust_id, int vcc_id) 
        {
            try {
                //create package in table
                var Datareturn = db.Database.SqlQuery<Packages2>("[backup].[s_EnterpriseProlong_VeeamReplication_BO] @cust_id, @vcc_id",
                              new SqlParameter("@cust_id", cust_id),
                              new SqlParameter("@vcc_id", vcc_id)
                            ).FirstOrDefault();
                //get invoice for prolong
                if (Datareturn != null)
                {
                    VeeamCC vm = new VeeamCC();
                    var getDate = db.Veeam_Tenant.Where(c => c.vcc_id == vcc_id).FirstOrDefault();
                    string tenantName = "VCC" + vcc_id.ToString();
                    HttpClient connectVcc = vm.ConnectVCC_API();
                    var UID = vm.Get_UIDByTenantName(connectVcc, tenantName);
                    var GetTenent = vm.Get_TenantByUID(connectVcc, UID);
                    GetTenent.LeaseOptions.ExpirationDate = getDate.end_dt;
                    var objClose = vm.Cv_CloudTenantToXmlStr(GetTenent);
                    var status = vm.Put_EditTenant(connectVcc, objClose, UID);
                    System.Threading.Thread.Sleep(8000);
                    if (status != null)
                    {
                        var invo = db.v_Get_InvoviceById_package_replication.Where(c => c.temp_pck_id == Datareturn.pck_id).FirstOrDefault();
                        return invo;
                    }
                }
                //get invoice for prolong
                return null;
            }
            catch (Exception exp) {
                return null;
            }
          
        }
        //Prolong Package VeeamBackup Resaller
        public v_Get_InvoviceById_package_backup_resaller ProlongPackage_VeeamBackupResaller(int cust_id, int vcc_id) 
        {
            try {
                //create package in table
                var Datareturn = db.Database.SqlQuery<m_Prolonged_package>("[backup].[s_ResellerProlongPackageBackUp] @cust_id, @vcc_id",
                         new SqlParameter("@cust_id", cust_id),
                         new SqlParameter("@vcc_id", vcc_id)
                       ).FirstOrDefault();
                if (Datareturn != null)
                {
                    VeeamCC vm = new VeeamCC();
                    string tenantName = "VCC" + vcc_id.ToString();
                    HttpClient connectVcc = vm.ConnectVCC_API();
                    var UID = vm.Get_UIDByTenantName(connectVcc, tenantName);
                    var GetTenent = vm.Get_TenantByUID(connectVcc, UID);
                    GetTenent.LeaseOptions.ExpirationDate = Datareturn.end_dt;
                    var objClose = vm.Cv_CloudTenantToXmlStr(GetTenent);
                    var status = vm.Put_EditTenant(connectVcc, objClose, UID);
                    System.Threading.Thread.Sleep(8000);
                    if (status != null)
                    {
                        var invo = db.v_Get_InvoviceById_package_backup_resaller.Where(c => c.temp_pck_id == Datareturn.pck_id).FirstOrDefault();
                        return invo;
                    }
                }
                //get invoice for prolong
                return null;
            }
            catch (Exception exp) {
                return null;
            }
           // throw new NotImplementedException();
        }
        //Prolong Package Replication Resaller
        public v_Get_InvoviceById_package_replication_resaller ProlongPackage_VeeamReplicationResaller(int cust_id, int vcc_id) 
        {
            try
            {
                //create package in table
                var Datareturn = db.Database.SqlQuery<m_Prolonged_package>("[backup].[s_ResellerProlongPackageReplication] @cust_id, @vcc_id",
                     new SqlParameter("@cust_id", cust_id),
                     new SqlParameter("@vcc_id", vcc_id)
                   ).FirstOrDefault();
                if (Datareturn != null) {
                    VeeamCC vm = new VeeamCC();
                    string tenantName = "VCC" + vcc_id.ToString();
                    HttpClient connectVcc = vm.ConnectVCC_API();
                    var UID = vm.Get_UIDByTenantName(connectVcc, tenantName);
                    var GetTenent = vm.Get_TenantByUID(connectVcc, UID);
                    GetTenent.LeaseOptions.ExpirationDate = Datareturn.end_dt;
                    var objClose = vm.Cv_CloudTenantToXmlStr(GetTenent);
                    var status = vm.Put_EditTenant(connectVcc, objClose, UID);
                    System.Threading.Thread.Sleep(8000);
                    if (status != null) {
                        var invo = db.v_Get_InvoviceById_package_replication_resaller.Where(c => c.temp_pck_id == Datareturn.pck_id).FirstOrDefault();
                        return invo;
                    }
                }
                return null;
                //get invoice for prolong

            }
            catch (Exception exp)
            {
                return null;
            }
           // throw new NotImplementedException();
        }

        public v_Get_InvoviceById_package_backup_Nakivo ProlongPackage_NakivoBackup(int cust_id, int vcc_id)
        {
            try
            {
                //create package in table
                var Datareturn = db.Database.SqlQuery<Packages2>("[backup].[s_EnterpriseProlong_VeeamBackup_BO] @cust_id, @vcc_id",
                         new SqlParameter("@cust_id", cust_id),
                         new SqlParameter("@vcc_id", vcc_id)
                         ).FirstOrDefault();
                if (Datareturn != null)
                {


                    //get invoice for prolong
                    var invo = db.v_Get_InvoviceById_package_backup_Nakivo.Where(c => c.temp_pck_id == Datareturn.pck_id).FirstOrDefault();
                        return invo;
                    
                }
                //get invoice for prolong
                return null;
            }
            catch (Exception)
            {

                return null;
            }
        }
        public v_Get_InvoviceById_package_backup_Nakivo_resaller ProlongPackage_NakivoBackupResaller(int cust_id, int vcc_id)
        {
            try
            {
                //create package in table
                var Datareturn = db.Database.SqlQuery<m_Prolonged_package>("[backup].[s_ResellerProlongPackageBackUp] @cust_id, @vcc_id",
                         new SqlParameter("@cust_id", cust_id),
                         new SqlParameter("@vcc_id", vcc_id)
                       ).FirstOrDefault();
                if (Datareturn != null)
                {
     
                        var invo = db.v_Get_InvoviceById_package_backup_Nakivo_resaller.Where(c => c.temp_pck_id == Datareturn.pck_id).FirstOrDefault();
                        return invo;
                    
                }
                //get invoice for prolong
                return null;
            }
            catch (Exception)
            {
                return null;
            }
            // throw new NotImplementedException();
        }
    }
}
