namespace Backup.ClassLibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("backup.v_Get_InvoviceById_package_replication_resaller")]
    public partial class v_Get_InvoviceById_package_replication_resaller
    {
        [StringLength(20)]
        public string Alias { get; set; }

        [StringLength(15)]
        public string Username { get; set; }

        public string Password { get; set; }

        public int? Invoice_no { get; set; }

        [StringLength(2)]
        public string Invoice_status { get; set; }

        [Key]
        [Column(Order = 0)]
        public DateTime Issued { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Due { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Start_dt { get; set; }

        [Column(TypeName = "date")]
        public DateTime? End_dt { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(20)]
        public string PhoneNum { get; set; }

        [StringLength(100)]
        public string Company { get; set; }

        [StringLength(100)]
        public string Firstname { get; set; }

        [StringLength(100)]
        public string Lastname { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        [StringLength(100)]
        public string Country { get; set; }

        [StringLength(100)]
        public string City { get; set; }

        [StringLength(100)]
        public string Province { get; set; }

        [StringLength(20)]
        public string PostCode { get; set; }

        public int? Vm { get; set; }

        public int? Storage { get; set; }

        public bool? StorageType { get; set; }

        public int? Processor { get; set; }

        public int? Ram { get; set; }

        public int? IpAddress { get; set; }

        public int? Networks { get; set; }

        public int? Traffic { get; set; }

        [Column(TypeName = "money")]
        public decimal? VmPrice { get; set; }

        [Column(TypeName = "money")]
        public decimal? StoragePrice { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProcessorPrice { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RamPrice { get; set; }

        [Column(TypeName = "money")]
        public decimal? IpAddressPrice { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NetworksPrice { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TrafficPrice { get; set; }

        [Column(TypeName = "money")]
        public decimal? SupTotal { get; set; }

        [Column(TypeName = "money")]
        public decimal? DiscountResaller { get; set; }

        [Column(TypeName = "money")]
        public decimal? Discount { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Fees { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Total { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int temp_pck_id { get; set; }

        public int? temp_pck_id_ref { get; set; }

        public int? temp_vcc_id { get; set; }
    }
}
