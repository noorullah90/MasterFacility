using MasterFacility.Data.Models.AuditLog;
using MasterFacility.Data.Models.Grants;
using MasterFacility.Data.Models.Identity;
using MasterFacility.Data.Models.Lookups;
using MasterFacility.Extensions;
using MasterFacility.Models.Lookups;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MasterFacility.Data
{
    public class ApplicationDbContext : AuditableIdentityContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<district>()
                .HasOne(p => p.province)
                .WithMany(b => b.districts);

            modelBuilder.Entity<lookupitem>()
                .HasOne(p => p.lookup)
                .WithMany(b => b.lookupitems);

            modelBuilder.Entity<donor>().HasMany(e => e.programs);
            modelBuilder.Entity<programs>().HasMany(e => e.grants);

            modelBuilder.Entity<implementers>().HasMany(e => e.grants);

            modelBuilder.Entity<lookupitem>().HasMany(e => e.lookupitems).WithOne(e => e.parent).HasForeignKey(q => q.parentid);

        

           
            // modelBuilder.Entity<AppRole>().HasData(new List<AppRole>{
            //  new AppRole {
            //    Id = 1,
            //    Name = "Admin",
            //    NormalizedName = "ADMIN"
            //  },
            //  new AppRole {
            //    Id = 2,
            //    Name = "Staff",
            //    NormalizedName = "STAFF"
            //  },
            //});
        }

        //Lookups Models
        public DbSet<language> languages { get; set; }
        public DbSet<province> provinces { get; set; }
        public DbSet<district> districts { get; set; }

        public DbSet<lookup> lookups { get; set; }
        public DbSet<lookupitem> lookupitems { get; set; }

        //Grants
        public DbSet<donor> donors { get; set; }
        public DbSet<programs> programs { get; set; }
        public DbSet<grant> grants { get; set; }
        public DbSet<implementers> implementers { get; set; }
        
        //Identity Models
        public DbSet<UserGrantedProvince> UserGrantedProvinces { get; set; }
        public IEnumerable<object> Grantitems { get; internal set; }
    }
}
