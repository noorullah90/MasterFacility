using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterFacility.Data.Models.Request
{
    public class requestforupdate
    {
        public int id { get; set; }
        public int facilityid { get; set; }
        public int requestid { get; set; }
        public bool isprocessed { get; set; }
        public DateTime processeddate { get; set; }
        public int processedby { get; set; }

        public request request { get; set; }
    }
}
