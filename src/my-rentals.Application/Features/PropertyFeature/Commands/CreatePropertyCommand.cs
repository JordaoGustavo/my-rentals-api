namespace my_rentals.Application.Features.Property.Commands
{
    public class CreatePropertyCommand
    {
        public string Name { get; set; }

        public Guid OwnerId { get; set; }

        internal my_rental.Domain.Entities.Property ParseToProperty()
        {
            return new my_rental.Domain.Entities.Property(Name, OwnerId);
        }
    }
}
