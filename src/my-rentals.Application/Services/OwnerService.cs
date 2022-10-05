using LanguageExt.Common;
using my_rental.Domain.Entities;
using my_rental.Domain.Seedwork.Exceptions;
using my_rentals.Application.Contracts.Repositories;
using my_rentals.Application.Contracts.Services;
using my_rentals.Application.Features.Owner.Commands;

namespace my_rentals.Application.Services
{
    internal class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;

        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        public async Task<Result<Owner>> ChangeNameAsync(ChangeOwnerNameCommand changeOwnerNameCommand)
        {
            if (changeOwnerNameCommand is null)
            {
                return new Result<Owner>(new InvalidDomainOperationException("Operação inválida"));
            }

            var owner = await _ownerRepository.FindOneAsync(o => o.Id == changeOwnerNameCommand.OwnerId);

            if (owner is null)
            {
                return new Result<Owner>(new NotFoundException("Proprietário não encontrado!"));
            }

            owner.ChangeName(changeOwnerNameCommand.NewName);

            if (!owner.IsSuccess)
            {
                return owner.OperationResult;
            }

            _ownerRepository.Patch(owner);
            await _ownerRepository.CommitAsync();

            owner.HidePassword();

            return owner;
        }

        public async Task<Result<Owner>> ChangePasswordAsync(UpdatePasswordCommand updatePasswordCommand)
        {
            if (updatePasswordCommand is null)
            {
                return new Result<Owner>(new InvalidDomainOperationException("Operação inválida"));
            }

            var owner = await _ownerRepository.FindOneAsync(o => o.Id == updatePasswordCommand.OwnerId);

            if (owner is null)
            {
                return new Result<Owner>(new NotFoundException("Proprietário não encontrado!"));
            }

            if (owner.IsPasswordValid(updatePasswordCommand.OldPassword))
            {
                return new Result<Owner>(new InvalidDomainOperationException("Senhas inválidas!"));
            }

            owner.UpdatePassword(updatePasswordCommand.NewPassword);

            _ownerRepository.Patch(owner);
            await _ownerRepository.CommitAsync();

            owner.HidePassword();

            return owner;
        }

        public async Task<Result<Owner>> CreateAsync(CreateOwnerCommand ownerCommand)
        {
            if (ownerCommand is null)
            {
                return new Result<Owner>(new InvalidDomainOperationException("Você deve informar um proprietário valido!"));
            }

            var owner = ownerCommand.ParseToOwner();

            if (!owner.IsSuccess)
            {
                return owner.OperationResult;
            }

            await _ownerRepository.InsertAsync(owner);
            await _ownerRepository.CommitAsync();

            owner.HidePassword();

            return owner;
        }

        public async Task<Result<Owner>> DeleteAsync(Guid id)
        {
            var owner = await _ownerRepository.DeleteAsync(id);
            
            if (owner is null)
            {
                return new Result<Owner>(new NotFoundException("Proprietário não encontrado!"));
            }

            await _ownerRepository.CommitAsync();
            owner.HidePassword();
            return owner;
        }

        public async Task<Result<Owner>> GetAsync(Guid id)
        {
                var owner = await _ownerRepository.FindOneAsync(o => o.Id == id);

                if (owner is null)
                {
                    return new Result<Owner>(new NotFoundException("Proprietário não encontrado!"));
                }

                owner.HidePassword();

                return owner;
        }
    }
}
