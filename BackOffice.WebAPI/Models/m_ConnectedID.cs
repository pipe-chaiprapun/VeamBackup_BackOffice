using Backup.ClassLibrary.Concrete;
using Backup.ClassLibrary.Entity;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace BackOffice.WebAPI.Models
{
    public class UsersHub
    {
        public string ConnectId { get; set; }
        public int Type { get; set; }
        public int UserRef { get; set; }
        public UserConnect User { get; set; }
        public List<MessageHub> Messages { get; set; }
        public Address Address { get; set; }

        // get ip address
        public string IpAddress
        {
            get
            {
                // Retrive the Name of HOST
                string hostName = Dns.GetHostName();
                if (string.IsNullOrEmpty(hostName))
                    return "";
                // Get the IP
                return Dns.GetHostByName(hostName).AddressList[0].ToString();
            }
        }

        public List<UsersHub> Clients { get; set; }
        public bool hasQueue { get; set; }
    }

    public class MessageHub
    {
        public string ConnectId { get; set; }
        public string Message { get; set; }
        public DateTime Time { get; set; }
        public UserConnect User { get; set; }
    }

    public class MessageHub2
    {
        public string ConnectId { get; set; }
        public string Message { get; set; }
        public UserConnect User { get; set; }
        public bool rating { get; set; }
    }

    public class UserConnect
    {
        public string email { get; set; }
        public string name { get; set; }
        public string topic { get; set; }
    }

    public class Usertype
    {
        public static int Operator = 2;
        public static int User = 1;
        public static int UnUser = 0;
    }


    // For Customer from Database
    public class CustomerHub
    {
        public int cust_id { get; set; }
        public string email { get; set; }
        public string name { get; set; }
    }

    // For Operator from Database
    public class OperatorHub
    {
        public int cust_id { get; set; }
        public string email { get; set; }
        public string name { get; set; }
    }


    public class UserLog
    {
        private BackOfficeDB db = new BackOfficeDB();

        [BsonId]
        public ObjectId _id { get; set; }
        public string ChatRoom { get; set; }
        public int UserRef { get; set; }
        public string UserRefFname { get; set; }
        public string UserRefLname { get; set; }
        public string OperatorRefUsername { get; set; }
        public string OperatorRefName { get; set; }
        public int OperatorRef { get; set; }
        public string Message { get; set; }
        public int UserType { get; set; }
        public object Time { get; set; }
        public object Readed { get; set; }
        public UserConnect User
        {
            get
            {
                var _User = new UserConnect();
                if (this.UserType == Models.Usertype.User)
                {
                    var Customer = db.Customer.FirstOrDefault(m => m.cust_id == this.UserRef);
                    var Address = db.Address.FirstOrDefault(m => m.cust_id == this.UserRef);
                    if (Customer != null && Address != null)
                    {
                        _User.email = Customer.email;
                        _User.name = Address.firstname + " " + Address.lastname;
                        _User.topic = "";
                    }
                }
                else if (this.UserType == Models.Usertype.Operator && this.OperatorRef > 0)
                {
                    var Employee = db.BO_Employee.FirstOrDefault(m => m.emp_id == this.OperatorRef);
                    if (Employee != null)
                    {
                        _User.email = Employee.emp_email;
                        _User.name = Employee.emp_fristname + " " + Employee.emp_lastname;
                        _User.topic = "";
                    }
                }
                return _User;
            }
        }
    }
}