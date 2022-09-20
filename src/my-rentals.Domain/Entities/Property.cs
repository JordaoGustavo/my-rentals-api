using my_rental.Domain.Commons;
using System;

namespace my_rental.Domain.Entities
{
    public class Property : Entity
    {
        public string Name { get; set; }

        public Guid OwnerId { get; set; }

        public Owner Owner { get; set; }
    }
}
