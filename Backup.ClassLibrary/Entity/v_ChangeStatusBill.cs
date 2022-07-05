namespace Backup.ClassLibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("backup.v_ChangeStatusBill")]
    public partial class v_ChangeStatusBill
    {
        public long? id { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int reseller_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int bill_No { get; set; }

        [StringLength(20)]
        public string month { get; set; }

        [StringLength(2)]
        public string status { get; set; }

        public DateTime? create_date { get; set; }

        [StringLength(255)]
        public string comments { get; set; }

        public int? discount { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int pck_id { get; set; }

        public int? invoice_no { get; set; }

        [StringLength(2)]
        public string invo_status { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime date { get; set; }
    }
}
