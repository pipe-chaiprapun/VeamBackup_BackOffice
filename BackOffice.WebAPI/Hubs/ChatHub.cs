using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Backup.ClassLibrary.Concrete;
using BackOffice.WebAPI.Models;
using BackOffice.WebAPI.Authen;
using System.Threading.Tasks;
using Backup.ClassLibrary.Entity;

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.IO;
using Backup.ClassLibrary.Abstract;

namespace BackOffice.WebAPI.Hubs
{
    public class ChatHub : Hub
    {

        private BackOfficeDB db = new BackOfficeDB();
        static List<UsersHub> Users = new List<UsersHub>();
        static List<CustomerHub> customer = new List<CustomerHub>();
        static List<OperatorHub> operater = new List<OperatorHub>();


        //connect MongoDB 
        //static MongoClient client = new MongoClient("mongodb://chatlog:Addlink123!@10.50.41.13:27017?authMechanism=SCRAM-SHA-1&authSource=chatlog");
        static MongoClient client = new MongoClient("mongodb://10.50.18.4:27017");
        static IMongoDatabase _database = client.GetDatabase("chatlog");


        #region สำหรับการ chat

        // ส่งข้อความไปยัง operator 
        public void sendMessage(string message)
        {
            string userId = Context.ConnectionId;

            var users = Users.FirstOrDefault(c => c.ConnectId.Equals(userId));
            var qry_use = customer.Where(e => e.email.Equals(users.User.email)).FirstOrDefault();

            if (users != null)
            {
                var messageHub = new MessageHub { ConnectId = userId, Message = message, Time = DateTime.Now, User = users.User };
                // เก็บข้อความของ user
                users.Messages.Add(messageHub);
                // ส่งไปยัง operator
                Clients.Clients(this.GetOperatorConnectId()).sendMessage(messageHub);
                // ส่งให้ตัวเองเห็น
                Clients.Client(userId).sendMessage(messageHub);
            }
        }

        // ส่งข้อความไปยัง ลูกค้า 
        public void op_sendMessage(string connectId, string message)
        {
            string opId = Context.ConnectionId;

            var ops = Users.FirstOrDefault(c => c.ConnectId.Equals(opId) && c.Type == Usertype.Operator);

            if (ops != null)
            {
                var messageHub = new MessageHub { ConnectId = opId, Message = message, Time = DateTime.Now, User = ops.User };
                ops.Messages.Add(messageHub);
                // ส่งไปยัง ลูกค้า
                Clients.Client(connectId).op_sendMessage(messageHub);
                // ส่งให้ตัวเองเห็น
                Clients.Caller.op_sendMessage(messageHub);
            }

        }

        // ส่งต่อผู้ใช้งาน ไปอีก operator
        public void op_assign2op(int userRefAssign, string clientCD)
        {

            var operators = this.GetOperators();

            // ผู้ใช้ที่ถูกย้าย
            var userAssign = this.GetUsers().FirstOrDefault(m => m.ConnectId.Equals(clientCD));
            // Operator ที่รับการโอน
            var operaterAssign = operators.FirstOrDefault(m => m.UserRef == userRefAssign);
            // Operator ที่ส่งการโอน
            var operaterConnect = operators.FirstOrDefault(m => m.ConnectId == Context.ConnectionId);

            if (operaterAssign != null && userAssign != null && operaterConnect != null)
            {
                operaterConnect.Clients.Remove(operaterConnect.Clients.FirstOrDefault(m => m.ConnectId == clientCD));
                userAssign.Messages = new List<MessageHub>();
                // เพิ่มผู้ใช้งานาเข้าไปใน Queue ของ operator
                operaterAssign.Clients.Add(userAssign);
                // operator connect
                Clients.Client(operaterConnect.ConnectId).userLoginByQueues(operaterConnect.Clients);
                // operator assign
                Clients.Client(operaterAssign.ConnectId).userLoginByQueues(operaterAssign.Clients);
            }
        }

