using System.Collections.Generic;

namespace UserRoles.Models.ViewModels
{
    public class UserListViewModel
    {
        //public IEnumerable<ApplicationUser> Users { get; set; }
        public IEnumerable<ApplicationUser> Sellers { get; set; }
        public IEnumerable<ApplicationUser> Technicals { get; set; }
        public IEnumerable<ApplicationUser> Admins { get; set; }
        public IEnumerable<ApplicationUser> Clients { get; set; }
        public IEnumerable<ApplicationUser> Bankers { get; set; }
    }
}
