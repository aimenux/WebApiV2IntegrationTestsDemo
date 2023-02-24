using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Example05.Models;

namespace Example05.Controllers
{
    public class ProductsController : ApiController
    {
        private static readonly ICollection<Product> Products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Bread",
                Price = 1.5m
            },
            new Product
            {
                Id = 2,
                Name = "Sugar",
                Price = 2.5m
            }
        };

        [HttpGet]
        public ICollection<Product> GetProducts()
        {
            return Products;
        }

        [HttpGet]
        public Product GetProductById(int id)
        {
            return Products.FirstOrDefault(x => x.Id == id);
        }
    }
}