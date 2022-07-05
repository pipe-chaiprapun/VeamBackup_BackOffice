namespace Backup.ClassLibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("backup.Package_Type")]
    public partial class Package_Type
    {
        [Key]
        public byte pck_type_id { get; set; }

        [StringLength(100)]
        public string pck_type_name { get; set; }
    }
}