        // ฝั่ง Operator ร้องขอ feedback จากลูกค้า
        public void op_ask4rating(int userRefOp, string clientCD)
        {
            string opId = Context.ConnectionId;
            string lastMessage = "Hope your problem was solved. Also you can rate my work and five star for chosing";
            var ops = Users.FirstOrDefault(c => c.ConnectId.Equals(opId) && c.Type == Usertype.Operator);

            if (ops != null)
            {
                var messageHub = new MessageHub2 { ConnectId = opId, Message = lastMessage, User = ops.User, rating = true };

                Clients.Client(clientCD).op_sendMessage(messageHub);
            }

        }

        // Operator เชื่อมต่อกับลูกค้าครั้งแรก
        public void op_connectToClient(int userRefOp, string clientCD)
        {
            string opId = Context.ConnectionId;
            string lastMessage = "";
            var ops = Users.FirstOrDefault(c => c.ConnectId.Equals(opId) && c.Type == Usertype.Operator);

            if (ops != null)
            {
                var messageHub = new MessageHub2 { ConnectId = opId, Message = lastMessage, User = ops.User, rating = true };

                Clients.Client(clientCD).op_sendMessage(messageHub);
            }
        }

        // ฝั่งลูกค้า ให้คะแนนกับ operator
        public void clientRating(string opCD, int score)
        {
            var ops = Users.FirstOrDefault(c => c.ConnectId.Equals(opCD) && c.Type == Usertype.Operator);

            if (ops != null)
            {
                //MongoClient client = new MongoClient("mongodb://chatlog:Addlink123!@10.50.41.13:27017?authMechanism=SCRAM-SHA-1&authSource=chatlog");
               // IMongoDatabase _database = client.GetDatabase("chatlog");
                BsonDocument data = new BsonDocument();
                var collection = _database.GetCollection<BsonDocument>("RateScore");
                data.Add("emp_id", ops.UserRef);
                data.Add("score", score);
                data.Add("DateTime", DateTime.Now);
                collection.InsertOne(data);
            }
        }

        #endregion

        #region สำหรับการ เข้าสู่ระบบและออกจากระบบ

        // เมื่อผู้ใช้งานเข้าสู่ระบบ สำหรับ User ธรรมดา
        public void onLogin(UserConnect model)
        {
            // ตรวจสอบว่ามีการเข้าระบบช้ำหรือไม่
            UsersHub UserLogin = null;
            if (this.CheckUser() == null)
            {
                UserLogin = new UsersHub { ConnectId = Context.ConnectionId, Type = Usertype.UnUser, User = model };
                UserLogin.Messages = new List<MessageHub>();
                // set ค่าผู้ใช้งานว่ายังไม่มี Queue
                UserLogin.hasQueue = false;
                // add to users
                ChatHub.Users.Add(UserLogin);
                // call กลับมายัง Server
                Clients.Caller.onLogin(UserLogin);
                // จัดการ Queue และ call ไปยัง Operator
                this.onManageClientQueue();
                return;
            }
            Clients.Caller.onLogin(null);
        }

        // เมื่อผู้ใช้งานเข้าสู่ระบบ สำหรับ User ลูกค้า
        public void onUserLogin(string token)
        {
            var tokenDecode = Securities.JWTDecode<Authentication>(token);
            var u = Users.FirstOrDefault(c => c.User.email.Equals(tokenDecode.email) && c.Type == 1);

            if (u != null)
            {
                Clients.Client(u.ConnectId).LogOut(u.ConnectId);
            }

            if (tokenDecode != null)
            {
                var customer = this.GetCustomer(tokenDecode.email);
                // ตรวจสอบว่ามีลูกค้าหรือไม่ customer, ตรวจสอบว่ามีการเข้ามาใช้งานซ้ำหรือไม่
                if (customer != null && this.CheckUser() == null)
                {
                    UsersHub user = new UsersHub
                    {
                        ConnectId = Context.ConnectionId,
                        Type = Usertype.User,
                        UserRef = customer.cust_id,
                        User = new UserConnect { email = customer.email, name = customer.name },
                        Address = db.Address.FirstOrDefault(m => m.cust_id == customer.cust_id)
                    };
                    user.Messages = new List<MessageHub>();
                    // set ค่าผู้ใช้งานว่ายังไม่มี Queue
                    user.hasQueue = false;
                    // add to Users model
                    ChatHub.Users.Add(user);
                    // call to client
                    Clients.Caller.onUserLogin(user);
                    // call ไปยัง Operator
                    Clients.Clients(this.GetOperatorConnectId()).onUserLoginAll(Users);
                    return;
                }
            }

            Clients.Caller.onUserLogin(null);
        }

