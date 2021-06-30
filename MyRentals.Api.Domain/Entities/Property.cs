using MyRentals.Api.Domain.Common;
using System;

namespace MyRentals.Api.Domain.Entities
{
    public class Property : AuditableEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid OwnerId { get; set; }
    }
}
