namespace Backup.ClassLibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("backup.Customer_Notification")]
    public partial class Customer_Notification
    {
        public int? cust_id { get; set; }

        [Key]
        [Column(Order = 0)]
        public bool pck_sys_create { get; set; }

        [Key]
        [Column(Order = 1)]
        public bool pck_sys_expire { get; set; }

        [Key]
        [Column(Order = 2)]
        public bool pck_sys_request { get; set; }

        [Key]
        [Column(Order = 3)]
        public bool pck_sys_suspend { get; set; }

        [Key]
        [Column(Order = 4)]
        public bool inv_sys_new { get; set; }

        [Key]
        [Column(Order = 5)]
        public bool inv_sys_over { get; set; }

        [Key]
        [Column(Order = 6)]
        public bool new_sys_promotion { get; set; }

        [Key]
        [Column(Order = 7)]
        public bool new_sys_new { get; set; }
    }
}
