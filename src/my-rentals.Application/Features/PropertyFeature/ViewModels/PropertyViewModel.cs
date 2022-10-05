namespace my_rentals.Application.Features.PropertyFeature.ViewModels
{
    public class PropertyViewModel
    {
        public string Name { get; private set; }

        public Guid OwnerId { get; private set; }

        public static PropertyViewModel Create(my_rental.Domain.Entities.Property property)
        {
            return new PropertyViewModel()
            {
                Name = property.Name,
                OwnerId = property.OwnerId
            };
        }
    }
}
