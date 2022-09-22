using Microsoft.EntityFrameworkCore;
using my_rental.Domain.Entities;
using my_rentals.Application.Contracts.Repositories;
using my_rentals.Infrastructure.Persistence;

namespace my_rentals.Infrastructure.Repositories
{
    internal class PropertyRepository : Repository<Property>, IPropertyRepository
    {
        public PropertyRepository(RentsCoreDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Property>> GetByOwnerIdAsync(Guid ownerId)
        {
            var query = FindAll();

            var properties = await query.Where(q => q.Owner.Id == ownerId).ToListAsync();

            return properties;
        }
    }
}
