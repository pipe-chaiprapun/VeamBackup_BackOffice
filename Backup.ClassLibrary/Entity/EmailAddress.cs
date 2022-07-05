namespace Backup.ClassLibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("backup.EmailAddress")]
    public partial class EmailAddress
    {
        [Key]
        public int email_id { get; set; }

        public int cust_id { get; set; }

        [Required]
        [StringLength(100)]
        public string email { get; set; }

        public byte status { get; set; }

        public bool email_primary { get; set; }

        public Guid token { get; set; }

        public DateTime add_dt { get; set; }
    }
}
