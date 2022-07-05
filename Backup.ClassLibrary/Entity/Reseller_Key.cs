namespace Backup.ClassLibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("backup.Reseller_Key")]
    public partial class Reseller_Key
    {
        public int id { get; set; }

        public int seller_id { get; set; }

        public string private_key { get; set; }

        public string public_key { get; set; }
    }
}
