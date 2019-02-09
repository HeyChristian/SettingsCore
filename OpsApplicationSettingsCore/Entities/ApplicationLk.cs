using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace OpsApplicationSettingsCore.Entities
{
   
        [Table(name: "applications_lk", Schema = "dbo")]
        public sealed class ApplicationLk
        {
            [Key]
            public int ApplicationId { get; set; }
            public string Name { get; set; }
            public string DefaultUrl { get; set; }
            public int CompanyTypeId { get; set; }
            public int AppLang { get; set; }
            public int DefaultAppVersionId { get; set; }
            public int ProductId { get; set; }
            public bool HasQuantity { get; set; }
        }

}
