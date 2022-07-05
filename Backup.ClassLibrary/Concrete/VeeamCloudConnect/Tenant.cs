using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup.ClassLibrary.Concrete.VeeamCloudConnect
{
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.veeam.com/ent/v1.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.veeam.com/ent/v1.0", IsNullable = false)]
    public partial class CloudTenant
    {

        private CloudTenantLink[] linksField;

        //private object passwordField;

        private string descriptionField;

        private bool enabledField;

        private CloudTenantLeaseOptions leaseOptionsField;

        private CloudTenantResources resourcesField;

        private string lastResultField;

        private System.DateTime lastActiveField;

        private object computeResourcesField;

        private bool throttlingEnabledField;

        private byte throttlingSpeedLimitField;

        private string throttlingSpeedUnitField;

        private byte publicIpCountField;

        private byte backupCountField;

        private byte replicaCountField;

        private byte maxConcurrentTasksField;

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
       /* public object Password
        {
            get
            {
                return this.passwordField;
            }
            set
            {
                this.passwordField = value;
            }
        }*/

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
        public CloudTenantResources Resources
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
        public object ComputeResources
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
    public partial class CloudTenantResources
    {

        private CloudTenantResourcesCloudTenantResource cloudTenantResourceField;

        /// <remarks/>
        public CloudTenantResourcesCloudTenantResource CloudTenantResource
        {
            get
            {
                return this.cloudTenantResourceField;
            }
            set
            {
                this.cloudTenantResourceField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.veeam.com/ent/v1.0")]
    public partial class CloudTenantResourcesCloudTenantResource
    {

        private CloudTenantResourcesCloudTenantResourceRepositoryQuota repositoryQuotaField;

        private string hrefField;

        private string typeField;

        private string idField;

        /// <remarks/>
        public CloudTenantResourcesCloudTenantResourceRepositoryQuota RepositoryQuota
        {
            get
            {
                return this.repositoryQuotaField;
            }
            set
            {
                this.repositoryQuotaField = value;
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
    public partial class CloudTenantResourcesCloudTenantResourceRepositoryQuota
    {

        private string displayNameField;

        private string repositoryUidField;

        private uint quotaField;

        private byte usedQuotaField;

        /// <remarks/>
        public string DisplayName
        {
            get
            {
                return this.displayNameField;
            }
            set
            {
                this.displayNameField = value;
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
        public uint Quota
        {
            get
            {
                return this.quotaField;
            }
            set
            {
                this.quotaField = value;
            }
        }

        /// <remarks/>
        public byte UsedQuota
        {
            get
            {
                return this.usedQuotaField;
            }
            set
            {
                this.usedQuotaField = value;
            }
        }
    }
}
