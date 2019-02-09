using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpsApplicationSettingsCore.Entities
{

    [Table(name: "application_settings_options", Schema = "dbo")]
    public class SettingOption
    {
        public int SettingOptionId { get; set; }
        public string SettingKey { get; set; }
        public string SettingOptionName { get; set; }
        public string SettingOptionValue { get; set; }
    }
}
