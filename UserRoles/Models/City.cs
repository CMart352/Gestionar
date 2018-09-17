using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UserRoles.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nonmbre ciudad es requerido")]
        [StringLength(20)]
        public string Name { get; set; }

        [Display(Name = "Estados"), ForeignKey("State")]
        public int StateId { get; set; }
        public State State { get; set; }

        public ICollection<Persona> Personas { get; set; }

    }
}
