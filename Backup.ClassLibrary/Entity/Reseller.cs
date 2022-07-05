namespace Backup.ClassLibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("backup.Reseller")]
    public partial class Reseller
    {
        [Key]
        public int seller_id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Required]
        [StringLength(15)]
        public string resller_id { get; set; }

        [Required]
        [StringLength(100)]
        public string email { get; set; }

        [Required]
        [StringLength(255)]
        public string password { get; set; }

        [StringLength(2)]
        public string status { get; set; }

        public DateTime? add_date { get; set; }
    }
}
