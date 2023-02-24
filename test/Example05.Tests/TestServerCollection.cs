using Xunit;

namespace Example05.Tests
{
    [CollectionDefinition(Name)]
    public sealed class TestServerCollection : ICollectionFixture<TestServerFixture>
    {
        public const string Name = "TestServerCollectionTests";
    }
}