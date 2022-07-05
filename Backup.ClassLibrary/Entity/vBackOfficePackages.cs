namespace Backup.ClassLibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("backup.vBackOfficePackages")]
    public partial class vBackOfficePackages
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int pck_id { get; set; }

        [Column(TypeName = "money")]
        public decimal? total_price { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int vm { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "money")]
        public decimal vm_total_price { get; set; }

        [Column(TypeName = "date")]
        public DateTime? pck_start_dt { get; set; }

        [Column(TypeName = "date")]
        public DateTime? pck_end_dt { get; set; }

        [StringLength(50)]
        public string firstname { get; set; }

        [StringLength(50)]
        public string lastname { get; set; }

        [StringLength(100)]
        public string company_name { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int storage { get; set; }

        [StringLength(20)]
        public string phone_num { get; set; }

        public byte? pck_type_id { get; set; }

        [StringLength(100)]
        public string pck_type_name { get; set; }

        [StringLength(2)]
        public string status { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int cust_id { get; set; }

        public int? cart_id { get; set; }

        [StringLength(50)]
        public string payment_id { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(2)]
        public string pck_status { get; set; }

        [StringLength(15)]
        public string username { get; set; }

        public int? vcc_id { get; set; }

        public bool? premiums_storage { get; set; }

        public short? cust_type_id { get; set; }

        public int? Expr1 { get; set; }
    }

    public partial class BO_Packages_Find
    {
        public int pck_id { get; set; }
        public byte pck_type_id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string pck_status { get; set; }
    }

    public partial class BO_Report_Find
    {
        public int cust_id { get; set; }
        public string pck_status { get; set; }
    }
    public partial class BO_Packages_Block
    {
        public int vcc_id { get; set; }
        public int cust_id { get; set; }
        public int cart_id { get; set; }
    }
}
