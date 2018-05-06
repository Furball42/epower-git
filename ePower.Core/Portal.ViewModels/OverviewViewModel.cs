using ePower.Identity.Models;
using ePower.Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePower.Portal.ViewModels
{
    public class OverviewViewModel
    {
        public IEnumerable<OrganizationInformation> Organizations { get; set; }
        public ApplicationUser User { get; set; }
    }
}
