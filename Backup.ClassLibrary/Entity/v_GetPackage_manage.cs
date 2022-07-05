namespace Backup.ClassLibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("backoffice.v_GetPackage_manage")]
    public partial class v_GetPackage_manage
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int pck_id { get; set; }

        [StringLength(50)]
        public string firstname { get; set; }

        [StringLength(50)]
        public string lastname { get; set; }

        [StringLength(50)]
        public string type { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime add_dt { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string promo_code { get; set; }

        public int? vcc_id { get; set; }

        [StringLength(100)]
        public string pck_type_name { get; set; }
    }
}
