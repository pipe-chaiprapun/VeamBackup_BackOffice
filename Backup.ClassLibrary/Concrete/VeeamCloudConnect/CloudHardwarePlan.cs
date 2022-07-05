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
    public partial class CloudHardwarePlan
    {

        private CloudHardwarePlanLink[] linksField;

        private string descriptionField;

        private ushort processorUsageLimitMhzField;

        private ushort memoryUsageLimitMbField;

        private CloudHardwarePlanHardwarePlanDetails hardwarePlanDetailsField;

        private string hrefField;

        private string typeField;

        private string nameField;

        private string uIDField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Link", IsNullable = false)]
        public CloudHardwarePlanLink[] Links
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
        public ushort ProcessorUsageLimitMhz
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
        public ushort MemoryUsageLimitMb
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
        public CloudHardwarePlanHardwarePlanDetails HardwarePlanDetails
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
    public partial class CloudHardwarePlanLink
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
    public partial class CloudHardwarePlanHardwarePlanDetails
    {

        private CloudHardwarePlanHardwarePlanDetailsViCloudHardwarePlan viCloudHardwarePlanField;

        /// <remarks/>
        public CloudHardwarePlanHardwarePlanDetailsViCloudHardwarePlan ViCloudHardwarePlan
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
    public partial class CloudHardwarePlanHardwarePlanDetailsViCloudHardwarePlan
    {

        private string hypervisorHostRefField;

        private string parentTypeField;

        private string parentNameField;

        private CloudHardwarePlanHardwarePlanDetailsViCloudHardwarePlanDatastores datastoresField;

        private CloudHardwarePlanHardwarePlanDetailsViCloudHardwarePlanNetwork networkField;

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
        public CloudHardwarePlanHardwarePlanDetailsViCloudHardwarePlanDatastores Datastores
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
        public CloudHardwarePlanHardwarePlanDetailsViCloudHardwarePlanNetwork Network
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
    public partial class CloudHardwarePlanHardwarePlanDetailsViCloudHardwarePlanDatastores
    {

        private CloudHardwarePlanHardwarePlanDetailsViCloudHardwarePlanDatastoresDatastore datastoreField;

        /// <remarks/>
        public CloudHardwarePlanHardwarePlanDetailsViCloudHardwarePlanDatastoresDatastore Datastore
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
    public partial class CloudHardwarePlanHardwarePlanDetailsViCloudHardwarePlanDatastoresDatastore
    {

        private string friendlyNameField;

        private string datastoreTypeField;

        private string referenceField;

        private object rootPathField;

        private ushort quotaGbField;

        private string idField;

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
        public object RootPath
        {
            get
            {
                return this.rootPathField;
            }
            set
            {
                this.rootPathField = value;
            }
        }

        /// <remarks/>
        public ushort QuotaGb
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
    public partial class CloudHardwarePlanHardwarePlanDetailsViCloudHardwarePlanNetwork
    {

        private byte countWithInternetField;

        private byte countWithoutInternetField;

        private string idField;

        /// <remarks/>
        public byte CountWithInternet
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
        public byte CountWithoutInternet
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


    /*/// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.veeam.com/ent/v1.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.veeam.com/ent/v1.0", IsNullable = false)]
    public partial class CloudHardwarePlan
    {

        private string descriptionField;

        private ushort processorUsageLimitMhzField;

        private ushort memoryUsageLimitMbField;

        private CloudHardwarePlanHardwarePlanDetails hardwarePlanDetailsField;

        private string typeField;

        private string hrefField;

        private string nameField;

        private string uIDField;

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
        public ushort ProcessorUsageLimitMhz
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
        public ushort MemoryUsageLimitMb
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
        public CloudHardwarePlanHardwarePlanDetails HardwarePlanDetails
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
    public partial class CloudHardwarePlanHardwarePlanDetails
    {

        private CloudHardwarePlanHardwarePlanDetailsViCloudHardwarePlan viCloudHardwarePlanField;

        /// <remarks/>
        public CloudHardwarePlanHardwarePlanDetailsViCloudHardwarePlan ViCloudHardwarePlan
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
    public partial class CloudHardwarePlanHardwarePlanDetailsViCloudHardwarePlan
    {

        private string hypervisorHostRefField;

        private string parentTypeField;

        private string parentNameField;

        private CloudHardwarePlanHardwarePlanDetailsViCloudHardwarePlanDatastores datastoresField;

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
        public CloudHardwarePlanHardwarePlanDetailsViCloudHardwarePlanDatastores Datastores
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
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.veeam.com/ent/v1.0")]
    public partial class CloudHardwarePlanHardwarePlanDetailsViCloudHardwarePlanDatastores
    {

        private CloudHardwarePlanHardwarePlanDetailsViCloudHardwarePlanDatastoresDatastore datastoreField;

        /// <remarks/>
        public CloudHardwarePlanHardwarePlanDetailsViCloudHardwarePlanDatastoresDatastore Datastore
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
    public partial class CloudHardwarePlanHardwarePlanDetailsViCloudHardwarePlanDatastoresDatastore
    {

        private string friendlyNameField;

        private string datastoreTypeField;

        private string referenceField;

        private object rootPathField;

        private ushort quotaGbField;

        private string idField;

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
        public object RootPath
        {
            get
            {
                return this.rootPathField;
            }
            set
            {
                this.rootPathField = value;
            }
        }

        /// <remarks/>
        public ushort QuotaGb
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
    }*/
}
