using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Tzoker.Results.Dd;
using MongoDB.Driver;

namespace Tzoker.Results.Models.Base
{
    public class Entity
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public void Insert(string Json)
        {
            DbHelper dbHelper = new DbHelper();

            MongoServer server = dbHelper.Server;
            MongoDatabase db = server.GetDatabase("APICache");
            MongoCollection<BsonDocument> Draws = db.GetCollection<BsonDocument>("Draws");

            MongoDB.Bson.BsonDocument doc = MongoDB.Bson.Serialization.BsonSerializer.Deserialize<BsonDocument>(Json);
            Draws.Insert(doc);
        }

        public void Insert<T>(T t) where T : class
        {
            DbHelper dbHelper = new DbHelper();

            MongoServer server = dbHelper.Server;
            MongoDatabase db = server.GetDatabase("APICache");
            MongoCollection<T> Draws = db.GetCollection<T>("Draws");
            Draws.Insert(t);
        }
    }
}