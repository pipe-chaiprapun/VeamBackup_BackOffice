namespace Backup.ClassLibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("backup.v_PackageTap")]
    public partial class v_PackageTap
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PackageNo { get; set; }

        [StringLength(100)]
        public string Type { get; set; }

        public decimal? PriceTotal { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Status { get; set; }

        [StringLength(50)]
        public string UserType { get; set; }

        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(15)]
        public string ClientID { get; set; }

        public int? Vms { get; set; }

        public int? Stroage { get; set; }

        public bool? StroageType { get; set; }

        public int? Processor { get; set; }

        public int? Ram { get; set; }

        public int? IpAddress { get; set; }

        public int? Networks { get; set; }

        public int? InternetTraffic { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Family { get; set; }

        [StringLength(100)]
        public string Company { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        public int? buff_cart_id { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int buff_vcc_id { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int buff_pck_id { get; set; }

        [Key]
        [Column(Order = 5)]
        public byte buff_pck_type_id { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(2)]
        public string buff_pck_status { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int buff_cust_id { get; set; }

        public short? buff_cust_type_id { get; set; }
    }
}
