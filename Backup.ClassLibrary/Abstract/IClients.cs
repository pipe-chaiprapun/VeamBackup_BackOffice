using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backup.ClassLibrary.Entity;
using Backup.ClassLibrary.Models;

namespace Backup.ClassLibrary.Abstract
{
    public interface IClients
    {
        Log_SignIn GetInfo(int cust_id, string browser, string ip_address);

        IEnumerable<vBackOfficeClients> getAllClients { get; }
        IEnumerable<vBackOfficeClients_new> getAllClients_new { get; }
        IEnumerable<Veeam_Tenant> getAllClientsVcc { get; }

        int UserAction(int emp_id, int cust_id, int current_state, int verify, int block, int freeze, int delete);

        IEnumerable<ReportClientActivity> ClientActivityReports(int CusId);

        IEnumerable<ReportPayment> ClientPaymentReports(int CusId);

        IEnumerable<ReportClientBackUps> ClientBackupsReports(int customerId);

        IEnumerable<ClientInfo> getClientInfo(int ClientId);
    }
}
