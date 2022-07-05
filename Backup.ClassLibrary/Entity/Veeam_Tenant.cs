namespace Backup.ClassLibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("backup.Veeam_Tenant")]
    public partial class Veeam_Tenant
    {
        [Key]
        public int vcc_id { get; set; }

        public Guid? tenant_id { get; set; }

        public int cust_id { get; set; }

        [Required]
        [StringLength(20)]
        public string name { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Required]
        [StringLength(15)]
        public string username { get; set; }

        [Required]
        public string password { get; set; }

        public DateTime create_dt { get; set; }

        [Column(TypeName = "date")]
        public DateTime? start_dt { get; set; }

        [Column(TypeName = "date")]
        public DateTime end_dt { get; set; }

        public int? pck_id { get; set; }
    }
}
