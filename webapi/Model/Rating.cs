using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.Model
{
    public class Rating
    {
        public double value { get; set; }
        public int type { get; set; }
        public string name { get; set; }
    }
}
