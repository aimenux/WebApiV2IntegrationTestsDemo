using System.Collections.Generic;
using System.Linq;
using Example03.Models;

namespace Example03.Services
{
    public class ProductService : IProductService
    {
        private static readonly Product[] Products = new[]
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

        public Product GetProductById(int id)
        {
            return Products.FirstOrDefault(x => x.Id == id);
        }

        public ICollection<Product> GetProducts()
        {
            return Products;
        }
    }
}
