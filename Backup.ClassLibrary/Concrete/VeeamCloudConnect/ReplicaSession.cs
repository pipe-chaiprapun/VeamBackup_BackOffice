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
    public partial class ReplicaJobSessions
    {

        private ReplicaJobSessionsReplicaJobSession[] replicaJobSessionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ReplicaJobSession")]
        public ReplicaJobSessionsReplicaJobSession[] ReplicaJobSession
        {
            get
            {
                return this.replicaJobSessionField;
            }
            set
            {
                this.replicaJobSessionField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.veeam.com/ent/v1.0")]
    public partial class ReplicaJobSessionsReplicaJobSession
    {

        private ReplicaJobSessionsReplicaJobSessionLink[] linksField;

        private string jobUidField;

        private string jobNameField;

        private string jobTypeField;

        private System.DateTime creationTimeUTCField;

        private System.DateTime endTimeUTCField;

        private string stateField;

        private string resultField;

        private byte progressField;

        private bool isRetryField;

        private string hrefField;

        private string typeField;

        private string nameField;

        private string uIDField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Link", IsNullable = false)]
        public ReplicaJobSessionsReplicaJobSessionLink[] Links
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
        public string JobUid
        {
            get
            {
                return this.jobUidField;
            }
            set
            {
                this.jobUidField = value;
            }
        }

        /// <remarks/>
        public string JobName
        {
            get
            {
                return this.jobNameField;
            }
            set
            {
                this.jobNameField = value;
            }
        }

        /// <remarks/>
        public string JobType
        {
            get
            {
                return this.jobTypeField;
            }
            set
            {
                this.jobTypeField = value;
            }
        }

        /// <remarks/>
        public System.DateTime CreationTimeUTC
        {
            get
            {
                return this.creationTimeUTCField;
            }
            set
            {
                this.creationTimeUTCField = value;
            }
        }

        /// <remarks/>
        public System.DateTime EndTimeUTC
        {
            get
            {
                return this.endTimeUTCField;
            }
            set
            {
                this.endTimeUTCField = value;
            }
        }

        /// <remarks/>
        public string State
        {
            get
            {
                return this.stateField;
            }
            set
            {
                this.stateField = value;
            }
        }

        /// <remarks/>
        public string Result
        {
            get
            {
                return this.resultField;
            }
            set
            {
                this.resultField = value;
            }
        }

        /// <remarks/>
        public byte Progress
        {
            get
            {
                return this.progressField;
            }
            set
            {
                this.progressField = value;
            }
        }

        /// <remarks/>
        public bool IsRetry
        {
            get
            {
                return this.isRetryField;
            }
            set
            {
                this.isRetryField = value;
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
    public partial class ReplicaJobSessionsReplicaJobSessionLink
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


}
