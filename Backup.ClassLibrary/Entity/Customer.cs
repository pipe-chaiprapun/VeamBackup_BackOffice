namespace Backup.ClassLibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("backup.Customer")]
    public partial class Customer
    {
        [Key]
        public int cust_id { get; set; }

        [Required]
        [StringLength(100)]
        [RegularExpression(@"([a-zA-Z0-9]+)([_\.\-{1}])?([a-zA-Z0-9]+)\@([a-zA-Z0-9]+)([\.])([a-zA-Z\.]+)")]
        public string email { get; set; }

        [Required]
        [StringLength(255)]
        public string password { get; set; }

        public byte acc_status { get; set; }

        public DateTime regist_date { get; set; }
    }
}
