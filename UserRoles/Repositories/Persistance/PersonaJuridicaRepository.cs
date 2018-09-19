using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRoles.Data;
using UserRoles.Models;
using UserRoles.Repositories.Interface;

namespace UserRoles.Repositories.Persistance
{
    public class PersonaJuridicaRepository : GenericRepository<PersonaJuridica>, IPersonaJuridicaRepository
    {
        public PersonaJuridicaRepository(ApplicationDbContext context) : base(context)
        {
        }

        public List<PersonaJuridica> GetPersonaJuridicas()
        {
            var personas = Table.OfType<PersonaJuridica>().ToList();

            return personas;
        }

        public PersonaJuridica GetPersonaJuridicaById(int? personaId)
        {
            var persona = SingleOrDefaultAsync(p => p.PersonId == personaId).Result;

            if (persona == null)
            {
                return null;
            }

            return persona;
        }
    }
}
