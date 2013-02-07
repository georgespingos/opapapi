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
                "mongodb://localhost/OpapDraws";
        }

        public MongoCollection GetCollection<T>() 
        {
            MongoServer server = this.Server;
            MongoDatabase db = server.GetDatabase(this.MongoDatabaseName);
            MongoCollection<T> Draws = db.GetCollection<T>(this.MongoCollectionName);
            return Draws;
        }

        public bool Exists (int DrawId,int DrawTypeValue,string ResultType)
        {
            var collection = this.GetCollection <BsonDocument>();
            
            var QryDrawId = Query.EQ("DrawNumber", DrawId);
            var QryResultType = Query.EQ("ResultType", ResultType);
            var QryDrawTypeValue = Query.EQ("Type", DrawTypeValue);
            IMongoQuery[] QryArray = { QryDrawId, QryDrawTypeValue, QryResultType };
            var QryFinal = Query.And(QryArray);

            var Result = collection.FindOneAs(typeof(BsonDocument), QryFinal);

            return false;
        }
    }
}