using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.Model
{
    public class Production
    {
        [BsonId]
        public ObjectId _id { get; set; }

        public int id { get; set; }
        public string sku { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public Attribute attribute { get; set; }
    }
}
