using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpsApplicationSettingsCore.Entities
{
    [Table(name: "application_settings_data_types_lk", Schema = "dbo")]
    public class SettingDataType
    {
        [Key]
        public int DataTypeId { get; set; }
        public int DataTypeValue { get; set; }
    }
}
