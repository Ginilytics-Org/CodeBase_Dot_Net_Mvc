using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ginilytics.StartUp.Configuration
{
    public class JwtConfiguration
    {
        [JsonPropertyName("Secret")]
        public string Secret { get; set; }
    }
}
