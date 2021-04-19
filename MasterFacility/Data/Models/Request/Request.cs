using MasterFacility.Data.Models.Facility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterFacility.Data.Models.Request
{
    public class request
    {
        public int id { get; set; }
        public int requesttypeid { get; set; }
        public int userid { get; set; }
        public DateTime date { get; set; }
        public string remarks { get; set; }
        public int requeststatusid { get; set; }

        public newfacilityrequestdetail requestedfacilitydetail { get; set; }

        public requestforupdate requestedupdate { get; set; }

        public ICollection<facilitydocument> documents { get; set; }
    }
}
