using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using UserRoles.Data;
using UserRoles.Repositories.Interface;

namespace UserRoles.Repositories.Persistance
{
    public class RoleRepository : IRoleRepository
    {
        private ApplicationDbContext _context;

        public RoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<IdentityRole> GetUserIdentityRoles()
        {
            var roles = _context.Roles
                    .Where(r => r.Name == "Seller" || r.Name == "Admin" || r.Name == "Technical" || r.Name == "Client" || r.Name == "Banker")
                    .ToList();

            return roles;
        }
    }
}
