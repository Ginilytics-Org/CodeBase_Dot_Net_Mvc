using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WirelessSupport.API.StartUp.ServiceInstallers.Contracts;
using WirelessSupport.Service.Services;
using WirelessSupport.Service.Services.Contracts;
using WirelessSupport.Service.SetUp.Configuration;
using WirelessSupport.Service.SetUp.ServiceInstallers;
using WirelessSupport.Service.SetUp.ServiceInstallers.Configuration;

namespace WirelessSupport.API.StartUp.ServiceInstallers
{
    public class ServiceInstaller : IInstaller
    {

        void IInstaller.ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            ResolvServiceDependencies(services, configuration);
            SetupServices(services, configuration);
        }

        private static void ResolvServiceDependencies(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ILogInService, LogInService>();
            services.AddScoped<IEmailService, EmailService>();
            services.Configure<ServiceJwtConfiguration>(configuration.GetSection("Jwt"));
        }

        private static void SetupServices(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("ConnectionString").Value;
            services.SetupServices(new ServiceConfiguration
            {
                ConnectionString = connectionString,
                Lifetime = ServiceLifetime.Scoped
            });
        }


    }
}
