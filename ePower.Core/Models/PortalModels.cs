using ePower.Identity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePower.Portal.Models
{
    public class OrganizationInformation
    {
        public OrganizationInformation()
        {
            this.ApplicationUserOrganizationInformations = new HashSet<ApplicationUserOrganizationInformations>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string OrganizationName { get; set; }
        public string Database { get; set; }
        public string Server { get; set; }
        public string User { get; set; }
        public string Password { get; set; }

        public virtual ICollection<ApplicationUserOrganizationInformations> ApplicationUserOrganizationInformations { get; set; }
    }

    public class ApplicationUserOrganizationInformations
    {
        [Key, Column(Order = 0)]
        public Guid OrganizationId { get; set; }
        
        [Key, Column(Order = 1)]
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set;}
        public virtual OrganizationInformation OrganizationInformation { get; set; }
    }
}
