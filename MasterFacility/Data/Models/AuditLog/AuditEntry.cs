using MasterFacility.Enums;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterFacility.Data.Models.AuditLog
{
    public class auditentry
    {
        public auditentry(EntityEntry _entry)
        {
            entry = entry;
        }

        public EntityEntry entry { get; set; }
        public int userid { get; set; }
        public string tablename { get; set; }
        public Dictionary<string, object> keyvalues { get; } = new Dictionary<string, object>();
        public Dictionary<string, object> oldvalues { get; } = new Dictionary<string, object>();
        public Dictionary<string, object> newvalues { get; } = new Dictionary<string, object>();
        public AuditType auditytype { get; set; }
        public List<string> changedcolumns { get; } = new List<string>();
        public audit toaudit()
        {
            var audit = new audit();
            audit.userid = userid;
            audit.type = auditytype.ToString();
            audit.tablename = tablename;
            audit.datetime = DateTime.UtcNow;
            audit.primarykey = JsonConvert.SerializeObject(keyvalues);
            audit.oldvalues = oldvalues.Count == 0 ? null : JsonConvert.SerializeObject(oldvalues);
            audit.newvalues = newvalues.Count == 0 ? null : JsonConvert.SerializeObject(newvalues);
            audit.affectedcolumns = changedcolumns.Count == 0 ? null : JsonConvert.SerializeObject(changedcolumns);
            return audit;
        }

    }
}
