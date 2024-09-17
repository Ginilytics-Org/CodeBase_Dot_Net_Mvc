using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ginilytics.Service.SetUp.DI
{
    internal static class RepositoryDependencyInjector
    {
        internal static void Resolve(IServiceCollection services)
        {
            //services.AddScoped<ILoginRepository, LoginRepository>();
        }
    }
}
