using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MasterFacility.Models.Lookups
{
    public class language
    {
        [Key]
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
    }
}
