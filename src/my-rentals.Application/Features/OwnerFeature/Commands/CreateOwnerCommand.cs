﻿using OwnerEntity =  my_rental.Domain.Entities.Owner;
namespace my_rentals.Application.Features.Owner.Commands
{
    public class CreateOwnerCommand
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        internal OwnerEntity ParseToOwner()
        {
            return new OwnerEntity(Name, Email, Password);
        }
    }
}