        // เมื่อผู้ใช้งานเข้าสู่ระบบ สำหรับ User Operator
        public void onOperatorLogin(string token)
        {
            var tokenDecode = Securities.JWTDecode<Authentication>(token);
            if (tokenDecode != null)
            {
                var Operator = this.GatOperator(tokenDecode.username);
                if (Operator != null && this.CheckUser() == null)
                {
                    var user = new UsersHub
                    {
                        ConnectId = Context.ConnectionId,
                        Type = Usertype.Operator,
                        UserRef = Operator.cust_id,
                        User = new UserConnect
                        {
                            email = Operator.email,
                            name = Operator.name
                        }
                    };
                    user.Messages = new List<MessageHub>();
                    // สำหรับเก็บ Queue ผู้ใช้งาน
                    user.Clients = new List<UsersHub>();
                    // add to users
                    ChatHub.Users.Add(user);
                    // จัดการ Queue และ call ไปยัง Operator
                    this.onManageClientQueue();
                    // call to client
                    Clients.Caller.onOperatorLogin(user);
                    return;
                }
            }
            Clients.Caller.onOperatorLogin(null);
        }

        // เมื่อผู้ใช้งานออกจากระบบ
        public void onLogout()
        {
            // ตรวจสอบว่ามี user หรือไม่
            var user = this.CheckUser();
            if (user != null)
            {
                if (user.Type == Usertype.Operator)
                {
                    var clientUsers = user.Clients;
                    foreach (var client in clientUsers)
                    {
                        client.hasQueue = false;
                        client.Messages = new List<MessageHub>();
                    }
                }
                else
                {
                    var operatorUser = this.GetOperators().FirstOrDefault(m => m.Clients.FirstOrDefault(c => c.ConnectId.Equals(user.ConnectId)) != null);
                    if (operatorUser != null)
                    {
                        var userClient = operatorUser.Clients.FirstOrDefault(c => c.ConnectId.Equals(user.ConnectId));
                        operatorUser.Clients.Remove(userClient);
                    }
                }
                // ลบผู้ใช้งาน
                ChatHub.Users.Remove(user);
                // ส่งข้อมูลออกไป
                Clients.All.onUserLogoutAll(Context.ConnectionId);
                // จัดการ Queue และ call ไปยัง Operator
                this.onManageClientQueue();
            }
        }

        // จัด Queue ให้กับ Operator
        public void onManageClientQueue()
        {
            var userQueue = this.GetUsers().Where(m => m.hasQueue == false);
            foreach (var user in userQueue)
            {
                var operatorQueue = this.GetOperators().OrderBy(m => m.Clients.Count).FirstOrDefault();
                if (operatorQueue == null)
                    break;
                user.hasQueue = true;
                // เก็บ ผู้ใช้งานไว้กับ User มี Client ที่น้อยที่สุด
                operatorQueue.Clients.Add(user);
                // call to operator
                Clients.Client(operatorQueue.ConnectId).userLoginByQueues(operatorQueue.Clients);
            }
            // call ไปยัง Operator ทุกคน
            Clients.Clients(this.GetOperatorConnectId()).onOperatorLoginAll(this.GetOperators());
        }

        // ตรวจจับเหตุการณ์ว่ามีการ Connect WS หรือไม่
        public override Task OnConnected()
        {
            return base.OnConnected();
        }

        // ตรวจจับเหตุการณ์ว่ามีการ DisConnect WS หรือไม่
        public override Task OnDisconnected(bool stopCalled)
        {
            this.onLogout();
            return base.OnDisconnected(stopCalled);
        }


