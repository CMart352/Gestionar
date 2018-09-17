using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRoles.Models;

namespace UserRoles.Repositories.Interface
{
    public interface ICityRepository : IGenericRepository<City>
    {
        IEnumerable<City> GetAllCity(int? countryId);
    }
}
