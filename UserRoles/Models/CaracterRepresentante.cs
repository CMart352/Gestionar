using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserRoles.Models
{
    public class CaracterRepresentante
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El tipo de documento es requerido")]
        [Display(Name = "Tipo de Documento")]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
