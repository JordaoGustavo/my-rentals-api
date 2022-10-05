namespace my_rentals.Application.Features.PropertyFeature.ViewModels
{
    public class PropertyEnumerableViewModel
    {
        public static IEnumerable<PropertyViewModel> Create(IEnumerable<my_rental.Domain.Entities.Property> properties)
        {
            
            var propertiesViewModel = new List<PropertyViewModel>();

            foreach (var property in properties)
            {
                propertiesViewModel.Add(PropertyViewModel.Create(property));
            }

            return propertiesViewModel;
        }
    }
}
