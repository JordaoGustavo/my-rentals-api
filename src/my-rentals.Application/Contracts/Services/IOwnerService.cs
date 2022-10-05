using LanguageExt.Common;
using my_rental.Domain.Entities;
using my_rentals.Application.Features.Owner.Commands;

namespace my_rentals.Application.Contracts.Services
{
    public interface IOwnerService
    {
        Task<Result<Owner>> GetAsync(Guid id);
        Task<Result<Owner>> ChangeNameAsync(ChangeOwnerNameCommand changeOwnerNameCommand);
        Task<Result<Owner>> DeleteAsync(Guid id);
        Task<Result<Owner>> CreateAsync(CreateOwnerCommand ownerCommand);
        Task<Result<Owner>> ChangePasswordAsync(UpdatePasswordCommand updatePasswordCommand);
    }
}
