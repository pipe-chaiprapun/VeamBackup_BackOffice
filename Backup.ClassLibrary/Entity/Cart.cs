namespace Backup.ClassLibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("backup.Cart")]
    public partial class Cart
    {
        [Key]
        public int cart_id { get; set; }

        public int cust_id { get; set; }

        [StringLength(20)]
        public string invoice_no { get; set; }

        [Column(TypeName = "money")]
        public decimal? cart_total_price { get; set; }

        [Required]
        [StringLength(3)]
        public string currency { get; set; }

        [Required]
        [StringLength(2)]
        public string status { get; set; }

        public DateTime add_dt { get; set; }
    }
}
