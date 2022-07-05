using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup.ClassLibrary.Models
{
    public class m_reseller
    {
        public int seller_id { get; set; }
        public string company_name { get; set; }
        public string website { get; set; }
        public string company_email { get; set; }
        public string company_phone { get; set; }
        public string company_country { get; set; }
        public string company_provine { get; set; }
        public string company_city { get; set; }
        public string company_address { get; set; }
        public string company_postcode { get; set; }
        public string vat_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string reseller_email { get; set; }
        public string reseller_phone { get; set; }
        public string reseller_country { get; set; }
        public string reseller_provine { get; set; }
        public string reseller_city { get; set; }
        public string reseller_address { get; set; }
        public string reseller_postcode { get; set; }
        public string reseller_role { get; set; }
        public string password { get; set; }

    }

    public class from_reseller
    {
        public string company_name { get; set; }
        public string website { get; set; }
        public string company_email { get; set; }
        public string company_phone { get; set; }
        public string company_country { get; set; }
        public string company_provine { get; set; }
        public string company_city { get; set; }
        public string company_address { get; set; }
        public string company_postcode { get; set; }
        public string vat_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string reseller_email { get; set; }
        public string reseller_phone { get; set; }
        public string reseller_country { get; set; }
        public string reseller_provine { get; set; }
        public string reseller_city { get; set; }
        public string reseller_address { get; set; }
        public string reseller_postcode { get; set; }
        public string reseller_role { get; set; }
        public string password { get; set; }
        public bool send_email { get; set; }
        public string job_title { get; set; }
        public int seller_id { get; set; }
    }

    public class from_reseller_update
    {
        public int seller_id { get; set; }
        public string company_name { get; set; }
        public string website { get; set; }
        public string company_email { get; set; }
        public string company_phone { get; set; }
        public string company_country { get; set; }
        public string company_provine { get; set; }
        public string company_city { get; set; }
        public string company_address { get; set; }
        public string company_postcode { get; set; }
        public string vat_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string reseller_email { get; set; }
        public string reseller_phone { get; set; }
        public string reseller_country { get; set; }
        public string reseller_provine { get; set; }
        public string reseller_city { get; set; }
        public string reseller_address { get; set; }
        public string reseller_postcode { get; set; }
        public string reseller_role { get; set; }
        public string contract_number { get; set; }
        public DateTime? contract_period_from { get; set; }
        public DateTime? contract_period_to { get; set; }
        public string contract_comment { get; set; }
        public int contract_discount { get; set; }
        public string job_title { get; set; }
    }

    public class from_reseller_Block
    {
        public int seller_id { get; set; }
    }

    public class from_approve
    {
        public int seller_id { get; set; }
        public string contract_num { get; set; }
        public DateTime? contract_period_from { get; set; }
        public DateTime? contract_period_to { get; set; }
        public string contract_comment { get; set; }
        public int contract_discount { get; set; }
    }

    public class from_change_status
    {
        public int bill_no { get; set; }
        public string status { get; set; }
        public string comments { get; set; }
    }

    public class m_bill
    {
        public int seller_id { get; set; }
        public string reseller_email { get; set; }
        public string resller_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string reseller_phone { get; set; }
        public string reseller_country { get; set; }
        public string reseller_provine { get; set; }
        public string reseller_city { get; set; }
        public string reseller_adderss { get; set; }
        public string reseller_postcode { get; set; }
        public string reseller_role { get; set; }
        public string company_name { get; set; }
        public string website { get; set; }
        public string company_email { get; set; }
        public string company_phone { get; set; }
        public string company_country { get; set; }
        public string company_provine { get; set; }
        public string company_city { get; set; }
        public string company_adderss { get; set; }
        public string company_postcode { get; set; }
        public string vat_id { get; set; }
        public string password { get; set; }
        public string status { get; set; }
        public string contract_number { get; set; }
        public DateTime? contract_period_from { get; set; }
        public DateTime? contract_period_to { get; set; }
        public string contract_comment { get; set; }
        public int? contract_discount { get; set; }
        public string private_key { get; set; }
        public string public_key { get; set; }
        public int bill_No { get; set; }
        public string month { get; set; }
        public int? sales { get; set; }
        public decimal? bill_amount { get; set; }
        public string bill_status { get; set; }
        public DateTime? bill_date { get; set; }
        public string comments { get; set; }
        public string payment_number { get; set; }
        public DateTime? payment_date { get; set; }
        public string payment_status { get; set; }
        public decimal? payment_amount { get; set; }
        public string destination { get; set; }
       
    }

    public class m_viewbill
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int reseller_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string reseller_email { get; set; }

        [StringLength(100)]
        public string first_name { get; set; }

        [StringLength(100)]
        public string last_name { get; set; }

        [StringLength(100)]
        public string company_name { get; set; }

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

        public int? discount { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int bill_no { get; set; }

        [StringLength(20)]
        public string month { get; set; }

        public int? sales { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string bill_status { get; set; }

        public DateTime? bill_create_date { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int client_id { get; set; }

        public int? invoice_no { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int pck_id { get; set; }

        [Key]
        [Column(Order = 6)]
        public byte pck_type_id { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(20)]
        public string vem_name { get; set; }

        [Key]
        [Column(Order = 8)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int vcc_id { get; set; }

        [Column(TypeName = "money")]
        public decimal? pck_price { get; set; }

        [StringLength(3)]
        public string currency { get; set; }

        [Key]
        [Column(Order = 9)]
        [StringLength(50)]
        public string pck_status { get; set; }

        [Column(TypeName = "date")]
        public DateTime? pck_start_dt { get; set; }

        [Column(TypeName = "date")]
        public DateTime? pck_end_dt { get; set; }
    }

    public class m_sendbill
    {
        public int bill_no { get; set; }
    }

    public partial class v_Reseller_show
    {
        public int seller_id { get; set; }
        public string reseller_email { get; set; }
        public string resller_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string reseller_phone { get; set; }
        public string reseller_country { get; set; }
        public string reseller_provine { get; set; }
        public string reseller_city { get; set; }
        public string reseller_adderss { get; set; }
        public string reseller_postcode { get; set; }
        public string reseller_role { get; set; }
        public string company_name { get; set; }
        public string website { get; set; }
        public string company_email { get; set; }
        public string company_phone { get; set; }
        public string company_country { get; set; }
        public string company_provine { get; set; }
        public string company_city { get; set; }
        public string company_adderss { get; set; }
        public string company_postcode { get; set; }
        public string vat_id { get; set; }
        public string password { get; set; }
        public string status { get; set; }
        public string contract_number { get; set; }
        public string contract_period_from { get; set; }
        public string contract_period_to { get; set; }
        public string contract_comment { get; set; }
        public int? contract_discount { get; set; }
        public string private_key { get; set; }
        public string public_key { get; set; }
        public string job_title { get; set; }
    }

}
