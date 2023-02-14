using System.Collections.Generic;
using Example02.Models;

namespace Example02.Services
{
    public interface IProductService
    {
        Product GetProductById(int id);

        ICollection<Product> GetProducts();
    }
}
