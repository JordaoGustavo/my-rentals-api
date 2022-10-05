using LanguageExt.Common;
using my_rental.Domain.Commons;
using my_rental.Domain.Seedwork.Exceptions;
using System;

namespace my_rental.Domain.Entities
{
    public class Property : Entity<Property>
    {
        public string Name { get; set; }

        public Guid OwnerId { get; set; }

        public Owner Owner { get; set; }

        public Property()
        {
        }

        public Property(string name, Guid ownerId)
        {
            Name = name;
            OwnerId = ownerId;
            Validate();
        }

        public void ChangeName(string name)
        {
            if (!IsValidName(name))
            {
                OperationResult = new Result<Property>(new InvalidDomainOperationException("Você deve informar um nome valido!"));
            }

            Name = name;
            LastModifiedDate = DateTime.UtcNow;
        }

        protected void Validate()
        {
            if (!IsValidName(Name))
            {
                OperationResult = new Result<Property>(new InvalidDomainOperationException("Você deve informar um nome valido!"));
                return;
            }
        }

        protected static bool IsValidName(string name)
        {
            return !string.IsNullOrEmpty(name) && name.Length <= 70;
        }
    }
}
