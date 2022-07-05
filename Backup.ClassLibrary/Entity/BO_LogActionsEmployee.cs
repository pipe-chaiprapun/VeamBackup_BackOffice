namespace Backup.ClassLibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("backup.BO_LogActionsEmployee")]
    public partial class BO_LogActionsEmployee
    {
        [Key]
        public int act_id { get; set; }

        [Column(TypeName = "text")]
        public string description { get; set; }

        [Column(TypeName = "text")]
        public string desc_of_entry { get; set; }

        [StringLength(20)]
        public string ip_address { get; set; }

        public int? emp_id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? log_dt { get; set; }

        [StringLength(50)]
        public string type { get; set; }
    }
}
