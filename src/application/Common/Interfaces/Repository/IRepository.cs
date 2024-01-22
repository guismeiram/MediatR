using domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace application.Common.Interfaces.Repository
{
    public interface IRepository<T> where T : Entity
    {
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(Guid id);
        Task<T> GetAsyncById(Guid id);
        Task<IEnumerable<T>> GetAsyncList();
        IQueryable<T> AsQueryable(Expression<Func<T, bool>> predicate = null);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
    }
}
