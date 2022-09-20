using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace my_rentals.API.Controllers
{
    [ApiController]
    [Route("api/v1/owners/{ownerId}/properties")]
    public class OwnerPropertyController : ControllerBase
    {
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(object), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByOwnerId(Guid id)
        {
            return Ok();
        }
    }
}
