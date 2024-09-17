using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ginilytics.StartUp.Configuration
{
    public class AppConfiguration
    {
        [JsonPropertyName("secret")]
        public JwtConfiguration JwtConfig { get; set; }

        [JsonPropertyName("AllowedHosts")]
        public string AllowedHosts { get; set; }
    }
}
