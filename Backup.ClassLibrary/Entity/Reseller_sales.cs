namespace Backup.ClassLibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("backup.Reseller_sales")]
    public partial class Reseller_sales
    {
        public int id { get; set; }

        public int reseller_id { get; set; }

        public int client_id { get; set; }

        public int pck_id { get; set; }

        public int? invoice_no { get; set; }

        [StringLength(2)]
        public string invo_status { get; set; }

        public DateTime date { get; set; }
    }
}
