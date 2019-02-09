
using System;
using System.Collections.Generic;
using System.Linq;
using OpsApplicationSettingsCore.Entities;
using OpsApplicationSettingsCore.Services;

namespace OpsApplicationSettingsCore.Data
{
    public class SettingsCoreRepository
    {
        private readonly DBCommunicationContext _context;


        public SettingsCoreRepository(DBCommunicationContext context)
        {
            this._context = context;
        }
        public List<SettingEntity> GetEntities()
        {
            var entities = new List<SettingEntity>();

         //   if (this._context.Database.CanConnect())
         //  {
                entities = this._context.SettingEntities.ToList();
         //   }
            return entities;

        }
    }
}
