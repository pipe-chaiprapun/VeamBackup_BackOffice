namespace Backup.ClassLibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("backup.Packages")]
    public partial class Packages2
    {
        [Key]
        public int pck_id { get; set; }

        public int cust_id { get; set; }

        public int? cart_id { get; set; }

        public byte pck_type_id { get; set; }

        [Column(TypeName = "money")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal? total_price { get; set; }

        [StringLength(3)]
        public string currency { get; set; }

        [Required]
        [StringLength(2)]
        public string pck_status { get; set; }

        public DateTime pck_add_dt { get; set; }

        [Column(TypeName = "date")]
        public DateTime pck_start_dt { get; set; }

        [Column(TypeName = "date")]
        public DateTime? pck_end_dt { get; set; }

        public int? pck_id_ref { get; set; }

        public bool? freetrial { get; set; }

        public DateTime? suspend_dt { get; set; }
    }
}
