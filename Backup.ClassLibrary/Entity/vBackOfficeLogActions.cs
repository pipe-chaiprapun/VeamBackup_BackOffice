namespace Backup.ClassLibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("backup.vBackOfficeLogActions")]
    public partial class vBackOfficeLogActions
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int act_id { get; set; }

        public DateTime? log_dt { get; set; }

        [StringLength(50)]
        public string type { get; set; }

        [Column(TypeName = "text")]
        public string description { get; set; }

        [Column(TypeName = "text")]
        public string desc_of_entry { get; set; }

        [StringLength(20)]
        public string ip_address { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string emp_username { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string emp_fristname { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string emp_lastname { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string emp_permission { get; set; }

        [Key]
        [Column(Order = 5)]
        public byte emp_position { get; set; }
    }


    public partial class BO_LogAction_Find
    {
        public string date_from { get; set; }
        public string date_to { get; set; }
        public string role { get; set; }
    }

    public partial class BO_LogAction_page
    {
        public string page { get; set; }
        public string pageaction { get; set; }
    }
}
