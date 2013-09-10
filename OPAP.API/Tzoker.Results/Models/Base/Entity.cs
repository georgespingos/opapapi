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
        public enum DrawType
        {
            Undefined = 0,
            Extra5 = 1,
            Proto = 2,
            Lotto = 3,
            Super3 = 4,
            Tzoker = 5
        }
        public DrawType Type { get; set; }
        public Entity(DrawType _Type = DrawType.Undefined)
        {
            this.Type = _Type;
        }

        public void Insert<T>(T t) where T : Entity
        {
            DbHelper dbHelper = new DbHelper();
            MongoCollection Draws = dbHelper.GetCollection<T>();
            Draws.Insert(t);
        }

        

    }
}