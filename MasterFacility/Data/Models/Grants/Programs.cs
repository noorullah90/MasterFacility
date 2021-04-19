using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MasterFacility.Data.Models.Grants
{
    public class programs
    {
        [Key]
        public string code { get; set; }
        public string donorcode { get; set; }
        public string name { get; set; }
        public string namedari { get; set; }
        public string namepashto { get; set; }
        public DateTime? startdate { get; set; }
        public DateTime? enddate { get; set; }
        public bool isactive { get; set; }

        public ICollection<grant> grants { get; set; }
        public donor donor { get; set; }

    }
}
