using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Ginilytics.Service.SetUp.Configuration;

namespace Ginilytics.Service.SetUp.ServiceInstallers.Contract
{
    interface IServiceInstaller
    {
        internal void ConfigureServices(IServiceCollection services, ServiceConfiguration configuration);
    }
}
