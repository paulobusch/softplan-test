using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Softplan.Api2;
using Softplan.Domain.Interfaces.Services;
using Softplan.IntegrationTests._Common.Application;
using Softplan.IntegrationTests._Common.Utils;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Softplan.IntegrationTests
{
    public class SoftplanFixture : IDisposable
    {
        public Request Request { get; private set; }
        public HttpClient Client { get; private set; }
        public TestServer Server { get; private set; }
        public Dictionary<Type, Mock> Mocks { get; private set; }

        private readonly IConfiguration _configuration;

        public SoftplanFixture()
        {
            _configuration = Configuration.GetConfiguration();

            var webHostBuilder = new WebHostBuilder()
                .UseContentRoot(Project.GetDirectory("Softplan.Api2"))
                .ConfigureTestServices(ConfigureTestServices)
                .UseConfiguration(_configuration)
                .UseEnvironment("Development")
                .UseStartup(typeof(Startup));

            Server = new TestServer(webHostBuilder);
            Client = Server.CreateClient();
            Client.BaseAddress = new Uri(" https://localhost:44344");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Request = new Request(Client);
        }

        private void ConfigureTestServices(IServiceCollection services) {
            Mocks = new Dictionary<Type, Mock> {
                { typeof(IApi1Service), new Mock<IApi1Service>() },
            };
            foreach (var typeMock in Mocks) services.AddScoped(typeMock.Key, _ => typeMock.Value.Object);
        }

        public void Dispose()
        {
            Client.Dispose();
            Server.Dispose();
        }
    }
}
