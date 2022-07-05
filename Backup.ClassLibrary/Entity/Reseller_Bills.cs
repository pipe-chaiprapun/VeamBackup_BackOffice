namespace Backup.ClassLibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("backup.Reseller_Bills")]
    public partial class Reseller_Bills
    {
        public int reseller_id { get; set; }

        [Key]
        public int bill_No { get; set; }

        [StringLength(20)]
        public string month { get; set; }

        public int? sales { get; set; }

        [Column(TypeName = "money")]
        public decimal? amount { get; set; }

        [StringLength(2)]
        public string status { get; set; }

        public DateTime? create_date { get; set; }

        [StringLength(255)]
        public string comments { get; set; }

        public int? discount { get; set; }
    }
}
