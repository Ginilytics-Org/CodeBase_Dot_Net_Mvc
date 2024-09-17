using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ginilytics.Repository.SetUp.ServiceExtention.Configuration;
using Ginilytics.Service.Services;
using Ginilytics.Service.Services.Contracts;
using Ginilytics.Service.SetUp.Configuration;
using Ginilytics.Service.SetUp.ServiceInstallers;
using Ginilytics.StartUp.Configuration;
using Ginilytics.StartUp.ServiceInstallers.Contracts;

namespace Ginilytics.StartUp.ServiceInstallers
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
        }

        private static void SetupServices(IServiceCollection services, IConfiguration configuration)
        {

            var connectionString = configuration.GetSection("ConnectionString").Value;
            services.SetupServices(new ServiceConfiguration
            {
                ConnectionString = connectionString,
                Lifetime = ServiceLifetime.Scoped
            });

            var appSettingsSection = configuration.GetSection("AppSettings");
            services.Configure<AppConfiguration>(appSettingsSection);

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/account/login";
                options.LogoutPath = $"/account/logout";
                options.AccessDeniedPath = $"/account/accessDenied";
            });
            
        }


    }
}
