namespace Backup.ClassLibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("backup.v_Reseller_Order")]
    public partial class v_Reseller_Order
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int reseller_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(15)]
        public string resller_id { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int pck_id { get; set; }

        public int? invoice_no { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int client_id { get; set; }

        [StringLength(100)]
        public string client_name { get; set; }

        [StringLength(100)]
        public string client_family_name { get; set; }

        [StringLength(50)]
        public string client_email { get; set; }

        [StringLength(100)]
        public string pck_type_name { get; set; }

        public int? vm { get; set; }

        public int? storage { get; set; }

        public bool? premiums_storage { get; set; }

        public int? processor { get; set; }

        public int? ram { get; set; }

        public int? ip_address { get; set; }

        public int? networks { get; set; }

        public int? internet_traffic { get; set; }

        [StringLength(112)]
        public string specification { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string pck_status { get; set; }

        [Column(TypeName = "money")]
        public decimal? total_price { get; set; }

        [Column(TypeName = "date")]
        public DateTime? pck_start_dt { get; set; }

        [Key]
        [Column(Order = 5)]
        public DateTime pck_add_dt { get; set; }

        [Column(TypeName = "date")]
        public DateTime? pck_end_dt { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int vcc_id { get; set; }
    }
}
