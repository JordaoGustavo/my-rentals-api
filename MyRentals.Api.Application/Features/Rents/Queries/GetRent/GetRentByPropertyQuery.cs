using MediatR;
using System;

namespace MyRentals.Api.Application.Features.Rents.Queries.GetRent
{
    public class GetRentByPropertyQuery : IRequest<RentViewModel>
    {
        public Guid PropertyId { get; }
    }
}
