namespace Backup.ClassLibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("backup.Reseller_Contract")]
    public partial class Reseller_Contract
    {
        public int id { get; set; }

        public int seller_id { get; set; }

        [StringLength(100)]
        public string contract_num { get; set; }

        [Column(TypeName = "date")]
        public DateTime? contract_period_from { get; set; }

        [Column(TypeName = "date")]
        public DateTime? contract_period_to { get; set; }

        [StringLength(255)]
        public string contract_comment { get; set; }

        public int? contract_discount { get; set; }
    }
}
