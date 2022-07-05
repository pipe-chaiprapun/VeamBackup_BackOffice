using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup.ClassLibrary.Models
{

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.veeam.com/ent/v1.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.veeam.com/ent/v1.0", IsNullable = false)]
    public partial class BackupTaskSessions
    {

        private BackupTaskSessionsBackupTaskSession[] backupTaskSessionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("BackupTaskSession")]
        public BackupTaskSessionsBackupTaskSession[] BackupTaskSession
        {
            get
            {
                return this.backupTaskSessionField;
            }
            set
            {
                this.backupTaskSessionField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.veeam.com/ent/v1.0")]
    public partial class BackupTaskSessionsBackupTaskSession
    {

        private BackupTaskSessionsBackupTaskSessionLink[] linksField;

        private string jobSessionUidField;

        private System.DateTime creationTimeUTCField;

        private System.DateTime endTimeUTCField;

        private string stateField;

        private string resultField;

        private string reasonField;

        private byte totalSizeField;

        private string hrefField;

        private string typeField;

        private string nameField;

        private string uIDField;

        private string vmDisplayNameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Link", IsNullable = false)]
        public BackupTaskSessionsBackupTaskSessionLink[] Links
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
        public string JobSessionUid
        {
            get
            {
                return this.jobSessionUidField;
            }
            set
            {
                this.jobSessionUidField = value;
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
        public string Reason
        {
            get
            {
                return this.reasonField;
            }
            set
            {
                this.reasonField = value;
            }
        }

        /// <remarks/>
        public byte TotalSize
        {
            get
            {
                return this.totalSizeField;
            }
            set
            {
                this.totalSizeField = value;
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

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string VmDisplayName
        {
            get
            {
                return this.vmDisplayNameField;
            }
            set
            {
                this.vmDisplayNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.veeam.com/ent/v1.0")]
    public partial class BackupTaskSessionsBackupTaskSessionLink
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
