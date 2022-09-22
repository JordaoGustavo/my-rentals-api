using LanguageExt.Common;
using my_rental.Domain.Entities;
using my_rentals.Application.Features.Property.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace my_rentals.Application.Contracts.Services
{
    public interface IPropertyService
    {
        Task<Result<Property>> CreateAsync(CreatePropertyCommand createPropertyCommand);
        Task<Result<Property>> GetAsync(Guid id);
        Task<Result<Property>> PatchAsync(PatchPropertyCommand patchPropertyCommand);
        Task<Result<Property>> DeleteAsync(Guid id);
        Task<Result<IEnumerable<Property>>> GetByOwnerIdAsync(Guid ownerId);
    }
}
