namespace Backup.ClassLibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("backup.vBackOfficePayments")]
    public partial class vBackOfficePayments
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(7)]
        public string pck_status { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int pck_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? pck_end_dt { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(15)]
        public string username { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(1)]
        public string password { get; set; }

        [StringLength(50)]
        public string firstname { get; set; }

        [StringLength(50)]
        public string lastname { get; set; }

        [StringLength(100)]
        public string company_name { get; set; }

        [StringLength(20)]
        public string phone_num { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(2)]
        public string pck_statusId { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? total_price { get; set; }

        [Key]
        [Column(Order = 5)]
        public byte pck_type_id { get; set; }

        [StringLength(100)]
        public string pck_type_name { get; set; }

        [Key]
        [Column(Order = 6)]
        public DateTime add_dt { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(50)]
        public string payment_id { get; set; }

        [Key]
        [Column(Order = 8)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int cust_id { get; set; }

        [StringLength(50)]
        public string type { get; set; }

        [Key]
        [Column(Order = 9)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short cust_type_id { get; set; }

        public int? vm { get; set; }

        public int? storage { get; set; }

        [Key]
        [Column(Order = 10)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int vcc_id { get; set; }

        [StringLength(14)]
        public string invoice_no { get; set; }
    }
}
