using Microsoft.AspNetCore.Identity;
using UserRoles.Repositories.Interface;

namespace UserRoles.Repositories.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        //private RoleManager<IdentityRole> _roleManager;

        //public IRoleRepository Role { get; private set; }

        //public UnitOfWork(RoleManager<IdentityRole> roleManager)
        //{
        //    _roleManager = roleManager;

        //    Role = new RoleRepository(roleManager);
        //}
    }
}
