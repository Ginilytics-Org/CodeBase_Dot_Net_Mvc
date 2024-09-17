﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ginilytics.StartUp.ApplicationBuilders.Contracts;

namespace Ginilytics.StartUp.ApplicationBuilders
{
    public static class ApplicationBuilderExtention
    {
        public static void BuildApplication(this IApplicationBuilder app, IWebHostEnvironment env, IConfiguration configuration)
        {
            var builders = typeof(ApplicationBuilderExtention).Assembly
                        .ExportedTypes.Where(
                            x => typeof(IBuilder).IsAssignableFrom(x)
                                && !x.IsInterface
                                && !x.IsAbstract)
                        .Select(Activator.CreateInstance).Cast<IBuilder>().ToList();

            builders.ForEach(x => x.AddBuilder(app, env, configuration));

           
        }
    }
}
