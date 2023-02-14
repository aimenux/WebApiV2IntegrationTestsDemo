using System;
using System.Collections.Generic;
using System.Web.Http;
using Example03.Models;
using Example03.Services;

namespace Example03.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        [HttpGet]
        public ICollection<Product> GetProducts()
        {
            return _productService.GetProducts();
        }

        [HttpGet]
        public Product GetProductById(int id)
        {
            return _productService.GetProductById(id);
        }
    }
}