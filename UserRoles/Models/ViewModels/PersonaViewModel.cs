using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserRoles.Models.ViewModels
{
    public class PersonaViewModel
    {
        public IEnumerable<PersonaFisica> PersonaFisica { get; set; }
        public IEnumerable<PersonaJuridica> PersonaJuridicas { get; set; }
    }
}
