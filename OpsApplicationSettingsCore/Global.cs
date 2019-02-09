using System;
using System.IO;

namespace OpsApplicationSettingsCore
{
    public static class Global
    {
        public static readonly string DefaultAuthenticateScheme = "APIKey Scheme";

        public static readonly string DefaultAuthenticationAPIKey = "APIKey Authentication";

        public static void SetDefaultSettings()
        {
            var objJsonAppSetting = File.ReadAllText("defaultappsettings.json");
            var objJsonDeserialize = Newtonsoft.Json.JsonConvert.DeserializeObject<AppSetting>(objJsonAppSetting);

            var objJsonSerialize = Newtonsoft.Json.JsonConvert.SerializeObject(objJsonDeserialize, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText("appsettings.json", objJsonSerialize);
        }

        public enum GlobalContext
        {
            ServiceKingDbContext = 1,
            api_key = 2,
        };
    }
}
