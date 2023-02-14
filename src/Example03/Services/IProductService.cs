using System.Collections.Generic;
using Example03.Models;

namespace Example03.Services
{
    public interface IProductService
    {
        Product GetProductById(int id);

        ICollection<Product> GetProducts();
    }
}
