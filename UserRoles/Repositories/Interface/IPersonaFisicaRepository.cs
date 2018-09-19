using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRoles.Models;

namespace UserRoles.Repositories.Interface
{
    public interface IPersonaFisicaRepository : IGenericRepository<PersonaFisica>
    {
        List<PersonaFisica> GetPersonaFisicas();
        PersonaFisica GetPersonaFisicaById(int? personaId);
    }

}
