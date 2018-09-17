using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace UserRoles.Models.ViewModels.ManageViewModels
{
    public class ChangeUserRoleViewModel
    {
        public string Email { get; set; }
        public List<IdentityRole> Roles { get; set; }
        public string UserRole { get; set; }
        public string OldRole { get; set; }
    }
}
