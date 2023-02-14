using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace Example01.Tests
{
    public sealed class HttpServerFixture : IDisposable
    {
        private readonly HttpServer _httpServer;
        
        public HttpServerFixture()
        {
            var config = new HttpConfiguration
            {
                IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always
            };

            WebApiConfig.Register(config);

            _httpServer = new HttpServer(config);
        }
        
        public HttpClient CreateHttpClient()
        {
            var httpClient = new HttpClient(_httpServer, false)
            {
                BaseAddress = new Uri("http://localhost")
            };
            
            httpClient.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            return httpClient;
        }

        public void Dispose()
        {
            _httpServer?.Dispose();
        }
    }
}
