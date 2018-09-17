using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UserRoles.Models.FormsViewModels;

namespace UserRoles.Models
{
    public class PersonaFisica : Persona
    {
       public PersonaFisica()
        {
        }
        //pueedo crear un constructor y pasarle como parametro un objeto
       /*  public PersonaFisica(PersonaFisicaFormViewModel fisicavmodel)
        {
            PersonId = fisicavmodel.PersonId;
            Street = fisicavmodel.Street;
            Numero = fisicavmodel.Numero;
            Floor = fisicavmodel.Floor;
            Aparment = fisicavmodel.Aparment;
            Zip = fisicavmodel.Zip;
            CityId = fisicavmodel.City;
            Email = fisicavmodel.Email;
            HomePhone = fisicavmodel.HomePhone;
            CellPhone = fisicavmodel.CellPhone;
            TypoDocumento = fisicavmodel.TypoDocumento;
            NumeroDoc = fisicavmodel.NumeroDoc;
            FirstName = fisicavmodel.FirstName;
            SecondName = fisicavmodel.SecondName;
            FirstLastName = fisicavmodel.FirstLastName;
            SecondLastName = fisicavmodel.SecondLastName;
        }*/

      
        //i can create a constrcutor de persona fisica y pasar los parametros de la persona y sus propios ya que es una herencia e incluir al final la base que es la persona 
        public PersonaFisica(int personId, string street, int numero, int floor, int aparment, int zip, int? cityId, City city, string email, string web, string homePhone, string cellPhone, int id, TypoDocumento typoDocument, CustomEnums.TypoDocumentoEnum document, CustomEnums.TypoDocumentoEnum typoDocumento, string numeroDoc, string firstName, string secondName, string firstLastName, string secondLastName) : base(personId, street, numero, floor, aparment, zip, cityId, city, email, web, homePhone, cellPhone, id, typoDocument, document, typoDocumento, numeroDoc)
        {
            FirstName = firstName;
            SecondName = secondName;
            FirstLastName = firstLastName;
            SecondLastName = secondLastName;
        }

        [Key]
        public int Id { get; set; }

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


    }
}
