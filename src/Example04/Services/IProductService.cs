using System.Collections.Generic;
using Example04.Models;

namespace Example04.Services
{
    public interface IProductService
    {
        Product GetProductById(int id);

        ICollection<Product> GetProducts();
    }
}
