using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterFacility.Data.Models.Facility
{
    public class facilityhumanresources
    {
        public int id { get; set; }
        public int facilityid { get; set; }
        public int positionid { get; set; }
        public int numberofworkers { get; set; }
        public int sequencenumber { get; set; }

        public facility facility { get; set; }
    }
}
