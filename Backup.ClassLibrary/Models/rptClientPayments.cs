using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup.ClassLibrary.Models
{
    public class ReportPayment
    {
        public int PAYMENT_ID { get; set; }

        public string DUEDATE { get; set; }

        public decimal TOTAL { get; set; }

        public decimal OUTSTANDING { get; set; }

        public string STATUS { get; set; }
    }

    public class ReportClientActivity
    {
        public int cust_id { get; set; }

        public string browser { get; set; }

        public string Placelocation { get; set; }

        public string DateTimeDiff { get; set; }

        public DateTime signin_dt { get; set; }
    }

    public class ReportClientBackUps
    {
        public int Number { get; set; }

        public string DateTimes { get; set; }

        public string Duration { get; set; }

        public string Status { get; set; }

        public string MBs { get; set; }

        public string Warnnings { get; set; }

        public string Errors { get; set; }

    }
}
