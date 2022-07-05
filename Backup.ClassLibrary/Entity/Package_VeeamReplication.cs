namespace Backup.ClassLibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("backup.Package_VeeamReplication")]
    public partial class Package_VeeamReplication
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int pck_id { get; set; }

        public int? cust_id { get; set; }

        public int? vm { get; set; }

        public int? storage { get; set; }

        public int? processor { get; set; }

        public int? ram { get; set; }

        public int? ip_address { get; set; }

        public int? networks { get; set; }

        public int? internet_traffic { get; set; }

        [Column(TypeName = "money")]
        public decimal? vm_price { get; set; }

        [Column(TypeName = "money")]
        public decimal? storage_price { get; set; }

        [Column(TypeName = "money")]
        public decimal? processor_price { get; set; }

        [Column(TypeName = "money")]
        public decimal? ram_price { get; set; }

        [Column(TypeName = "money")]
        public decimal? ip_address_price { get; set; }

        [Column(TypeName = "money")]
        public decimal? internet_traffic_price { get; set; }

        public bool? type_storage { get; set; }
    }
}
