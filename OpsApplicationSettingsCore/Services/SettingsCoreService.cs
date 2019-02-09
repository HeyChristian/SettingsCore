using System;
using System.Collections.Generic;
using OpsApplicationSettingsCore.Data;
using OpsApplicationSettingsCore.Entities;

namespace OpsApplicationSettingsCore.Services
{
    public class SettingsCoreService
    {
        public static SettingsCoreRepository repository;
        public static DBCommunicationContext _context;
        public SettingsCoreService(DBCommunicationContext context)
        {
            _context = context;
            repository = new SettingsCoreRepository(_context);
        }

        public List<SettingEntity> GetEntityTypes()
        {

            return repository.GetEntities();
        }
    }
}
