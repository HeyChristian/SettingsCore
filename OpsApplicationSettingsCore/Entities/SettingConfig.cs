using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpsApplicationSettingsCore.Entities
{
    [Table(name: "application_settings_config", Schema = "dbo")]
    public class SettingConfig
    {
        [Key]
        public int SettingKeyId { get; set; }
        public int AppId { get; set; }
        public int EntityId { get; set; }
        public string SettingKey { get; set; }
        public string SettingName { get; set; }
        public string SettingDesc { get; set; }
        public int DataTypeId { get; set; }
        public bool InternalUse { get; set; }
        public string DefaultValue { get; set; }
        public System.DateTime CreateDate { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public string FeatureCode { get; set; }
        public int CategoryId { get; set; }
    }
}
