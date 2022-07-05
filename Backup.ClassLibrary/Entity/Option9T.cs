namespace Backup.ClassLibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("backoffice.Option9T")]
    public partial class Option9T
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(3)]
        public string Option_code { get; set; }

        [Required]
        [StringLength(50)]
        public string Option { get; set; }

        public bool use { get; set; }

        public DateTime update_dt { get; set; }

        public DateTime add_dt { get; set; }
    }
}
