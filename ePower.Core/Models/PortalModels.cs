using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePower.Portal.Models
{
    public class UserInformation
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<OrganizationInformation> Organization { get; set; }
    }

    public class OrganizationInformation
    {
        public Guid Id { get; set; }
        public string Database { get; set; }
        public string Server { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
    }
}
