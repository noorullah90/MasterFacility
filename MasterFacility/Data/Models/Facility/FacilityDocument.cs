using MasterFacility.Data.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterFacility.Data.Models.Facility
{
    public class facilitydocument
    {
        public int id { get; set; }
        public int? requestid { get; set; }
        public request request { get; set; }
        public int documenttypeid { get; set; }
        public string documentpath { get; set; }
        public int? facilityid { get; set; }
        public facility facility { get; set; }
        public bool isactive { get; set; }
    }
}
