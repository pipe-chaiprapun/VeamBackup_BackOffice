namespace Backup.ClassLibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("backup.v_Invovice_tap")]
    public partial class v_Invovice_tap
    {
        [StringLength(14)]
        public string Invoice_no { get; set; }

        [StringLength(50)]
        public string Invoice_status { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string Package_status { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(100)]
        public string Firstname { get; set; }

        [StringLength(100)]
        public string Lastname { get; set; }

        [StringLength(100)]
        public string Company { get; set; }

        [StringLength(100)]
        public string Package_type { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Start_dt { get; set; }

        [Column(TypeName = "date")]
        public DateTime? End_dt { get; set; }

        public int? ClientId { get; set; }

        [StringLength(50)]
        public string ClientType { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(8)]
        public string Created { get; set; }

        public int? temp_pck_id { get; set; }

        public int? temp_vcc_id { get; set; }

        public int? temp_cart_id { get; set; }

        public int? temp_cust_type_id { get; set; }
    }
}
