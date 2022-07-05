using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using BackOffice.WebAPI.Authen;
using VeeamBackOfficeUnit.Test.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Embedded;
using Backup.ClassLibrary.Abstract;

namespace VeeamBackOfficeUnit.Test
{
    /// <summary>
    /// UnitTest ChatController by FarkramDev
    /// </summary>
    [TestClass]
    public class ChatController
    {
        private string token = string.Empty;
        private BackOffice.WebAPI.Controllers.ChatController Ctl;
        private EmbeddedMongoDbServer mongoEmbedded;
        private Mock<IAppRep> mockAppR = new Mock<IAppRep>();
        //private MongoClient mongoClient;
        //private MongoServer mongoServer;

        [ClassInitialize]
        public void StartMongoEmbedded(TestContext cont)
        {
            //mongoEmbedded = new EmbeddedMongoDbServer();
            //mongoClient = mongoEmbedded.Client;
            //mongoServer = mongoClient.GetServer();
        }

        [TestInitialize]
        public void Initialize()
        {
            token = Authentication.SetAuthenticated(DataMock.Employee, TimeSpan.FromMinutes(120).Minutes); //Set Authentication Mock
            Ctl = new BackOffice.WebAPI.Controllers.ChatController(mockAppR.Object);
        }

        //[TestMethod]
        //public void PostshowAutoSentences()
        //{
        //    //Mock<Request> req = new Mock<Request>();
        //    //req.Setup(r => r.request).Returns("addlink");
        //    ////_database.Setup(f=>f.GetCollection<BsonDocument>("GreetingSentences", null)).Returns(_database.Object.);
        //    ////mongoDatabase.Setup(f => f.GetCollection(MongoCollection.Settings)).Returns(collection.Object);
        //    //if (req.Object.request.Equals("addlink"))
        //    //{
        //    //    Assert.IsTrue(req.Object.request.Equals("addlink"));
        //    //    var userLog = Authentication.User.emp_id;
        //    //    //var mongoDatabase = new Mock<MongoDatabase>();
        //    //    //var collection = new Mock<MongoCollection<BsonDocument>>();
        //    //    //BsonDocument greeting = new BsonDocument { { "emp_id", userLog } };
        //    //    //_database.Setup(o => o.GetCollection<BsonDocument>("GreetingSentences", null)).Returns(null);
        //    //}
        //}
    }
}
