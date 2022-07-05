namespace Backup.ClassLibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("backup.CustomerOnline")]
    public partial class CustomerOnline
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int cust_id { get; set; }

        public bool online_status { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime online_dt { get; set; }
    }
}