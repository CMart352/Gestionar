using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRoles.Data;
using UserRoles.Models;
using UserRoles.Repositories.Interface;

namespace UserRoles.Repositories.Persistance
{
    public class PersonaRepository : GenericRepository<Persona>, IPersonaRepository
    {
        public PersonaRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task ApprovePersona(int personId)
        {
            try
            {
                var persona = SingleOrDefaultAsync(p => p.PersonId == personId).Result;

                if(persona == null)
                {
                    throw new Exception("Persona no existen");
                }

                persona.StatusCliente = Models.FormsViewModels.CustomEnums.TypoStatusClienteEnum.Aproved;
                await Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task DenyPersona(int personId)
        {
            try
            {
                var persona = SingleOrDefaultAsync(p => p.PersonId == personId).Result;

                if (persona == null)
                {
                    throw new Exception("Persona no existen");
                }

                persona.StatusCliente = Models.FormsViewModels.CustomEnums.TypoStatusClienteEnum.Denied;
                await Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}

