using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WirelessSupport.API.StartUp.ApplicationBuilders.Contract;

namespace WirelessSupport.API.StartUp.ApplicationBuilders
{
    public class MvcBuilder : IBuilder
    {
        public void AddBuilder(IApplicationBuilder app, IWebHostEnvironment env, IConfiguration configuration)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WirelessSupport API v1"));

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors(configuration.GetSection("CorsSettings:DefaultPolicyName").Value);

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
