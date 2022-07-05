using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup.ClassLibrary.Concrete.VeeamCloudConnect
{
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.veeam.com/ent/v1.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.veeam.com/ent/v1.0", IsNullable = false)]
    public partial class CreateCloudTenantSpec
    {

        private string nameField;

        private string descriptionField;

        private string passwordField;

        private bool enabledField;

        private System.DateTime leaseExpirationDateField;

        private CreateCloudTenantSpecResources resourcesField;

        private CreateCloudTenantSpecComputeResources computeResourcesField;

        private bool throttlingEnabledField;

        private int throttlingSpeedLimitField;

        private string throttlingSpeedUnitField;

        private int publicIpCountField;

        private string backupServerUidField;

        private int maxConcurrentTasksField;

        /// <remarks/>
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public string Description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        public string Password
        {
            get
            {
                return this.passwordField;
            }
            set
            {
                this.passwordField = value;
            }
        }

        /// <remarks/>
        public bool Enabled
        {
            get
            {
                return this.enabledField;
            }
            set
            {
                this.enabledField = value;
            }
        }

        /// <remarks/>
        public System.DateTime LeaseExpirationDate
        {
            get
            {
                return this.leaseExpirationDateField;
            }
            set
            {
                this.leaseExpirationDateField = value;
            }
        }

        /// <remarks/>
        public CreateCloudTenantSpecResources Resources
        {
            get
            {
                return this.resourcesField;
            }
            set
            {
                this.resourcesField = value;
            }
        }

        /// <remarks/>
        public CreateCloudTenantSpecComputeResources ComputeResources
        {
            get
            {
                return this.computeResourcesField;
            }
            set
            {
                this.computeResourcesField = value;
            }
        }

        /// <remarks/>
        public bool ThrottlingEnabled
        {
            get
            {
                return this.throttlingEnabledField;
            }
            set
            {
                this.throttlingEnabledField = value;
            }
        }

        /// <remarks/>
        public int ThrottlingSpeedLimit
        {
            get
            {
                return this.throttlingSpeedLimitField;
            }
            set
            {
                this.throttlingSpeedLimitField = value;
            }
        }

        /// <remarks/>
        public string ThrottlingSpeedUnit
        {
            get
            {
                return this.throttlingSpeedUnitField;
            }
            set
            {
                this.throttlingSpeedUnitField = value;
            }
        }

        /// <remarks/>
        public int PublicIpCount
        {
            get
            {
                return this.publicIpCountField;
            }
            set
            {
                this.publicIpCountField = value;
            }
        }

        /// <remarks/>
        public string BackupServerUid
        {
            get
            {
                return this.backupServerUidField;
            }
            set
            {
                this.backupServerUidField = value;
            }
        }

        /// <remarks/>
        public int MaxConcurrentTasks
        {
            get
            {
                return this.maxConcurrentTasksField;
            }
            set
            {
                this.maxConcurrentTasksField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.veeam.com/ent/v1.0")]
    public partial class CreateCloudTenantSpecResources
    {

        private CreateCloudTenantSpecResourcesBackupResource backupResourceField;

        /// <remarks/>
        public CreateCloudTenantSpecResourcesBackupResource BackupResource
        {
            get
            {
                return this.backupResourceField;
            }
            set
            {
                this.backupResourceField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.veeam.com/ent/v1.0")]
    public partial class CreateCloudTenantSpecResourcesBackupResource
    {

        private string nameField;

        private string repositoryUidField;

        private int quotaMbField;

        /// <remarks/>
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public string RepositoryUid
        {
            get
            {
                return this.repositoryUidField;
            }
            set
            {
                this.repositoryUidField = value;
            }
        }

        /// <remarks/>
        public int QuotaMb
        {
            get
            {
                return this.quotaMbField;
            }
            set
            {
                this.quotaMbField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.veeam.com/ent/v1.0")]
    public partial class CreateCloudTenantSpecComputeResources
    {

        private CreateCloudTenantSpecComputeResourcesComputeResource computeResourceField;

        /// <remarks/>
        public CreateCloudTenantSpecComputeResourcesComputeResource ComputeResource
        {
            get
            {
                return this.computeResourceField;
            }
            set
            {
                this.computeResourceField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.veeam.com/ent/v1.0")]
    public partial class CreateCloudTenantSpecComputeResourcesComputeResource
    {

        private string cloudHardwarePlanUidField;

        private string platformTypeField;

        private bool useNetworkFailoverResourcesField;

        /// <remarks/>
        public string CloudHardwarePlanUid
        {
            get
            {
                return this.cloudHardwarePlanUidField;
            }
            set
            {
                this.cloudHardwarePlanUidField = value;
            }
        }

        /// <remarks/>
        public string PlatformType
        {
            get
            {
                return this.platformTypeField;
            }
            set
            {
                this.platformTypeField = value;
            }
        }

        /// <remarks/>
        public bool UseNetworkFailoverResources
        {
            get
            {
                return this.useNetworkFailoverResourcesField;
            }
            set
            {
                this.useNetworkFailoverResourcesField = value;
            }
        }
    }
}
