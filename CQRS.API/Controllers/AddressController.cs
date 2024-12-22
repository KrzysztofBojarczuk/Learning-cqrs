using AutoMapper;
using CQRS.APPLICATION.Dtos;
using CQRS.APPLICATION.Features.Address.Command;
using CQRS.APPLICATION.Features.Address.Queries;
using CQRS.APPLICATION.Features.Employee.Commands;
using CQRS.APPLICATION.Features.Employee.Queries;
using CQRS.CORE.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AddressController(ISender sender, UserManager<AppUserEntity> userManager, IMapper mapper) : ControllerBase
    {
        [HttpGet()]
        public async Task<IActionResult> GetAllAddressesAsync()
        {
            var addresses = await sender.Send(new GetAllAddressesQuery());

            var addressesDtos = mapper.Map<IEnumerable<AddressGetDto>>(addresses);

            return Ok(addressesDtos);
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetUserAddressAsync()
        {
            var userId = userManager.GetUserId(User);

            var result = await sender.Send(new GetUsserAddressesQuery(userId));

            var addressDtos = mapper.Map<IEnumerable<AddressGetDto>>(result);

            return Ok(addressDtos);
        }

        [HttpPost()]
        public async Task<IActionResult> AddAddressAsync([FromBody] AddressCreateDto addressDto)
        {
            var userId = userManager.GetUserId(User);
            var appUserEntity = await userManager.FindByIdAsync(userId);

            var addressEntity = mapper.Map<AddressEntity>(addressDto);

            addressEntity.AppUserId = userId;
            addressEntity.AppUserEntity = appUserEntity;

            var result = await sender.Send(new AddAddressCommand(addressEntity));

            return Ok(result);
        }

        [HttpDelete("{addressId}")]
        public async Task<IActionResult> DeleteAddressAsync([FromRoute] Guid addressId)
        {
            var result = await sender.Send(new DeleteAddressCommand(addressId));

            return Ok(result);
        }

        [HttpPut("{addressId}")]
        public async Task<IActionResult> UpdateAddressAsync([FromRoute] Guid addressId, [FromBody] AddressCreateDto updateAddressDto)
        {
            var addressEntity = mapper.Map<AddressEntity>(updateAddressDto);

            var result = await sender.Send(new UpdateAddressCommand(addressId, addressEntity));

            return Ok(result);
        }
    }
}
