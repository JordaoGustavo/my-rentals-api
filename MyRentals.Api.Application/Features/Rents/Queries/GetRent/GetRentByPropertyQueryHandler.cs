using AutoMapper;
using MediatR;
using MyRentals.Api.Application.Contracts.Persistence;
using MyRentals.Api.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyRentals.Api.Application.Features.Rents.Queries.GetRent
{
    public class GetRentByPropertyQueryHandler : IRequestHandler<GetRentByPropertyQuery, RentViewModel>
    {
        private readonly IAsyncRepository<Rent> _rentRepository;
        private readonly IMapper _mapper;

        public GetRentByPropertyQueryHandler(IMapper mapper, IAsyncRepository<Rent> rentRepository)
        {
            _rentRepository = rentRepository;
            _mapper = mapper;
        }

        public Task<RentViewModel> Handle(GetRentByPropertyQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
