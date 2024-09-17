using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ginilytics.StartUp.ServiceInstallers.Contracts
{
    interface IInstaller
    {
        internal void ConfigureServices(IServiceCollection services, IConfiguration configuration);
    }
}
