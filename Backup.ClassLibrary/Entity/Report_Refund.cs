namespace Backup.ClassLibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("backup.Report_Refund")]
    public partial class Report_Refund
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int vcc_id { get; set; }

        [Column(TypeName = "text")]
        public string description { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [StringLength(50)]
        public string refund_status { get; set; }

        [StringLength(255)]
        public string operator_comment { get; set; }
    }
}
