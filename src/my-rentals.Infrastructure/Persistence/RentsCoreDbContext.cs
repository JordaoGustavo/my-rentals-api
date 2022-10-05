using Microsoft.EntityFrameworkCore;
using my_rental.Domain.Entities;

namespace my_rentals.Infrastructure.Persistence
{
    internal class RentsCoreDbContext : DbContext
    {
        public RentsCoreDbContext(DbContextOptions<RentsCoreDbContext> options) : base(options)
        {
        }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Property> Properties { get; set; }

    }
}
