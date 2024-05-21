using Microsoft.EntityFrameworkCore;
using ProductManager.Core.Services.Entities;
using ProductManager.Core.Services.Interfaces;
using ProductManager.Infrastructure.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Infrastructure.Data.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class 
    {
        private readonly DbContext context;

        public BaseRepository(DbContext dbContext)
        {
            context = dbContext;

        }

        protected DbSet<T> EntitySet
        {
            get {
                return context.Set<T>();

            }
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await EntitySet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid Id)
        {
            return await EntitySet.FindAsync(Id);
        }

        public async Task CreateAsync(T entity)
        {
            await EntitySet.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid Id)
        {
            T? entity = await GetByIdAsync(Id);
            if (entity != null)
            {
                context.Remove(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

    }
}
