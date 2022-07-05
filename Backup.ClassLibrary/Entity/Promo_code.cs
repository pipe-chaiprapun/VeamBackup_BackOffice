namespace Backup.ClassLibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("9t_all.Promo_code")]
    public partial class Promo_code
    {
        public int Id { get; set; }

        [Column("promo_code")]
        [Required]
        [StringLength(50)]
        public string promo_code { get; set; }

        public double discount { get; set; }

        public DateTime expired_dt { get; set; }

        public DateTime add_dt { get; set; }

        [StringLength(2)]
        public string staus { get; set; }
    }
}
