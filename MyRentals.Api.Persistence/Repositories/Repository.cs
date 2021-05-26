using MyRentals.Api.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyRentals.Api.Persistence.Repositories
{
    public abstract class Repository<T> : IAsyncRepository<T> where T : class
    {
        public Task<T> AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync<TId>(TId id) where TId : struct
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<T>> ListAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
