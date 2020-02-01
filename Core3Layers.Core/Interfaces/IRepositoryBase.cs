using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core3Layers.Core.Interfaces
{
    public interface IRepositoryBase<T>
    {
        Task<(IQueryable<T>, int Count)> ListAllAsync(int pageSize, int pageIndex);
        Task<IEnumerable<T>> ListByConditionAsync(Expression<Func<T, bool>> expression);
        Task<T> FindByConditionAsync(Expression<Func<T, bool>> expression);
        Task<bool> CheckAnyByConditionAsync(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SaveAsync();
    }
}
