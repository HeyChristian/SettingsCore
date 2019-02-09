using System;
using Microsoft.EntityFrameworkCore;
using OpsApplicationSettingsCore.Entities;

namespace OpsApplicationSettingsCore.Services
{
    public class DBCommunicationContext: DbContext
    {
        public DBCommunicationContext(DbContextOptions<DBCommunicationContext> options)
             : base(options)
        { }

        public DbSet<ApplicationLk> Applications { get; set; }
        public DbSet<SettingConfig> SettingConfigs { get; set; }
        public DbSet<SettingCategory> SettingCategories { get; set; }
        public DbSet<SettingEntity> SettingEntities { get; set; }
        public DbSet<SettingOption> SettingOptions { get; set; }
        public DbSet<SettingDataType> SettingDataTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(db.dev1.opstrax.com)\mssqllocaldb;Database=ops_dfw_prod;Trusted_Connection=True;");
        }
    }
}
