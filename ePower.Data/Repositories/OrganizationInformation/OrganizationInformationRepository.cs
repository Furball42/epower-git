using ePower.Identity.Models;
using ePower.Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePower.Data.Repositories
{
    public class OrganizationInformationRepository : IOrganizationInformationRepository
    {
        private PortalDbContext context;

        public OrganizationInformationRepository(PortalDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<OrganizationInformation> GetOrganizationInformation()
        {
            return context.OrganizationInformation.ToList();
        }

        public OrganizationInformation GetOrganizationInformationById(Guid orgId)
        {
           return context.OrganizationInformation.Find(orgId);
        }

        public IEnumerable<OrganizationInformation> GetOrganizationInformationByUserId(Guid userId)
        {
            ApplicationUser user = context.Users.Find(userId.ToString());
            return user.ApplicationUserOrganizationInformations.Select(p => p.OrganizationInformation).ToList();

        }

        public void InsertGetOrganizationInformationr(OrganizationInformation user)
        {
            throw new NotImplementedException();
        }

        #region Dispose

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }        

        #endregion
    }
}
