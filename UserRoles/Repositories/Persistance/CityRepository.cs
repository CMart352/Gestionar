using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRoles.Data;
using UserRoles.Models;
using UserRoles.Repositories.Interface;

namespace UserRoles.Repositories.Persistance
{
    public class CityRepository : GenericRepository<City>, ICityRepository
    {
        public CityRepository(ApplicationDbContext context) : base(context)
        {
                   
        }
        public IEnumerable<City> GetAllCity(int? stateId)
        {
            return Table.Where(c => c.StateId == stateId).ToList();
        }

       
    }
}
