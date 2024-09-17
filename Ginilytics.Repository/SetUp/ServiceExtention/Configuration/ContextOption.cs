using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ginilytics.Repository.SetUp.ServiceExtention.Configuration
{
   public class ContextOption
    {
        public string ConnectionString { get; set; }
        public ServiceLifetime Lifetime { get; set; }
    }
}
