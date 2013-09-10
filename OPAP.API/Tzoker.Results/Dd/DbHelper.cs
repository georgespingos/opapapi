using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using System.Configuration;
using Tzoker.Results.Models.Base;
using MongoDB.Driver.Linq;
using MongoDB.Bson;
using MongoDB.Driver.Builders;

namespace Tzoker.Results.Dd
{
    public class DbHelper
    {
        public String MongoDatabaseName
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("MongoDatabaseName");
            }
        }
        public String MongoCollectionName
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("MongoCollection");
            }
        }
        public MongoServer Server
        {
            get
            {
                return MongoServer.Create(GetMongoDbConnectionString());
            }
        }
        private string GetMongoDbConnectionString()
        {
            return ConfigurationManager.AppSettings.Get("MONGOHQ_URL") ??
                ConfigurationManager.AppSettings.Get("MONGOLAB_URI") ??
                "mongodb://localhost/APICache";
        }

        public MongoCollection GetCollection<T>() 
        {
            var connectionstring = GetMongoDbConnectionString();
            var mongoUrl = new MongoUrl(connectionstring);
            var cl = new MongoClient(mongoUrl);
            MongoServer srv = cl.GetServer();

            var database = srv.GetDatabase(MongoUrl.Create(connectionstring).DatabaseName);
// ReSharper disable InconsistentNaming
            MongoCollection<T> Draws = database.GetCollection<T>(this.MongoCollectionName);
// ReSharper restore InconsistentNaming
            return Draws;
        }

        public bool TryGet (int DrawId,int DrawTypeValue,string ResultType, out BsonDocument Draw)
        {
            bool Result = false;
            var collection = this.GetCollection <BsonDocument>();
            
            var QryDrawId = Query.EQ("DrawNumber", DrawId);
            var QryResultType = Query.EQ("ResultType", ResultType);
            var QryDrawTypeValue = Query.EQ("Type", DrawTypeValue);
            IMongoQuery[] QryArray = { QryDrawId, QryDrawTypeValue, QryResultType };
            var QryFinal = Query.And(QryArray);

            var QryResult = collection.FindOneAs(typeof(BsonDocument), QryFinal);
            Draw = (BsonDocument)QryResult;

            if (QryResult != null)
                Result = true;
            else
                Result = false;
            
            return Result;
        }
    }
}