namespace Backup.ClassLibrary.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("backup.v_Reseller_Bill")]
    public partial class v_Reseller_Bill
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int seller_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string reseller_email { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(15)]
        public string resller_id { get; set; }

        [StringLength(100)]
        public string first_name { get; set; }

        [StringLength(100)]
        public string last_name { get; set; }

        [StringLength(20)]
        public string reseller_phone { get; set; }

        [StringLength(100)]
        public string reseller_country { get; set; }

        [StringLength(100)]
        public string reseller_provine { get; set; }

        [StringLength(100)]
        public string reseller_city { get; set; }

        [StringLength(100)]
        public string reseller_adderss { get; set; }

        [StringLength(20)]
        public string reseller_postcode { get; set; }

        [StringLength(50)]
        public string reseller_role { get; set; }

        [StringLength(100)]
        public string company_name { get; set; }

        [StringLength(100)]
        public string website { get; set; }

        [StringLength(100)]
        public string company_email { get; set; }

        [StringLength(20)]
        public string company_phone { get; set; }

        [StringLength(100)]
        public string company_country { get; set; }

        [StringLength(100)]
        public string company_provine { get; set; }

        [StringLength(100)]
        public string company_city { get; set; }

        [StringLength(100)]
        public string company_adderss { get; set; }

        [StringLength(20)]
        public string company_postcode { get; set; }

        [StringLength(100)]
        public string vat_id { get; set; }

        [StringLength(2)]
        public string status { get; set; }

        [StringLength(100)]
        public string contract_number { get; set; }

        [Column(TypeName = "date")]
        public DateTime? contract_period_from { get; set; }

        [Column(TypeName = "date")]
        public DateTime? contract_period_to { get; set; }

        [StringLength(255)]
        public string contract_comment { get; set; }

        public int? contract_discount { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int bill_No { get; set; }

        [StringLength(20)]
        public string month { get; set; }

        public int? sales { get; set; }

        [Column(TypeName = "money")]
        public decimal? bill_amount { get; set; }

        [StringLength(2)]
        public string bill_status { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string bill_description { get; set; }

        public DateTime? bill_date { get; set; }

        [StringLength(255)]
        public string comments { get; set; }

        [StringLength(100)]
        public string payment_number { get; set; }

        [Column(TypeName = "date")]
        public DateTime? payment_date { get; set; }

        [StringLength(2)]
        public string payment_status { get; set; }

        [StringLength(50)]
        public string payment_description { get; set; }

        [Column(TypeName = "money")]
        public decimal? payment_amount { get; set; }

        [StringLength(100)]
        public string destination { get; set; }
    }
}
