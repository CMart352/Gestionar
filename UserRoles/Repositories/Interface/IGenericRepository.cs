using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace UserRoles.Repositories.Interface
{
    public interface IGenericRepository<T> where T : class
    {

        Task<IEnumerable<T>> All();
        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate);
        Task<int> Add(T obj);
        Task<int> Edit(T obj);
        Task<int> Remove(T obj);
        void Dispose();
        Task<int> Save();
        bool Exists(Expression<Func<T, bool>> predicate);
    }
}
