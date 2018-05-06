using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using ePower.Core.Models;
using ePower.Identity.Models;
using ePower.Portal.Models;

namespace ePower.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {

        }

        public ApplicationDbContext(string connString)
        {
            this.Database.Connection.ConnectionString = connString;
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //public DbSet<Region> Regions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }    

    public class PortalDbContext : IdentityDbContext<ApplicationUser>
    {
        public PortalDbContext()
            : base("PortalConnection", throwIfV1Schema: false)
        {
        }

        public static PortalDbContext Create()
        {
            return new PortalDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {            
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(au => au.ApplicationUserOrganizationInformations)
                .WithRequired(ug => ug.ApplicationUser)
                .HasForeignKey(ug => ug.ApplicationUserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrganizationInformation>()
                .HasMany(grp => grp.ApplicationUserOrganizationInformations)
                .WithRequired(ug => ug.OrganizationInformation)
                .HasForeignKey(ug => ug.OrganizationId)
                .WillCascadeOnDelete();
        }  

        public DbSet<OrganizationInformation> OrganizationInformation { get; set; }
    }
}


