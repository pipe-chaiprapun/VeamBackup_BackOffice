namespace Backup.ClassLibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("backup.Reseller_Notification")]
    public partial class Reseller_Notification
    {
        public int id { get; set; }

        public int reseller_id { get; set; }

        public int? bill_id { get; set; }

        public int? invoice_id { get; set; }

        public int? waspaid_id { get; set; }

        public int? package_id { get; set; }

        public bool status_new { get; set; }

        public bool status_read { get; set; }

        public DateTime date { get; set; }

        [StringLength(50)]
        public string title { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        [Required]
        [StringLength(2)]
        public string status { get; set; }
    }
}
