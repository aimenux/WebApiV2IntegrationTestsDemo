using Xunit;

namespace Example06.Tests
{
    [CollectionDefinition(Name)]
    public sealed class TestServerCollection : ICollectionFixture<TestServerFixture>
    {
        public const string Name = "TestServerCollectionTests";
    }
}