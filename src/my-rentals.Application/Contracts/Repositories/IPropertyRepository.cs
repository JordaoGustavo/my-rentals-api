using my_rental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace my_rentals.Application.Contracts.Repositories
{
    public interface IPropertyRepository : IRepository<Property>
    {
        Task<IEnumerable<Property>> GetByOwnerIdAsync(Guid ownerId);
    }
}
