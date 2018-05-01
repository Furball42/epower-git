using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using ePower.Portal.Models;
using ePower.Common;
using System.ComponentModel.DataAnnotations;

namespace ePower.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.OrganizationInformation = new HashSet<OrganizationInformation>();
        }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]        
        public DateTime DateCreated { get; set; }

        [Required]
        public DateTime? DoB { get; set; }

        public byte[] ProfilePicture { get; set; }

        [Required]
        public Gender Gender { get; set; }

        public virtual ICollection<OrganizationInformation> OrganizationInformation { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
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

        public DbSet<OrganizationInformation> Table1 { get; set; }
    }


    //---------------------------
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    //public class ApplicationUser : IdentityUser
    //{
    //    public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
    //    {
    //        // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
    //        var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
    //        // Add custom user claims here
    //        return userIdentity;
    //    }
    //}

    //public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    //{
    //    public ApplicationDbContext()
    //        : base("DefaultConnection", throwIfV1Schema: false)
    //    {
    //    }

    //    public static ApplicationDbContext Create()
    //    {
    //        return new ApplicationDbContext();
    //    }
    //}
}