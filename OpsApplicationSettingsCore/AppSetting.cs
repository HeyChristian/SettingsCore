using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
namespace OpsApplicationSettingsCore
{

    public class AppSetting
    {
        [JsonProperty("Logging")]
        public Logging logging { get; set; }

        [JsonProperty("AllowedHosts")]
        public string allowedHosts { get; set; }

        [JsonProperty("ConnectionStrings")]
        public ConnectionString connectionString { get; set; }
    }
    public class Logging
    {
        [JsonProperty("LogLevel")]
        public LogLevel logLevel { get; set; }
    }
    public class LogLevel
    {
        [JsonProperty("Default")]
        public string Default { get; set; }
    }
    public class ConnectionString
    {
        [JsonProperty("DefaultConnection")]
        public string defaultConnection { get; set; }
    }
}
