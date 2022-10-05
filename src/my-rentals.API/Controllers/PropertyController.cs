using Microsoft.AspNetCore.Mvc;
using my_rentals.API.Extentions;
using my_rentals.Application.Contracts.Services;
using my_rentals.Application.Features.Property.Commands;
using my_rentals.Application.Features.PropertyFeature.ViewModels;
using System.Net;

namespace my_rentals.API.Controllers
{
    [ApiController]
    [Route("api/v1/properties")]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService _propertyService;

        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PropertyViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var property = await _propertyService.GetAsync(id);

            return property.ToOk((owner) => PropertyViewModel.Create(owner));
        }

        [HttpPost]
        [ProducesResponseType(typeof(PropertyViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Create([FromBody] CreatePropertyCommand createPropertyCommand)
        {
            var property = await _propertyService.CreateAsync(createPropertyCommand);

            return property.ToOk((property) => PropertyViewModel.Create(property));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(PropertyViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] PatchPropertyCommand patchPropertyCommand)
        {
            patchPropertyCommand.PropertyId = id;

            var property = await _propertyService.PatchAsync(patchPropertyCommand);

            return property.ToOk((property) => PropertyViewModel.Create(property));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(PropertyViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var property = await _propertyService.DeleteAsync(id);

            return property.ToOk((property) => PropertyViewModel.Create(property));
        }
    }
}
