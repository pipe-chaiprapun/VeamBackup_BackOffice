namespace Backup.ClassLibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("backup.Log_SignIn")]
    public partial class Log_SignIn
    {
        [Key]
        public int log_id { get; set; }

        public int? cust_id { get; set; }

        [StringLength(15)]
        public string ip { get; set; }

        [StringLength(100)]
        public string country { get; set; }

        [StringLength(100)]
        public string browser { get; set; }

        [StringLength(100)]
        public string device_name { get; set; }

        public bool signin { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime signin_dt { get; set; }
    }
}
