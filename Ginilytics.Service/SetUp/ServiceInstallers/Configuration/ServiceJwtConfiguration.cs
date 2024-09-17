using System;
using System.Collections.Generic;
using System.Text;

namespace Ginilytics.Service.SetUp.ServiceInstallers.Configuration
{
    public class ServiceJwtConfiguration
    {
        public string Secret { get; set; }
        public int ExpiryTimeInSeconds { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
