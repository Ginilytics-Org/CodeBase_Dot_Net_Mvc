using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WirelessSupport.API.StartUp.Configuration;
using WirelessSupport.API.StartUp.ServiceInstallers.Contracts;

namespace WirelessSupport.API.StartUp.ServiceInstallers.Extentions
{
    public static class ServiceExtentions
    {
        public static void InstallConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppConfiguration>(configuration);
            services.Configure<JwtConfiguration>(configuration.GetSection("Jwt"));
        }

        public static void AddInstallers(this IServiceCollection services, IConfiguration configuration)
        {
            var middlewares = typeof(ServiceExtentions).Assembly
                        .ExportedTypes.Where(
                            x => typeof(IInstaller).IsAssignableFrom(x)
                                && !x.IsInterface
                                && !x.IsAbstract)
                        .Select(Activator.CreateInstance)
                        .Cast<IInstaller>()
                        .ToList();

            middlewares.ForEach(x => x.ConfigureServices(services, configuration));
        }
    }
}
