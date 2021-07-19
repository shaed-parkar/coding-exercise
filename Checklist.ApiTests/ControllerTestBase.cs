using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;

namespace Checklist.ApiTests
{
    public abstract class ControllerTestsBase
    {
        private TestServer Server;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            var webHostBuilder = WebHost.CreateDefaultBuilder()
                .UseKestrel()
                .UseEnvironment("Development")
                .UseStartup<Startup>();
            Server = new TestServer(webHostBuilder);
        }
        
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Server.Dispose();
        }
        
        private HttpClient CreateClient()
        {
            return Server.CreateClient();
        }
        
        protected async Task<HttpResponseMessage> SendGetRequestAsync(string uri)
        {
            using var client = CreateClient();
            return await client.GetAsync(uri);
        }

        protected async Task<HttpResponseMessage> SendPostRequestAsync(string uri, HttpContent httpContent)
        {
            using var client = CreateClient();
            return await client.PostAsync(uri, httpContent);
        }

        protected async Task<HttpResponseMessage> SendPatchRequestAsync(string uri, StringContent httpContent)
        {
            using var client = CreateClient();
            return await client.PatchAsync(uri, httpContent);
        }

        protected async Task<HttpResponseMessage> SendPutRequestAsync(string uri, StringContent httpContent)
        {
            using var client = CreateClient();
            return await client.PutAsync(uri, httpContent);
        }

        protected async Task<HttpResponseMessage> SendDeleteRequestAsync(string uri)
        {
            using var client = CreateClient();
            return await client.DeleteAsync(uri);
        }
    }
}