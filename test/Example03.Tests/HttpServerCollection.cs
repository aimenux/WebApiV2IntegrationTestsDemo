using Example03.Tests;
using Xunit;

namespace WebApiOneTests
{
    [CollectionDefinition(Name)]
    public sealed class HttpServerCollection : ICollectionFixture<HttpServerFixture>
    {
        public const string Name = "HttpServerCollectionTests";
    }
}