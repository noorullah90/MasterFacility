using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterFacility.Data.Models.Facility
{
    public class privatefacilitylicense
    {
        public int id { get; set; }
        public int facilityid { get; set; }
        public string ownername { get; set; }
        public string ownerfathername { get; set; }
        public int numberofbeds { get; set; }
        public DateTime startdate { get; set; }
        public DateTime enddate  { get; set; }
        public facility facility { get; set; }
    }
}
