using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MasterFacility.Data.Models.Lookups
{
    public class lookup
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required(ErrorMessageResourceName = "Name", ErrorMessageResourceType = typeof(AppResources.Common))]
        [MaxLength(100)]
        public string name { get; set; }

        [Required(ErrorMessageResourceName = "Name", ErrorMessageResourceType = typeof(AppResources.Common))]
        [MaxLength(100)]
        public string namedari { get; set; }

        [MaxLength(100)]
        public string namepashto { get; set; }

        public ICollection<lookupitem> lookupitems { get; set; }
    }
}
