namespace Backup.ClassLibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("backup.Reseller_Company")]
    public partial class Reseller_Company
    {
        public int id { get; set; }

        public int seller_id { get; set; }

        [StringLength(100)]
        public string company_name { get; set; }

        [StringLength(100)]
        public string website { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        [StringLength(20)]
        public string company_phone { get; set; }

        [StringLength(100)]
        public string country { get; set; }

        [StringLength(100)]
        public string provine { get; set; }

        [StringLength(100)]
        public string city { get; set; }

        [StringLength(100)]
        public string adderss { get; set; }

        [StringLength(20)]
        public string postcode { get; set; }

        [StringLength(100)]
        public string vat_id { get; set; }
    }
}
