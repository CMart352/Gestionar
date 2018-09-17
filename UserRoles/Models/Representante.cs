using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

using UserRoles.Models.FormsViewModels;

namespace UserRoles.Models
{
    public class Representante
    {
        [Key]
        public int RepresentanteId { get; set; }

        [Required(ErrorMessage = "Nombre es requerido")]
        [StringLength(20)]
        [Display(Name = "Primer Nombre")]
        public string FirstName { get; set; }

        [StringLength(20)]
        [Display(Name = "Segundo Nombre")]
        public string SecondName { get; set; }

        [Required(ErrorMessage = "Apellido es requerido")]
        [StringLength(20)]
        [Display(Name = "Primer Apellido")]
        public string FirstLastName { get; set; }

        [StringLength(20)]
        [Display(Name = "Segundo Apellido")]
        public string SecondLastName { get; set; }

       
       
        //The cuit is a 11 digit number
        [Display(Name = "Numero de Documento")]
        [RegularExpression(@"^[0-9]{0,11}$", ErrorMessage = "error Message ")]
        public string NumeroDoc { get; set; }

        [Display(Name = "Typo")]
        [Required(ErrorMessage = "Seleccione una opcion")]
        //[Range(1, 2)]
        public CustomEnums.TypoRepresentanteEnum TypoRepresentante { get; set; }

        public PersonaJuridica Juridico { get; set; }

        [Display(Name = "Typo")]
        [Required(ErrorMessage = "Seleccione una opcion")]
        //[Range(1, 3)]
        public CustomEnums.TypoDocumentoEnum TypoDocumento { get; set; }


    }
}
