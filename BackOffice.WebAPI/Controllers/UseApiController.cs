using BackOffice.WebAPI.Models;
using Backup.ClassLibrary.Abstract;
using Backup.ClassLibrary.Entity;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace BackOffice.WebAPI.Controllers
{
    public class UseApiController : ApiController
    {
        private IAppRep _sss;

        public UseApiController(IAppRep AppRep)
        {
            _sss = AppRep;
        }

        [Route("api/map")]
        public IHttpActionResult Postmap(Ip value)
        {
            using (WebClient wc = new WebClient())
            {
                try
                {
                    var url = "http://ip-api.com/json/" + value.ip;
                    var json = wc.DownloadString(url);
                    JObject o = JObject.Parse(json);
                    var ss = "";
                    ss += o["lat"] + ",";
                    ss += o["lon"];
                    return Json(ss);
                }
                catch (Exception e)
                {
                    var ss = "";
                    ss += "13.72917" + ",";
                    ss += "100.52389";
                    return Json(ss);
                }
            }
        }

        [Route("api/filter-ChatLog")]
        public IHttpActionResult filterChatLog(ChatLog value)
        {

            BO_Messausefilter_return zxxz = new BO_Messausefilter_return();

            try { 
            MongoClient client = new MongoClient("mongodb://10.50.18.4:27017");
                IMongoDatabase _database = client.GetDatabase("chatlog");
            var Collection = _database.GetCollection<m_ChatLog>("UserLog");

            if (value.From == "" && value.To == "" && value.Operator == "" && value.ClientID == 0) // x x x x
            {
                var chatLog = Collection.Find(new BsonDocument { }).ToList();
                return Json(chatLog);
            } else if (value.From == "" && value.To == "" && value.Operator != "" && value.ClientID == 0) // x x o x
            {
                var chatLog = Collection.Find(new BsonDocument { { "OperatorRefUsername", value.Operator } }).ToList();
                return Json(chatLog);
            }
            else if (value.From == "" && value.To == "" && value.Operator == "" && value.ClientID != 0) // x x x o
            {
                var chatLog = Collection.Find(new BsonDocument { { "UserRef", value.ClientID } }).ToList();
                return Json(chatLog);
            }
            else if (value.From == "" && value.To == "" && value.Operator != "" && value.ClientID != 0) // x x o o
            {
                var chatLog = Collection.Find(new BsonDocument { { "OperatorRefUsername", value.Operator }, { "UserRef", value.ClientID } }).ToList();
                return Json(chatLog);
            }
            else if (value.From != "" && value.To != "" && value.Operator == "" && value.ClientID == 0)// o o x x
            {
                var filterBuilder = Builders<m_ChatLog>.Filter;
                var filter = filterBuilder.Gte(x => x.Time, new BsonDateTime(FromDate(value.From))) &
                    filterBuilder.Lte(x => x.Time, new BsonDateTime(ToDate(value.To)));
                var chatLog = Collection.Find(filter).ToList();
                return Json(chatLog);
            }
            else if (value.From != "" && value.To != "" && value.Operator != "" && value.ClientID == 0) // o o o x
            {
                var filterBuilder = Builders<m_ChatLog>.Filter;
                var filter = filterBuilder.Gte(x => x.Time, new BsonDateTime(FromDate(value.From))) &
                    filterBuilder.Lte(x => x.Time, new BsonDateTime(ToDate(value.To))) &
                    filterBuilder.Eq(x => x.OperatorRefUsername , value.Operator);
                var chatLog = Collection.Find(filter).ToList();
                return Json(chatLog);
            }
            else if (value.From != "" && value.To != "" && value.Operator == "" && value.ClientID != 0) // o o x o
            {
                var filterBuilder = Builders<m_ChatLog>.Filter;
                var filter = filterBuilder.Gte(x => x.Time, new BsonDateTime(FromDate(value.From))) &
                    filterBuilder.Lte(x => x.Time, new BsonDateTime(ToDate(value.To))) &
                    filterBuilder.Eq(x => x.UserRef, value.ClientID);
                var chatLog = Collection.Find(filter).ToList();
                return Json(chatLog);
            }
            else if (value.From != "" && value.To != "" && value.Operator != "" && value.ClientID != 0) // o o o o
            {
                var filterBuilder = Builders<m_ChatLog>.Filter;
                var filter = filterBuilder.Gte(x => x.Time, new BsonDateTime(FromDate(value.From))) &
                    filterBuilder.Lte(x => x.Time, new BsonDateTime(ToDate(value.To))) &
                    filterBuilder.Eq(x => x.OperatorRefUsername, value.Operator) &
                    filterBuilder.Eq(x => x.UserRef, value.ClientID);
                var chatLog = Collection.Find(filter).ToList();
                return Json(chatLog);
            }

            var mass = "no";

            return Json(mass);
            }
            catch (Exception e)
            {
                zxxz.Message = "UnSuccessful";
                return Json(zxxz);
            }
        }

        public DateTime FromDate(String From)
        {

            string date_from = From;
            string[] words_from = date_from.Split('/');
            //var from = new DateTime(2017, 08, 03, 00, 00, 00);
            int from1 = Convert.ToInt32(words_from[2]);
            int from2 = Convert.ToInt32(words_from[0]);
            int from3 = Convert.ToInt32(words_from[1]);

            var from = new DateTime(from1, from2, from3, 00, 00, 00);
            return from;
        }
        public DateTime ToDate(String To)
        {
            string date_to = To;
            string[] words_to = date_to.Split('/');
            //var to = new DateTime(2017, 08, 03, 23, 59, 59);
            int to1 = Convert.ToInt32(words_to[2]);
            int to2 = Convert.ToInt32(words_to[0]);
            int to3 = Convert.ToInt32(words_to[1]);

            var to = new DateTime(to1, to2, to3, 23, 59, 59);

            return to;
        }

    }

 
    


    public class ChatLog
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Operator { get; set; }
        public int ClientID { get; set; }
    }

    public class Ip
    {
        public string ip { get; set; }
    }

    public class BO_Messausefilter_return
    {
        public string Message { get; set; }
    }
}