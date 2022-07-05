namespace Backup.ClassLibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("backup.BackOfficePaypalRefund")]
    public partial class BackOfficePaypalRefund
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int vcc_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int pck_id { get; set; }

        [StringLength(17)]
        public string pck_type { get; set; }

        [StringLength(36)]
        public string specification { get; set; }

        [Column(TypeName = "money")]
        public decimal? price { get; set; }

        [StringLength(4)]
        public string pck_status { get; set; }

        [Column(TypeName = "date")]
        public DateTime? pck_start_dt { get; set; }

        [Column(TypeName = "date")]
        public DateTime? pck_end_dt { get; set; }

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

        [StringLength(8)]
        public string created { get; set; }

        [StringLength(14)]
        public string invoice_no { get; set; }

        [Column(TypeName = "text")]
        public string description { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string refund_status { get; set; }

        [StringLength(255)]
        public string operator_comment { get; set; }
    }
    public partial class BO_Refund_Find
    {
        public int cust_id { get; set; }
        public string email { get; set; }
        public int invoice_id { get; set; }
        public int pck_id { get; set; }
        public string pck_type_name { get; set; }
    }

    public partial class BO_Refund_Update
    {
        public int pck_id { get; set; }  
        public int vcc_id { get; set; }
    }

    public partial class BO_Refund_Comment
    {
        public int pck_id { get; set; }
        public int vcc_id { get; set; }
        public string operator_comment { get; set; }
    }
}
