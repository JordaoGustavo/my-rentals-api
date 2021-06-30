using MyRentals.Api.Domain.Common;
using MyRentals.Api.Domain.Enums;
using System;

namespace MyRentals.Api.Domain.Entities
{
    public abstract class Expense : AuditableEntity
    {
        public Guid Id { get; set; }

        public Guid PropertyId { get; set; }

        public decimal Amount { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public byte Type { get; set; }
    }
}
