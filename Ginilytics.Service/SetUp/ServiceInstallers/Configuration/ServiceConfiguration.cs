using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ginilytics.Service.SetUp.Configuration
{
    public class ServiceConfiguration
    {
        public string ConnectionString { get; set; }
        public ServiceLifetime Lifetime { get; set; }
    }
}
