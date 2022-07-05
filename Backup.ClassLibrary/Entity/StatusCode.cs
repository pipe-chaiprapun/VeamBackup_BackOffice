namespace Backup.ClassLibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("backup.StatusCode")]
    public partial class StatusCode
    {
        [Key]
        [StringLength(2)]
        public string status { get; set; }

        [Required]
        [StringLength(50)]
        public string description { get; set; }
    }
}
