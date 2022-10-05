using LanguageExt.Common;
using my_rental.Domain.Entities;
using my_rental.Domain.Seedwork.Exceptions;
using my_rentals.Application.Contracts.Repositories;
using my_rentals.Application.Contracts.Services;
using my_rentals.Application.Features.Property.Commands;

namespace my_rentals.Application.Services
{
    internal class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IOwnerRepository _ownerRepository;

        public PropertyService(
            IPropertyRepository propertyRepository,
            IOwnerRepository ownerRepository
            )
        {
            _propertyRepository = propertyRepository;
            _ownerRepository = ownerRepository;
        }

        public async Task<Result<Property>> CreateAsync(CreatePropertyCommand createPropertyCommand)
        {
            if (createPropertyCommand is null)
            {
                return new Result<Property>(new InvalidDomainOperationException("Você deve informar uma propriedade!"));
            }

            var owner = await _ownerRepository.FindOneAsync(o => o.Id == createPropertyCommand.OwnerId);

            if (owner is null)
            {
                return new Result<Property>(new NotFoundException("Proprietário não encontrado!"));
            }

            var property = createPropertyCommand.ParseToProperty();

            if (!property.IsSuccess)
            {
                return property.OperationResult;
            }

            await _propertyRepository.InsertAsync(property);
            await _propertyRepository.CommitAsync();

            return property;
        }

        public async Task<Result<Property>> DeleteAsync(Guid id)
        {
            var property = await _propertyRepository.DeleteAsync(id);

            if (property is null)
            {
                return new Result<Property>(new NotFoundException("Propriedade não encontrada!"));
            }

            await _propertyRepository.CommitAsync();
            return property;
        }

        public async Task<Result<Property>> GetAsync(Guid id)
        {
            var property = await _propertyRepository.FindOneAsync(o => o.Id == id);

            if (property is null)
            {
                return new Result<Property>(new NotFoundException("Propriedade não encontrada!"));
            }

            return property;
        }

        public async Task<Result<IEnumerable<Property>>> GetByOwnerIdAsync(Guid ownerId)
        {
            var property = await _propertyRepository.GetByOwnerIdAsync(ownerId);

            if (property is null || !property.Any())
            {
                return new Result<IEnumerable<Property>>(new NotFoundException("Propriedades não encontradas!"));
            }

            return new Result<IEnumerable<Property>>(property);
        }

        public async Task<Result<Property>> PatchAsync(PatchPropertyCommand patchPropertyCommand)
        {
            if (patchPropertyCommand is null)
            {
                return new Result<Property>(new InvalidDomainOperationException("Operação inválida"));
            }

            var property = await _propertyRepository.FindOneAsync(o => o.Id == patchPropertyCommand.PropertyId);

            if (property is null)
            {
                return new Result<Property>(new NotFoundException("Propriedade não encontrada!"));
            }

            property.ChangeName(patchPropertyCommand.Name);

            if (!property.IsSuccess)
            {
                return property.OperationResult;
            }

            _propertyRepository.Patch(property);
            await _propertyRepository.CommitAsync();

            return property;
        }
    }
}
