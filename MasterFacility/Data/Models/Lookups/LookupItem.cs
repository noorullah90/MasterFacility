using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MasterFacility.Data.Models.Lookups
{
    public class lookupitem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        public int lookupid { get; set; }

        [Remote(action: "IsHmisExists", controller:"Lookups", areaName:"Administration", HttpMethod = "Post", AdditionalFields = "id,lookupid")]
        public string hmisid { get; set; }
        [MaxLength(100)]
        public string name { get; set; }
        [MaxLength(100)]
        public string namedari { get; set; }
        [MaxLength(100)]
        public string namepashto { get; set; }
        public int? parentid { get; set; }
        public lookupitem parent { get; set; }
        public ICollection<lookupitem> lookupitems { get; set; }
        public int? order { get; set; }
        public bool isactive { get; set; }
        public lookup lookup { get; set; }
    }
}
