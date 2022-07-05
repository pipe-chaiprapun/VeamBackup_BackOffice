namespace Backup.ClassLibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("backup.v_Reseller_Invoices_BO")]
    public partial class v_Reseller_Invoices_BO
    {
        public int? Invoice_No { get; set; }

        [Column(TypeName = "money")]
        public decimal? Invoice_Price { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string Invoice_status { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Start_Date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? End_date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Suspend { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Package_No { get; set; }

        [StringLength(100)]
        public string Package_type { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string Package_status { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Client_ID { get; set; }

        [StringLength(50)]
        public string Client_Email { get; set; }

        [StringLength(100)]
        public string Client_Name { get; set; }

        [StringLength(100)]
        public string Client_Family { get; set; }

        [StringLength(100)]
        public string Company { get; set; }

        [Key]
        [Column(Order = 4)]
        public DateTime Created { get; set; }

        public int vcc_id { get; set; }
    }
}
