using MasterFacility.Data.Models.Facility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MasterFacility.Data.Models.Lookups
{
    public class district
    {

        [Key]
        public int id { get; set; }

        [Display(Name = "Province", ResourceType = typeof(AppResources.Common))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AppResources.ValidationMessages))]

        public int provinceid { get; set; }

        [Display(Name = "Name", ResourceType = typeof(AppResources.Common))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AppResources.ValidationMessages))]
        [MaxLength(100)]
        public string name { get; set; }

        [Display(Name = "NameDari", ResourceType = typeof(AppResources.Common))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AppResources.ValidationMessages))]
        [MaxLength(100)]
        public string namedari { get; set; }

        [Display(Name = "NamePashto", ResourceType = typeof(AppResources.Common))]
        [MaxLength(100)]
        public string namepashto { get; set; }

        [Display(Name = "IsActive", ResourceType = typeof(AppResources.Common))]
        public bool isactive { get; set; }
        public province province { get; set; }

        public ICollection<facility> facilities { get; set; }
    }
}
