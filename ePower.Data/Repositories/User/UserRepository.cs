using ePower.Identity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePower.Data.Repositories
{   
    public class UserRepository : IUserRepository
    {
        private PortalDbContext context;

        public UserRepository(PortalDbContext context)
        {
            this.context = context;
        }

        public void DeleteUser(Guid userId)
        {
            ApplicationUser user = context.Users.Find(userId);
            context.Users.Remove(user);
        }

        public ApplicationUser GetUserById(Guid userId)
        {
            return context.Users.Find(userId);
        }

        public IEnumerable<ApplicationUser> GetUsers()
        {
            return context.Users.ToList();
        }

        public void InsertUser(ApplicationUser user)
        {
            context.Users.Add(user);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateUser(ApplicationUser user)
        {
            context.Entry(user).State = EntityState.Modified;
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
