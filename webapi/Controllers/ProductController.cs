using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using webapi.Model;
using System.Collections.ObjectModel;
using webapi.DAL;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IDataAccess mongodbAccess;

        public ProductController(IDataAccess dataAccess)
        {
            mongodbAccess = dataAccess;
        }

        // get api/product
        [HttpGet]
        public IEnumerable<Production> Get()
        {
            return mongodbAccess.getProduct();
        }

        [Route("get-product")]
        public IEnumerable<Production> GetProduct(double start,double end)
        {
            return mongodbAccess.getProductByRange(start,end);
        }

        [Route("get-product-min")]
        public Production GetProductMinPrice()
        {
            return mongodbAccess.getProductMinPrice();
        }

        [Route("get-product-max")]
        public Production GetProductMaxPrice()
        {
            return mongodbAccess.getProductMaxPrice();
        }

        //http://localhost:3668/api/product/get-product-fantastic?values=false
        [Route("get-product-fantastic")]
        public IEnumerable<Production> GetProductByFantastic(bool values)
        {
            return mongodbAccess.getProductByFantastic(values);
        }

        //http://localhost:3668/api/product/get-product-min-rating
        [Route("get-product-min-rating")]
        public IEnumerable<Production> getProductMinRating()
        {
            return mongodbAccess.getProductMinRating();
        }

        //http://localhost:3668/api/product/get-product-max-rating
        [Route("get-product-max-rating")]
        public IEnumerable<Production> getProductMaxRating()
        {
            return mongodbAccess.getProductMaxRating();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}