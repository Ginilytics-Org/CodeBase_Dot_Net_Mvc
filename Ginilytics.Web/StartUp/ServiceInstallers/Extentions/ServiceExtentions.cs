using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ginilytics.Model.ViewModel;
using Ginilytics.StartUp.Configuration;
using Ginilytics.StartUp.ServiceInstallers.Contracts;

namespace Ginilytics.StartUp.ServiceInstallers.Extentions
{
    public static class ServiceExtentions
    {
        public static void InstallConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettingsSection = configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
        }

        public static void AddInstallers(this IServiceCollection services, IConfiguration configuration)
        {
            var middlewares = typeof(ServiceExtentions).Assembly.ExportedTypes.Where(x => typeof(IInstaller).IsAssignableFrom(x)
                                && !x.IsInterface
                                && !x.IsAbstract)
                        .Select(Activator.CreateInstance)
                        .Cast<IInstaller>()
                        .ToList();

            middlewares.ForEach(x => x.ConfigureServices(services, configuration));
        }

    }
}
