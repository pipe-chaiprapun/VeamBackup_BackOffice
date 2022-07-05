namespace Backup.ClassLibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("backup.Address")]
    public partial class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int cust_id { get; set; }

        [StringLength(100)]
        public string company_name { get; set; }

        [StringLength(50)]
        public string firstname { get; set; }

        [StringLength(50)]
        public string lastname { get; set; }

        [StringLength(20)]
        public string phone_num { get; set; }

        [Column("address")]
        [StringLength(100)]
        public string address { get; set; }

        [StringLength(100)]
        public string country { get; set; }

        [StringLength(100)]
        public string city { get; set; }

        [StringLength(100)]
        public string province { get; set; }

        [StringLength(10)]
        public string post_code { get; set; }
    }
}
