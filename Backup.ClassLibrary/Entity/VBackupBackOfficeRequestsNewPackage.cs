namespace Backup.ClassLibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("backup.VBackupBackOfficeRequestsNewPackage")]
    public partial class VBackupBackOfficeRequestsNewPackage
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int pck_id { get; set; }

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

        [StringLength(20)]
        public string phone_num { get; set; }

        [StringLength(50)]
        public string firstname { get; set; }

        [StringLength(50)]
        public string lastname { get; set; }

        [StringLength(100)]
        public string company_name { get; set; }

        [StringLength(100)]
        public string pck_type_name { get; set; }

        public int? vm { get; set; }

        public int? storage { get; set; }

        public int? processor { get; set; }

        public int? ram { get; set; }

        public int? ip_address { get; set; }

        public int? networks { get; set; }

        public int? internet_traffic { get; set; }

        [StringLength(4)]
        public string premiums_backup { get; set; }

        [StringLength(2)]
        public string premiums_replication { get; set; }
    }
}

public class RequestsPackage_Find
{
    public int cust_id { get; set; }
    public string email { get; set; }

    public string pck_status { get; set; }

}