using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRoles.Models.FormsViewModels;

namespace UserRoles.Models.ViewModels
{
    public class PersonaDetailViewModel
    {
        public PersonaDetailViewModel()
        {
        }

        public int PersonId { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string FirstLastName { get; set; }

        public string SecondLastName { get; set; }

        public string Street { get; set; }

        public int Numero { get; set; }

        public int Zip { get; set; }

        public string Email { get; set; }

        public string HomePhone { get; set; }

        public string CellPhone { get; set; }

        public int? CityId { get; set; }

        //public int City { get; set; }
        public CustomEnums.TypoDocumentoEnum TypoDocumento { get; set; }

        public string NumeroDoc { get; set; }

        public City City { get; set; }

        public State State { get; set; }

        public string Web { get; set; }

        public CustomEnums.TypoStatusClienteEnum Status { get; set; }

        public string Razonsocial { get; set; }

        public List<Representante> Representantes { get; set; }

        public bool Atm { get; set; }

        public bool Location { get; set; }

        public bool WorkingCapital { get; set; }
    }
}