        #endregion

        #region Options เสริม Event ต่างๆ
        // สำหรับ ผู้ใช้งานที่ทำการพิมพ์ข้อความ
        public void onKeying()
        {
            Clients.Clients(this.GetOperatorConnectId()).onKeying(Context.ConnectionId);
        }

        // สำหรับ Operator ที่ทำการพิมพ์ข้อความ
        public void onOpKeying(string connectId)
        {
            var operatorUser = ChatHub.Users.FirstOrDefault(m => m.ConnectId == Context.ConnectionId);
            if (operatorUser != null)
            {
                Clients.Client(connectId).onOpKeying(operatorUser.User);
            }
        }

        // สำหรับผู้ใช้งาน อ่านข้อมูล
        public void onReading(string ConnectId)
        {
            var userConnect = ChatHub.Users.FirstOrDefault(m => m.ConnectId == ConnectId);
            var operatorUser = ChatHub.Users.FirstOrDefault(m => m.ConnectId == Context.ConnectionId);
            if (userConnect != null && operatorUser != null)
            {
                Clients.Client(ConnectId).onReading(operatorUser.User, DateTime.Now);
                // อัพเดต User Log
                if (operatorUser != null)
                {
                    this.updateUserLog(ConnectId);
                }
            }
        }
        #endregion

        #region สำหรับดึงค่าของ Users

        // ดึงข้อมูล Users ที่เข้ามาในห้องแชท
        private IEnumerable<UsersHub> GetUsers()
        {
            return ChatHub.Users.Where(m => m.Type == Usertype.User || m.Type == Usertype.UnUser);
        }

        // ดึงข้อมูล Operators ที่เข้ามาในห้องแชท
        private IEnumerable<UsersHub> GetOperators()
        {
            return ChatHub.Users.Where(m => m.Type == Usertype.Operator);
        }

        // ดึงข้อมูล ConnectIds ของ Operators
        private List<string> GetOperatorConnectId()
        {
            return this.GetOperators().Select(m => m.ConnectId).ToList();
        }
        #endregion

        #region สำหรับการ Method ที่ใช้งานบ่อยๆ

        // ตรวจสอบข้อมูลว่ามีผู้ใช้หรือไม่
        private UsersHub CheckUser()
        {
            return ChatHub.Users.FirstOrDefault(m => m.ConnectId.Equals(Context.ConnectionId));
        }

        // ดึงข้อมูลของลูกค้า
        private CustomerHub GetCustomer(string email)
        {
            var query = from c in db.Customer
                        join a in db.Address on c.cust_id equals a.cust_id
                        where c.email.Equals(email)
                        select new CustomerHub
                        {
                            cust_id = c.cust_id,
                            email = c.email,
                            name = a.firstname + " " + a.lastname
                        };
            return query.FirstOrDefault();
        }

        // ดึงข้อมูลของ Operator
        private OperatorHub GatOperator(string username)
        {
            var query = from op in this.db.BO_Employee
                        where op.emp_username.Equals(username)
                        select new OperatorHub
                        {
                            cust_id = op.emp_id,
                            email = op.emp_username,
                            name = op.emp_fristname + " " + op.emp_lastname
                        };
            return query.FirstOrDefault();
        }
        #endregion

        #region สำหรับการเก็บ Logs of chat
        private string CollationName = "UserLog";

