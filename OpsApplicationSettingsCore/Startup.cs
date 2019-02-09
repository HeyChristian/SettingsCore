using System.IO;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpsApplicationSettingsCore.Services;

namespace OpsApplicationSettingsCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Global.SetDefaultSettings();
            SetDbContextCredentials();
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // API Key authentication method call
            services.AddAuthentication(options =>
            {
                // Scheme name HAS to match the value we're going to use in AuthenticationBuilder.AddScheme() in Core.PartsProviderAPI.API.Extensions
                options.DefaultAuthenticateScheme = Global.DefaultAuthenticateScheme;
                options.DefaultChallengeScheme = Global.DefaultAuthenticateScheme;
            });
            //.AddAPIKeyAuth(o => { });

            services.AddScoped<SettingsCoreService, SettingsCoreService>();

            // Database server method call
            services.AddDbContext<DBCommunicationContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString(ConnectionString.DefaultConnection.ToString())));

            services.AddMvcCore().AddJsonFormatters().AddAuthorization();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }

        private void SetDbContextCredentials()
        {
            var objJsonAppSetting = File.ReadAllText("appsettings.json");
            var objJsonDeserialize = Newtonsoft.Json.JsonConvert.DeserializeObject<AppSetting>(objJsonAppSetting);

            // Assign DbContext values
            AssignAppSettingValues(ref objJsonDeserialize);

            var objJsonSerialize = Newtonsoft.Json.JsonConvert.SerializeObject(objJsonDeserialize, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText("appsettings.json", objJsonSerialize);
        }


        // Set AppSettings object values
        private void AssignAppSettingValues(ref AppSetting appSetting)
        {
            var strCredentials = appSetting.connectionString.defaultConnection;
            var arrCredentials = strCredentials.Split(';');
            var dicCredentials = arrCredentials.Select(x => x.Split('=')).ToDictionary(y => y[0], y => y[1]);

            AddDefaultConnection(ref appSetting, dicCredentials);
        }
        private void AddDefaultConnection(ref AppSetting appSetting, Dictionary<string, string> dicCredentials)
        {
            AssignDefaultConnectionValues(ref dicCredentials);

            var userID = string.Concat(ConnectionString.User.ToString(), new string(' ', 1), ConnectionString.Id.ToString());
            var objServer = string.Concat(ConnectionString.Server.ToString(), new string('=', 1), dicCredentials[ConnectionString.Server.ToString()]);
            var objDatabase = string.Concat(ConnectionString.Database.ToString(), new string('=', 1), dicCredentials[ConnectionString.Database.ToString()]);
            var objUserID = string.Concat(userID, new string('=', 1), dicCredentials[userID]);
            var objPassword = string.Concat(ConnectionString.Password.ToString(), new string('=', 1), dicCredentials[ConnectionString.Password.ToString()]);
            var objTrustedConnection = string.Concat(ConnectionString.Trusted_Connection.ToString(), new string('=', 1), dicCredentials[ConnectionString.Trusted_Connection.ToString()]);
            var objResultSets = string.Concat(ConnectionString.MultipleActiveResultSets.ToString(), new string('=', 1), dicCredentials[ConnectionString.MultipleActiveResultSets.ToString()]);

            appSetting.connectionString.defaultConnection = string.Concat(objServer, objDatabase, objUserID, objPassword, objTrustedConnection, objResultSets);
            appSetting.logging.logLevel.Default = "Warning";
            appSetting.allowedHosts = "*";
        }
        private void AssignDefaultConnectionValues(ref Dictionary<string, string> dicCredentials)
        {
            var userID = string.Concat(ConnectionString.User.ToString(), new string(' ', 1), ConnectionString.Id.ToString());

            // From S3 CloudFront on AWS
            dicCredentials[ConnectionString.Server.ToString()] = "db.dev1.opstrax.com;";
            dicCredentials[ConnectionString.Database.ToString()] = "ops_dfw_prod;";
            dicCredentials[userID] = "ops;";
            dicCredentials[ConnectionString.Password.ToString()] = "Ops2016!;";
            dicCredentials[ConnectionString.Trusted_Connection.ToString()] = "False;";
            dicCredentials[ConnectionString.MultipleActiveResultSets.ToString()] = "true;";
        }
        private enum ConnectionString
        {
            DefaultConnection = 1,
            Server = 2,
            Database = 3,
            User = 4,
            Id = 5,
            Password = 6,
            Trusted_Connection = 7,
            MultipleActiveResultSets = 8,
        };
    }
}
