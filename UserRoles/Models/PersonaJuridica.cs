using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UserRoles.Models.FormsViewModels;

namespace UserRoles.Models
{
    public class PersonaJuridica : Persona
    {
        public PersonaJuridica()
        {
            Representantes = new List<Representante>();
        }

        [Key]
        public int Id { get; set; }

        //[ForeignKey("Persona")]
        //public int PersonId { get; set; }

        //[ForeignKey("Representante")]
        //public int RepresentanteId { get; set; }

        [Required(ErrorMessage = "Nombre es requerido")]
        [StringLength(20)]
        [Display(Name = "Razon Social/ Denominacion")]
        public string RazonSocial { get; set; }

        public ICollection<Representante> Representantes { get; set; }



    }
}
