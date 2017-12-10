using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.Model
{
    public class Test
    {
        [BsonId]
        public ObjectId _id { get; set; }
        public int id { get; set; }
        public string name { get; set; }
    }
}
