namespace Backup.ClassLibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("9t_all.Package_manage")]
    public partial class Package_manage
    {
        public int Id { get; set; }

        public int pck_id { get; set; }

        [Required]
        [StringLength(50)]
        public string promo_code { get; set; }

        public int cust_id { get; set; }

        public DateTime add_dt { get; set; }
    }
}