        // บันทึกประวัติการแชทของผู้ใช้งาน
        public void saveUserLog(string ChatRoom, MessageHub Message, string Readed)
        {
            var userConnect = ChatHub.Users.FirstOrDefault(m => m.ConnectId == Message.ConnectId);
            if (userConnect == null || userConnect.Type == Usertype.UnUser)
                return;
            var Collection = _database.GetCollection<BsonDocument>(this.CollationName);
            if (userConnect.Type == Usertype.Operator)
            {
                var userClient = ChatHub.Users.FirstOrDefault(m => m.ConnectId == ChatRoom);
                if (userClient == null) return;
                if (userClient.Type == Usertype.UnUser) return;
                // for operator

                var model1 = db.Address.FirstOrDefault(c => c.cust_id == userClient.UserRef);
                var model2 = db.BO_Employee.FirstOrDefault(c => c.emp_id == userConnect.UserRef);


                Collection.InsertOne(new BsonDocument {
                    { "ChatRoom", ChatRoom },
                    { "UserRef", userClient.UserRef },
                    { "UserRefFname", model1.firstname },
                    { "UserRefLname", model1.lastname },
                    { "OperatorRef", userConnect.UserRef },
                    { "OperatorRefUsername", model2.emp_username },
                    { "OperatorRefName", model2.emp_fristname },
                    { "Message", Message.Message },
                    { "UserType", userConnect.Type },
                    { "Time", Message.Time },
                    { "Readed", Readed }
                });
            }
            else
            {
                var model1 = db.Address.FirstOrDefault(c => c.cust_id == userConnect.UserRef);
                // for user 
                Collection.InsertOne(new BsonDocument {
                    { "ChatRoom", ChatRoom },
                    { "UserRef", userConnect.UserRef },
                    { "UserRefFname", model1.firstname },
                    { "UserRefLname", model1.lastname },
                    { "OperatorRef", 0 },
                    { "Message", Message.Message },
                    { "UserType", userConnect.Type },
                    { "Time", Message.Time },
                    { "Readed", Readed }
                });
            }
        }

        // อัพเตรประวัติการแชทของผู้ใช้งาน
        public void updateUserLog(string ChatRoom)
        {
            var operatorUser = ChatHub.Users.FirstOrDefault(m => m.ConnectId == Context.ConnectionId);
            if (operatorUser == null) return;
            var Collection = _database.GetCollection<BsonDocument>(this.CollationName);
            var model2 = db.BO_Employee.FirstOrDefault(c => c.emp_id == operatorUser.UserRef);
            Collection.UpdateMany(new BsonDocument {
                { "ChatRoom", ChatRoom },
                { "OperatorRef", 0 }
            },
            new BsonDocument {
                {
            "$set", new BsonDocument {
                        { "OperatorRef", operatorUser.UserRef },
                        { "OperatorRefUsername", model2.emp_username },
                        { "OperatorRefName", model2.emp_fristname },
                        { "Readed", DateTime.Now }
                    }
                }
            });
        }

        // แสดงข้อมุลประวัติการแชทของผู้ใช้งาน จาก ConnectId
        public void showUserLog(string ConnectId)
        {
            var userConnect = ChatHub.Users.FirstOrDefault(m => m.ConnectId == ConnectId);
            if (userConnect == null) return;
            this._showUserLog(userConnect);
        }

        // แสดงข้อมุลประวัติการแชทของผู้ใช้งาน จาก CustId
        public void showUserLogById(int CustId)
        {
            var customer = db.Customer.FirstOrDefault(m => m.cust_id == CustId);
            if (customer == null) return;
            var userConnect = new UsersHub();
            userConnect.UserRef = customer.cust_id;
            this._showUserLog(userConnect);
        }

        // แสดงข้อมูลประวัติการแชทของผู้ใช้งานที่ไม่ได้เข้าสู่ระบบ
        public void showUserLogNotLogin(string ChatRoom)
        {
            var oparetor = this.GetOperators().FirstOrDefault(m => m.ConnectId.Equals(Context.ConnectionId));
            if (oparetor == null)
                return;
            var Collection = _database.GetCollection<UserLog>(this.CollationName);
            var userLogs = Collection.Find(new BsonDocument { { "OperatorRef", oparetor.UserRef }, { "ChatRoom", ChatRoom } }).ToList();
            Clients.Caller.showUserLogNotLogin(userLogs);
        }

        // แสดงข้อมุลประวัติการแชทของผู้ใช้งาน
        private void _showUserLog(UsersHub userConnect)
        {
            var Collection = _database.GetCollection<UserLog>(this.CollationName);
            var userLogs = Collection.Find(new BsonDocument { { "UserRef", userConnect.UserRef } }).ToList();
            Clients.Caller.showUserLog(userLogs);
        }
        #endregion
    }
}