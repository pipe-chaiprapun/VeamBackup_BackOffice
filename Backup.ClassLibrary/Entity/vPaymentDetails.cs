namespace Backup.ClassLibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("backup.vPaymentDetails")]
    public partial class vPaymentDetails
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string payment_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string invoice_no { get; set; }

        [StringLength(20)]
        public string state { get; set; }

        public DateTime? payment_dt { get; set; }

        [StringLength(100)]
        public string payer_email { get; set; }

        [StringLength(100)]
        public string payer_status { get; set; }

        [StringLength(100)]
        public string first_name { get; set; }

        [StringLength(100)]
        public string last_name { get; set; }

        [StringLength(100)]
        public string address_name { get; set; }

        [StringLength(100)]
        public string address_street { get; set; }

        [StringLength(100)]
        public string address_city { get; set; }

        [StringLength(100)]
        public string address_state { get; set; }

        [StringLength(100)]
        public string address_country_code { get; set; }

        [StringLength(100)]
        public string address_zip { get; set; }

        [StringLength(100)]
        public string residence_country { get; set; }

        [StringLength(100)]
        public string txn_id { get; set; }

        [StringLength(100)]
        public string mc_currency { get; set; }

        [StringLength(100)]
        public string txn_type { get; set; }

        [Column(TypeName = "money")]
        public decimal? cart_total_price { get; set; }
    }
}
