namespace Backup.ClassLibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("backup.v_Repository")]
    public partial class v_Repository
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int pck_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int cust_id { get; set; }

        [Key]
        [Column(Order = 2)]
        public byte pck_type_id { get; set; }

        public int? vm { get; set; }

        public int? storage { get; set; }

        public int? vm_vr { get; set; }

        public int? storage_vr { get; set; }

        public int? processor_vr { get; set; }

        public int? ram_vr { get; set; }

        public int? ip_address_vr { get; set; }

        public int? networks_vr { get; set; }

        public int? internet_traffic_vr { get; set; }
    }
}
