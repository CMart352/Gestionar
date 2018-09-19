using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRoles.Models.FormsViewModels;

namespace UserRoles.Models.ViewModels
{
    public class PersonaDetailViewModel
    {
        public string FirstName { get; set; }
        public string SecondFirstName { get; set; }
        public string LastName { get; set; }
        public string SecondLastName { get; set; }
        public string Calle { get; set; }
        public int Numero { get; set; }
        public int Zipcode { get; set; }
        public string Email { get; set; }
        public string Homephone { get; set; }
        public string Cellphone { get; set; }
        public City City { get; set; }
        public State State { get; set; }
        public string Web { get; set; }
        public CustomEnums.TypoStatusClienteEnum Status { get; set; }

        public string Razonsocial { get; set; }
        public List<Representante> Representantes { get; set; }
        public bool ATM { get; set; }
        public bool Location { get; set; }
        public bool WorkingCapital { get; set; }
    }
}
