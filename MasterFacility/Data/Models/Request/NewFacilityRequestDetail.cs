using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterFacility.Data.Models.Request
{
    public class newfacilityrequestdetail
    {
        public int id { get; set; }
        public int requestid { get; set; }
        public int districtid { get; set; }
        public string grantcode { get; set; }
        public int facilitytypeid { get; set; }
        public string name { get; set; }
        public string namedari { get; set; }
        public string namepashto { get; set; }
        public DateTime establisheddate { get; set; }
        public string location { get; set; }
        public string locationdari { get; set; }
        public string address { get; set; }
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }
        public string approvedfacilitycode { get; set; }
        public DateTime approveddate { get; set; }
        public int approvedby { get; set; }

        public request request { get; set; }

    }
}
