using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Example05.Models;
using FluentAssertions;
using Xunit;

namespace Example05.Tests
{
    [Collection(TestServerCollection.Name)]
    public class ProductsControllerTests
    {
        private readonly TestServerFixture _httpServerFixture;

        public ProductsControllerTests(TestServerFixture httpServerFixture)
        {
            _httpServerFixture = httpServerFixture;
        }

        [Fact]
        public async Task Should_Get_Products()
        {
            using (var client = _httpServerFixture.CreateHttpClient())
            {
                using (var response = await client.GetAsync("api/products"))
                {
                    response.Should().NotBeNull();
                    response.IsSuccessStatusCode.Should().BeTrue();
                    var products = await response.Content.ReadAsAsync<List<Product>>();
                    products.Should().NotBeNullOrEmpty();
                }
            }
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async Task Should_Get_Product_By_Id(int productId)
        {
            using (var client = _httpServerFixture.CreateHttpClient())
            {
                using (var response = await client.GetAsync($"api/products/{productId}"))
                {
                    response.Should().NotBeNull();
                    response.IsSuccessStatusCode.Should().BeTrue();
                    var product = await response.Content.ReadAsAsync<Product>();
                    product.Should().NotBeNull();
                    product.Id.Should().Be(productId);
                }
            }
        }
    }
}
