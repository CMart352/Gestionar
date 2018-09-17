using System.ComponentModel.DataAnnotations;

namespace UserRoles.Models.ViewModels.ManageViewModels
{
    public class ClientViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        [Required]
        [StringLength(50)]
        public string PhoneNumber { get; set; }
    }
}
