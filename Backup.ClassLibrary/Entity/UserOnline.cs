namespace Backup.ClassLibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("backup.UserOnline")]
    public partial class UserOnline
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int cust_id { get; set; }

        [Key]
        [Column(Order = 1)]
        public bool online_status { get; set; }

        [Key]
        [Column(Order = 2)]
        public bool user_type { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime online_dt { get; set; }
    }
}
