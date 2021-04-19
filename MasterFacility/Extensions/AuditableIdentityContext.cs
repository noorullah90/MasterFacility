using MasterFacility.Data.Models.AuditLog;
using MasterFacility.Data.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasterFacility.Extensions
{
    public abstract class AuditableIdentityContext: IdentityDbContext<AppUser, AppRole, int>
    {
        public AuditableIdentityContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<audit> auditlogs { get; set; }


        public virtual async Task<int> SaveChangesAsync(int? userid)
        {
            if(userid!=null)
            {
                OnBeforeSaveChanges((int)userid);
                var result = await base.SaveChangesAsync();
                return result;
            }
            else
            {
                var result = await base.SaveChangesAsync();
                return result;
            } 
        }


        private void OnBeforeSaveChanges(int userid)
        {
            ChangeTracker.DetectChanges();
            var auditEntries = new List<auditentry>();
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is audit || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                    continue;

                var auditEntry = new auditentry(entry);
                auditEntry.tablename = entry.Entity.GetType().Name;
                auditEntry.userid = userid;
                auditEntries.Add(auditEntry);
                foreach(var property in entry.Properties)
                {
                    string propertyName = property.Metadata.Name;
                    if(property.Metadata.IsPrimaryKey())
                    {
                        auditEntry.keyvalues[propertyName] = property.CurrentValue;
                        continue;
                    }
                    
                    switch(entry.State)
                    {
                        case EntityState.Added:
                            auditEntry.auditytype = Enums.AuditType.Create;
                            auditEntry.oldvalues[propertyName] = property.CurrentValue;
                            break;
                        case EntityState.Deleted:
                            auditEntry.auditytype = Enums.AuditType.Delete;
                            auditEntry.oldvalues[propertyName] = property.OriginalValue;
                            break;
                        case EntityState.Modified:
                            if(property.IsModified)
                            {
                                auditEntry.changedcolumns.Add(propertyName);
                                auditEntry.auditytype = Enums.AuditType.Update;
                                auditEntry.oldvalues[propertyName] = property.OriginalValue;
                                auditEntry.newvalues[propertyName] = property.CurrentValue;
                            }
                            break;

                    }
                }
            }

            foreach(var auditEntry in auditEntries)
            {
                auditlogs.Add(auditEntry.toaudit());
            }
        }
    }
}
