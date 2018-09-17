using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UserRoles.Models.FormsViewModels;

namespace UserRoles.Models
{
    public class Persona
    {
        public Persona()
        {
        }

        //public Persona(PersonaFisicaFormViewModel fisicavmodel)
        //{
        //    PersonId = fisicavmodel.PersonId;
        //    Street = fisicavmodel.Street;
        //    Numero = fisicavmodel.Numero;
        //    Floor = fisicavmodel.Floor;
        //    Aparment = fisicavmodel.Aparment;
        //    Zip = fisicavmodel.Zip;
        //    CityId = fisicavmodel.City;
        //    Email = fisicavmodel.Email;
        //    HomePhone = fisicavmodel.HomePhone;
        //    CellPhone = fisicavmodel.CellPhone;
        //    TypoDocumento = fisicavmodel.TypoDocumento;
        //    NumeroDoc = fisicavmodel.NumeroDoc;

        //}

        public Persona(int personId, string street, int numero, int floor, int aparment, int zip, int? cityId, City city, string email, string web, string homePhone, string cellPhone, int id, TypoDocumento typoDocument, CustomEnums.TypoDocumentoEnum document, CustomEnums.TypoDocumentoEnum typoDocumento, string numeroDoc)
        {
            PersonId = personId;
            Street = street;
            Numero = numero;
            Floor = floor;
            Aparment = aparment;
            Zip = zip;
            CityId = cityId;
            City = city;
            Email = email;
            Web = web;
            HomePhone = homePhone;
            CellPhone = cellPhone;
            Id = id;
            TypoDocument = typoDocument;
            Document = document;
            TypoDocumento = typoDocumento;
            NumeroDoc = numeroDoc;
        }

        [Key]
        public int PersonId { get; set; }

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

        //[Required(ErrorMessage = "El pais es requerido")]
        //[Display(Name = "Pais")]
        //public int CountryId { get; set; }

        //public Country Country { get; set; }

        //[Required(ErrorMessage = "The state is required")]
        //public int StateId { get; set; }

        //[Display(Name = "Provincia")]   //same as state
        //public State State { get; set; }

        public int? CityId { get; set; }

        [Display(Name = "Localidad")]  //same as city
        public City City { get; set; }

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

        //do not use it
        [ForeignKey("TypoDocumento")]// do not use it instead use enums
        public int Id { get; set; }// do not use it instead use enums
        public TypoDocumento TypoDocument { get; set; } // do not use it instead use enums

        //do not use it
        [Required(ErrorMessage = "Seleccione una opcion")]// do not use it
        [Range(1, 3)]// do not use it
        public CustomEnums.TypoDocumentoEnum Document { get; set; } // do not use it


        [Required(ErrorMessage = "Seleccione una opcion")]
        //[Range(1, 3)]
        public CustomEnums.TypoDocumentoEnum TypoDocumento { get; set; }

        //The cuit is a 11 digit number
        [Display(Name = "Numero de Documento")]
        [RegularExpression(@"^[0-9]{0,11}$", ErrorMessage = "error Message ")]
        public string NumeroDoc { get; set; }

        //maybe we do not need to added it in the table we just use the discriminator
        //typo de persona
        [Required(ErrorMessage = "Seleccione una persobna")]
        public CustomEnums.TypoPersonaEnum TypoPersona { get; set; }

        //status of cliente
        public CustomEnums.TypoStatusClienteEnum StatusCliente { get; set; }

        //typo cliente working capital
        public CustomEnums.TypoClienteWCEnum TypoClienteWC { get; set; }

        













    }
}
