using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Model;

namespace webapi.DAL
{
    public class DataAccess : IDataAccess
    {
        private string url = "mongodb://localhost:27017";
        private MongoClient client;
        public DataAccess()
        {
            client =  new MongoClient(url);
        }

        public IEnumerable<Production> getProduct()
        {
            IMongoCollection<Production> c = client.GetDatabase("Production").GetCollection<Production>("Production");
            return c.Find(new BsonDocument()).ToList();
        }

        public IEnumerable<Production> getProductByRange(double start,double end)
        {
            IMongoCollection<Production> c = client.GetDatabase("Production").GetCollection<Production>("Production");
            return c.Find(_=>_.price>=start && _.price<=end).ToList();
        }

        public Production getProductMinPrice()
        {
            IMongoCollection<Production> c = client.GetDatabase("Production").GetCollection<Production>("Production");
            return c.Find(new BsonDocument()).ToList().OrderBy(_=>_.price).First();
        }

        public Production getProductMaxPrice()
        {
            IMongoCollection<Production> c = client.GetDatabase("Production").GetCollection<Production>("Production");
            return c.Find(new BsonDocument()).ToList().OrderByDescending(_=>_.price).First();
        }

        public IEnumerable<Production> getProductByFantastic(bool values)
        {
            IMongoCollection<Production> c = client.GetDatabase("Production").GetCollection<Production>("Production");
            return c.Find(_=>_.attribute.fantastic.value == values).ToList();
        }

        public IEnumerable<Production> getProductMinRating()
        {
            IMongoCollection<Production> c = client.GetDatabase("Production").GetCollection<Production>("Production");
            return c.Find(new BsonDocument()).ToList().OrderBy(_=>_.attribute.rating.value);
        }

        public IEnumerable<Production> getProductMaxRating()
        {
            IMongoCollection<Production> c = client.GetDatabase("Production").GetCollection<Production>("Production");
            return c.Find(new BsonDocument()).ToList().OrderByDescending(_=>_.attribute.rating.value);
        }

    }
}
