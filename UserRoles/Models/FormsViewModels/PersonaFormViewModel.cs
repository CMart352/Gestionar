using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace UserRoles.Models.FormsViewModels
{
    public class PersonaFormViewModel
    {
        public PersonaFormViewModel()
        {
        }

        public PersonaFormViewModel(SelectList selectList)
        {
            Countries = selectList;
        }

        [Key]
        public int PersonId { get; set; }

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

        [Required(ErrorMessage = "La calle es requerido")]
        [Display(Name = "Calle")]
        [StringLength(50)]
        public string Street { get; set; }

        [Required(ErrorMessage = "El numero es requerido")]
        [Display(Name = "Numero")]
        public int Numero { get; set; }

        [Display(Name = "Piso")]
        public int Floor { get; set; }

        [Display(Name = "Depto")]
        public int Aparment { get; set; }

        [Required(ErrorMessage = "El codigo postal es requerido")]
        [Display(Name = "Zip Code")]
        public int Zip { get; set; }

        public SelectList Countries { get; set; }

        public int Country { get; set; }

        public SelectList States { get; set; }

        public int State { get; set; }

        public SelectList Cities { get; set; }

        public int City { get; set; }

        [Required(ErrorMessage = "Email es requerido")]
        [StringLength(50, ErrorMessage = "Must be between 5 and 50 characters", MinimumLength = 5)]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Debe ser un email valido")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail no es valido")]
        public string Email { get; set; }

        [StringLength(50)]
        public string Web { get; set; }


        [Required(ErrorMessage = "Telefono Fijo")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Numero telefono no es valido")]
        public string HomePhone { get; set; }

        [Required(ErrorMessage = "Telefono movil")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Telefono movil")]
        public string CellPhone { get; set; }

        //do no use it
        [ForeignKey("TypoDocumento")] // do not use it instead use enums
        public int Id { get; set; } // do not use it instead use enums
        public TypoDocumento TypoDocument { get; set; } // do not use it instead use enums

        //public IEnumerable<TypoDocumento> TypoDocumentos { get; set; } // do not use it instead use enums

        //[Required(ErrorMessage = "Seleccione una opcion")]
        //[Range(1, 3)]
        //public CustomEnums.TypoDocumentoEnum Document { get; set; } //do not use it

        [Display(Name = "Typo")]
        [Required(ErrorMessage = "Seleccione una opcion")]
        //[Range(1, 3)]
        public CustomEnums.TypoDocumentoEnum TypoDocumento { get; set; }

        //The cuit is a 11 digit number
        [Display(Name = "Numero")]
        [RegularExpression(@"^[0-9]{0,11}$", ErrorMessage = "error Message ")]
        public string NumeroDoc { get; set; }

        //from persona juridica model
        [Required(ErrorMessage = "Nombre es requerido")]
        [StringLength(20)]
        [Display(Name = "Razon Social/ Denominacion")]
        public string RazonSocial { get; set; }


        //to select what tpye of person to choose
        [Required(ErrorMessage = "Seleccione una persobna")]
        public CustomEnums.TypoPersonaEnum TypoPersona { get; set; }

        [Display(Name = "Typo")]
        [Required(ErrorMessage = "Seleccione una opcion")]
        //[Range(1, 2)]
        public CustomEnums.TypoRepresentanteEnum TypoRepresentante { get; set; }


        public ICollection<Representante> Representantes { get; set; }


        [Required(ErrorMessage = "Seleccione una persobna")]
        public CustomEnums.TypoClienteEnum TypoCliente { get; set; }

        //status of cliente
        public CustomEnums.TypoStatusClienteEnum StatusCliente { get; set; }

        //typo cliente working capital
        public CustomEnums.TypoClienteWCEnum TypoClienteWC { get; set; }

        public bool Atm { get; set; }

        public bool Location { get; set; }

        public bool WorkingCapital { get; set; }

        public double CantInvertida { get; set; } //this is for cliente atm

        public string LocationName { get; set; } //this is for cliente location

        public string LocationType { get; set; } //this is for cliente location

        //public string  { get; set; } //this is for cliente location




    }
}
