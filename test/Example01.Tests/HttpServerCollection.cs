using Xunit;

namespace Example01.Tests
{
    [CollectionDefinition(Name)]
    public sealed class HttpServerCollection : ICollectionFixture<HttpServerFixture>
    {
        public const string Name = "HttpServerCollectionTests";
    }
}