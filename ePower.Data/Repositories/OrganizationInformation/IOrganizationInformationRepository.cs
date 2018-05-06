using ePower.Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePower.Data.Repositories
{
    public interface IOrganizationInformationRepository : IDisposable
    {
        IEnumerable<OrganizationInformation> GetOrganizationInformation();
        OrganizationInformation GetOrganizationInformationById(Guid orgId);
        IEnumerable<OrganizationInformation> GetOrganizationInformationByUserId(Guid orgId);
        void InsertGetOrganizationInformationr(OrganizationInformation user);
    }
}
