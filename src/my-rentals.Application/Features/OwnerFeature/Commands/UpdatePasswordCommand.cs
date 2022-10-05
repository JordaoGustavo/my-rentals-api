using System;

namespace my_rentals.Application.Features.Owner.Commands
{
    public class UpdatePasswordCommand
    {
        public Guid OwnerId { get; set; }
        public string NewPassword { get; set; }
        public string OldPassword { get; set; }
    }
}
