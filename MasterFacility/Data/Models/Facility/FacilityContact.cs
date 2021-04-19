using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterFacility.Data.Models.Facility
{
    public class facilitycontact
    {
        public int id { get; set; }
        public int facilityid { get; set; }
        public int positionid { get; set; }
        public string fullname { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public bool iscurrent { get; set; }

        public facility facility { get; set; }
    }
}
