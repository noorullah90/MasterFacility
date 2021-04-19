using MasterFacility.Data.Models.Grants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MasterFacility.Data.Models.Grants

{
    public class donor
    {
        [Key]
        public string code { get; set; }
        public int donortypeid { get; set; }
        [Display(Name = "Name", ResourceType = typeof(AppResources.Common))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AppResources.ValidationMessages))]
        [MaxLength(100)]
        public string name { get; set; }
        
        [Display(Name = "NameDari", ResourceType = typeof(AppResources.Common))]
        [MaxLength(100)]
        public string namedari { get; set; }
        [Display(Name = "NamePashto", ResourceType = typeof(AppResources.Common))]
        [MaxLength(100)]
        public string namepashto { get; set; }

        [Display(Name = "IsActive", ResourceType = typeof(AppResources.Common))]
        public bool isactive { get; set; }

        public ICollection<programs> programs { get; set; }
    }
}
