using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ginilytics.Service.SetUp.Configuration;
using Ginilytics.Service.SetUp.DI;
using Ginilytics.Service.SetUp.ServiceInstallers.Contract;

namespace Ginilytics.Service.SetUp.ServiceInstallers
{
    public static class WirelessSupportServiceCollectionExtentions
    {
        public static IServiceCollection SetupServices(this IServiceCollection services, ServiceConfiguration serviceOptions)
        {
            ResolveServiceInstallers(services, serviceOptions);
            ResolveDependencies(services);

            return services;
        }

        private static void ResolveServiceInstallers(IServiceCollection services, ServiceConfiguration serviceOptions)
        {
            var assemblyServices = typeof(WirelessSupportServiceCollectionExtentions).Assembly
            .DefinedTypes.Where(
                x => typeof(IServiceInstaller).IsAssignableFrom(x)
                    && !x.IsInterface
                    && !x.IsAbstract)
            .Select(Activator.CreateInstance).Cast<IServiceInstaller>().ToList();

            assemblyServices.ForEach(x => x.ConfigureServices(services, serviceOptions));
        }

        private static void ResolveDependencies(IServiceCollection services)
        {
            RepositoryDependencyInjector.Resolve(services);
        }
    }
}
