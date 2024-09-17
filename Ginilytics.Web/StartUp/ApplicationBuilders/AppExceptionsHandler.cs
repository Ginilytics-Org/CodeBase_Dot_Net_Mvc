using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Ginilytics.StartUp.ApplicationBuilders.Contracts;

namespace Ginilytics.Web.StartUp.ApplicationBuilders
{
    public class AppExceptionsHandler : IBuilder
    {
        public void AddBuilder(IApplicationBuilder app, IWebHostEnvironment env, IConfiguration configuration)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //    return;
            //}

            UseProductionExceptionHandling(app);
            app.UseHostFiltering();
        }

        private static void UseProductionExceptionHandling(IApplicationBuilder app)
        {
            app.UseExceptionHandler((builder) =>
            {
                builder.Run(async context =>
                {
                    await WriteErrorResponse(context);
                });
            });
        }

        private static async Task WriteErrorResponse(HttpContext context)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "text/html";

            await context.Response.WriteAsync("<p>Internal Server Error!</p>");
        }
    }
}
