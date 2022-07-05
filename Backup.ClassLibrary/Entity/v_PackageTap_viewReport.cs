namespace Backup.ClassLibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("backup.v_PackageTap_viewReport")]
    public partial class v_PackageTap_viewReport
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PackageNo { get; set; }

        [Column(TypeName = "money")]
        public decimal? Price { get; set; }

        [StringLength(100)]
        public string Package_type { get; set; }

        public int? Vms { get; set; }

        public int? Stroage { get; set; }

        public bool? StroageType { get; set; }

        public int? Processor { get; set; }

        public int? Ram { get; set; }

        public int? IpAddress { get; set; }

        public int? Networks { get; set; }

        public int? InternetTraffic { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime Create_at { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(2)]
        public string Status { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string Statusful { get; set; }

        public int? id_ref { get; set; }
    }
}
