namespace Backup.ClassLibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("backup.ChatMessage")]
    public partial class ChatMessage
    {
        public int id { get; set; }

        public int cust_id { get; set; }

        public int emp_id { get; set; }

        //[Column(TypeName = "text")]
        //[Required]
        public string message { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime msg_dt { get; set; }
    }
}
