namespace Backup.ClassLibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("backup.Paypal_Refund")]
    public partial class Paypal_Refund
    {
        public int id { get; set; }

        public int pck_id { get; set; }

        [StringLength(100)]
        public string pck_type_name { get; set; }

        [StringLength(100)]
        public string specifcation { get; set; }

        [StringLength(50)]
        public string price { get; set; }

        [StringLength(2)]
        public string pck_status { get; set; }

        [Column(TypeName = "date")]
        public DateTime? pck_start_dt { get; set; }

        [Column(TypeName = "date")]
        public DateTime? pck_end_dt { get; set; }

        public int cust_id { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [StringLength(50)]
        public string family { get; set; }

        [StringLength(100)]
        public string company_name { get; set; }

        [StringLength(100)]
        public string created { get; set; }

        public int? invoice_id { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        [StringLength(50)]
        public string refund_status { get; set; }

        [StringLength(255)]
        public string commemt { get; set; }
    }
}
