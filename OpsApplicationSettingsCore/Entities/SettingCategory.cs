using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpsApplicationSettingsCore.Entities
{
    [Table(name: "application_settings_categories", Schema = "dbo")]
    public class SettingCategory
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int CategoryOrder { get; set; }
    }
}
