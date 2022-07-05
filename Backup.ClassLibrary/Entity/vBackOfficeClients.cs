namespace Backup.ClassLibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("backup.vBackOfficeClients")]
    public partial class vBackOfficeClients
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int cust_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string email { get; set; }

        [StringLength(20)]
        public string phone_num { get; set; }

        [StringLength(50)]
        public string firstname { get; set; }

        [StringLength(50)]
        public string familyName { get; set; }

        [StringLength(100)]
        public string company { get; set; }

        public byte? verify { get; set; }

        public byte? block { get; set; }

        public byte? freeze { get; set; }

        public byte? delete { get; set; }

        [StringLength(100)]
        public string pck_type_name { get; set; }

        [Column(TypeName = "date")]
        public DateTime? pck_start_dt { get; set; }

        [Column(TypeName = "date")]
        public DateTime? pck_end_dt { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int pck_id { get; set; }

        [Key]
        [Column(Order = 3)]
        public byte acc_status { get; set; }

        //[Key]
        //[Column(Order = 4)]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public int vcc_id { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(12)]
        public string status { get; set; }
    }
}
