using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Ginilytics.Repository.SetUp.Contract;
using Ginilytics.Repository.SetUp.Provider;
using Ginilytics.Repository.SetUp.ServiceExtention.Configuration;

namespace Ginilytics.Repository.SetUp.ServiceExtention
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDapperDbContext(this IServiceCollection services, DapperOptions dapperOptions) => ResolveDbProviders(services, dapperOptions);

        private static IServiceCollection ResolveDbProviders(IServiceCollection services, DapperOptions dapperOptions)
        {
            services.Add(ServiceDescriptor.Describe(typeof(IDbProvider), (provider) =>
            {
                return new DbProvider(dapperOptions.ConnectionString);
            }, dapperOptions.Lifetime));

            return services;
        }


        private static IServiceCollection ResolveDbContext(IServiceCollection services, DapperOptions dapperOptions)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(dapperOptions.ConnectionString));
            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();
            return services;
        }
    }
}
