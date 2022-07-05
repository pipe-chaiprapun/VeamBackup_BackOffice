namespace Backup.ClassLibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("backup.Reseller_Payment")]
    public partial class Reseller_Payment
    {
        public int id { get; set; }

        [StringLength(100)]
        public string payment_number { get; set; }

        public int bill_no { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date { get; set; }

        [StringLength(2)]
        public string status { get; set; }

        [Column(TypeName = "money")]
        public decimal? amount { get; set; }

        [StringLength(100)]
        public string destination { get; set; }

        public DateTime create_date { get; set; }

        [StringLength(255)]
        public string comment { get; set; }
    }
}
