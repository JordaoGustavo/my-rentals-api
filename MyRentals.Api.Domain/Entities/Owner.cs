using MyRentals.Api.Domain.Common;
using MyRentals.Api.Domain.ValuesTypes;
using System;

namespace MyRentals.Api.Domain.Entities
{
    public class Owner : AuditableEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Email Email { get; set; }

        public string Password { get; set; }
    }
}
