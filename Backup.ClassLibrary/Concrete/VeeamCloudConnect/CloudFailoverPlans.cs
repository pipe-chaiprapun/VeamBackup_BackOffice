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
    public partial class CloudFailoverPlans
    {

        private CloudFailoverPlansCloudFailoverPlan[] cloudFailoverPlanField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CloudFailoverPlan")]
        public CloudFailoverPlansCloudFailoverPlan[] CloudFailoverPlan
        {
            get
            {
                return this.cloudFailoverPlanField;
            }
            set
            {
                this.cloudFailoverPlanField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.veeam.com/ent/v1.0")]
    public partial class CloudFailoverPlansCloudFailoverPlan
    {

        private CloudFailoverPlansCloudFailoverPlanLink[] linksField;

        private string tenantUidField;

        private string tenantNameField;

        private string descriptionField;

        private CloudFailoverPlansCloudFailoverPlanCloudFailoverPlanOptions cloudFailoverPlanOptionsField;

        private CloudFailoverPlansCloudFailoverPlanCloudFailoverPlanInfo cloudFailoverPlanInfoField;

        private string hrefField;

        private string typeField;

        private string nameField;

        private string uIDField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Link", IsNullable = false)]
        public CloudFailoverPlansCloudFailoverPlanLink[] Links
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
        public string TenantUid
        {
            get
            {
                return this.tenantUidField;
            }
            set
            {
                this.tenantUidField = value;
            }
        }

        /// <remarks/>
        public string TenantName
        {
            get
            {
                return this.tenantNameField;
            }
            set
            {
                this.tenantNameField = value;
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
        public CloudFailoverPlansCloudFailoverPlanCloudFailoverPlanOptions CloudFailoverPlanOptions
        {
            get
            {
                return this.cloudFailoverPlanOptionsField;
            }
            set
            {
                this.cloudFailoverPlanOptionsField = value;
            }
        }

        /// <remarks/>
        public CloudFailoverPlansCloudFailoverPlanCloudFailoverPlanInfo CloudFailoverPlanInfo
        {
            get
            {
                return this.cloudFailoverPlanInfoField;
            }
            set
            {
                this.cloudFailoverPlanInfoField = value;
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
    public partial class CloudFailoverPlansCloudFailoverPlanLink
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
    public partial class CloudFailoverPlansCloudFailoverPlanCloudFailoverPlanOptions
    {

        private bool postFailoverPlanCommandEnabledField;

        private object postFailoverPlanCommandField;

        private bool preFailoverPlanCommandEnabledField;

        private object preFailoverPlanCommandField;

        /// <remarks/>
        public bool PostFailoverPlanCommandEnabled
        {
            get
            {
                return this.postFailoverPlanCommandEnabledField;
            }
            set
            {
                this.postFailoverPlanCommandEnabledField = value;
            }
        }

        /// <remarks/>
        public object PostFailoverPlanCommand
        {
            get
            {
                return this.postFailoverPlanCommandField;
            }
            set
            {
                this.postFailoverPlanCommandField = value;
            }
        }

        /// <remarks/>
        public bool PreFailoverPlanCommandEnabled
        {
            get
            {
                return this.preFailoverPlanCommandEnabledField;
            }
            set
            {
                this.preFailoverPlanCommandEnabledField = value;
            }
        }

        /// <remarks/>
        public object PreFailoverPlanCommand
        {
            get
            {
                return this.preFailoverPlanCommandField;
            }
            set
            {
                this.preFailoverPlanCommandField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.veeam.com/ent/v1.0")]
    public partial class CloudFailoverPlansCloudFailoverPlanCloudFailoverPlanInfo
    {

        private CloudFailoverPlansCloudFailoverPlanCloudFailoverPlanInfoIncludes includesField;

        /// <remarks/>
        public CloudFailoverPlansCloudFailoverPlanCloudFailoverPlanInfoIncludes Includes
        {
            get
            {
                return this.includesField;
            }
            set
            {
                this.includesField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.veeam.com/ent/v1.0")]
    public partial class CloudFailoverPlansCloudFailoverPlanCloudFailoverPlanInfoIncludes
    {

        private CloudFailoverPlansCloudFailoverPlanCloudFailoverPlanInfoIncludesCloudFailoveredVm cloudFailoveredVmField;

        /// <remarks/>
        public CloudFailoverPlansCloudFailoverPlanCloudFailoverPlanInfoIncludesCloudFailoveredVm CloudFailoveredVm
        {
            get
            {
                return this.cloudFailoveredVmField;
            }
            set
            {
                this.cloudFailoveredVmField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.veeam.com/ent/v1.0")]
    public partial class CloudFailoverPlansCloudFailoverPlanCloudFailoverPlanInfoIncludesCloudFailoveredVm
    {

        private string failoverPlanVMIdField;

        private string nameField;

        private byte orderField;

        private string hrefField;

        private string typeField;

        /// <remarks/>
        public string FailoverPlanVMId
        {
            get
            {
                return this.failoverPlanVMIdField;
            }
            set
            {
                this.failoverPlanVMIdField = value;
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
        public byte Order
        {
            get
            {
                return this.orderField;
            }
            set
            {
                this.orderField = value;
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
    }
}
