using System;
using System.Collections.Generic;
using webapi.Controllers;
using webapi.DAL;
using webapi.Model;
using Xunit;
using Microsoft.AspNetCore.Mvc;

namespace webapi_test
{
    public class WebApiTest
    {
        [Fact]
        public void ProductController_ShouldReturnAllProduct ()
        {
            DataAccess da = new DataAccess();

            IEnumerable<Production> x = da.getProduct();

            int counter = 0;

            foreach(Production p in x)
            {
                counter++;
            }

            ProductController controller = new ProductController(da);

            IEnumerable<Production> y = controller.Get();

            int counter1 = 0;

            foreach (Production p in y)
            {
                counter1++;
            }

            Assert.Equal(counter, counter1);
        }

        [Fact]
        public void ProductController_ShouldNotFindProduct()
        {
            DataAccess da = new DataAccess();
            ProductController controller = new ProductController(da);

            IEnumerable<Production> x = controller.GetProduct(1000, 2000);

            int counter = 0;

            foreach (Production p in x)
            {
                counter++;
            }

            Assert.Equal(counter, 0);

        }


        [Fact]
        public void ProductController_FantasticShouldBeTrue()
        {
            DataAccess da = new DataAccess();
            ProductController controller = new ProductController(da);

            IEnumerable<Production> x = controller.GetProductByFantastic(true);

            foreach (Production p in x)
            {
                Assert.Equal(p.attribute.fantastic.value, true);
            }

            IEnumerable<Production> y = controller.GetProductByFantastic(false);

            foreach (Production p in y)
            {
                Assert.Equal(p.attribute.fantastic.value, false);
            }
        }

        [Fact]
        public void ProductController_FindMinAndMax()
        {
            DataAccess da = new DataAccess();
            ProductController controller = new ProductController(da);

            IEnumerable<Production> x = controller.Get();

            Production min = controller.GetProductMinPrice();

            Production max = controller.GetProductMaxPrice();

            foreach (Production p in x)
            {
                Assert.True(p.price >= min.price);

                Assert.True(p.price <= max.price);
            }
        }

        [Fact]
        public void ProductController_FindMinAndMaxRating()
        {
            DataAccess da = new DataAccess();
            ProductController controller = new ProductController(da);

            IEnumerable<Production> x = controller.Get();
            IEnumerable<Production> min = controller.getProductMinRating();
            IEnumerable<Production> max = controller.getProductMaxRating();
            double minRating = double.MaxValue;
            double maxRating = double.MinValue;
            foreach(Production p in min)
            {
                minRating = p.attribute.rating.value;
                break;
            }

            foreach (Production p in max)
            {
                maxRating = p.attribute.rating.value;
                break;
            }

            foreach (Production p in x)
            {
                Assert.True(p.attribute.rating.value >= minRating);

                Assert.True(p.attribute.rating.value <= maxRating);
            }
        }

    }
}
