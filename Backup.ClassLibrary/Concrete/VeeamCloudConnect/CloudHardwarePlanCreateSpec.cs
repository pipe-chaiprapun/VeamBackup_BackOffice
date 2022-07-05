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
    public partial class CloudHardwarePlanCreateSpec
    {

        private string backupServerUidField;

        private string nameField;

        private string descriptionField;

        private int processorUsageLimitMhzField;

        private int memoryUsageLimitMbField;

        private CloudHardwarePlanCreateSpecHardwarePlanDetails hardwarePlanDetailsField;

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
        public int ProcessorUsageLimitMhz
        {
            get
            {
                return this.processorUsageLimitMhzField;
            }
            set
            {
                this.processorUsageLimitMhzField = value;
            }
        }

        /// <remarks/>
        public int MemoryUsageLimitMb
        {
            get
            {
                return this.memoryUsageLimitMbField;
            }
            set
            {
                this.memoryUsageLimitMbField = value;
            }
        }

        /// <remarks/>
        public CloudHardwarePlanCreateSpecHardwarePlanDetails HardwarePlanDetails
        {
            get
            {
                return this.hardwarePlanDetailsField;
            }
            set
            {
                this.hardwarePlanDetailsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.veeam.com/ent/v1.0")]
    public partial class CloudHardwarePlanCreateSpecHardwarePlanDetails
    {

        private CloudHardwarePlanCreateSpecHardwarePlanDetailsViCloudHardwarePlan viCloudHardwarePlanField;

        /// <remarks/>
        public CloudHardwarePlanCreateSpecHardwarePlanDetailsViCloudHardwarePlan ViCloudHardwarePlan
        {
            get
            {
                return this.viCloudHardwarePlanField;
            }
            set
            {
                this.viCloudHardwarePlanField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.veeam.com/ent/v1.0")]
    public partial class CloudHardwarePlanCreateSpecHardwarePlanDetailsViCloudHardwarePlan
    {

        private string hypervisorHostRefField;

        private string parentTypeField;

        private string parentNameField;

        private CloudHardwarePlanCreateSpecHardwarePlanDetailsViCloudHardwarePlanDatastores datastoresField;

        private CloudHardwarePlanCreateSpecHardwarePlanDetailsViCloudHardwarePlanNetwork networkField;

        /// <remarks/>
        public string HypervisorHostRef
        {
            get
            {
                return this.hypervisorHostRefField;
            }
            set
            {
                this.hypervisorHostRefField = value;
            }
        }

        /// <remarks/>
        public string ParentType
        {
            get
            {
                return this.parentTypeField;
            }
            set
            {
                this.parentTypeField = value;
            }
        }

        /// <remarks/>
        public string ParentName
        {
            get
            {
                return this.parentNameField;
            }
            set
            {
                this.parentNameField = value;
            }
        }

        /// <remarks/>
        public CloudHardwarePlanCreateSpecHardwarePlanDetailsViCloudHardwarePlanDatastores Datastores
        {
            get
            {
                return this.datastoresField;
            }
            set
            {
                this.datastoresField = value;
            }
        }

        /// <remarks/>
        public CloudHardwarePlanCreateSpecHardwarePlanDetailsViCloudHardwarePlanNetwork Network
        {
            get
            {
                return this.networkField;
            }
            set
            {
                this.networkField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.veeam.com/ent/v1.0")]
    public partial class CloudHardwarePlanCreateSpecHardwarePlanDetailsViCloudHardwarePlanDatastores
    {

        private CloudHardwarePlanCreateSpecHardwarePlanDetailsViCloudHardwarePlanDatastoresDatastore datastoreField;

        /// <remarks/>
        public CloudHardwarePlanCreateSpecHardwarePlanDetailsViCloudHardwarePlanDatastoresDatastore Datastore
        {
            get
            {
                return this.datastoreField;
            }
            set
            {
                this.datastoreField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.veeam.com/ent/v1.0")]
    public partial class CloudHardwarePlanCreateSpecHardwarePlanDetailsViCloudHardwarePlanDatastoresDatastore
    {

        private string friendlyNameField;

        private string datastoreTypeField;

        private string referenceField;

        private int quotaGbField;

        /// <remarks/>
        public string FriendlyName
        {
            get
            {
                return this.friendlyNameField;
            }
            set
            {
                this.friendlyNameField = value;
            }
        }

        /// <remarks/>
        public string DatastoreType
        {
            get
            {
                return this.datastoreTypeField;
            }
            set
            {
                this.datastoreTypeField = value;
            }
        }

        /// <remarks/>
        public string Reference
        {
            get
            {
                return this.referenceField;
            }
            set
            {
                this.referenceField = value;
            }
        }

        /// <remarks/>
        public int QuotaGb
        {
            get
            {
                return this.quotaGbField;
            }
            set
            {
                this.quotaGbField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.veeam.com/ent/v1.0")]
    public partial class CloudHardwarePlanCreateSpecHardwarePlanDetailsViCloudHardwarePlanNetwork
    {

        private int countWithInternetField;

        private int countWithoutInternetField;

        /// <remarks/>
        public int CountWithInternet
        {
            get
            {
                return this.countWithInternetField;
            }
            set
            {
                this.countWithInternetField = value;
            }
        }

        /// <remarks/>
        public int CountWithoutInternet
        {
            get
            {
                return this.countWithoutInternetField;
            }
            set
            {
                this.countWithoutInternetField = value;
            }
        }
    }
}
