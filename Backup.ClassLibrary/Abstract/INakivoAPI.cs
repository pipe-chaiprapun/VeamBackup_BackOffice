using Backup.ClassLibrary.Concrete.Nakivo.NakivoModel.BackupObject;
using Backup.ClassLibrary.Concrete.Nakivo.NakivoModel.Inventory;
using Backup.ClassLibrary.Concrete.Nakivo.NakivoModel.Inventory.Info;
using Backup.ClassLibrary.Concrete.Nakivo.NakivoModel.Job;
using Backup.ClassLibrary.Concrete.Nakivo.NakivoModel.Job.Info;
using Backup.ClassLibrary.Concrete.Nakivo.NakivoModel.Repository;
using Backup.ClassLibrary.Concrete.Nakivo.NakivoModel.Repository.Info;
using Backup.ClassLibrary.Concrete.Nakivo.NakivoModel.Tenant;
using Backup.ClassLibrary.Concrete.Nakivo.NakivoModel.Tenant.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Backup.ClassLibrary.Abstract
{
    public interface INakivoAPI
    {
        HttpClient ConnectNakivo_API();
        bool LoginStateCheck();
        void Logout();
        int CreateTenant(HttpClient connection, string vcc, string AdminPassword, string emailAdmin, string emailGuest, string GuestPassword, int vm, int storage, bool premium = false);
        bool DeleteTenant(HttpClient connection, string vcc);
        bool DisableTenant(HttpClient connection, string vcc);
        bool EnableTenant(HttpClient connection, string vcc);
        ListTenant getListTenants(HttpClient connection);
        TenantInfo getTenantByName(HttpClient connection, string name);
        string getUID(TenantInfo tn);
        RepositoryList getRepoList(HttpClient connection);
        RepositoryInfo getRepoInfo(HttpClient connection);
        bool refreshRepo(HttpClient connection);
        bool detachRepo(HttpClient connection, int id);
        bool attachRepo(HttpClient connection, int id);
        JobList getJobList(HttpClient connection);
        JobInfo getJobInfo(HttpClient connection, int id);
        bool enableJob(HttpClient connection, int id, bool enable);
        bool runJob(HttpClient connection, int id);
        bool stopJob(HttpClient connection, int id);
        bool removeJob(HttpClient connection, int id);
        ObjectList getOjectList(HttpClient connection, int id);
        bool removeBackupObject(HttpClient connection, int id);
        InventoryItems getAllItems(HttpClient connection);
        ItemInfo getItemInfo(HttpClient connection, int id);
        bool refreshInv(HttpClient connection);
    }
}
