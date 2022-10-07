using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AmanTask.Core.Repository
{
    public interface IBaseRepository<T>where T : class
    {
        Task<IEnumerable<T>> GellAllAsync();
        Task<IEnumerable<T>> GellAllAsync(params Expression<Func<T, object>>[] includeProperty);

        Task<T>GetByIDAsync(int id);

        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);

        Task DeleteAsync(T entity);
    }
}
