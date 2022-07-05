using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup.ClassLibrary.Models.Veeam
{
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.veeam.com/ent/v1.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.veeam.com/ent/v1.0", IsNullable = false)]
    public partial class Repositories
    {

        private RepositoriesRepository repositoryField;

        /// <remarks/>
        public RepositoriesRepository Repository
        {
            get
            {
                return this.repositoryField;
            }
            set
            {
                this.repositoryField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.veeam.com/ent/v1.0")]
    public partial class RepositoriesRepository
    {

        private RepositoriesRepositoryLink[] linksField;

        private ulong capacityField;

        private ulong freeSpaceField;

        private string kindField;

        private string hrefField;

        private string typeField;

        private string nameField;

        private string uIDField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Link", IsNullable = false)]
        public RepositoriesRepositoryLink[] Links
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
        public ulong Capacity
        {
            get
            {
                return this.capacityField;
            }
            set
            {
                this.capacityField = value;
            }
        }

        /// <remarks/>
        public ulong FreeSpace
        {
            get
            {
                return this.freeSpaceField;
            }
            set
            {
                this.freeSpaceField = value;
            }
        }

        /// <remarks/>
        public string Kind
        {
            get
            {
                return this.kindField;
            }
            set
            {
                this.kindField = value;
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
    public partial class RepositoriesRepositoryLink
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
