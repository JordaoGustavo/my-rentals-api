namespace my_rentals.Application.Features.Property.Commands
{
    public class PatchPropertyCommand
    {
        public Guid PropertyId { get; set; }

        public string Name { get; set; }
    }
}
