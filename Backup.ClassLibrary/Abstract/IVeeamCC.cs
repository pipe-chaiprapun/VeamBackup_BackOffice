using Backup.ClassLibrary.Concrete.VeeamCloudConnect;
using Backup.ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup.ClassLibrary.Abstract
{
    public interface IVeeamCC
    {

        string SetX_RestSvcSessionId(string X_RestSvcSessionId);

        string FindHrefTenantEntity(string TenantName);

        string getX_RestSvcSessionId();

        string ConvertXml2Json(string XmlElements);

        Rootobject getCloudTenantsAll();

        Rootobject getCloudTenantsEntity(string TenantUri);

        Rootobject getCloudTenantsEntity();

        Rootobject getRepositories();

        IEnumerable<VeeamReportModel> ReportDetails();

        bool CreateTenant(string username, string password, DateTime expireDate, int Quota, string BackupServerUid = "", string RepositoryUid = "", string Description = "");
    }
}