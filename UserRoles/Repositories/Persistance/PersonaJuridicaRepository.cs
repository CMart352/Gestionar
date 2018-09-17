﻿using System;
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
    }
}
