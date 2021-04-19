using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterFacility.Data.Models.Facility
{
    public class facilitydataset
    {
        public int id { get; set; }
        public int facilityid { get; set; }
        public int datasetid { get; set; }
        public DateTime startdate { get; set; }
        public DateTime enddate { get; set; }
        public bool isactive { get; set; }
        public facility facility { get; set; }

    }
}
