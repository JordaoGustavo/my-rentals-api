using System;

namespace my_rentals.Application.Features.Owner.Commands
{
    public class ChangeOwnerNameCommand
    {
        public Guid OwnerId { get; set; }
        public string NewName { get; set; }
    }
}
