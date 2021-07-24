using Microsoft.Extensions.Configuration;
using System;

namespace Softplan.IntegrationTests._Common.Application
{
    public static class Configuration
    {
        public static IConfiguration GetConfiguration(string environment = default)
        {
            if (string.IsNullOrWhiteSpace(environment))
                environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
            return new ConfigurationBuilder()
                .SetBasePath(Project.GetDirectory("Softplan.Api2"))
                .AddJsonFile($"appsettings.{environment}.json")
                .Build();
        }
    }
}
