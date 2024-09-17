using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NLog;
using NLog.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WirelessSupport.API.StartUp.ServiceInstallers.Contracts;

namespace WirelessSupport.API.StartUp.ServiceInstallers
{
    public class MiddlewaresInstaller : IInstaller
    {
        void IInstaller.ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            AddLogger(services, configuration);
            AddAuthentication(services, configuration);
            AddSwagger(services);
            AddCors(services, configuration);
        }


        private static void AddSwagger(IServiceCollection services) =>
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WirelessSupport API", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using bearer token",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme {
                            Reference= new OpenApiReference {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        }, new List<string>()
                    }
                });
            });

        private static void AddLogger(IServiceCollection services, IConfiguration configuration)
        {
            var logLevel = (Microsoft.Extensions.Logging.LogLevel)Enum.Parse(typeof(Microsoft.Extensions.Logging.LogLevel), configuration.GetSection("Logging:LogLevel:Default").Value);
            var nLogConfig = configuration.GetSection("NLog");

            services.AddLogging(logBuilder =>
            {
                logBuilder.ClearProviders();
                logBuilder.SetMinimumLevel(logLevel);

                LogManager.Configuration = new NLogLoggingConfiguration(nLogConfig);
                logBuilder.AddNLog(nLogConfig);
            });
        }

        private static void AddAuthentication(IServiceCollection services, IConfiguration configuration) =>
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.IncludeErrorDetails = false;

                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration.GetSection("Jwt:Secret").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    RequireExpirationTime = true,
                };
            });

        private static void AddCors(IServiceCollection services, IConfiguration configuration) =>
            services.AddCors(options =>
            {
                options.AddPolicy(configuration.GetSection("CorsSettings:DefaultPolicyName").Value,
                    builder => builder.WithOrigins(configuration.GetSection("CorsSettings:ProdClientAppUrl").Get<string[]>())
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                    );
            });


    }
}
