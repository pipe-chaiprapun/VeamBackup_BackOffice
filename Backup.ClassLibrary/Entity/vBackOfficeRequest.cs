namespace Backup.ClassLibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("backup.vBackOfficeRequest")]
    public partial class vBackOfficeRequest
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int pck_id { get; set; }

        public int? pck_id_ref { get; set; }

        [StringLength(100)]
        public string pck_type_name { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(2)]
        public string pck_status { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int cust_id { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(100)]
        public string email { get; set; }

        [StringLength(50)]
        public string firstname { get; set; }

        [StringLength(50)]
        public string lastname { get; set; }

        [StringLength(100)]
        public string company_name { get; set; }

        public int? vm { get; set; }

        public int? storage { get; set; }

        public bool? premiums_storage { get; set; }

        public int? Processor { get; set; }

        public int? Ram { get; set; }

        public int? IpAddress { get; set; }

        public int? Networks { get; set; }

        public int? InternetTraffic { get; set; }

        public int? new_vm { get; set; }

        public int? new_storage { get; set; }

        public int? new_Processor { get; set; }

        public int? new_Ram { get; set; }

        public int? new_IpAddress { get; set; }

        public int? new_Networks { get; set; }

        public int? new_InternetTraffic { get; set; }

        public int? vcc_id { get; set; }
    }
}
