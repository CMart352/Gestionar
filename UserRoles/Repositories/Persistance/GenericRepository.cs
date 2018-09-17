
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
using UserRoles.Data;
using UserRoles.Repositories.Interface;
using UserRoles.Models;

namespace UserRoles.Repositories.Persistance
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        public ApplicationDbContext Context;
        public DbSet<T> Table;

        protected GenericRepository(ApplicationDbContext context)
        {
            Context = context;
            Table = Context.Set<T>();
        }
       
        //added type async task 
        public async Task<IEnumerable<T>> All()
        {
            return await Table.ToListAsync();
        }

       
        public async Task<int> Edit(T obj)
        {
            Table.Attach(obj);
            Context.Entry(obj).State = EntityState.Modified;         
            return await Save();
        
        }

        
        public async Task<int> Save()
        {
           return await Context.SaveChangesAsync();
           
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return Table.SingleOrDefaultAsync(predicate);
        }

        public async Task<int> Add(T obj)
        {
            Table.Add(obj);
           return await Save();
        }

        public async Task<int> Remove(T obj)
        {
            Table.Remove(obj);
            return await Save();
        }

         bool IGenericRepository<T>.Exists(Expression<Func<T, bool>> predicate)
        {
            return Table.Any(predicate);
        }

        public async Task<T> FindBy(object id)
        {
            return await Table.FindAsync(id);
        }
    }
}
