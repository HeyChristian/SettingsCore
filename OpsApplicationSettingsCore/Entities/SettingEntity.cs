using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpsApplicationSettingsCore.Entities
{
    [Table(name: "application_settings_entity_type_lk", Schema = "dbo")]
    public class SettingEntity
    {
        [Key]
        public int EntityId { get; set; }
        public string EntityType { get; set; }
    }
}
