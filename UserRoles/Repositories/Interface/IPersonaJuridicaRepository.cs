﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRoles.Models;

namespace UserRoles.Repositories.Interface
{
    public interface IPersonaJuridicaRepository : IGenericRepository<PersonaJuridica>
    {
        List<PersonaJuridica> GetPersonaJuridicas();
        PersonaJuridica GetPersonaJuridicaById(int? personaId);
    }
}
