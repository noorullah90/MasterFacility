using MasterFacility.Data.Models.Lookups;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MasterFacility.Data.Models.Grants
{
    public class grant
    {
        [Key]
        public string  code { get; set; }
        public int implementerid { get; set; }
        public string programcode { get; set; }
        public DateTime? startdate { get; set; }
        public DateTime? enddate { get; set; }
        public bool isactive { get; set; }

        public implementers implementer { get; set; }
        public programs program { get; set; }

    }
}
