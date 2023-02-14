using System;
using System.Collections.Generic;
using System.Web.Http;
using Example02.Models;
using Example02.Services;

namespace Example02.Controllers
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