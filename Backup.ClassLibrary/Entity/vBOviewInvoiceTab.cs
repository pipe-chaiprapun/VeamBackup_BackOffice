namespace Backup.ClassLibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("backup.vBOviewInvoiceTab")]
    public partial class vBOviewInvoiceTab
    {
        [StringLength(50)]
        public string payment_id { get; set; }

        [StringLength(14)]
        public string invoice_no { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(15)]
        public string username { get; set; }

        [Key]
        [Column(Order = 1)]
        public string password { get; set; }

        [StringLength(4000)]
        public string issued { get; set; }

        [StringLength(4000)]
        public string due { get; set; }

        public int? vm { get; set; }

        [Column(TypeName = "money")]
        public decimal? vm_total_price { get; set; }

        public int? storage { get; set; }

        [Column(TypeName = "money")]
        public decimal? storage_total_price { get; set; }

        [Column(TypeName = "money")]
        public decimal? cart_total_price { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? fees { get; set; }

        [StringLength(4000)]
        public string pck_start_dt { get; set; }

        [StringLength(4000)]
        public string pck_end_dt { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(100)]
        public string email { get; set; }

        [StringLength(20)]
        public string phone_num { get; set; }

        [StringLength(100)]
        public string company_name { get; set; }

        [StringLength(50)]
        public string firstname { get; set; }

        [StringLength(50)]
        public string lastname { get; set; }

        [StringLength(100)]
        public string address { get; set; }

        [StringLength(100)]
        public string country { get; set; }

        [StringLength(100)]
        public string city { get; set; }

        [StringLength(100)]
        public string province { get; set; }

        [StringLength(10)]
        public string post_code { get; set; }

        public int? processor { get; set; }

        public int? ram { get; set; }

        public int? ip_address { get; set; }

        public int? networks { get; set; }

        public int? internet_traffic { get; set; }

        [Column(TypeName = "money")]
        public decimal? vm_price { get; set; }

        [Column(TypeName = "money")]
        public decimal? storage_price { get; set; }

        [Column(TypeName = "money")]
        public decimal? processor_price { get; set; }

        [Column(TypeName = "money")]
        public decimal? ram_price { get; set; }

        [Column(TypeName = "money")]
        public decimal? ip_address_price { get; set; }

        [Column(TypeName = "money")]
        public decimal? internet_traffic_price { get; set; }

        public bool? type_storage { get; set; }

        [Key]
        [Column(Order = 3)]
        public byte pck_type_id { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int pck_id { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(20)]
        public string name { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int vcc_id { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int cust_id { get; set; }

        public int? cart_id { get; set; }

        [Key]
        [Column(Order = 8)]
        public DateTime add_dt { get; set; }

        [Column(TypeName = "money")]
        public decimal? discount { get; set; }
    }
}
