namespace Backup.ClassLibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("backup.BO_Employee")]
    public partial class BO_Employee
    {
        [Key]
        public int emp_id { get; set; }

        [StringLength(100)]
        public string emp_email { get; set; }

        [Required]
        [StringLength(100)]
        public string emp_username { get; set; }

        [Required]
        [StringLength(255)]
        public string emp_password { get; set; }

        [StringLength(255)]
        public string emp_pin { get; set; }

        [Required]
        [StringLength(50)]
        public string emp_fristname { get; set; }

        [Required]
        [StringLength(50)]
        public string emp_lastname { get; set; }

        [Required]
        [StringLength(50)]
        public string emp_permission { get; set; }

        public byte emp_position { get; set; }

        [StringLength(1)]
        public string emp_status { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime register_date { get; set; }
    }


    [Table("backup.vBackOfficeUser")]
    public partial class BO_Employee_Find
    {

        public int emp_id { get; set; }
        public string emp_username { get; set; }

        public string emp_fristname { get; set; }

        public string emp_lastname { get; set; }

        public byte emp_position { get; set; }

        public string emp_status { get; set; }

        public string emp_email { get; set; }

    }

}
