using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterFacility.Data.Models.AuditLog
{
    public class audit
    {
        public int id { get; set; }
        public int userid { get; set; }
        public string type { get; set; }
        public string tablename { get; set; }
        public DateTime datetime { get; set; }
        public string oldvalues { get; set; }
        public string newvalues { get; set; }
        public string affectedcolumns { get; set; }
        public string primarykey { get; set; }
    }
}
