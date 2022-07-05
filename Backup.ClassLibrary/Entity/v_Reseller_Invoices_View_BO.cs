namespace Backup.ClassLibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("backup.v_Reseller_Invoices_View_BO")]
    public partial class v_Reseller_Invoices_View_BO
    {
        public int? Invoice_ID { get; set; }

        public int? vcc_id { get; set; }

        [StringLength(100)]
        public string Company { get; set; }

        [StringLength(100)]
        public string client_name { get; set; }

        [StringLength(100)]
        public string client_family_name { get; set; }

        [StringLength(100)]
        public string address_prefix { get; set; }

        [StringLength(100)]
        public string country { get; set; }

        [StringLength(10)]
        public string post_code { get; set; }

        [StringLength(100)]
        public string province { get; set; }

        [StringLength(20)]
        public string client_phone { get; set; }

        [StringLength(50)]
        public string client_email { get; set; }

        [Column(TypeName = "date")]
        public DateTime? pck_start_dt { get; set; }

        [Column(TypeName = "date")]
        public DateTime? pck_end_dt { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int reseller_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int pck_id { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int client_id { get; set; }

        [StringLength(20)]
        public string Alias { get; set; }

        public bool? premiums_storage { get; set; }

        public int? storage { get; set; }

        public int? vm { get; set; }

        public int? processor { get; set; }

        public int? ram { get; set; }

        public int? internet_traffic { get; set; }

        public int? networks { get; set; }

        public int? ip_address { get; set; }

        [Column(TypeName = "money")]
        public decimal? price_storage { get; set; }

        [Column(TypeName = "money")]
        public decimal? price_vm { get; set; }

        [Column(TypeName = "money")]
        public decimal? price_processor { get; set; }

        [Column(TypeName = "money")]
        public decimal? price_ram { get; set; }

        [Column(TypeName = "money")]
        public decimal? price_internet_traffic { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int price_networks { get; set; }

        [Column(TypeName = "money")]
        public decimal? price_ip_address { get; set; }

        [Column(TypeName = "money")]
        public decimal? Sub_Total { get; set; }

        [Column(TypeName = "money")]
        public decimal? Tax { get; set; }

        [Column(TypeName = "money")]
        public decimal? Discount { get; set; }

        [Column(TypeName = "money")]
        public decimal? DiscountResize { get; set; }

        [Column(TypeName = "money")]
        public decimal? Total { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string pck_status { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(50)]
        public string invo_status { get; set; }

        [Key]
        [Column(Order = 6)]
        public DateTime pck_add_dt { get; set; }
    }
}
