using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BackOffice.WebAPI.Models
{
    public class clientsInfo
    {
        public int ClientId { get; set; }
    }

    public class m_rpt_clients
    {
        public int customerId { get; set; }
    }
    public class m_clients
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string FName { get; set; }
        public string Company { get; set; }
        public int statusFilter { get; set; }
        public bool exactmatch { get; set; }
    }

    public class m_clients_user_action
    {
        public int emp_id { get; set; }

        public int cust_id { get; set; }

        public int current_state { get; set; }

        public int verify { get; set; }

        public int block { get; set; }

        public int freeze { get; set; }

        public int delete { get; set; }
    }
    public class m_client_file
    {
        public string file_name { get; set; }
    }

    public class m_client_reset_password
    {
        public int cust_id { get; set; }
        public string email { get; set; }
    }
}