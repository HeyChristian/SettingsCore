using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpsApplicationSettingsCore.Services;

namespace OpsApplicationSettingsCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public sealed class SettingsCoreController : ControllerBase
    {
        private readonly SettingsCoreService service;
        public SettingsCoreController(SettingsCoreService service)
        {
            this.service = service;
        }
        [HttpGet]
        [Route("entities")]
        public ActionResult<string> GetEntities()
        {
            return this.Ok(service.GetEntityTypes());
        }
    }
}
