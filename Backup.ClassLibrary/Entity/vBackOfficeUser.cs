namespace Backup.ClassLibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("backup.vBackOfficeUser")]
    public partial class vBackOfficeUser
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(100)]
        public string position_name { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int emp_id { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(100)]
        public string emp_username { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(255)]
        public string emp_password { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string emp_fristname { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(50)]
        public string emp_lastname { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(50)]
        public string emp_permission { get; set; }

        [Key]
        [Column(Order = 7)]
        public byte emp_position { get; set; }

        [StringLength(1)]
        public string emp_status { get; set; }

        [StringLength(100)]
        public string emp_email { get; set; }
    }
}
