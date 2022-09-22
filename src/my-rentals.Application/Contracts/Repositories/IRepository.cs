using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace my_rentals.Application.Contracts.Repositories
{
    public interface IRepository<T>
    {
        Task InsertAsync(T tObject);
        Task<T> FindOneAsync(Expression<Func<T, bool>> filter);
        IQueryable<T> FindAll();
        void Patch(T tObject);
        Task<T> DeleteAsync<TId>(TId id);
        Task CommitAsync();
    }
}
