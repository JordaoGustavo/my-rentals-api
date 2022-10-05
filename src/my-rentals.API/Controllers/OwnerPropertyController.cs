using Microsoft.AspNetCore.Mvc;
using my_rentals.API.Extentions;
using my_rentals.Application.Contracts.Services;
using my_rentals.Application.Features.PropertyFeature.ViewModels;
using System.Net;

namespace my_rentals.API.Controllers
{
    [ApiController]
    [Route("api/v1/owners/{ownerId}/properties")]
    public class OwnerPropertyController : ControllerBase
    {
        private readonly IPropertyService _propertyService;

        public OwnerPropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpGet()]
        [ProducesResponseType(typeof(IEnumerable<PropertyViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByOwnerId([FromRoute] Guid id)
        {
            var properties = await _propertyService.GetByOwnerIdAsync(id);

            return properties.ToOk((properties) => PropertyEnumerableViewModel.Create(properties));
        }
    }
}
