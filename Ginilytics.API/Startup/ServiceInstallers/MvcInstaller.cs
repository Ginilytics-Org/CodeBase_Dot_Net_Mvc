using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WirelessSupport.API.StartUp.ServiceInstallers.Contracts;

namespace WirelessSupport.API.StartUp.ServiceInstallers
{
    public class MvcInstaller : IInstaller
    {
        void IInstaller.ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();

            services
                .AddMvc(options =>
                {
                    options.EnableEndpointRouting = false;
                    //options.Filters.Add(typeof(CustomAuthorizationFilter));
                })
                .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);
        }
    }
}
