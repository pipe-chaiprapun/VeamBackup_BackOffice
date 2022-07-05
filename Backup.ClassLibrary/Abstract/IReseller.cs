using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backup.ClassLibrary.Models;
using Backup.ClassLibrary.Entity;

namespace Backup.ClassLibrary.Abstract
{
    public interface IReseller
    {
        v_Reseller addReseller(from_reseller val);

        bool updateReseller(from_reseller_update val);
        bool removeReseller(int id);
        Reseller approve_Reseller(Reseller_Contract val);

        Reseller blockReseller(from_reseller_Block val);

        IEnumerable<v_Reseller> GetReseller { get; }
        v_Reseller_show Get_Reseller(int id);

        Reseller_Payment get_Payment(string id);

        Reseller_Bills change_status(from_change_status val);
        IEnumerable<v_Reseller_Bill> GetBill { get; }
        Guid setToken(string email,int id);

        IEnumerable<v_Reseller_Order> GetReseller_Order { get; }

        //void SendBill(int bill_no, string name, string month, int? sales, string amount);
        string send(int bill_no);


        void Bill_was_paid_to_email(int bill_no);

        IEnumerable<StatusCode> GetStatusCode();

        Reseller_Notification add_noti_was_paid(int bill_no, int payment_id);

        IEnumerable<m_viewbill> show_view_bill(int bill_no);
    }
}
