using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRoles.Data;
using UserRoles.Models;
using UserRoles.Repositories.Interface;

namespace UserRoles.Repositories.Persistance
{
    public class StateRepository : GenericRepository<State>, IStateRepository
    {
        public StateRepository(ApplicationDbContext context) : base(context)
        {
            
        }
        public IEnumerable<State> GetAllStates(int? countryId)
        {
            return Table.Where(c => c.CountryId == countryId).ToList();
        }
    }
}
