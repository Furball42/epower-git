using ePower.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePower.Data.Repositories
{
    public interface IUserRepository : IDisposable
    {
        IEnumerable<ApplicationUser> GetUsers();
        ApplicationUser GetUserById(Guid userId);
        void InsertUser(ApplicationUser user);
        void DeleteUser(Guid userId);
        void UpdateUser(ApplicationUser user);
        void Save();
    }
}
