﻿using Microsoft.EntityFrameworkCore;
using my_rentals.Application.Contracts.Repositories;
using my_rentals.Infrastructure.Persistence;
using System.Linq.Expressions;

namespace my_rentals.Infrastructure.Repositories
{
    internal abstract class Repository<T> : DbContext, IRepository<T> where T : class
    {
        protected DbContext _context;

        public Repository(RentsCoreDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task CommitAsync()
        {
            await SaveChangesAsync();
        }

        public async Task<T> DeleteAsync<TId>(TId id)
        {
            var entityToBeDeleted = await _context.Set<T>().FindAsync(id);
            Delete(entityToBeDeleted);
            return entityToBeDeleted;
        }

        public IQueryable<T> FindAll()
        {
            IQueryable<T> query = _context.Set<T>().AsQueryable();

            return query;
        }

        public async Task<T> FindOneAsync(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().FindAsync(filter).AsTask();
        }

        public async Task InsertAsync(T tObject)
        {
            await _context.Set<T>().AddAsync(tObject).AsTask();
        }

        public void Patch(T tObject)
        {
            var set = _context.Set<T>();
            set.Attach(tObject);
            _context.Entry(tObject).State = EntityState.Modified;
        }

        protected virtual void Delete(T entityToDelete)
        {
            var set = _context.Set<T>();
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                set.Attach(entityToDelete);
            }

            set.Remove(entityToDelete);
        }
    }
}
