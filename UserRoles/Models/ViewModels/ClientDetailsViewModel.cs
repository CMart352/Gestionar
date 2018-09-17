using System.Collections.Generic;

namespace UserRoles.Models.ViewModels
{
    public class ClientDetailsViewModel
    {
        public string Email { get; set; }
        public IList<string> Roles { get; set; }
    }
}
