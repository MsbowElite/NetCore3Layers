using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core3Layers.Core.Interfaces;
using Core3Layers.Infrastructure;

namespace Core3Layers.Infrastructure
{
    public abstract class RepositoryBase<T> : IDisposable, IRepositoryBase<T> where T : class
    {
        protected ApplicationDbContext ApplicationDbContext { get; set; }

        protected RepositoryBase(ApplicationDbContext applicationDbContext)
        {
            ApplicationDbContext = applicationDbContext;
        }

        public async Task<(IQueryable<T>, int Count)> ListAllAsync(int pageSize, int pageIndex)
        {
            return (ApplicationDbContext.Set<T>().Skip(pageSize * pageIndex).Take(pageSize),
                await ApplicationDbContext.Set<T>().CountAsync());
        }

        public async Task<IEnumerable<T>> ListByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await ApplicationDbContext.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<T> FindByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await ApplicationDbContext.Set<T>().SingleOrDefaultAsync(expression);
        }

        public async Task<bool> CheckAnyByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await ApplicationDbContext.Set<T>().AnyAsync(expression);
        }

        public void Create(T entity)
        {
            ApplicationDbContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.ApplicationDbContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.ApplicationDbContext.Set<T>().Remove(entity);
        }

        public async Task SaveAsync()
        {
            await this.ApplicationDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (ApplicationDbContext != null)
                {
                    ApplicationDbContext.Dispose();
                    ApplicationDbContext = null;
                }
            }
        }
    }
}
