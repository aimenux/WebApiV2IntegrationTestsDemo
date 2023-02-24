using Microsoft.Owin.Testing;
using System;
using System.Net.Http;

namespace Example05.Tests
{
    public sealed class TestServerFixture : IDisposable
    {
        private readonly TestServer _testServer;

        public TestServerFixture()
        {
            _testServer = TestServer.Create<Startup>();
        }

        public HttpClient CreateHttpClient() => _testServer.HttpClient;

        public void Dispose()
        {
            _testServer?.Dispose();
        }
    }
}
