namespace my_rentals.Application.Features.OwnerFeature.ViewModels
{
    public class OwnerViewModel
    {
        public string Name { get; private set; }

        public string Email { get; private set; }

        public static OwnerViewModel Create(my_rental.Domain.Entities.Owner owner)
        {
            return new OwnerViewModel()
            {
                Name = owner.Name,
                Email = owner.Email
            };
        }
    }
}
