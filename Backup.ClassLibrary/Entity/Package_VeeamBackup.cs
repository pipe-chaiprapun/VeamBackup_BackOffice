namespace Backup.ClassLibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("backup.Package_VeeamBackup")]
    public partial class Package_VeeamBackup
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int pck_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int vm { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int storage { get; set; }

        public bool? premiums_storage { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "money")]
        public decimal vm_total_price { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "money")]
        public decimal storage_total_price { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(3)]
        public string currency { get; set; }
    }
}
