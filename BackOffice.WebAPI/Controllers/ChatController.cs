using BackOffice.WebAPI.Authen;
using BackOffice.WebAPI.Models;
using Backup.ClassLibrary.Abstract;
using Backup.ClassLibrary.Entity;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BackOffice.WebAPI.Controllers
{
    [JWTAuthorize("SuperAdmin", "Admin", "Supervisor", "Operator", "Manager")]
    public class ChatController : ApiController
    {
        private IAppRep _EFApp;

        #region ---------------------------------------------  Auto Sentence ------------------------------------------------------
        public static AssignReq assignData;
      //  public static MongoClient client = new MongoClient("mongodb://chatlog:Addlink123!@10.50.41.13:27017?authMechanism=SCRAM-SHA-1&authSource=chatlog");
        public static MongoClient client = new MongoClient("mongodb://10.50.18.4:27017");
        public static IMongoDatabase _database = client.GetDatabase("chatlog");

        public string ipaddress = (System.Web.HttpContext.Current != null) ? System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString() : "No Ip";

        public ChatController(IAppRep appref)
        {
            _EFApp = appref;
        }
        [Route("api/auto-sentences")]
        [HttpPost]
        public IHttpActionResult PostshowAutoSentences([FromBody]Request value)
        {
            var user = Authentication.User;
            _EFApp.save_logaction("Chat page", "Show Auto Sentences : " + user.emp_permission, ipaddress, user.emp_id);

            try
            {
                if (value.request == "addlink")
                {
                    var userLog = Authentication.User.emp_id;

                    //var queryDoc = BsonSerializer.Deserialize<BsonDocument>("{$or: [ { emp_id: "+userLog+" }, { emp_id: 999 } ]}");

                    var collection = _database.GetCollection<BsonDocument>("GreetingSentences");

                    var greeting = collection.Find(new BsonDocument { { "emp_id", userLog } }).ToList();

                    collection = _database.GetCollection<BsonDocument>("PaymentSentences");
                    var payment = collection.Find(new BsonDocument { { "emp_id", userLog } }).ToList();

                    collection = _database.GetCollection<BsonDocument>("SettingSentences");
                    //var setting = collection.Find(new BsonDocument(queryDoc)).ToList();
                    var setting = collection.Find(new BsonDocument { { "emp_id", userLog } }).ToList();

                    collection = _database.GetCollection<BsonDocument>("PricingSentences");
                    var pricing = collection.Find(new BsonDocument { { "emp_id", userLog } }).ToList();

                    collection = _database.GetCollection<BsonDocument>("FinishingSentences");

                    var finishing = collection.Find(new BsonDocument { { "emp_id", userLog } }).ToList();

                    Dictionary<string, object> result = new Dictionary<string, object>();
                    result.Add("greeting", greeting);
                    result.Add("payment", payment);
                    result.Add("setting", setting);
                    result.Add("pricing", pricing);
                    result.Add("finishing", finishing);
                    Console.Write("result => " + result);
                    return Json(result);
                }
                else
                    return Json("No request input");
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        [Route("api/read-score")]
        [HttpPost]
        public IHttpActionResult PostShowRaedScore([FromBody]Request value)
        {
            var user = Authentication.User;
            _EFApp.save_logaction("Chat page", "Show Raed Score : " + user.emp_permission, ipaddress, user.emp_id);

            try
            {
                if (value.request == "addlink")
                {
                    var userLog = Authentication.User.emp_id;
                    var collection = _database.GetCollection<BsonDocument>("RateScore");
                    var allSupport = collection.Find(new BsonDocument { { "emp_id", userLog } }).ToList();
                    var rate = collection.Find(
                        new BsonDocument {
                            { "emp_id", userLog },
                            {"score", new BsonDocument{ { "$gt", 0} } }
                        }).ToList();
                    Dictionary<string, object> result = new Dictionary<string, object>();
                    result.Add("rate", rate);
                    result.Add("allSupport", allSupport);
                    return Json(result);
                }
                else
                    return Json("No request input");
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        [Route("api/new-sentence")]
        [HttpPost]
        public IHttpActionResult PostAddSentences([FromBody]Sentence value)
        {
            var user = Authentication.User;
            _EFApp.save_logaction("Chat page", "Add Sentences : " + user.emp_permission, ipaddress, user.emp_id);

            try
            {
                BsonDocument data = new BsonDocument();
                value.emp_id = Authentication.User.emp_id;
                var collection = _database.GetCollection<BsonDocument>("GreetingSentences");

                if (value.group != null && value.sentence != null)
                {

                    if (value.group == "greeting")
                    {
                        data.Add("sentence", value.sentence);
                        data.Add("emp_id", value.emp_id);
                        collection.InsertOne(data);
                    }
                    else if (value.group == "payment")
                    {
                        collection = _database.GetCollection<BsonDocument>("PaymentSentences");
                        data.Add("sentence", value.sentence);
                        data.Add("emp_id", value.emp_id);
                        collection.InsertOne(data);
                    }
                    else if (value.group == "setting")
                    {
                        collection = _database.GetCollection<BsonDocument>("SettingSentences");
                        data.Add("sentence", value.sentence);
                        data.Add("emp_id", value.emp_id);
                        collection.InsertOne(data);
                    }
                    else if (value.group == "pricing")
                    {
                        collection = _database.GetCollection<BsonDocument>("PricingSentences");
                        data.Add("sentence", value.sentence);
                        data.Add("emp_id", value.emp_id);
                        collection.InsertOne(data);
                    }
                    else if (value.group == "finishing")
                    {
                        collection = _database.GetCollection<BsonDocument>("FinishingSentences");
                        data.Add("sentence", value.sentence);
                        data.Add("emp_id", value.emp_id);
                        collection.InsertOne(data);
                    }
                    else
                        return Json("Incorrect data input");

                    return Json("Add " + "\"" + value.sentence + "\"" + " complete!");
                }
                else
                    return Json("No data input!");
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        [Route("api/delete-sentence")]
        [HttpPost]
        public IHttpActionResult PostDeleteSentences([FromBody]Sentence value)
        {
            var user = Authentication.User;
            _EFApp.save_logaction("Chat page", "Delete Sentences : " + user.emp_permission, ipaddress, user.emp_id);

            try
            {
                BsonDocument data = new BsonDocument();
                value.emp_id = Authentication.User.emp_id;
                //var queryDoc = BsonSerializer.Deserialize<BsonDocument>("{ sentence: \""+value.sentence+"\", \"emp_id\":"+ value.emp_id + "}");
                var collection = _database.GetCollection<BsonDocument>("GreetingSentences");

                if (value.group != null && value.sentence != null)
                {
                    if (value.group == "greeting")
                    {
                        collection.FindOneAndDelete(new BsonDocument {
                                                                        { "sentence", value.sentence },
                                                                        { "emp_id", value.emp_id }
                        });
                    }
                    else if (value.group == "payment")
                    {
                        collection = _database.GetCollection<BsonDocument>("PaymentSentences");
                        collection.FindOneAndDelete(new BsonDocument {
                                                                        { "sentence", value.sentence },
                                                                        { "emp_id", value.emp_id }
                        });
                    }
                    else if (value.group == "setting")
                    {
                        collection = _database.GetCollection<BsonDocument>("SettingSentences");
                        collection.FindOneAndDelete(new BsonDocument {
                                                                        { "sentence", value.sentence },
                                                                        { "emp_id", value.emp_id }
                        });
                    }
                    else if (value.group == "pricing")
                    {
                        collection = _database.GetCollection<BsonDocument>("PricingSentences");
                        collection.FindOneAndDelete(new BsonDocument {
                                                                        { "sentence", value.sentence },
                                                                        { "emp_id", value.emp_id }
                        });
                    }
                    else if (value.group == "finishing")
                    {
                        collection = _database.GetCollection<BsonDocument>("FinishingSentences");
                        collection.FindOneAndDelete(new BsonDocument {
                                                                        { "sentence", value.sentence },
                                                                        { "emp_id", value.emp_id }
                        });
                    }
                    else
                        return Json("Incorrect data input");

                    return Json("Delete " + "\"" + value.sentence + "\"" + " complete!");
                }
                else
                    return Json("No data input!");
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        [Route("api/update-sentence")]
        [HttpPost]
        public IHttpActionResult PostUpdateSentences([FromBody]Sentence value)
        {
            var user = Authentication.User;
            _EFApp.save_logaction("Chat page", "Update Sentences : " + user.emp_permission, ipaddress, user.emp_id);

            try
            {
                BsonDocument data = new BsonDocument();
                value.emp_id = Authentication.User.emp_id;
                //var queryDoc = BsonSerializer.Deserialize<BsonDocument>("{ sentence: \"" + value.sentence + "\", \"emp_id\":" + value.emp_id + "}");
                var collection = _database.GetCollection<BsonDocument>("GreetingSentences");

                if (value.group != null && value.sentence != null)
                {
                    if (value.group == "greeting")
                    {
                        collection.UpdateOne(new BsonDocument {
                                                                        { "sentence", value.sentence },
                                                                        { "emp_id", value.emp_id }},
                                                                        new BsonDocument {
                                                                        {
                                                                            "$set", new BsonDocument {
                                                                            { "sentence", value.newSentence },
                                                                            { "emp_id", value.emp_id }}
                                                                        }});
                    }
                    else if (value.group == "payment")
                    {
                        collection = _database.GetCollection<BsonDocument>("PaymentSentences");
                        collection.UpdateOne(new BsonDocument {
                                                                        { "sentence", value.sentence },
                                                                        { "emp_id", value.emp_id }},
                                                                        new BsonDocument {
                                                                        {
                                                                            "$set", new BsonDocument {
                                                                            { "sentence", value.newSentence },
                                                                            { "emp_id", value.emp_id }}
                                                                        }});
                    }
                    else if (value.group == "setting")
                    {
                        collection = _database.GetCollection<BsonDocument>("SettingSentences");
                        collection.UpdateOne(new BsonDocument {
                                                                        { "sentence", value.sentence },
                                                                        { "emp_id", value.emp_id }},
                                                                        new BsonDocument {
                                                                        {
                                                                            "$set", new BsonDocument {
                                                                            { "sentence", value.newSentence },
                                                                            { "emp_id", value.emp_id }}
                                                                        }});
                    }
                    else if (value.group == "pricing")
                    {
                        collection = _database.GetCollection<BsonDocument>("PricingSentences");
                        collection.UpdateOne(new BsonDocument {
                                                                        { "sentence", value.sentence },
                                                                        { "emp_id", value.emp_id }},
                                                                        new BsonDocument {
                                                                        {
                                                                            "$set", new BsonDocument {
                                                                            { "sentence", value.newSentence },
                                                                            { "emp_id", value.emp_id }}
                                                                        }});
                    }
                    else if (value.group == "finishing")
                    {
                        collection = _database.GetCollection<BsonDocument>("FinishingSentences");
                        collection.UpdateOne(new BsonDocument {
                                                                        { "sentence", value.sentence },
                                                                        { "emp_id", value.emp_id }},
                                                                        new BsonDocument {
                                                                        {
                                                                            "$set", new BsonDocument {
                                                                            { "sentence", value.newSentence },
                                                                            { "emp_id", value.emp_id }}
                                                                        }});
                    }
                    else
                        return Json("Incorrect data input");

                    return Json("Update " + "\"" + value.newSentence + "\"" + " complete!");
                }
                else
                    return Json("No data input!");
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        [Route("api/assign")]
        [HttpPost]
        public IHttpActionResult PostAssign([FromBody]AssignReq data)
        {
           

            try
            {
                assignData = new AssignReq();
                assignData.userRef = data.userRef;
                assignData.clientCD = data.clientCD;
                return Json(assignData);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        [Route("api/updateAssign")]
        [HttpPost]
        public IHttpActionResult PostUpdateAssign(Request value)
        {
          

            try
            {
                if (value.request == "addlink")
                {
                    return Json(assignData);
                }
                else
                {
                    return Json("Incorrect Post permission");
                }
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        [Route("api/AddChatBot")]
        [HttpPost]
        public IHttpActionResult Postchatbot([FromBody]ChatBot value)
        {
            try
            {
             //   MongoClient client = new MongoClient("mongodb://chatlog:Addlink123!@10.50.41.13:27017?authMechanism=SCRAM-SHA-1&authSource=chatlog");
                IMongoDatabase _database = client.GetDatabase("chatlog");
                var Collection = _database.GetCollection<BsonDocument>("ChatBoTKnowledge");
                Collection.InsertOne(new BsonDocument {
                    { "Qtext", value.Qtext},
                    { "Atext", value.Atext }
                });
                return Json("data input");
            }
            catch (Exception e)
            {
                return Json(e.Message);

            }

        }

        [Route("api/EditChatBot")]
        [HttpPost]
        public IHttpActionResult EditChatBot([FromBody]ChatBot value)
        {
            try
            {
               // MongoClient client = new MongoClient("mongodb://chatlog:Addlink123!@10.50.41.13:27017?authMechanism=SCRAM-SHA-1&authSource=chatlog");
                IMongoDatabase _database = client.GetDatabase("chatlog");

                var Collection = _database.GetCollection<BsonDocument>("ChatBoTKnowledge");
                var Find = Collection.Find(value.ID);
                var update = Collection.UpdateOne(new BsonDocument {
                                { "_id", ObjectId.Parse(value.ID)}
                                },
                                new BsonDocument {
                                {
                                    "$set", new BsonDocument {
                                    { "Qtext", value.Qtext },
                                    { "Atext", value.Atext }}
                                }});
                return Json(update.IsModifiedCountAvailable);


            }
            catch (Exception e)
            {
                return Json(e.Message);

            }

        }
        [Route("api/GetChatbotTest")]
        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult Getchatbot([FromBody]ChatBot value)
        {
            //MongoClient client = new MongoClient("mongodb://chatlog:Addlink123!@10.50.41.13:27017?authMechanism=SCRAM-SHA-1&authSource=chatlog");
            IMongoDatabase _database = client.GetDatabase("chatlog");
            var Collection = _database.GetCollection<BsonDocument>("ChatBoTKnowledge");
            var greeting = Collection.Find(new BsonDocument()).ToList();
            return Json(greeting);

        }
        [Route("api/GetChatbot")]
        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult PostGetchatbot([FromBody]ChatBot value)
        {
            //MongoClient client = new MongoClient("mongodb://chatlog:Addlink123!@10.50.41.13:27017?authMechanism=SCRAM-SHA-1&authSource=chatlog");
            IMongoDatabase _database = client.GetDatabase("chatlog");
            var Collection = _database.GetCollection<BsonDocument>("ChatBoTKnowledge");
            var greeting = Collection.Find(new BsonDocument()).ToList();
            return Json(greeting);

        }

        [Route("api/DeleteChatbot")]
        [HttpPost]
        public IHttpActionResult PostDeleteChatbot([FromBody]ChatBot value)
        {
           // MongoClient client = new MongoClient("mongodb://chatlog:Addlink123!@10.50.41.13:27017?authMechanism=SCRAM-SHA-1&authSource=chatlog");
            IMongoDatabase _database = client.GetDatabase("chatlog");
            var Collection = _database.GetCollection<BsonDocument>("ChatBoTKnowledge");
            Collection.DeleteOne(new BsonDocument { { "_id", ObjectId.Parse(value.ID) } });
            return Json("Delete success");

        }

        [Route("api/AddHistory")]
        [HttpPost]
        public IHttpActionResult PostAddHistory([FromBody]HistoryChatBot value)
        {
            try
            {
              //  MongoClient client = new MongoClient("mongodb://chatlog:Addlink123!@10.50.41.13:27017?authMechanism=SCRAM-SHA-1&authSource=chatlog");
                IMongoDatabase _database = client.GetDatabase("chatlog");
                var Collection = _database.GetCollection<BsonDocument>("ChatBotHistory");
                Collection.InsertOne(new BsonDocument {
                                                            { "Qtext", value.Topic },
                                                            { "Atext", value.Atext }
                                                          });
                return Json("success add");
            }
            catch (Exception e)
            {
                return Json(e.Message);

            }

        }

        [Route("api/GetHistory")]
        [HttpPost]
        public IHttpActionResult PostGetHistory([FromBody]ChatBot value)
        {
            //MongoClient client = new MongoClient("mongodb://chatlog:Addlink123!@10.50.41.13:27017?authMechanism=SCRAM-SHA-1&authSource=chatlog");
            IMongoDatabase _database = client.GetDatabase("chatlog");
            var Collection = _database.GetCollection<BsonDocument>("ChatBotHistory");
            var greeting = Collection.Find(new BsonDocument()).ToList();
            return Json(greeting);

        }

        [Route("api/GetStatusBot")]
        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult PostGetStatusBot([FromBody]ChatBot value)
        {
           // MongoClient client = new MongoClient("mongodb://chatlog:Addlink123!@10.50.41.13:27017?authMechanism=SCRAM-SHA-1&authSource=chatlog");
            IMongoDatabase _database = client.GetDatabase("chatlog");
            var Collection = _database.GetCollection<BsonDocument>("OnOffBot");
            var greeting = Collection.Find(new BsonDocument()).ToList();
            if (greeting.Count < 1)
            {
                Collection.InsertOne(new BsonDocument {
                    { "status", "Off"}
                });
                greeting = Collection.Find(new BsonDocument()).ToList();
                return Json(greeting);
            }
            else
            {
                return Json(greeting);
            }


        }

        [Route("api/SetOnOffChatbot")]
        [HttpPost]
        public IHttpActionResult PostSetOnOffChatbot([FromBody]ChatBot value)
        {

            try
            {

              //  MongoClient client = new MongoClient("mongodb://chatlog:Addlink123!@10.50.41.13:27017?authMechanism=SCRAM-SHA-1&authSource=chatlog");
                IMongoDatabase _database = client.GetDatabase("chatlog");
                var Collection = _database.GetCollection<BsonDocument>("OnOffBot");
                var greeting = Collection.Find(new BsonDocument()).ToList();
                if (greeting.Count == 1)
                {
                    if (value.Qtext == "On")
                    {
                        var update = Collection.UpdateOne(new BsonDocument {
                                { "status", value.Qtext}
                                },
                        new BsonDocument {
                                {
                                    "$set", new BsonDocument {
                                    { "status", "Off"}}
                                }});
                    }
                    else
                    {
                        var update = Collection.UpdateOne(new BsonDocument {
                                { "status", value.Qtext}
                                },
                        new BsonDocument {
                                {
                                    "$set", new BsonDocument {
                                    { "status", "On" }}
                                }});
                    }

                }
                else
                {
                    Collection.InsertOne(new BsonDocument {
                    { "status", value.Qtext}
                });
                }
                return Json("setbot success");
            }
            catch (Exception e)
            {
                return Json(e.Message);

            }

        }

        public class Request { public string request { get; set; } }
        public class Sentence
        {
            public string group { get; set; }
            public string sentence { get; set; }
            public int emp_id { get; set; }
            public string newSentence { get; set; }

        }
        public class AssignReq
        {
            public int userRef { get; set; }
            public string clientCD { get; set; }
        }
        public class ChatBot
        {
            public string ID { get; set; }
            public string Qtext { get; set; }
            public string Atext { get; set; }
        }
        public class HistoryChatBot
        {
            public string Topic { get; set; }
            public string Atext { get; set; }
        }
        #endregion
    }
}
