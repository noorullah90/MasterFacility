using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterFacility.Data.Models.Grants
{
    public class implementers
    {
        public int id { get; set; }
        public string abbreviation { get; set; }
        public string name { get; set; }
        public string namedari { get; set; }
        public string namepashto { get; set; }
        public DateTime? registerationdate { get; set; }
        public string? afghanistanaddress { get; set; }
        public string? otheraddress { get; set; }
        public string? website { get; set; }
        public bool isactive { get; set; }

        public ICollection<grant> grants { get; set; }
    }
}
