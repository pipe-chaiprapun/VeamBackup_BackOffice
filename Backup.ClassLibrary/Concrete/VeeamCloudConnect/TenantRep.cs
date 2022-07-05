using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup.ClassLibrary.Concrete.VeeamCloudConnect.Replication
{

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.veeam.com/ent/v1.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.veeam.com/ent/v1.0", IsNullable = false)]
    public partial class CloudTenant
    {

        private CloudTenantLink[] linksField;

        private object passwordField;

        private object descriptionField;

        private bool enabledField;

        private CloudTenantLeaseOptions leaseOptionsField;

        private object resourcesField;

        private string lastResultField;

        private System.DateTime lastActiveField;

        private CloudTenantComputeResources computeResourcesField;

        private bool throttlingEnabledField;

        private byte throttlingSpeedLimitField;

        private string throttlingSpeedUnitField;

        private byte publicIpCountField;

        private byte backupCountField;

        private byte replicaCountField;

        private byte maxConcurrentTasksField;

        private byte workStationBackupCountField;

        private byte serverBackupCountField;

        private string hrefField;

        private string typeField;

        private string nameField;

        private string uIDField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Link", IsNullable = false)]
        public CloudTenantLink[] Links
        {
            get
            {
                return this.linksField;
            }
            set
            {
                this.linksField = value;
            }
        }

        /// <remarks/>
        public object Password
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
        public object Description
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
        public CloudTenantLeaseOptions LeaseOptions
        {
            get
            {
                return this.leaseOptionsField;
            }
            set
            {
                this.leaseOptionsField = value;
            }
        }

        /// <remarks/>
        public object Resources
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
        public string LastResult
        {
            get
            {
                return this.lastResultField;
            }
            set
            {
                this.lastResultField = value;
            }
        }

        /// <remarks/>
        public System.DateTime LastActive
        {
            get
            {
                return this.lastActiveField;
            }
            set
            {
                this.lastActiveField = value;
            }
        }

        /// <remarks/>
        public CloudTenantComputeResources ComputeResources
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
        public byte ThrottlingSpeedLimit
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
        public byte PublicIpCount
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
        public byte BackupCount
        {
            get
            {
                return this.backupCountField;
            }
            set
            {
                this.backupCountField = value;
            }
        }

        /// <remarks/>
        public byte ReplicaCount
        {
            get
            {
                return this.replicaCountField;
            }
            set
            {
                this.replicaCountField = value;
            }
        }

        /// <remarks/>
        public byte MaxConcurrentTasks
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

        /// <remarks/>
        public byte WorkStationBackupCount
        {
            get
            {
                return this.workStationBackupCountField;
            }
            set
            {
                this.workStationBackupCountField = value;
            }
        }

        /// <remarks/>
        public byte ServerBackupCount
        {
            get
            {
                return this.serverBackupCountField;
            }
            set
            {
                this.serverBackupCountField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Href
        {
            get
            {
                return this.hrefField;
            }
            set
            {
                this.hrefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
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
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string UID
        {
            get
            {
                return this.uIDField;
            }
            set
            {
                this.uIDField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.veeam.com/ent/v1.0")]
    public partial class CloudTenantLink
    {

        private string hrefField;

        private string nameField;

        private string typeField;

        private string relField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Href
        {
            get
            {
                return this.hrefField;
            }
            set
            {
                this.hrefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
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
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Rel
        {
            get
            {
                return this.relField;
            }
            set
            {
                this.relField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.veeam.com/ent/v1.0")]
    public partial class CloudTenantLeaseOptions
    {

        private bool enabledField;

        private System.DateTime expirationDateField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
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
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public System.DateTime ExpirationDate
        {
            get
            {
                return this.expirationDateField;
            }
            set
            {
                this.expirationDateField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.veeam.com/ent/v1.0")]
    public partial class CloudTenantComputeResources
    {

        private CloudTenantComputeResourcesCloudTenantComputeResource cloudTenantComputeResourceField;

        /// <remarks/>
        public CloudTenantComputeResourcesCloudTenantComputeResource CloudTenantComputeResource
        {
            get
            {
                return this.cloudTenantComputeResourceField;
            }
            set
            {
                this.cloudTenantComputeResourceField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.veeam.com/ent/v1.0")]
    public partial class CloudTenantComputeResourcesCloudTenantComputeResource
    {

        private string cloudHardwarePlanUidField;

        private string platformTypeField;

        private bool useNetworkFailoverResourcesField;

        private CloudTenantComputeResourcesCloudTenantComputeResourceComputeResourceStats computeResourceStatsField;

        private string hrefField;

        private string typeField;

        private string idField;

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

        /// <remarks/>
        public CloudTenantComputeResourcesCloudTenantComputeResourceComputeResourceStats ComputeResourceStats
        {
            get
            {
                return this.computeResourceStatsField;
            }
            set
            {
                this.computeResourceStatsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Href
        {
            get
            {
                return this.hrefField;
            }
            set
            {
                this.hrefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.veeam.com/ent/v1.0")]
    public partial class CloudTenantComputeResourcesCloudTenantComputeResourceComputeResourceStats
    {

        private byte memoryUsageMbField;

        private byte cPUCountField;

        private CloudTenantComputeResourcesCloudTenantComputeResourceComputeResourceStatsStorageResourceStats storageResourceStatsField;

        /// <remarks/>
        public byte MemoryUsageMb
        {
            get
            {
                return this.memoryUsageMbField;
            }
            set
            {
                this.memoryUsageMbField = value;
            }
        }

        /// <remarks/>
        public byte CPUCount
        {
            get
            {
                return this.cPUCountField;
            }
            set
            {
                this.cPUCountField = value;
            }
        }

        /// <remarks/>
        public CloudTenantComputeResourcesCloudTenantComputeResourceComputeResourceStatsStorageResourceStats StorageResourceStats
        {
            get
            {
                return this.storageResourceStatsField;
            }
            set
            {
                this.storageResourceStatsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.veeam.com/ent/v1.0")]
    public partial class CloudTenantComputeResourcesCloudTenantComputeResourceComputeResourceStatsStorageResourceStats
    {

        private CloudTenantComputeResourcesCloudTenantComputeResourceComputeResourceStatsStorageResourceStatsStorageResourceStat storageResourceStatField;

        /// <remarks/>
        public CloudTenantComputeResourcesCloudTenantComputeResourceComputeResourceStatsStorageResourceStatsStorageResourceStat StorageResourceStat
        {
            get
            {
                return this.storageResourceStatField;
            }
            set
            {
                this.storageResourceStatField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.veeam.com/ent/v1.0")]
    public partial class CloudTenantComputeResourcesCloudTenantComputeResourceComputeResourceStatsStorageResourceStatsStorageResourceStat
    {

        private string storageNameField;

        private byte storageUsageGbField;

        private ushort storageLimitGbField;

        /// <remarks/>
        public string StorageName
        {
            get
            {
                return this.storageNameField;
            }
            set
            {
                this.storageNameField = value;
            }
        }

        /// <remarks/>
        public byte StorageUsageGb
        {
            get
            {
                return this.storageUsageGbField;
            }
            set
            {
                this.storageUsageGbField = value;
            }
        }

        /// <remarks/>
        public ushort StorageLimitGb
        {
            get
            {
                return this.storageLimitGbField;
            }
            set
            {
                this.storageLimitGbField = value;
            }
        }
    }


}
