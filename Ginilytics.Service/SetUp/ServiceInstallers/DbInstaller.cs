using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Ginilytics.Repository.SetUp.Provider;
using Ginilytics.Repository.SetUp.ServiceExtention;
using Ginilytics.Repository.SetUp.ServiceExtention.Configuration;
using Ginilytics.Service.SetUp.Configuration;
using Ginilytics.Service.SetUp.ServiceInstallers.Contract;

namespace Ginilytics.Service.SetUp.ServiceInstallers
{
    internal class DbInstaller : IServiceInstaller
    {
        void IServiceInstaller.ConfigureServices(IServiceCollection services, ServiceConfiguration configuration) =>
                services.AddDapperDbContext(new DapperOptions
                {
                    ConnectionString = configuration.ConnectionString,
                    Lifetime = configuration.Lifetime
                });

    }
}
