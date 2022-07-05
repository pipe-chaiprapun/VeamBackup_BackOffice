namespace Backup.ClassLibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("backup.BO_Position")]
    public partial class BO_Position
    {
        [Key]
        public byte position_id { get; set; }

        [Required]
        [StringLength(100)]
        public string position_name { get; set; }
    }
}
