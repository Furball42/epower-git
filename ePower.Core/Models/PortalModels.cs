using ePower.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePower.Portal.Models
{
    public class OrganizationInformation
    {
        public OrganizationInformation()
        {
            this.ApplicationUsers = new HashSet<ApplicationUser>();
        }

        public Guid Id { get; set; }
        public string OrganizationName { get; set; }
        public string Database { get; set; }
        public string Server { get; set; }
        public string User { get; set; }
        public string Password { get; set; }

        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}
