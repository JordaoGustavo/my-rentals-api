using my_rental.Domain.Entities;
using my_rentals.Application.Contracts.Repositories;
using my_rentals.Infrastructure.Persistence;

namespace my_rentals.Infrastructure.Repositories
{
    internal class OwnerRepository : Repository<Owner>, IOwnerRepository
    {
        public OwnerRepository(RentsCoreDbContext dbContext) : base(dbContext)
        {
        }
    }
}
