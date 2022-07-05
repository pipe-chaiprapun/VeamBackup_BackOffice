namespace Backup.ClassLibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("backup.v_Products_Price")]
    public partial class v_Products_Price
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int products_id { get; set; }

        [Key]
        [Column(Order = 1)]
        public byte pck_type_id { get; set; }

        [StringLength(100)]
        public string pck_type_name { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string products_name { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "money")]
        public decimal price { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(3)]
        public string currency { get; set; }

        [Key]
        [Column(Order = 5)]
        public decimal quantity { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(20)]
        public string unit { get; set; }

        public DateTime? update_dt { get; set; }
    }
}
