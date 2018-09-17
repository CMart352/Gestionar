using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace UserRoles.Repositories.Interface
{
    public interface IRoleRepository
    {
        List<IdentityRole> GetUserIdentityRoles();
    }
}