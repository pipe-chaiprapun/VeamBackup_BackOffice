using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.WebAPI.Models
{
    public class m_ChatLog
    {
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
        [BsonElementAttribute("Time")]
        public DateTime Time { get; set; }
        public object Readed { get; set; }
    }
}