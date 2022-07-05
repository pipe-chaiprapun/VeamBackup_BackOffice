namespace Backup.ClassLibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("backup.v_BOinvoice")]
    public partial class v_BOinvoice
    {
        [StringLength(14)]
        public string invoice_no { get; set; }

        [Column(TypeName = "numeric")]
        public decimal invoice_price { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(7)]
        public string invoice_status { get; set; }

        [Column(TypeName = "date")]
        public DateTime? pck_start_dt { get; set; }

        [Column(TypeName = "date")]
        public DateTime? pck_end_dt { get; set; }

        public DateTime? suspend { get; set; }

        [StringLength(33)]
        public string package_no { get; set; }

        [StringLength(100)]
        public string pck_type_name { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(17)]
        public string package_status { get; set; }

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

        [StringLength(50)]
        public string created { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int cart_id { get; set; }

        public DateTime? suspend_dt { get; set; }

        public int? vcc_id { get; set; }

        public Guid? tenant_id { get; set; }

        [StringLength(15)]
        public string username { get; set; }

        [StringLength(20)]
        public string name { get; set; }

        [Key]
        [Column(Order = 5)]
        public DateTime add_dt { get; set; }
    }
    public class filter_invoice
    {
        public int cust_id { get; set; }
        public string invoice_no { get; set; }
        public string email { get; set; }
        public string invoice_status { get; set; }
    }
}
