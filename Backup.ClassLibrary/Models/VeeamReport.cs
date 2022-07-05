using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup.ClassLibrary.Models
{
    /// <summary>
    /// Json Tenant Entity
    /// </summary>
    public class Rootobject
    {
        public Xml xml { get; set; }
        public Entityreferences EntityReferences { get; set; }
        public Cloudtenant CloudTenant { get; set; }
        public Repositories Repositories { get; set; }
    }

    public class Xml
    {
        public string version { get; set; }
        public string encoding { get; set; }
    }

    public class Entityreferences
    {
        public string xmlns { get; set; }
        public string xmlnsxsd { get; set; }
        public string xmlnsxsi { get; set; }
        public Ref[] Ref { get; set; }
    }

    public class Cloudtenant
    {
        public string Href { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string UID { get; set; }
        public string xmlns { get; set; }
        public string xmlnsxsd { get; set; }
        public string xmlnsxsi { get; set; }
        public Links Links { get; set; }
       /* public object Password { get; set; }*/
        public string Description { get; set; }
        public string Enabled { get; set; }
        public Leaseoptions LeaseOptions { get; set; }
        public Resources Resources { get; set; }
        public string LastResult { get; set; }
        public DateTime LastActive { get; set; }
        public object ComputeResources { get; set; }
        public string ThrottlingEnabled { get; set; }
        public string ThrottlingSpeedLimit { get; set; }
        public string ThrottlingSpeedUnit { get; set; }
        public string PublicIpCount { get; set; }
        public string BackupCount { get; set; }
        public string ReplicaCount { get; set; }
        public string MaxConcurrentTasks { get; set; }
    }

    public class Resources
    {
        public Cloudtenantresource CloudTenantResource { get; set; }
    }

    public class Cloudtenantresource
    {
        public string Href { get; set; }
        public string Type { get; set; }
        public string Id { get; set; }
        public Repositoryquota RepositoryQuota { get; set; }
    }

    public class Repositoryquota
    {
        public string DisplayName { get; set; }
        public string RepositoryUid { get; set; }
        public string Quota { get; set; }
        public string UsedQuota { get; set; }
    }

    public class Ref
    {
        public string UID { get; set; }
        public string Name { get; set; }
        public string Href { get; set; }
        public string Type { get; set; }
        public Links Links { get; set; }
    }

    public class Links
    {
        public Link[] Link { get; set; }
    }

    public class Leaseoptions
    {
        public string Enabled { get; set; }
        public DateTime ExpirationDate { get; set; }
    }

    public class Link
    {
        public string Href { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Rel { get; set; }
    }

    public class VeeamReportModel
    {
        public string TENANT_NAME { get; set; }
        public string QUOTA { get; set; }
        public string FREE_SPACE { get; set; }
        public string USED_SPACE { get; set; }
        public string USED_SPACE_Percent { get; set; }
        public string LAST_RESULT { get; set; }
        public string LAST_ACTIVE { get; set; }
        public string Repository { get; set; }
        public string DESCRIPTION { get; set; }
        public string ThrottlingSpeedLimit { get; set; }
        public string ThrottlingSpeedUnit { get; set; }
        public string BackupCount { get; set; }
        public string ExpirationDate { get; set; }
        
    }

    public class VeeamReportModelRep
    {
        public string TENANT_NAME { get; set; }
        public string QUOTA { get; set; }
        public string FREE_SPACE { get; set; }
        public string USED_SPACE { get; set; }
        public string USED_SPACE_Percent { get; set; }
        public string LAST_RESULT { get; set; }
        public string LAST_ACTIVE { get; set; }
        public string Repository { get; set; }
        public string DESCRIPTION { get; set; }
        public string ThrottlingSpeedLimit { get; set; }
        public string ThrottlingSpeedUnit { get; set; }
        public string ReplicaCount { get; set; }
        public string ExpirationDate { get; set; }
        public string MemoryUsages { get; set; }
        public string cpuCount { get; set; }
    }

    public class GetStorag
    {
        public Repository[] Repository { get; set; }
    }

    public class Repositories
    {
        public string xmlns { get; set; }
        public string xmlnsxsd { get; set; }
        public string xmlnsxsi { get; set; }
        public Repository[] Repository { get; set; }
    }

    public class Repository
    {
        public string Href { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string UID { get; set; }
        public Links Links { get; set; }
        public string Capacity { get; set; }
        public string FreeSpace { get; set; }
    }


    

}



