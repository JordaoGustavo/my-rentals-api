using System;

namespace my_rentals.Application.Features.Property.Commands
{
    public class CreatePropertyCommand
    {
        public string Name { get; set; }

        public Guid OwnerId { get; set; }
    }
}
