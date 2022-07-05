namespace Backup.ClassLibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("backup.Reseller_Address")]
    public partial class Reseller_Address
    {
        public int id { get; set; }

        public int seller_id { get; set; }

        [StringLength(100)]
        public string first_name { get; set; }

        [StringLength(100)]
        public string last_name { get; set; }

        [StringLength(20)]
        public string reseller_phone { get; set; }

        [StringLength(100)]
        public string country { get; set; }

        [StringLength(100)]
        public string provine { get; set; }

        [StringLength(100)]
        public string city { get; set; }

        [StringLength(100)]
        public string adderss { get; set; }

        [StringLength(20)]
        public string postcode { get; set; }

        [StringLength(50)]
        public string role { get; set; }

        [StringLength(100)]
        public string job_title { get; set; }
    }
}
