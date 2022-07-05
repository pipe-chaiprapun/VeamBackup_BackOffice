using Backup.ClassLibrary.Concrete.VeeamCloudConnect;
using Backup.ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Backup.ClassLibrary.Abstract
{
    public interface IVeeamCC2
    {
        HttpClient ConnectVCC_API();
        CreateCloudTenantSpec Set_CreateCloudTenantSpec(string username, string password, int quote, bool storage = false);
        CreateCloudTenantSpec Set_CreateCloudTenantRepSpec(string username, string password, string HWID);
        StringContent Cv_CreateCloudTenantSpecToXmlStr(CreateCloudTenantSpec value);
        string Post_CreateTenant(HttpClient connect, HttpContent content);

        CloudTenant Get_TenantByUID(HttpClient connect, string UID);
        Backup.ClassLibrary.Concrete.VeeamCloudConnect.Replication.CloudTenant Get_TenantRepByUID(string UID);
        StringContent Cv_CloudTenantToXmlStr(CloudTenant tenantObj);
        string Put_EditTenant(HttpClient connect, HttpContent content, string UID);

        CloudHardwarePlanCreateSpec Set_CloudHardwarePlanCreateSpec(string HW_Name, int ProcessorUsageLimitMhz, int MemoryUsageLimitMb, int QuotaGb, int CountWithoutInternet);
        StringContent Cv_CloudHardwarePlanCreateSpecToXmlStr(CloudHardwarePlanCreateSpec HW_Spec);
        string Post_CreateHardwarePlan(HttpClient connect, HttpContent content);

        CloudHardwarePlan Get_HardwarePlanByID(HttpClient connect, string HardwarePlanID);
        StringContent Cv_CloudHardwarePlanToXmlStr(CloudHardwarePlan obj);
        string Put_EditHardwarePlan(HttpClient connect, HttpContent content, string HardwarePlanID);

        string Get_UIDByTenantName(HttpClient connect, string TenantName);
        string Get_UIDbyHardwareName(HttpClient connect, string name);
        string Filter(HttpClient connect, string QueryType, string filter, string value);

        object Delete_Tenant(HttpClient connect, string UID);
        bool subscribeTask(HttpClient connect, string id);
        object GetFailoverPlan(HttpClient connection, string VCC);
        object GetTaskSessions(HttpClient connection);
      //  CloudFailoverPlanManagementSpec SetCloudFailoverStart();
      //  StringContent Cv_CloudFailoverActionToXmlStr(CloudFailoverPlanManagementSpec action);
        string Post_CloudFailoverStart(HttpClient connect, HttpContent content, string UID);
        string Post_CloudFailoverStop(HttpClient connect, string UID);


    }
}
