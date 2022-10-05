using Microsoft.AspNetCore.Mvc;
using my_rentals.API.Extentions;
using my_rentals.Application.Contracts.Services;
using my_rentals.Application.Features.Owner.Commands;
using my_rentals.Application.Features.OwnerFeature.ViewModels;
using System.Net;

namespace my_rentals.API.Controllers
{
    [ApiController]
    [Route("api/v1/owners")]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(OwnerViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var owner = await _ownerService.GetAsync(id);

            return owner.ToOk((owner) => OwnerViewModel.Create(owner));
        }

        [HttpPost]
        [ProducesResponseType(typeof(OwnerViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Create([FromBody] CreateOwnerCommand ownerCommand)
        {
            var owner = await _ownerService.CreateAsync(ownerCommand);

            return owner.ToOk((owner) => OwnerViewModel.Create(owner));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(OwnerViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] ChangeOwnerNameCommand changeOwnerNameCommand)
        {
            changeOwnerNameCommand.OwnerId = id;

            var owner = await _ownerService.ChangeNameAsync(changeOwnerNameCommand);

            return owner.ToOk((owner) => OwnerViewModel.Create(owner));
        }

        [HttpPut("{id}/password")]
        [ProducesResponseType(typeof(OwnerViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> ChangePassword([FromRoute] Guid id, [FromBody] UpdatePasswordCommand updatePasswordCommand)
        {
            updatePasswordCommand.OwnerId = id;

            var owner = await _ownerService.ChangePasswordAsync(updatePasswordCommand);

            return owner.ToOk((owner) => OwnerViewModel.Create(owner));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(OwnerViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> LeavePlatform([FromRoute] Guid id)
        {
            var owner = await _ownerService.DeleteAsync(id);

            return owner.ToOk((owner) => OwnerViewModel.Create(owner));
        }
    }
}
