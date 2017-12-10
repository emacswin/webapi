using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Model;

namespace webapi.DAL
{
    public interface IDataAccess
    {
        IEnumerable<Production> getProduct();
        IEnumerable<Production> getProductByRange(double start,double end);
        Production getProductMinPrice();
        Production getProductMaxPrice();
        IEnumerable<Production> getProductByFantastic(bool values);
        IEnumerable<Production> getProductMinRating();
        IEnumerable<Production> getProductMaxRating();
    }
}
