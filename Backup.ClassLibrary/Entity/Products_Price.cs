namespace Backup.ClassLibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("backup.Products_Price")]
    public partial class Products_Price
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int products_id { get; set; }

        public byte pck_type_id { get; set; }

        [Required]
        [StringLength(50)]
        public string products_name { get; set; }

        [Column(TypeName = "money")]
        public decimal price { get; set; }

        [Required]
        [StringLength(3)]
        public string currency { get; set; }

        public decimal quantity { get; set; }

        [Required]
        [StringLength(20)]
        public string unit { get; set; }

        public DateTime? update_dt { get; set; }
    }
}
