using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRoles.Data;
using UserRoles.Models;
using UserRoles.Repositories.Interface;

namespace UserRoles.Repositories.Persistance
{
    public class PersonaFisicaRepository : GenericRepository<PersonaFisica>, IPersonaFisicaRepository
    {
        public PersonaFisicaRepository(ApplicationDbContext context) : base(context)
        {
        }

        public List<PersonaFisica> GetPersonaFisicas()
        {
            var personas = Table.OfType<PersonaFisica>().ToList();

            return personas;
        }

        public PersonaFisica GetPersonaFisicaById(int? personaId)
        {
            var persona = SingleOrDefaultAsync(p => p.PersonId == personaId).Result;

            if(persona == null)
            {
                return null;
            }

            return persona;
        }
    }
}
