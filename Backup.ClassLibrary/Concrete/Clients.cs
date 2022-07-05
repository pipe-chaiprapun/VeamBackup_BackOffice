using Backup.ClassLibrary.Abstract;
using Backup.ClassLibrary.Entity;
using Backup.ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup.ClassLibrary.Concrete
{
    public class Clients : IClients
    {
        private BackOfficeDB db = new BackOfficeDB();
        public Log_SignIn GetInfo(int cust_id, string browser, string ip_address)
        {
            string country = "";
            string OS = "Windows";
            string device_name = System.Environment.MachineName;
            Log_SignIn logObj = new Log_SignIn
            {
                cust_id = cust_id,
                browser = browser,
                ip = ip_address,
                device_name = device_name + ", " + OS,
                country = country
            };
            return logObj;
        }

        public IEnumerable<vBackOfficeClients> getAllClients
        {
            get { return db.Database.SqlQuery<vBackOfficeClients>("SELECT * from [backup].[vBackOfficeClients] AS c Order by c.cust_id DESC"); }
        }

        public IEnumerable<Veeam_Tenant> getAllClientsVcc
        {
            get { return db.Database.SqlQuery<Veeam_Tenant>("SELECT * from [backup].[Veeam_Tenant]").ToList(); }
        }

        public IEnumerable<vBackOfficeClients_new> getAllClients_new
        {
            get { return db.vBackOfficeClients_new; }
        } 

        public IEnumerable<ClientInfo> getClientInfo(int ClientId)
        {
            return db.Database.SqlQuery<ClientInfo>("[backup].[getCustomerInfo] @cust_id", new SqlParameter("@cust_id", ClientId)).ToList();
        }


        public int UserAction(int emp_id, int cust_id, int current, int verify, int block, int freeze, int delete)
        {
            int _verify = (current == 1) ? current : verify;
            int _block = (current == 2) ? current : block;
            int _freeze = (current == 3) ? current : freeze;
            int _delete = (current == 4) ? current : delete;

            return (db.Database.ExecuteSqlCommand("[backup].[s_newlog_client_state]  @emp_id, @cust_id, @current_state, @verify, @block, @freeze, @delete",
                new SqlParameter("@emp_id", emp_id),
                new SqlParameter("@cust_id", cust_id),
                new SqlParameter("@current_state", current),
                new SqlParameter("@verify", _verify),
                new SqlParameter("@block", _block),
                new SqlParameter("@freeze", _freeze),
                new SqlParameter("@delete", _delete)
                ) > 0) ? 1 : 0;
        }

        public IEnumerable<ReportPayment> ClientPaymentReports(int customerId)
        {
            return db.Database.SqlQuery<ReportPayment>("[backup].[s_getClientPaymentRPT] @CusId", new SqlParameter("@CusId", customerId)).ToList();
        }

        public IEnumerable<ReportClientActivity> ClientActivityReports(int customerId)
        {
            return db.Database.SqlQuery<ReportClientActivity>("SELECT TOP 10 * FROM[backup].vBO_ReportClientActivity AS C WHERE (cust_id = @CusId) ORDER BY signin_dt DESC", new SqlParameter("@CusId", customerId)).ToList();
        }

        public IEnumerable<ReportClientBackUps> ClientBackupsReports(int customerId)
        {
            // ยังไม่เสร็จ
            return db.Database.SqlQuery<ReportClientBackUps>("SELECT TOP 10 * FROM[backup].vBO_ReportClientActivity AS C WHERE (cust_id = @CusId) ORDER BY signin_dt DESC", new SqlParameter("@CusId", customerId)).ToList();
        }

    }
}
