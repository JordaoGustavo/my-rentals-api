using MyRentals.Api.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace MyRentals.Api.Persistence.Repositories
{
    public abstract class Repository<T> : IAsyncRepository<T> where T : class
    {
        public async Task<IDbConnection> GetConnectionAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<T> AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetByIdAsync<TId>(TId id) where TId : struct
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
