using MasterFacility.Data.Models.Grants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterFacility.Data.Models.Facility
{
    public class grantfacility
    {
        public int id { get; set; }
        public int grantid { get; set; }
        public int facilityid { get; set; }
        public DateTime startdate { get; set; }
        public DateTime enddate { get; set; }

        public bool iscurrent { get; set; }

        public facility facility { get; set; }
        public grant grant { get; set; }
    }
}
